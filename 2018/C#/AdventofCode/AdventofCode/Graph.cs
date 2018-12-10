using System;
using System.Collections.Generic;
using System.Text;

namespace AdventofCode {
    class Graph {
        public static readonly double INFINITY = double.MaxValue;
        Dictionary<string, Vertex> vertexMap = new Dictionary<string, Vertex>();


        public void AddEdge(string source, string dest, double cost) {
            Vertex v = GetVertex(source);
            Vertex w = GetVertex(dest);
            v.adj.Add(new Edge(w, cost));
            w.previous.Add(new Edge(v, cost));
        }

        public Vertex GetVertex(string name) {
            Vertex v;
            if (vertexMap.ContainsKey(name)) {
                v = vertexMap[name];
            } else {
                v = new Vertex(name);
                vertexMap.Add(name, v);
            }
            return v;
        }

        public override string ToString() {
            string returnString = "";
            foreach (Vertex v in vertexMap.Values) {
                returnString += v + "\n";
            }
            return returnString;
        }

        public List<Vertex> GetStart() {
            List<Vertex> result = new List<Vertex>();

            foreach (Vertex v in vertexMap.Values) {
                bool hasPrior = false;

                foreach (Vertex v2 in vertexMap.Values) {
                    if (v == v2)
                        continue;

                    foreach (Edge e in v2.adj) {
                        if (e.destination == v) {
                            hasPrior = true;
                            break;
                        }
                    }
                }

                if (!hasPrior)
                    result.Add(v);
            }

            return result;
        }

        public List<Vertex> GetOrder() {
            List<Vertex> result = new List<Vertex>();

            List<Vertex> available = GetStart();

            while (available.Count > 0) {
                Vertex current = available[0];

                foreach (Vertex v in available)
                    if (v.name[0] < current.name[0])
                        current = v;

                available.Remove(current);
                result.Add(current);
                current.scratch = true;

                foreach (Edge e in current.adj) {
                    if (e.destination.scratch)
                        continue;

                    if (available.Contains(e.destination))
                        continue;

                    bool cont = false;

                    foreach (Edge e2 in e.destination.previous) {
                        if (!(result.Contains(e2.destination) || current == e2.destination))
                            cont = true;
                    }

                    if (cont)
                        continue;

                    available.Add(e.destination);
                }
            }

            return result;
        }

        public int Make() {
            int result = -1;

            List<Vertex> done = new List<Vertex>();
            List<Vertex> available = GetStart();

            foreach (Vertex v in vertexMap.Values) {
                v.Reset();
            }

            int workersIdle = 5;
            int[] workerTimeRemaining = new int[5] { 0, 0, 0, 0, 0 };
            Vertex[] workerVertex = new Vertex[5] { null, null, null, null, null };

            while (available.Count > 0 || workersIdle < 5) {
                //Console.WriteLine("test");
                result++;
                if (workersIdle < 5) {
                    for (int i = 0; i < 5 - workersIdle; i++) {
                        if (workerVertex[i] == null)
                            continue;
                        workerTimeRemaining[i]--;
                        if (workerTimeRemaining[i] <= 0) {
                            foreach (Edge e in workerVertex[i].adj) {
                                if (e.destination.scratch)
                                    continue;

                                if (available.Contains(e.destination))
                                    continue;

                                bool cont = false;

                                foreach (Edge e2 in e.destination.previous) {
                                    if (!(done.Contains(e2.destination) || workerVertex[i] == e2.destination))
                                        cont = true;
                                }

                                if (cont)
                                    continue;

                                available.Add(e.destination);
                            }

                            done.Add(workerVertex[i]);

                            for (int j = i; j < 4 - workersIdle; j++) {
                                workerTimeRemaining[j] = workerTimeRemaining[j + 1];
                                workerVertex[j] = workerVertex[j + 1];
                            }
                            workerTimeRemaining[4 - workersIdle] = 0;
                            workerVertex[4 - workersIdle] = null;

                            workersIdle++;
                        }
                    }
                }
                if (workersIdle > 0) {
                    while (available.Count > 0) {
                        Vertex current = available[0];

                        foreach (Vertex v in available)
                            if (v.name[0] < current.name[0])
                                current = v;

                        workerVertex[5 - workersIdle] = current;
                        workerTimeRemaining[5 - workersIdle] = 0 + current.ToString()[0] - 65;
                        workersIdle--;
                        available.Remove(current);
                        current.scratch = true;
                    }
                }
            }

            return result;
        }

