// cd VsCodePractices/1-1-dotNet/C-Sharp
// csc CollectionsGenericsTest.cs
// mono CollectionsGenericsTest.exe

/*
* Collections are used to store, manage, and manipulate groups of related objects.
* Generic collections are type-safe, performance-optimized, and preferred over non-generic collections (System.Collections) because they avoid boxing/unboxing and runtime casting.
Generics are declared with "Less than <" and "Greater than >" in C#

Collections
Non-generic-Collections                      Generic-Collections
ArrayList                 ---------->        List<T> (Dynamically sized array of type T)
HashTable (Key-value)     ---------->        Dictionary
SortedList                ---------->        SortedList (Sorted by keys)
Stack (LIFO)              ---------->        Stack
Queue (FIFO)              ---------->        Queue

Non-Generic Collections (Old style — stores any type using object)
Generic Collections (Type-safe, modern, used in real projects)

ArrayList: Dynamically sized array (stores any type).
Hashtable: Key-value pairs, keys must be unique.

HashSet<T>: Unique unordered collection.
SortedList<TKey, TValue>: Sort by key.
LinkedList<T> Doubly-linked list.

*/

namespace Testing;

using System;
using System.Collections;
using System.Collections.Generic;

// Declare the generic class.
public class GenericList<T>
{
    public void Add(T input) { }
}

