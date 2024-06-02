using GraphLib;

namespace GraphTests
{
    [TestClass]
    public class DirectedGraphTests
    {
        [TestMethod]
        public void AddingAVertexToTheGraph_ShouldReturnAVertex()
        {
            // arrange
            DirectedGraph graph = new();

            // Acted
            var result = graph.AddVertex("Toast");

            // Assert
            Assert.IsInstanceOfType<Vertex>(result);
            Assert.AreEqual(result.Label, "Toast");
        }

        [TestMethod]
        [DataRow("Toast", "Butter", "Lawnmower")]
        public void AddingMoreThanOneNodeToTheGraph_ShouldRetainEachOfThem(string one, string two, string three)
        {
            // arrange
            DirectedGraph graph = new();

            // act
            graph.AddVertex(one);
            graph.AddVertex(two);
            graph.AddVertex(three);

            var result = graph.NumVertices;

            var resultone = graph.Vertices[0];
            var resulttwo = graph.Vertices[1];
            var resultthree = graph.Vertices[2];

            // Assert
            Assert.AreEqual(3, result);
            Assert.AreEqual(one, resultone.Label);
            Assert.AreEqual(two, resulttwo.Label);
            Assert.AreEqual(three, resultthree.Label);
        }
    }
}