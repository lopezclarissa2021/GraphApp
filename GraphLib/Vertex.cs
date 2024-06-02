namespace GraphLib
{
    public class Vertex(string lbl)
    {
        public string Label { get; set; } = lbl;

        private static readonly List<Edge> value = [];
        public List<Edge> Edges = value;
        private Edge edge;

        public Vertex AddEdge(Vertex child, int weight)
        {
            Edges.Add(new Edge
            {
                Parent = this,
                Child = child,
                Weight = weight
            });

            Edges.Add(edge);

            // do something here =
            if (child.Edges.Exists(e => e.Parent == child && e.Child == this))
            {
                //update here
                child.AddEdge(this, weight);
            }
            return this;

        }
    }
}