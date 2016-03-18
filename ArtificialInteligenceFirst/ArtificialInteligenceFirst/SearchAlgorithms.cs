using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    abstract class SearchAlgorithms
    {

        public List<int[,]> visitedList = new List<int[,]>();
        public int[,] startMatrix = new int[3, 3];
        public int[,] correctMatrix = new int[3, 3] { {1, 2, 3 }, { 8, 0, 4 },
                                        {7,6, 5} };
     
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
        public bool MoveUp(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            int[,] tempMatrix = (int[,])matrix.Clone();
            tempMatrix[row, line] = tempMatrix[row, line - 1];
            tempMatrix[row, line - 1] = 0;
            if (addNewNodeToGraph(tempMatrix, node)) return true;
            return false;

        }

        public bool MoveDown(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            int[,] tempMatrix = (int[,])matrix.Clone();
            tempMatrix[row, line] = tempMatrix[row, line + 1];
            tempMatrix[row, line + 1] = 0;
            if (addNewNodeToGraph(tempMatrix, node)) return true;
            return false;

        }
        public bool MoveLeft(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            int[,] tempMatrix = (int[,])matrix.Clone();
            tempMatrix[row, line] = tempMatrix[row - 1, line];
            tempMatrix[row - 1, line] = 0;
            if (addNewNodeToGraph(tempMatrix, node)) return true;
            return false;
        }

        public bool MoveRight(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            int[,] tempMatrix = (int[,])matrix.Clone();
            tempMatrix[row, line] = tempMatrix[row + 1, line];
            tempMatrix[row + 1, line] = 0;
            if (addNewNodeToGraph(tempMatrix, node)) return true;
            return false;
        }

        public abstract bool addNewNodeToGraph(int[,] tempMatrix, GraphNode node);
        

        public bool checkPath(GraphNode node, int[,] matrix)
        {
            while(node != null)
            {
                if (compareArrays(node.NumbersArray,matrix))
                {

                    visitedList.Add(matrix);
                    return false;
                }
                node = node.backElement;
            }
            return true;
        }
    }
}