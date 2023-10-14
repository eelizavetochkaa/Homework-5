using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5
{
    internal class Graph
    {
        private int V; // Количество вершин 
        private List<int>[] adjacencyList; // Список смежности 

        public Graph(int v)
        {
            V = v;
            adjacencyList = new List<int>[v];
            for (int i = 0; i < v; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            adjacencyList[v].Add(w);
        }

        public void BFS(int start, int end)
        {
            bool[] visited = new bool[V];
            int[] previous = new int[V];
            Queue<int> queue = new Queue<int>();

            visited[start] = true;
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                int current = queue.Dequeue();

                if (current == end)
                {
                    PrintShortestPath(previous, start, end);
                    return;
                }

                foreach (int neighbor in adjacencyList[current])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        previous[neighbor] = current;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            Console.WriteLine("Путь не найден.");
        }

        private void PrintShortestPath(int[] previous, int start, int end)
        {
            Console.WriteLine("Кратчайший путь между вершинами " + start + " и " + end + ":");
            int current = end;
            Stack<int> path = new Stack<int>();

            while (current != start)
            {
                path.Push(current);
                current = previous[current];
            }
            path.Push(start);

            while (path.Count > 0)
            {
                Console.Write(path.Pop());
                if (path.Count > 0)
                {
                    Console.Write(" -> ");
                }
            }
        }
    }
}
