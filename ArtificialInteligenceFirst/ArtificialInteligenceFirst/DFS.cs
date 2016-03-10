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
        public int[,] correctMatrix = new int[3, 3] { {1, 2, 3 }, { 8, 0, 4 },
                                        {7,6, 5} };
        Graph newGraph;
        public DFS()
        {
            newGraph = new Graph();
            Calculate();
        }

        public void Calculate()
        {
            bool k = true;
            int[,] startMatrix = ((new CreateNodeConsole()).GetNode()).NumbersArray;
            nodesList.Add(new GraphNode(startMatrix));
            
            while (k)
            {
                List<GraphNode> tempList = nodesList.ToList();
                foreach (GraphNode item in tempList)
                {
                    Move(item);
                }
                foreach (GraphNode item in nodesList)
                {
                    if(compareArrays(correctMatrix, item.NumbersArray))
                    {
                        Console.WriteLine("Radau");
                        k = false;
                        PrintPath(item);
                    }
                }
            }
            Console.ReadLine();
        }
        public void PrintPath(GraphNode node)
        {
            while (node != null)
            {
                printNode(node);
                node = node.backElement;
            }
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
        public bool compareArrays(int[,] arrayA, int[,] arrayB)
        {
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arrayA[i, j] == arrayB[i, j])
                    {
                        counter++;
                    }
                }
            }
            if (counter == 9)
            {
                return true;
            }
            else return false;
        }
        public void MoveUp(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            int[,] tempMatrix = (int[,])matrix.Clone();
            tempMatrix[row, line] = tempMatrix[row, line-1];
            tempMatrix[row, line-1] = 0;
            GraphNode newItem = new GraphNode(tempMatrix);         
            newGraph.addNode(newItem);
            newGraph.addEdge(node, newItem);
            nodesList.Add(newItem);

            
        }
        public void MoveDown(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            int[,] tempMatrix = (int[,])matrix.Clone();
            tempMatrix[row, line] = tempMatrix[row , line+1];
            tempMatrix[row , line+1] = 0;
            GraphNode newItem = new GraphNode(tempMatrix);
            
            newGraph.addNode(newItem);
            nodesList.Add(newItem);
            newGraph.addEdge(node, newItem);
        }
        public void MoveLeft(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            int[,] tempMatrix = (int[,])matrix.Clone();
            tempMatrix[row, line] = tempMatrix[row-1, line];
            tempMatrix[row-1, line] = 0;
            GraphNode newItem = new GraphNode(tempMatrix);
            
            newGraph.addNode(newItem);
            newGraph.addEdge(node, newItem);
            nodesList.Add(newItem);
        }
        public void MoveRight(GraphNode node, int row, int line)
        {
            int[,] matrix = node.GetNodeMatrix();
            int[,] tempMatrix = (int[,])matrix.Clone();
            tempMatrix[row, line] = tempMatrix[row+1, line];
            tempMatrix[row+1, line] = 0;
            GraphNode newItem = new GraphNode(tempMatrix);
          
            newGraph.addNode(newItem);
            newGraph.addEdge(node, newItem);
            nodesList.Add(newItem);
        }
    }
}
