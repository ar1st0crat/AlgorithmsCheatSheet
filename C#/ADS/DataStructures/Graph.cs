using System.Collections.Generic;

namespace ADS.DataStructures
{
    /// <summary>
    /// GRAPH REPRESENTATION: ADJACENCY MATRIX
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// The number of vertices
        /// </summary>
        private int V = 0;
        
        /// <summary>
        /// The adjacency matrix (mtrix of incidence)
        /// </summary>
        private int[,] graph = null;

        public Graph()
        {
        }

        /// <summary>
        /// Initialize graph with particular parameters
        /// </summary>
        /// <param name="adj">Adjacency matrix</param>
        /// <param name="N">Number of vertices</param>
        public Graph(int[,] adj, int N)
        {
            graph = adj;
            V = N;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <returns></returns>
        public Stack<int> backChain(int[] p, int startPos, int endPos)
        {
            int pos = endPos;

            Stack<int> pathStack = new Stack<int>();
            pathStack.Push( pos );
        
            while ( pos != startPos )
            {
                pos = p[pos];
                pathStack.Push( pos );
            }
        
            return pathStack;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <returns></returns>
        public Stack<int> DFS(int startPos, int endPos)
        {
            // stack for DFS
            Stack<int> st = new Stack<int>();
            
            // array for tracking path
            int[] vPath = new int[V];
            
            // array for already visited vertices 
            int[] checkedv = new int[V];
        
                
            st.Push( startPos );
            checkedv[startPos] = 1;
        
            while ( st.Count > 0 )
            {
                int i = st.Pop();
            
                for ( int j=V-1; j>=0; j-- )
                {
                    if ( graph[i,j] > 0 && checkedv[j] == 0 )
                    {
                        checkedv[j] = 1;
                        st.Push( j );
                        vPath[j] = i;
                    
                        if ( j == endPos )
                        {
                            return backChain( vPath, startPos, endPos );
                        }
                    }
                }    
            }
        
            return null;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <returns></returns>
        public Stack<int> BFS(int startPos, int endPos)
        {
            Queue<int> q = new Queue<int>();

            // array for tracking path
            int[] vPath = new int[V];

            int[] checkedv = new int[V];

            q.Enqueue(startPos);
            checkedv[startPos] = 1;

            while (q.Count > 0)
            {
                int i = q.Dequeue();

                for (int j = 0; j < V; j++)
                {
                    if (graph[i,j] > 0 && checkedv[j] == 0)
                    {
                        checkedv[j] = 1;
                        q.Enqueue(j);
                        vPath[j] = i;

                        if (j == endPos)
                        {
                            return backChain(vPath, startPos, endPos);
                        }
                    }
                }
            }
            return null;
        }
        
        /// <summary>
        /// Алгоритм Дейкстры (для всех узлов)
        /// </summary>
        public void Dijkstra()
        {
            // ------------------------------------ подготовка
            List<int> dist = new List<int>();

            List<int> q = new List<int>();

            for (int i = 0; i < V; i++)
            {
                dist.Add( int.MaxValue );
                q.Add( i );
            }

            dist[0] = 0;

            // ----------------------------------- главный цикл
            while (q.Count > 0)
            {
                // ----------------------- найти минимум в dist
                var min = double.PositiveInfinity;
                int u = -1;
                foreach (int val in q)
                {
                    if (dist[val] <= min)
                    {
                        min = dist[val];
                        u = val;
                    }
                }
                q.Remove( u );
                
                // ------------ нарастить расстояние, если нужно
                for (int i = 0; i < V; i++)
                {
                    if (graph[u, i] > 0)
                    {
                        if (dist[i] > graph[u, i] + dist[u])
                            dist[i] = graph[u, i] + dist[u];
                    }
                }
            }
        }


        /// <summary>
        /// Shortest path from the node u to the node v
        /// </summary>
        /// <param name="s">Starting node</param>
        /// <param name="v">Destination node</param>
        /// <returns>The shortest path</returns>
        public int[] ShortestPath(int s, int v, out int path)
        {
            int[] prev = new int[V];

            List<int> res = new List<int>();

            // ------------------------------------------- подготовка
            List<int> distances = new List<int>();
            List<int> q = new List<int>();
            for (int i = 0; i < V; i++)
            {
                distances.Add( int.MaxValue );
                q.Add( i );
            }
            distances[s] = 0;

            // ------------------------------------------ главный цикл
            while (q.Count > 0)
            {
                // --- find min 
                int u = -1, min = int.MaxValue;

                for (int i = 0; i < q.Count; i++)
                {
                    if (distances[q[i]] <= min)
                    {
                        min = distances[q[i]];
                        u = q[i];
                    }
                }
                q.Remove( u );

                // ------------------ нарастить расстояние, если нужно
                for (int i = 0; i < V; i++)
                    if (graph[u, i] > 0)
                        if (distances[i] > graph[u, i] + distances[u])
                        {
                            distances[i] = graph[u, i] + distances[u];
                            prev[i] = u;
                        }
            }

            path = distances[v];

            return prev;
        }


        /// <summary>
        /// FLOYD ALGORITHM FOR FINDING SHORTEST PATHS BETWEEN ALL PAIRS OF VERTICES
        /// </summary>
        /// <param name="paths">Matrix of </param>
        /// <returns>Matrix of distances between vertices</returns>
        public int[,] Floyd( int [,] paths )
        {
            // ----------------------------------------- initialize the paths matrix
            for (int i = 0; i < V; i++)
                for (int j = 0; j < V; j++)
                    if ( graph[i,j] == 0 || i == j )
                        paths[i, j] = -1;
                    else
                        paths[i, j] = i;
                    
            // --------------------------------------- working with distances matrix
            int [,] distances = new int[V,V];

            for (int i = 0; i < V; i++)
                for (int j = 0; j < V; j++)
                    if (i == j)
                        distances[i, j] = 0;
                    else
                        distances[i, j] = (graph[i, j] > 0) ? graph[i, j] : int.MaxValue;

            // ----------------------------------------------------------- main loop
            for (int i = 0; i < V; i++)
            {
                for (int u = 0; u < V; u++)
                {
                    for (int v = 0; v < V; v++)
                    {
                        if (distances[u, v] > 0)
                        {
                            if (u == i || v == i ||
                                distances[u, i] == int.MaxValue || distances[i, v] == int.MaxValue)
                                    continue;

                            if (distances[u, v] > distances[u, i] + distances[i, v])
                            {
                                distances[u, v] = distances[u, i] + distances[i, v];
                                paths[u, v] = paths[i, v];
                            }
                        }
                    }
                }
            }
            return distances;
        }
    }
}
