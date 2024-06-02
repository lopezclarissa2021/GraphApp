using GraphLib;

DirectedGraph graph = new DirectedGraph();

var a = graph.AddVertex("A");
var b = graph.AddVertex("B");
var c = graph.AddVertex("C");
var d = graph.AddVertex("D");
var e = graph.AddVertex("E");

a.AddEdge(b, 5).AddEdge(c, 2);
b.AddEdge(c, 1);
b.AddEdge(d, 2);
c.AddEdge(d, 1).AddEdge(e, 1);



graph.PrintMatrix();

var adj = graph.CreateAdjMatrix();

graph.Dijkstra(adj, 4);