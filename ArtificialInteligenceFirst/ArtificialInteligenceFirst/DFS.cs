using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class DFS:SearchAlgorithms
    {

        public Stack<GraphNode> nodeStack = new Stack<GraphNode>();
        public DFS()
        {
            Calculate();
        }

        public void Calculate()
        {
            bool k = true;
            var startNode = (new CreateNodeConsole()).GetNode();
            visitedList.Add(startMatrix);
            nodeStack.Push(startNode);
            int counter = 0;
          
            while (nodeStack.Count>0)
            {    
                var item = nodeStack.Pop();
                if (compareArrays(correctMatrix,item.NumbersArray))
                {
                    Console.WriteLine("Found");
                    PrintPath(item);
                    
                }           
                Move(item);
                counter = nodeStack.Count;
                Console.WriteLine(counter); 
            }
            Console.WriteLine("No solution");
            Console.ReadLine();
        }
       
        public bool Move(GraphNode node)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((node.NumbersArray[i, j] == 0) && (nodeStack.Count < 25))
                    {
                        if (i < 2) { if(MoveRight(node, i, j)) return true; };
                        if (i > 0) { if(MoveLeft(node, i, j)) return true; };
                        if (j < 2) { if(MoveDown(node, i, j)) return true; };
                        if (j > 0) { if(MoveUp(node, i, j)) return true; };
                        return false;
                    }
                }
            }
            return false;
        }

        public override bool addNewNodeToGraph(int[,] tempMatrix, GraphNode node)
        {
            
            if (!(visitedList.Any(x => compareArrays(x, tempMatrix))))
            {
                nodeStack.Push(node);
                GraphNode newItem = new GraphNode(tempMatrix,node);
                visitedList.Add(tempMatrix);
                nodeStack.Push(newItem);
                return true;
            }
            return false;
        }
    }
}
