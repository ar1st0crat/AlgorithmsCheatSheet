using ADS.DataStructures;
using ADS.Sort;
using ADS.Search;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADS
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = "";
            while (true)
            {
                Console.WriteLine("1. Sort demo");
                Console.WriteLine("2. Search demo");
                Console.WriteLine("3. Graph demo");
                Console.WriteLine("4. Quit");

                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": SortDemo(); break;
                    case "2": SearchDemo(); break;
                    case "3": GraphDemo(); break;
                    case "4": return;
                }
            }
        }

        static void SortDemo()
        {
            // seven custom algorithms;
            // for each algorithm prepare copies of the same array to sort
            Random rd = new Random();

            int[] z1 = new int[50000];
            for (int i = 0; i < z1.Length; i++)
            {
                z1[i] = rd.Next(0, z1.Length);
            }

            int[] z2 = new int[z1.Length];
            z1.CopyTo(z2, 0);

            int[] z3 = new int[z1.Length];
            z1.CopyTo(z3, 0);

            int[] z4 = new int[z1.Length];
            z1.CopyTo(z4, 0);
            
            int[] z5 = new int[z1.Length];
            z1.CopyTo(z5, 0);
            
            int[] z6 = new int[z1.Length];
            z1.CopyTo(z6, 0);

            int[] z7 = new int[z1.Length];
            z1.CopyTo(z7, 0);
            // ----------------------------------------------------------
            
            Console.WriteLine("Selection Sort:");

            ISorter<int> sorter = new SelectionSorter();

            DateTime dt1 = DateTime.Now;
            sorter.Sort(z1, 0, z1.Length - 1);
            DateTime dt2 = DateTime.Now;
            Console.WriteLine("Time: {0}:{1}", (dt2 - dt1).Seconds, (dt2 - dt1).Milliseconds);

            Console.WriteLine("First 20 elements:");
            foreach (int elem in z1.Take(20))
                Console.Write(elem + " ");


            Console.WriteLine();
            Console.WriteLine("Bubble sort");

            sorter = new BubbleSorter();

            dt1 = DateTime.Now;
            sorter.Sort(z2, 0, z1.Length - 1);
            dt2 = DateTime.Now;
            Console.WriteLine("{0}:{1}", (dt2 - dt1).Seconds, (dt2 - dt1).Milliseconds);

            Console.WriteLine("First 20 elements:");
            foreach (int elem in z2.Take(20))
                Console.Write(elem + " ");


            Console.WriteLine();
            Console.WriteLine("Insertion sort");

            sorter = new InsertionSorter();

            dt1 = DateTime.Now;
            sorter.Sort(z3, 0, z1.Length - 1);
            dt2 = DateTime.Now;
            Console.WriteLine("{0}:{1}", (dt2 - dt1).Seconds, (dt2 - dt1).Milliseconds);

            Console.WriteLine("First 20 elements:");
            foreach (int elem in z3.Take(20))
                Console.Write(elem + " ");


            Console.WriteLine();
            Console.WriteLine("Shaker sort");

            sorter = new ShakerSorter();

            dt1 = DateTime.Now;
            sorter.Sort(z4, 0, z1.Length - 1);
            dt2 = DateTime.Now;
            Console.WriteLine("{0}:{1}", (dt2 - dt1).Seconds, (dt2 - dt1).Milliseconds);

            Console.WriteLine("First 20 elements:");
            foreach (int elem in z4.Take(20))
                Console.Write(elem + " ");


            Console.WriteLine();
            Console.WriteLine("Shell sort");

            sorter = new ShellSorter();

            dt1 = DateTime.Now;
            sorter.Sort(z5, 0, z1.Length - 1);
            dt2 = DateTime.Now;
            Console.WriteLine("{0}:{1}", (dt2 - dt1).Seconds, (dt2 - dt1).Milliseconds);

            Console.WriteLine("First 20 elements:");
            foreach (int elem in z5.Take(20))
                Console.Write(elem + " ");


            Console.WriteLine();
            Console.WriteLine("Counting sort");

            sorter = new CountingSorter();

            dt1 = DateTime.Now;
            sorter.Sort(z6, 0, z1.Length - 1);
            dt2 = DateTime.Now;
            Console.WriteLine("{0}:{1}", (dt2 - dt1).Seconds, (dt2 - dt1).Milliseconds);

            Console.WriteLine("First 20 elements:");
            foreach (int elem in z6.Take(20))
                Console.Write(elem + " ");

            
            Console.WriteLine();
            Console.WriteLine("Quicksort");

            sorter = new QuickSorter();

            dt1 = DateTime.Now;
            sorter.Sort(z7, 0, z1.Length - 1);
            dt2 = DateTime.Now;
            Console.WriteLine("{0}:{1}", (dt2 - dt1).Seconds, (dt2 - dt1).Milliseconds);

            Console.WriteLine("First 20 elements:");
            foreach (int elem in z7.Take(20))
                Console.Write(elem + " ");

            Console.WriteLine();

            Console.ReadKey();
            Console.Clear();
        }
        
        static void SearchDemo()
        {
            string needle = "ardcara";
            string haystack = "abataradabardardcaraadatatabat";

            Console.WriteLine();
            Console.WriteLine("Needle:");
            Console.WriteLine( needle );
            Console.WriteLine();
            Console.WriteLine("Haystack:");
            Console.WriteLine( haystack );
            Console.WriteLine();

            IStringSearcher stringSearcher = new BoyerMooreSearcher();
            Console.WriteLine("BM found position: {0}", stringSearcher.Search(needle, haystack));
            
            stringSearcher = new BoyerMooreHorspoolSearcher();
            Console.WriteLine("BMH found position: {0}", stringSearcher.Search(needle, haystack));

            stringSearcher = new KnuthMorrisPrattSearcher();
            Console.WriteLine("KMP found position: {0}", stringSearcher.Search(needle, haystack));

            Console.WriteLine();
            Console.WriteLine("Array:");

            int[] arr = { 1,4,7,9,12,14,15,17,19,20,23,25,27,29,30,31,32,34,35,36,37,38,39 };
            int element = 37;

            ISearcher<int> searcher = new BinarySearcher();
            Console.WriteLine("Binary search of element {0}: position {1}", element, searcher.Search(element, arr, arr.Length));

            searcher = new InterpolationSearcher();
            Console.WriteLine("Interpolation search of element {0}: position {1}", element, searcher.Search(element, arr, arr.Length));

            Console.ReadKey();
            Console.Clear();
        }

        static void GraphDemo()
        {
            int[,] adjMatrix = {{ 0, 3, 5, 0, 0, 0, 0, 0  },
                                { 3, 0, 0, 0, 0, 1, 10, 0 },
                                { 5, 0, 0, 2, 0, 4, 0, 3  },
                                { 0, 0, 2, 0, 1, 0, 0, 0  },
                                { 0, 0, 0, 1, 0, 2, 0, 0  },
                                { 0, 1, 4, 0, 2, 0, 0, 0  },
                                { 0, 10, 0, 0, 0, 0, 0, 4 },
                                { 0, 0, 3, 0, 0, 0, 4, 0  }};

            Console.WriteLine();
            Console.WriteLine( "Adjacency matrix:" );
            PrintMatrix( adjMatrix );

            int V = adjMatrix.GetLength(0);

            Graph G = new Graph(adjMatrix, V);

            // ------------------------------------------------------------ DFS demo
            Stack<int> paths = G.DFS(3, 6);

            Console.WriteLine();
            Console.WriteLine("DFS - Path from 4 to 7:");
            while (paths.Count > 0)
            {
                Console.Write(" -> " + paths.Pop());
            }
            Console.WriteLine();

            // ------------------------------------------------------------ BFS demo
            paths = G.BFS(3, 6);

            Console.WriteLine("BFS - Path from 4 to 7:");
            while (paths.Count > 0)
            {
                Console.Write(" -> " + paths.Pop());
            }
            Console.WriteLine();
            Console.WriteLine();


            // ------------------------------------------------------- Dijkstra demo
            Console.WriteLine("Dijkstra algorithm:");

            int start = 0;

            for (int end = 1; end < V; end++)
            {
                int sum;
                var path = G.ShortestPath(start, end, out sum);

                var s = G.backChain(path, start, end);
                while (paths.Count > 0)
                {
                    Console.Write("-> {0}", s.Pop() + 1);
                }
                Console.WriteLine("\nThe shortest path from {0} to {1} is {2}", start + 1, end + 1, sum);
            }
            Console.WriteLine();


            // ------------------------------------------------- Floyd-Warshall demo
            Console.WriteLine("Floyd Warshall algorithm:");

            int[,] pths = new int[V, V];

            int[,] dist = G.Floyd(pths);

            Console.WriteLine("Matrix of distances:");

            PrintMatrix( dist );
            
            Console.WriteLine("All shortest paths:");

            for (int i = 0; i < V; i++)
            {
                for (int j = i + 1; j < V; j++)
                {
                    Console.Write(j + 1 + " <- ");

                    int k = j;
                    while (k != i && k != -1)
                    {
                        Console.Write(pths[i, k] + 1 + " <- ");
                        k = pths[i, k];
                    }

                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            // ----------------------------------------------------------------------

            Console.ReadKey();
            Console.Clear();
        }

        static void PrintMatrix<T>(T[,] mx)
        {
            for (int i = 0; i < mx.GetLength(0); i++)
            {
                for (int j = 0; j < mx.GetLength(1); j++)
                {
                    Console.Write("{0,4}", mx[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
