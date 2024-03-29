// cd VsCodePractices/1-1-dotNet/C-Sharp
// csc CollectionsGenericsTest.cs
// mono CollectionsGenericsTest.exe

/*
Generics are declared with "Less than <" and "Greater than >" in C#

Collections
Non-generic-Collections                      Generic-Collections
ArrayList                 ---------->        List
HashTable                 ---------->        Dictionary
SortedList                ---------->        SortedList  
Stack                     ---------->        Stack
Queue                     ---------->        Queue
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Testing
{
    // Declare the generic class.
    public class GenericList<T>
    {
        public void Add(T input) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Non-Generic-Collections
            #region ArrayList
            ArrayList al = new ArrayList();
            al.Add("Testing"); // string
            al.Add(7); //int
            al.Add(DateTime.Parse("8-oct-1985")); // DateTime
            foreach (object o in al)
            {
                Console.WriteLine("ArrayList Data :: " + o);
            }
            #endregion ArrayList

            #region Hashtable
            // The Hashtable is a non-generic collection that stores key-value pairs.
            Hashtable ht = new Hashtable();
            ht.Add("ora", DateTime.Parse("8-oct-1985"));
            ht.Add("vb", 333);
            ht.Add("cs", "cs.net");
            ht.Add("asp", "asp.net");
            foreach (DictionaryEntry d in ht)
            {
                Console.WriteLine("Hashtable Data :: " + d.Key + " " + d.Value);
            }
            #endregion Hashtable

            #region SortedList
            // The SortedList is a non-generic collection that stores key-value pairs.
            // and that are sorted by the keys based
            SortedList sl = new SortedList();
            sl.Add("ora", DateTime.Parse("8-oct-1985"));
            sl.Add("vb", 333);
            sl.Add("cs", "cs.net");
            sl.Add("asp", "asp.net");
            foreach (DictionaryEntry d in sl)
            {
                Console.WriteLine("SortedList Data :: " + d.Key + " " + d.Value);
            }
            #endregion SortedList

            #region Stack
            // LIFO - last in first out
            Stack stk = new Stack();
            stk.Push("cs.net");
            stk.Push(DateTime.Parse("8-oct-1985"));
            stk.Push(333);
            stk.Push("sqlserver");
            foreach (object o in stk)
            {
                Console.WriteLine("Stack Data :: " + o);
            }
            #endregion Stack

            #region Queue
            // FIFO - first in first out
            Queue q = new Queue();
            q.Enqueue("cs.net");
            q.Enqueue(DateTime.Parse("8-oct-1985"));
            q.Enqueue(333);
            q.Enqueue("sqlserver");
            foreach (object o in q)
            {
                Console.WriteLine("Queue Data :: " + o);
            }
            #endregion Queue
            #endregion Non-Generic-Collections

            #region Generic-Collections
            #region List
            List<Employee> lst = new List<Employee>();
            lst.Add(new Employee() { empId = 101, empName = "Name1" });
            lst.Add(new Employee() { empId = 102, empName = "Name2" });
            lst.Add(new Employee() { empId = 103, empName = "Name3" });
            lst.Add(new Employee() { empId = 104, empName = "Name4" });
            foreach (Employee i in lst)
            {
                Console.WriteLine("List Data :: " + i.empId);
            }
            #endregion List

            #region Dictionary
            // The Dictionary is a generic collection that stores key-value pairs.
            Dictionary<int, Employee> dct = new Dictionary<int, Employee>();
            dct.Add(1, new Employee() { empId = 101, empName = "Name1" });
            dct.Add(3, new Employee() { empId = 103, empName = "Name3" });
            dct.Add(2, new Employee() { empId = 102, empName = "Name2" });
            dct.Add(4, new Employee() { empId = 104, empName = "Name4" });
            foreach (KeyValuePair<int, Employee> kvp in dct)
            {
                Console.WriteLine("Dictionary Data :: " + kvp.Key + " " + kvp.Value.empId);
            }
            #endregion Dictionary

            #region SortedList
            // The Dictionary is a generic collection that stores key-value pairs.
            // and that are sorted by the keys based
            SortedList<int, Employee> sortedList = new SortedList<int, Employee>();
            sortedList.Add(1, new Employee() { empId = 101, empName = "Name1" });
            sortedList.Add(3, new Employee() { empId = 103, empName = "Name3" });
            sortedList.Add(2, new Employee() { empId = 102, empName = "Name2" });
            sortedList.Add(4, new Employee() { empId = 104, empName = "Name4" });
            foreach (KeyValuePair<int, Employee> kvp in sortedList)
            {
                Console.WriteLine("SortedList Data :: " + kvp.Key + " " + kvp.Value.empId);
            }
            #endregion SortedList

            #region Stack
            // LIFO - last in first out
            Stack<Employee> stack = new Stack<Employee>();
            stack.Push(new Employee() { empId = 101, empName = "Name1" });
            stack.Push(new Employee() { empId = 103, empName = "Name3" });
            stack.Push(new Employee() { empId = 102, empName = "Name2" });
            stack.Push(new Employee() { empId = 104, empName = "Name4" });
            foreach (Employee s in stack)
            {
                Console.WriteLine("Stack Data :: " + s.empId);
            }
            #endregion Stack

            #region Queue
            // FIFO - first in first out
            Queue<Employee> queue = new Queue<Employee>();
            queue.Enqueue(new Employee() { empId = 101, empName = "Name1" });
            queue.Enqueue(new Employee() { empId = 103, empName = "Name3" });
            queue.Enqueue(new Employee() { empId = 102, empName = "Name2" });
            queue.Enqueue(new Employee() { empId = 104, empName = "Name4" });
            foreach (Employee s in queue)
            {
                Console.WriteLine("Queue Data :: " + s.empId);
            }
            #endregion Queue
            #endregion Generic-Collections

        }
    }

    class Employee
    {
        public int empId { set; get; }
        public string empName { set; get; }
    }
}

// OutPut
/*
ArrayList Data :: Testing
ArrayList Data :: 7
ArrayList Data :: 10/8/1985 12:00:00 AM
Hashtable Data :: cs cs.net
Hashtable Data :: asp asp.net
Hashtable Data :: ora 10/8/1985 12:00:00 AM
Hashtable Data :: vb 333
SortedList Data :: asp asp.net
SortedList Data :: cs cs.net
SortedList Data :: ora 10/8/1985 12:00:00 AM
SortedList Data :: vb 333
Stack Data :: sqlserver
Stack Data :: 333
Stack Data :: 10/8/1985 12:00:00 AM
Stack Data :: cs.net
Queue Data :: cs.net
Queue Data :: 10/8/1985 12:00:00 AM
Queue Data :: 333
Queue Data :: sqlserver
List Data :: 101
List Data :: 102
List Data :: 103
List Data :: 104
Dictionary Data :: 1 101
Dictionary Data :: 3 103
Dictionary Data :: 2 102
Dictionary Data :: 4 104
SortedList Data :: 1 101
SortedList Data :: 2 102
SortedList Data :: 3 103
SortedList Data :: 4 104
Stack Data :: 104
Stack Data :: 102
Stack Data :: 103
Stack Data :: 101
Queue Data :: 101
Queue Data :: 103
Queue Data :: 102
Queue Data :: 104
*/
