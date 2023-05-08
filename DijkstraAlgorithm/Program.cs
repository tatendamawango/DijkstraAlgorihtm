using System;
using System.Collections.Generic;
using System.Linq;
using static System.String;

namespace DijkstraAlgorithm
{
    internal static class Program
    {
       private static class Dijkstra
        {
            private static List<int> DijkstraAlgorithm(double[,] graph, int start, int end)
            {
                var n = graph.GetLength(0);

                var distance = new double[n];
                for (var i = 0; i < n; i++)
                {
                    distance[i] = int.MaxValue;
                }

                distance[start] = 0;

                var used = new bool[n];
                var previous = new int?[n];

                while (true)
                {
                    var minDistance = double.MaxValue;
                    var minNode = 0;
                    for (var i = 0; i < n; i++)
                    {
                        if (used[i] || minDistance <= distance[i]) continue;
                        minDistance = distance[i];
                        minNode = i;
                    }

                    if (minDistance == double.MaxValue)
                    {
                        break;
                    }
                    used[minNode] = true;
                    for (var i = 0; i < n; i++)
                    {
                        switch (graph[minNode, i] > 0)
                        {
                            case true:
                            {
                                var shortestToMinNode = distance[minNode];
                                var distanceToNextNode = graph[minNode, i];

                                var totalDistance = shortestToMinNode + distanceToNextNode;

                                if (totalDistance < distance[i])
                                {
                                    distance[i] = totalDistance;
                                    previous[i] = minNode;
                                }

                                break;
                            }
                        }
                    }
                }

                switch (distance[end])
                {
                    case int.MaxValue:
                        return null;
                }

                var path = new LinkedList<int>();
                int? currentNode = end;
                while (currentNode != null)
                {
                    path.AddFirst(currentNode.Value);
                    currentNode = previous[currentNode.Value];
                }
                return path.ToList();
            }
            
            public static void Main()
            {
                var graph = new[,]
                {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, Cd(6,1), Cd(1,4), 0, 0, 0, 0, 0, 0},//1
                    {0, Cd(6,1), 0, Cd(7,2), 4, Cd(5,4), 0, 0, 0, 0},//2
                    {0, Cd(1,4), Cd(7,2), 0, Cd(7,2), Cd(2,2), 0, 0, 0, 0},//3
                    {0, 0, 4, Cd(7,2), 0, 5, Cd(7,2), Cd(1,2), 0, 0},//4
                    {0, 0, Cd(5,4), Cd(2,2), 5, 0, Cd(2,2), Cd(6,2), 0, 0},//5
                    {0, 0, 0, 0, Cd(7,2), Cd(2,2), 0, 8, Cd(6,1), Cd(3,1)},//6
                    {0, 0, 0, 0, Cd(1,2), Cd(6,2), 8, 0, Cd(2,1), 0},//7
                    {0, 0, 0, 0, 0, 0, Cd(6,1), Cd(2,1), 0, 3},//8
                    {0, 0, 0, Cd(3,1), 0, 0, 0, 0, 3, 0} //9
                };

                var path = 0.0;
                Console.WriteLine("Shortest path A-B\n" + PrintPath(graph,1,9, ref path));
                Console.WriteLine("Total weight is: " + path);
                path = 0;
                Console.WriteLine("\nShortest path A-D-C-B\n" +PrintPath(graph, 1, 7, ref path) 
                                                      +" " + PrintPath(graph, 7, 6, ref path) 
                                                      +" " + PrintPath(graph, 6, 9, ref path));
                Console.WriteLine("Total weight is: " + path);
                var n1 = path;
                path = 0;
                Console.WriteLine("\nShortest path A-C-D-B\n" +PrintPath(graph, 1, 6, ref path) 
                                                            +" " + PrintPath(graph, 6, 7, ref path) 
                                                            +" " + PrintPath(graph, 7, 9, ref path));
                Console.WriteLine("Total weight is: " + path);
                
                switch (n1 < path)
                {
                    case true:
                        Console.WriteLine("Path A-D-C-D is shorter than path A-C-D-B");
                        break;
                    default:
                    {
                        switch (n1 > path)
                        {
                            case true:
                                Console.WriteLine("Path A-C-D-B is shorter than path A-D-C-B");
                                break;
                            default:
                                Console.WriteLine("The paths are equal");
                                break;
                        }
                        break;
                    }
                }
            }

            private static string PrintPath(double[,] graph, int start, int end, ref double paths)
            {
                var path = DijkstraAlgorithm(graph, start, end);

                var pathLength = 0.0;
                if (path == null) return "no path";
                for (var i = 0; i < path.Count - 1; i++)
                {
                    pathLength += graph[path[i], path[i + 1]];
                }

                var formattedPath = Join("->", path);
                paths += pathLength;
                return formattedPath;

            }
            
            private static double Cd(int y, int x)
            {
                var res = Math.Sqrt(Math.Pow(y,2)+Math.Pow(x,2));
                return Math.Abs(Math.Round(res,4));
            }
        }
    }
}