using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    abstract class SearchAlgorithms
    {

        public List<GraphNode> nodesList = new List<GraphNode>();
        public int[,] startMatrix = new int[3, 3];
        public int[,] correctMatrix = new int[3, 3] { {1, 2, 3 }, { 8, 0, 4 },
                                        {7,6, 5} };
        public Graph newGraph;
        public void PrintPath(GraphNode node)
        {
            int counter = 0;
            while (node != null)
            {
                printNode(node);
                node = node.backElement;
                counter++;
            }
            Console.WriteLine("Total nodes: " + counter);
        }
        public void printNode(GraphNode node)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(node.NumbersArray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool compareArrays(int[,] arrayA, int[,] arrayB)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arrayA[i, j] != arrayB[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void MoveUp(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            int[,] tempMatrix = (int[,])matrix.Clone();
            tempMatrix[row, line] = tempMatrix[row, line - 1];
            tempMatrix[row, line - 1] = 0;
            GraphNode newItem = new GraphNode(tempMatrix);
            if (nodesList.FirstOrDefault(x => compareArrays(x.NumbersArray, tempMatrix)) == null)
            {
                newGraph.addNode(newItem);
                newGraph.addEdge(node, newItem);
                nodesList.Add(newItem);
            }


        }
        public void MoveDown(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            int[,] tempMatrix = (int[,])matrix.Clone();
            tempMatrix[row, line] = tempMatrix[row, line + 1];
            tempMatrix[row, line + 1] = 0;
            GraphNode newItem = new GraphNode(tempMatrix);
            if (nodesList.FirstOrDefault(x => compareArrays(x.NumbersArray, tempMatrix)) == null)
            {
                newGraph.addNode(newItem);
                newGraph.addEdge(node, newItem);
                nodesList.Add(newItem);
            }

        }
        public void MoveLeft(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            int[,] tempMatrix = (int[,])matrix.Clone();
            tempMatrix[row, line] = tempMatrix[row - 1, line];
            tempMatrix[row - 1, line] = 0;
            GraphNode newItem = new GraphNode(tempMatrix);
            if (nodesList.FirstOrDefault(x => compareArrays(x.NumbersArray, tempMatrix)) == null)
            {
                newGraph.addNode(newItem);
                newGraph.addEdge(node, newItem);
                nodesList.Add(newItem);
            }
        }
        public void MoveRight(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            int[,] tempMatrix = (int[,])matrix.Clone();
            tempMatrix[row, line] = tempMatrix[row + 1, line];
            tempMatrix[row + 1, line] = 0;
            GraphNode newItem = new GraphNode(tempMatrix);
            if (nodesList.FirstOrDefault(x => compareArrays(x.NumbersArray, tempMatrix)) == null)
            {
                newGraph.addNode(newItem);
                newGraph.addEdge(node, newItem);
                nodesList.Add(newItem);
            }
        }
    }
}