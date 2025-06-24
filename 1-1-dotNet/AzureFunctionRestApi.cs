using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

public static class EmployeeApiFunction
{
    [FunctionName("GetAllEmployees")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "emps/all")] HttpRequest req, ILogger log)
    {
        log.LogInformation("Processing request for /api/emps/all");

        // Check Authorization header
        string authHeader = req.Headers["Authorization"];

        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            return new UnauthorizedResult();
        }

        string token = authHeader.Substring("Bearer ".Length).Trim();

        if (!ValidateToken(token, out ClaimsPrincipal principal))
        {
            return new UnauthorizedResult();
        }

        // Return employee list
        var employees = GetEmployees();

        return new OkObjectResult(employees);
    }

    private static bool ValidateToken(string token, out ClaimsPrincipal principal)
    {
        principal = null;

        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "https://your-issuer.example.com",   // Replace with your issuer
            ValidAudience = "your-audience",                  // Replace with your audience

            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes("your-256-bit-secret"))  // Replace with your secret
        };

        try
        {
            principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static List<Employee> GetEmployees()
    {
        return new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice Johnson", Department = "Finance" },
            new Employee { Id = 2, Name = "Bob Smith", Department = "Engineering" },
            new Employee { Id = 3, Name = "Charlie Brown", Department = "HR" }
        };
    }

    private class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
}