        public void Unweighted(string name) {
            ClearAll();

            Vertex start;
            try {
                start = vertexMap[name];
            } catch {
                Console.WriteLine("Vertex does not exist");
                return;
            }

            Queue<Vertex> q = new Queue<Vertex>();
            q.Enqueue(start);
            start.dist = 0;

            while (q.Count > 0) {
                Vertex v = q.Dequeue();

                foreach (Edge e in v.adj) {
                    Vertex w = e.destination;

                    if (w.dist == INFINITY) {
                        w.dist = v.dist + 1;
                        w.prev = v;
                        q.Enqueue(w);
                    }
                }
            }
        }

        public void dijkstra(string name) {
            ClearAll();

            Vertex start;
            try {
                start = vertexMap[name];
            } catch {
                Console.WriteLine("Vertex does not exist");
                return;
            }

            List<Edge> availableRoutes = new List<Edge>();
            foreach (Edge e in start.adj)
                availableRoutes.Add(e);
            int nodesSeen = 0;

            while (availableRoutes.Count > 0 && nodesSeen < vertexMap.Count) {
                Edge route = getClosestEdge(availableRoutes);
                availableRoutes.Remove(route);

                Vertex v = route.destination;
                if (v.scratch)
                    continue;

                v.scratch = true;
                nodesSeen++;

                foreach (Edge e in v.adj) {
                    Vertex w = e.destination;
                    double cvw = e.cost;

                    if (w.dist > v.dist + cvw) {
                        w.dist = v.dist + cvw;
                        w.prev = v;
                        availableRoutes.Add(e);
                    }
                }
            }
        }

        private Edge getClosestEdge(List<Edge> list) {
            Edge v = list[0];
            foreach (Edge e in list) {
                if (e.cost < v.cost)
                    v = e;
            }
            return v;
        }

        private void printPath(Vertex dest) {
            if (dest.prev != null) {
                printPath(dest.prev);
                Console.Write(" to ");
            }
            Console.Write(dest.name);
        }

        public void printPath(string name) {
            Vertex v;
            try {
                v = vertexMap[name];
            } catch {
                Console.WriteLine("Vertex does not exist");
                return;
            }

            if (v.dist == INFINITY) {
                Console.WriteLine(name + " is unreachable");
            } else {
                Console.Write("Cost: " + v.dist + ". Path: ");
                printPath(v);
                Console.WriteLine();
            }
        }

        private void ClearAll() {
            foreach (Vertex v in vertexMap.Values) {
                v.Reset();
            }
        }
    }

    class Edge {
        public Vertex destination;
        public double cost;

        public Edge(Vertex dest, double cost) {
            destination = dest;
            this.cost = cost;
        }
    }

    class Vertex {
        public string name;
        public List<Edge> adj;
        public List<Edge> previous;
        public double dist;
        public Vertex prev;
        public bool scratch;

        public Vertex(string name) {
            this.name = name;
            adj = new List<Edge>();
            previous = new List<Edge>();
            Reset();
        }


        public void Reset() {
            dist = Graph.INFINITY;
            prev = null;
            scratch = false;
        }

        public override string ToString() {
            string returnString = string.Format("{0} -->", name);
            foreach (Edge e in adj) {
                returnString = string.Format("{0} {1}({2})", returnString, e.destination.name, e.cost);
            }
            return returnString;
        }
    }
}
