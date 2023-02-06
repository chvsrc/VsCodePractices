using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTesting1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };


            Console.WriteLine("*** Where with index ***");
            var filteredResult = studentList.Where((s, i) => { return i % 2 == 0; });
            foreach (var std1 in filteredResult)
                Console.WriteLine(std1.StudentName);


            Console.WriteLine("*** ThenBy with OrderBy ***");
            var thenByResult = studentList.OrderBy(s => s.StudentName).ThenBy(s => s.Age);
            foreach (var std2 in thenByResult)
                Console.WriteLine(std2.StudentName);


            Console.WriteLine("*** GroupBy ***");
            IEnumerable<IGrouping<int, Student>> groupedResult = studentList.GroupBy(s => s.Age);
            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine("Age Group: {0}", ageGroup.Key);  //Each group has a key 
                foreach (Student s in ageGroup)  //Each group has a inner collection  
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }


            IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };


            Console.WriteLine("*** Join ***");
            var innerJoinResult = studentList.Join(// outer sequence 
                          standardList,  // inner sequence 
                          student => student.StandardID,    // outerKeySelector
                          standard => standard.StandardID,  // innerKeySelector
                          (student, standard) => new  // result selector
                          {
                              StudentName = student.StudentName,
                              StandardName = standard.StandardName
                          });
            foreach (var obj in innerJoinResult)
                Console.WriteLine("{0} - {1}", obj.StudentName, obj.StandardName);


            Console.WriteLine("*** GroupJoin/ Left Outer Join ***");
            var groupJoin = standardList.GroupJoin(
                        studentList,  //inner sequence
                        std => std.StandardID, //outerKeySelector 
                        s => s.StandardID,     //innerKeySelector
                        (std, studentsGroup) => new // resultSelector 
                        {
                            Students = studentsGroup,
                            StandarFulldName = std.StandardName
                        });
            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.StandarFulldName);
                foreach (var stud in item.Students)
                    Console.WriteLine(stud.StudentName);
            }


            Console.WriteLine("*** Select ***");
            var selectResult = studentList.Select(s => new { Name = s.StudentName, Age = s.Age });
            foreach (var item in selectResult)
                Console.WriteLine("Student Name: {0}, Age: {1}", item.Name, item.Age);


            Console.WriteLine("*** All ***");
            bool areAllStudentsTeenAger = studentList.All(s => s.Age > 12 && s.Age < 20);
            Console.WriteLine(areAllStudentsTeenAger);


            Console.WriteLine("*** Any ***");
            bool isAnyStudentTeenAger = studentList.Any(s => s.Age > 12 && s.Age < 20);
            Console.WriteLine(isAnyStudentTeenAger);

            Student std = new Student() { StudentID = 3, StudentName = "Bill" };
            // bool result = studentList.Contains(std, new StudentComparer()); //returns true

            Console.WriteLine("Successfully completed !");
            Console.Read();
        }
    }

    class Student
    {
        public int StudentID { get; internal set; }
        public string StudentName { get; internal set; }
        public int Age { get; internal set; }
        public int StandardID { get; set; }
    }

    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }

}

