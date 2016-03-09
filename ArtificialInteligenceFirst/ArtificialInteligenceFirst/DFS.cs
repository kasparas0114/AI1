using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class DFS
    {

        List<GraphNode> nodesList = new List<GraphNode>();
        public int[,] startMatrix = new int[3, 3];
        public int[,] correctMatrix = new int[3, 3];
        Graph newGraph;
        public DFS(int[,] startMatrix, int[,] CorrectMatrix)
        {
            this.startMatrix = startMatrix;
            correctMatrix = CorrectMatrix;
            newGraph = new Graph();
        }
        GraphNode firstNode = (new CreateNodeConsole()).GetNode();

        public void Calculate()
        {
            bool k = false;
            nodesList.Add(new GraphNode(startMatrix));
            while (k)
            {      
                foreach (GraphNode item in nodesList)
                {
                    Move(item);
                }
                foreach (GraphNode item in nodesList)
                {
                    if (item.NumbersArray == correctMatrix)
                    {
                        Console.WriteLine("pisau radau");
                        k = true;
                    }
                }
            }

        }
        public void Move(GraphNode node)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (node.NumbersArray[i, j] == 0)
                    {
                        if (i < 2) MoveRight(node, i, j);
                        if (i > 0) MoveLeft(node, i, j);
                        if (j < 2) MoveDown(node, i, j);
                        if (j > 0) MoveUp(node, i, j);
                    }
                }
                nodesList.Remove(node);
            }
        }
        public void MoveUp(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            matrix[row, line] = matrix[row - 1, line];
            matrix[row - 1, line] = 0;
            GraphNode newItem = new GraphNode(matrix);
            newGraph.addNode(newItem);
            newGraph.addEdge(node, newItem);
            nodesList.Add(newItem);
        }
        public void MoveDown(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            matrix[row, line] = matrix[row + 1, line];
            matrix[row + 1, line] = 0;
            GraphNode newItem = new GraphNode(matrix);
            newGraph.addNode(newItem);
            nodesList.Add(newItem);
            newGraph.addEdge(node, newItem);
        }
        public void MoveLeft(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            matrix[row, line] = matrix[row, line - 1];
            matrix[row, line - 1] = 0;
            GraphNode newItem = new GraphNode(matrix);
            newGraph.addNode(newItem);
            newGraph.addEdge(node, newItem);
            nodesList.Add(newItem);
        }
        public void MoveRight(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            matrix[row, line] = matrix[row, line + 1];
            matrix[row, line + 1] = 0;
            GraphNode newItem = new GraphNode(matrix);
            newGraph.addNode(newItem);
            newGraph.addEdge(node, newItem);
            nodesList.Add(newItem);
        }
    }
}
