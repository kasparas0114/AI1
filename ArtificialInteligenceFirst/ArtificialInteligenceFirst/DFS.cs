using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class DFS:SearchAlgorithms
    {
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
                    if (compareArrays(correctMatrix, item.NumbersArray))
                    {
                        Console.WriteLine("Found");
                        k = false;
                        PrintPath(item);
                    }
                }
            }
            Console.ReadLine();
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
            }
        }
    }
}
