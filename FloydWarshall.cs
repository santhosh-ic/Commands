//C# implementation of FloydWarshall algorithm. Mostly derived from https://www.geeksforgeeks.org/dynamic-programming-set-16-floyd-warshall-algorithm/ with additional implementation of printing the path

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydWarshall
{
    class Program
    {

        // Number of vertices in the graph
        private static int V = 5;

        /* Define Infinite as a large enough value. This value will be used
          for vertices not connected to each other */
        private static int INF = 99999;


        // A function to print the solution matrix
        public static void printSolution(int [,]dist)
        {
            Console.Write("Following matrix shows the shortest distances between every pair of vertices \n");
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (dist[i, j] == INF)
                    {
                        Console.Write("       ");
                        Console.Write("INF");
                    }
                    else
                    {
                        Console.Write("       ");
                        Console.Write(dist[i, j]);
                    }
                }
                Console.Write("\n");
            }
        }

        private static void printPath(int u, int v, int[,] next)
        {
            if (next[u, v] == -1)
                return;
            Console.Write(u);
            Console.Write(" ");
            while (u != v)
            {
                u = next[u, v];
                Console.Write(u);
                Console.Write(" ");
            }
            Console.WriteLine(" ");
        }


        // Solves the all-pairs shortest path problem using Floyd Warshall algorithm
        public static void floydWarshall(int [,]graph)
        {
            /* dist[][] will be the output matrix that will finally have the shortest 
              distances between every pair of vertices */
            int [,]dist = new int[V,V];
            int [,] next = new int[V,V];
            int i, j, k;
 
    /* Initialize the solution matrix same as input graph matrix. Or 
       we can say the initial values of shortest distances are based
       on shortest paths considering no intermediate vertex. */
        for (i = 0; i<V; i++)
            for (j = 0; j < V; j++)
            {
                dist[i, j] = graph[i, j];
                next[i, j] = j;
            }

            /* Add all vertices one by one to the set of intermediate vertices.
              ---> Before start of a iteration, we have shortest distances between all
              pairs of vertices such that the shortest distances consider only the
              vertices in set {0, 1, 2, .. k-1} as intermediate vertices.
              ----> After the end of a iteration, vertex no. k is added to the set of
              intermediate vertices and the set becomes {0, 1, 2, .. k} */
    for (k = 0; k<V; k++)
    {
        // Pick all vertices as source one by one
        for (i = 0; i<V; i++)
        {
            // Pick all vertices as destination for the
            // above picked source
            for (j = 0; j<V; j++)
            {
                // If vertex k is on the shortest path from
                // i to j, then update the value of dist[i][j]
                if (dist[i, k] + dist[k, j] < dist[i, j])
                {
                    dist[i, j] = dist[i, k] + dist[k, j];
                    next[i, j] = next[i, k];
                }
            }
        }
    }

    // Print the shortest distance matrix
    printSolution(dist);

            //Print the path from 0 to 4 and 4 to 3
            Console.WriteLine("Path through a vertex from src to dst");
            printPath(0, 4, next);
            printPath(4, 3, next);
        }
 
/* A utility function to print solution */

static void Main(string[] args)
        {

            /* Let us create the following weighted graph
                    10
               (0)------->(3)
                |         /|\
              5 |          |
                |          | 1
               \|/         |
               (1)------->(2)
                    3           */
            int [,]graph = { {0,   5,  INF, 10, INF},
                {INF, 0,   3, INF, 4},
                {INF, INF, 0,   1, 1},
                {INF, INF, INF, 0, INF},
                {INF, INF, INF, 1, 0 }
            };

            // Print the solution
            floydWarshall(graph);
            System.Console.ReadKey();

        }
    }
}
