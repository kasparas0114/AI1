using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class DFS : SearchAlgorithms
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
                        Console.WriteLine("aa");

                        k = false;
                        PrintPath(item);
                    }
                }
            }
            Console.ReadLine();
        }
        public void Move(GraphNode node)
        {

        }
    }
}