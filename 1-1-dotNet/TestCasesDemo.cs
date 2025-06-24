using Ardalis.Specification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

[TestClass]
public class TestCasesDemo
{
    [TestMethod]
    public void UpdateModel1EndDate()
    {
        var Model1Data = new Model1(Guid.NewGuid(), "Instance1", "MachinName1");

        // Arrange
        var mockModel1Repository = new Mock<IRepository<Model1>>();
        var cogenService = new Service1(mockModel1Repository.Object, MockCommonData.SealTelemetryClient);
        // var mockModel1Repository = new Mock<IRepository<Model1>>();
        // mockModel1Repository.Setup(x => x.AddAsync(It.IsAny<Model1>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Model1(Guid.NewGuid(), "Instance1", "MachinName1"));


        // Act
        var result = cogenService.UpdateModel1EndDate(Model1Data);

        // Assert
        Assert.IsNotNull(result);
    }
}
