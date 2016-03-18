using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class IDFS:SearchAlgorithms
    {
        public Stack<GraphNode> nodeStack = new Stack<GraphNode>();
        public HashSet<GraphNode> visitedList = new HashSet<GraphNode>();
        public IDFS()
        {
            Calculate();
        }

        public void Calculate()
        {
            var startNode = (new CreateNodeConsole()).GetNode();
            visitedList.Add(startNode);
            nodeStack.Push(startNode);

            while (nodeStack.Count > 0)
            {
                var item = nodeStack.Pop();
                if (compareArrays(correctMatrix, item.NumbersArray))
                {
                    Console.WriteLine("Found");
                    PrintPath(item);
                    Console.ReadLine();

                }
                if (nodeStack.Count < 24) Move(item);
                Console.WriteLine(nodeStack.Count);
            }

            Console.WriteLine("No solution");
            Console.ReadLine();
        }

        public void Move(GraphNode node)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((node.NumbersArray[i, j] == 0))
                    {

                        if (i < 2) { if (MoveRight(node, i, j)) return; };
                        if (j > 0) { if (MoveUp(node, i, j)) return; };
                        if (i > 0) { if (MoveLeft(node, i, j)) return; };
                        if (j < 2) { if (MoveDown(node, i, j)) return; };
                        return;
                    }
                }
            }
            return;
        }

        public override bool addNewNodeToGraph(int[,] tempMatrix, GraphNode node)
        {
            var temp = visitedList.FirstOrDefault(x => compareArrays(x.NumbersArray, tempMatrix));
            if ((temp == null))
            {

                GraphNode newItem = new GraphNode(tempMatrix, node);
                visitedList.Add(newItem);
                nodeStack.Push(node);
                nodeStack.Push(newItem);
                return true;
            }
            else if ((temp.nodesCount > nodeStack.Count+2))
            {
                GraphNode newItem = new GraphNode(tempMatrix, node);
                visitedList.Add(newItem);
                nodeStack.Push(node);
                nodeStack.Push(newItem);
                visitedList.Remove(temp);
                return true;
            }
            return false;
        }
    }
}
