using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class DFS
    {
        public int[,] correctMatrix = new int[3, 3];
        Graph newGraph;
        public DFS (int[,] CorrectMatrix)
        {
            correctMatrix = CorrectMatrix;
            newGraph = new Graph();
        }
        GraphNode firstNode = (new CreateNodeConsole()).GetNode();

        public void Calculate()
        {

        }
        public void MoveUp(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            matrix[row, line] = matrix[row - 1, line];
            matrix[row - 1, line] = 0;
            GraphNode newItem = new GraphNode(matrix);
            newGraph.addNode(newItem);
            newGraph.addVertex(node, newItem);

        }
    }
}