class CollectionsAndGenericTesting
{
    public static void Run()
    {
        #region Non-Generic-Collections
        #region ArrayList
        ArrayList al = new ArrayList();
        al.Add("Testing"); // string
        al.Add(7); //int
        al.Add(DateTime.Parse("8-oct-1985")); // DateTime
        Console.WriteLine("ArrayListData :: " + al[0]);
        foreach (object o in al)
        {
            Console.WriteLine("ArrayListData :: " + o);
        }
        #endregion ArrayList

        #region Hashtable
        // The Hashtable is a non-generic collection that stores key-value pairs.
        Hashtable ht = new Hashtable();
        ht.Add("ora", DateTime.Parse("8-oct-1985"));
        ht.Add("vb", 333);
        ht.Add("cs", "cs.net");
        ht.Add("asp", "asp.net");
        Console.WriteLine("HashtableData :: " + ht["cs"]);
        foreach (DictionaryEntry d in ht)
        {
            Console.WriteLine("HashtableData :: " + d.Key + " " + d.Value);
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
        Console.WriteLine("SortedListData :: " + sl["asp"]);
        foreach (DictionaryEntry d in sl)
        {
            Console.WriteLine("SortedListData :: " + d.Key + " " + d.Value);
        }
        #endregion SortedList

        #region Stack
        // LIFO - last in first out
        Stack stk = new Stack();
        stk.Push("cs.net");
        stk.Push(DateTime.Parse("8-oct-1985"));
        stk.Push(333);
        stk.Push("sqlserver");
        Console.WriteLine("StackData :: " + stk.Pop());
        foreach (object o in stk)
        {
            Console.WriteLine("StackData :: " + o);
        }
        #endregion Stack

        #region Queue
        // FIFO - first in first out
        Queue q = new Queue();
        q.Enqueue("cs.net");
        q.Enqueue(DateTime.Parse("8-oct-1985"));
        q.Enqueue(333);
        q.Enqueue("sqlserver");
        Console.WriteLine("QueueData :: " + q.Dequeue());
        foreach (object o in q)
        {
            Console.WriteLine("QueueData :: " + o);
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
        Console.WriteLine("ListData :: " + lst[1].empId);
        foreach (Employee i in lst)
        {
            Console.WriteLine("ListData :: " + i.empId);
        }
        #endregion List

        #region HashSet
        HashSet<string> set = new HashSet<string>();
        set.Add("Apple");
        set.Add("Banana");
        set.Add("Apple"); // Duplicate - will be ignored
        List<string> setList = set.ToList();
        Console.WriteLine("HashSetData :: " + setList[1]);
        foreach (var fruit in set)
        {
            Console.WriteLine("HashSetData :: " + fruit); // Order is not guaranteed
        }
        #endregion HashSet

        #region Dictionary
        // The Dictionary is a generic collection that stores key-value pairs.
        Dictionary<int, Employee> dct = new Dictionary<int, Employee>();
        dct.Add(1, new Employee() { empId = 101, empName = "Name1" });
        dct.Add(3, new Employee() { empId = 103, empName = "Name3" });
        dct.Add(2, new Employee() { empId = 102, empName = "Name2" });
        dct.Add(4, new Employee() { empId = 104, empName = "Name4" });
        Console.WriteLine("DictionaryData :: " + dct[3].empId);
        foreach (KeyValuePair<int, Employee> kvp in dct)
        {
            Console.WriteLine("DictionaryData :: " + kvp.Key + " " + kvp.Value.empId);
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
        Console.WriteLine("SortedListData :: " + sortedList[3].empId);
        foreach (KeyValuePair<int, Employee> kvp in sortedList)
        {
            Console.WriteLine("SortedListData :: " + kvp.Key + " " + kvp.Value.empId);
        }
        #endregion SortedList

        #region Stack
        // LIFO - last in first out
        Stack<Employee> stack = new Stack<Employee>();
        stack.Push(new Employee() { empId = 101, empName = "Name1" });
        stack.Push(new Employee() { empId = 103, empName = "Name3" });
        stack.Push(new Employee() { empId = 102, empName = "Name2" });
        stack.Push(new Employee() { empId = 104, empName = "Name4" });
        Console.WriteLine("StackData :: " + stack.Pop().empId);
        foreach (Employee s in stack)
        {
            Console.WriteLine("StackData :: " + s.empId);
        }
        #endregion Stack

        #region Queue
        // FIFO - first in first out
        Queue<Employee> queue = new Queue<Employee>();
        queue.Enqueue(new Employee() { empId = 101, empName = "Name1" });
        queue.Enqueue(new Employee() { empId = 103, empName = "Name3" });
        queue.Enqueue(new Employee() { empId = 102, empName = "Name2" });
        queue.Enqueue(new Employee() { empId = 104, empName = "Name4" });
        Console.WriteLine("QueueData :: " + queue.Dequeue().empId);
        foreach (Employee s in queue)
        {
            Console.WriteLine("QueueData :: " + s.empId);
        }
        #endregion Queue

        #region LinkedList
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.AddLast(100);   // Add at the end
        linkedList.AddLast(20);
        linkedList.AddFirst(5);   // Add at the beginning
        Console.WriteLine("LinkedListData :: " + linkedList.ToList()[2]);
        Console.WriteLine("LinkedList after adding 5, 10, 20:");
        foreach (int number in linkedList)
        {
            Console.WriteLine("LinkedListData :: " + number);
        }
        // Insert after a specific node
        LinkedListNode<int>? node = linkedList.Find(100);
        if (node != null)
        {
            linkedList.AddAfter(node, 101);
        }
        Console.WriteLine("LinkedList After inserting 101 after 100:");
        foreach (int number in linkedList)
        {
            Console.WriteLine("LinkedListData :: " + number);
        }
        #endregion LinkedList
        #endregion Generic-Collections

        #region Array
        int[] emptyArray;                                // Declare array without initialization
        int[] defaultValues = new int[5];                // Initialized with default 0 values
        int[] primeNumbers = new int[3] { 2, 3, 5 };     // Initialize with fixed size and values
        int[] numbers = { 2, 3, 5, 7, 11 };              // Implicit size initialization

        primeNumbers[1] = 17;                            // Set or modify element at index 1
        Console.WriteLine(string.Join(", ", primeNumbers));

        Console.WriteLine($"Prime numbers length: {primeNumbers.Length}");  // Array length property

        int[] unsortedNumbers = { 5, 3, 8, 1, 9 };
        Array.Sort(unsortedNumbers);                      // Sort array ascending
        Console.WriteLine("Sort :: " + string.Join(", ", unsortedNumbers));

        Array.Reverse(unsortedNumbers);                   // Reverse array elements
        Console.WriteLine("Reverse :: " + string.Join(", ", unsortedNumbers));

        int[] copiedPrimes = new int[primeNumbers.Length];
        Array.Copy(primeNumbers, copiedPrimes, primeNumbers.Length);  // Copy elements to new array
        Console.WriteLine("Copy :: " + string.Join(", ", copiedPrimes));

        Array.Resize(ref primeNumbers, 7);                // Resize array to length 7
        primeNumbers[5] = 19;                             // Add new element at index 5
        primeNumbers[6] = 23;                             // Add new element at index 6
        Console.WriteLine("Resize :: " + string.Join(", ", primeNumbers));

        Console.WriteLine($"Max and Min prime number: {primeNumbers.Max()} and {primeNumbers.Min()}"); // Max and Min using LINQ

        // Multidimensional (rectangular) array
        int[,] matrix2D = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
        Console.WriteLine("2D matrix:");
        for (int row = 0; row < matrix2D.GetLength(0); row++)
        {
            for (int col = 0; col < matrix2D.GetLength(1); col++)
            {
                Console.Write(matrix2D[row, col] + " ");
            }
            Console.WriteLine();
        }

        // Jagged array (array of arrays)
        int[][] jaggedArray = new int[3][];
        jaggedArray[0] = new int[] { 1, 2 };
        jaggedArray[1] = new int[] { 3, 4, 5 };
        jaggedArray[2] = new int[] { 6 };

        Console.WriteLine("Jagged array:");
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Console.Write("Row " + i + ": ");
            foreach (int value in jaggedArray[i])
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
        #endregion Array

    }
}

class Employee
{
    public int empId { set; get; }
    public string? empName { set; get; }
}

// OutPut
/*
ArrayListData :: Testing
ArrayListData :: Testing
ArrayListData :: 7
ArrayListData :: 10/8/1985 12:00:00AM
HashtableData :: cs.net
HashtableData :: asp asp.net
HashtableData :: ora 10/8/1985 12:00:00AM
HashtableData :: vb 333
HashtableData :: cs cs.net
SortedListData :: asp.net
SortedListData :: asp asp.net
SortedListData :: cs cs.net
SortedListData :: ora 10/8/1985 12:00:00AM
SortedListData :: vb 333
StackData :: sqlserver
StackData :: 333
StackData :: 10/8/1985 12:00:00AM
StackData :: cs.net
QueueData :: cs.net
QueueData :: 10/8/1985 12:00:00AM
QueueData :: 333
QueueData :: sqlserver
ListData :: 102
ListData :: 101
ListData :: 102
ListData :: 103
ListData :: 104
HashSetData :: Banana
HashSetData :: Apple
HashSetData :: Banana
DictionaryData :: 103
DictionaryData :: 1 101
DictionaryData :: 3 103
DictionaryData :: 2 102
DictionaryData :: 4 104
SortedListData :: 103
SortedListData :: 1 101
SortedListData :: 2 102
SortedListData :: 3 103
SortedListData :: 4 104
StackData :: 104
StackData :: 102
StackData :: 103
StackData :: 101
QueueData :: 101
QueueData :: 103
QueueData :: 102
QueueData :: 104
LinkedListData :: 20
LinkedList after adding 5, 10, 20:
LinkedListData :: 5
LinkedListData :: 100
LinkedListData :: 20
LinkedList After inserting 101 after 100:
LinkedListData :: 5
LinkedListData :: 100
LinkedListData :: 101
LinkedListData :: 20
2, 17, 5
Prime numbers length: 3
Sort :: 1, 3, 5, 8, 9
Reverse :: 9, 8, 5, 3, 1
Copy :: 2, 17, 5
Resize :: 2, 17, 5, 0, 0, 19, 23
Max and Min prime number: 23 and 0
2D matrix:
1 2 3
4 5 6
Jagged array:
Row 0: 1 2
Row 1: 3 4 5
Row 2: 6
*/