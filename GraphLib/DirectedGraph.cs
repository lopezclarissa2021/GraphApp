using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace GraphLib
{


    public class DirectedGraph
    {
        public int NumVertices { get => Vertices.Count; }
        public List<Vertex> Vertices = new List<Vertex>();
        public Vertex AddVertex(string label)
        {
            Vertex v = new Vertex(label);
            Vertices.Add(v);
            return v;

        }

        public int?[,] CreateAdjMatrix()
        {

            int?[,] AdjMatrix = new int?[Vertices.Count, Vertices.Count];

            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertex v1 = Vertices[i];

                for (int j = 0; j < Vertices.Count; j++)
                {
                    Vertex v2 = Vertices[j];

                    Edge edge = v1.Edges.FirstOrDefault(e => e.Child == v2);

                    if (edge != null)
                    {
                        AdjMatrix[i, j] = edge.Weight;
                    }
                }

            }
            return AdjMatrix;
        }

        public void PrintMatrix()
        {
            var matrix = CreateAdjMatrix();

            Console.Write("\t");
            {
                for (int i = 0; i < Vertices.Count; i++)
                {
                    Console.Write($"{Vertices[i].Label}");
                }

                Console.WriteLine();

                for (int i = 0; i < Vertices.Count; i++)
                {
                    Console.Write($"{Vertices[i].Label}\t");
                    for (int j = 0; j < Vertices.Count; j++)
                    {
                        if (matrix[i, j] == null)
                        {
                            Console.Write($"[{matrix[i, j].ToString()}]");
                        }
                        else
                        {
                            Console.Write("[.]");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        public void Dijkstra(int[,] graph, int src)
        {
            int[] dist = new int[Vertices.Count];
            bool[] visits = new bool[Vertices.Count];

            for (int i = 0; i < Vertices.Count; i++)
            {
                dist[i] = int.MaxValue;
                visits[i] = false;
            }


            dist[src] = 0;

            for (int count = 0; count < Vertices.Count - 1; count++)
            {

                int u = MinDistance(dist, visits);

                visits[u] = true;



                for (int v = 0; v < Vertices.Count; v++)
                {

                    if (!visits[v] &&
                       graph[u, v] != 0 &
                       dist[u] != int.MaxValue &
                       dist[u] + graph[u, v] < dist[v]
                       )
                    {
                        dist[v] = dist[u] + graph[u, v];
                    }
                }
            }
            PrintSolution(dist, Vertices.Count);
        }

        private int MinDistance(int[] dist, bool[] visits)
        {
            throw new NotImplementedException();
        }

        private void PrintSolution(int[] dist, int count)
        {
            throw new NotImplementedException();
        }

        private int MidDistance(int[] dist, bool[] visits)
        {
            int min = int.MaxValue;
            int min_index = -1;


            for (int i = 0; i < Vertices.Count; i++)
            {
                if (visits[i] == false && dist[i] <= min)
                {
                    min = dist[i];
                    min_index = i;
                }
            }
            return min_index;
        }
    }
}