using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class Astar : SearchAlgorithms
    {
        public HashSet<GraphNode> visitedList = new HashSet<GraphNode>();
        public Queue<GraphNode> queue = new Queue<GraphNode>();
        public List<GraphNode> possibleMoves = new List<GraphNode>();
        public Astar()
        {
            Calculate();
        }

        public void Calculate()
        {
            bool k = true;
            var startNode = (new CreateNodeConsole()).GetNode();
            visitedList.Add(startNode);
            queue.Enqueue(startNode);
            int counter = 0;
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                if (compareArrays(correctMatrix, item.NumbersArray))
                {
                    Console.WriteLine("Found");
                    PrintPath(item);
                    Console.ReadLine();

                }
                counter++;
                Move(item);
                // printNode(item);
                //Console.WriteLine(counter);
            }
           
            Console.WriteLine("No solution");
            Console.ReadLine();
            Console.ReadLine();
        }

        public override bool addNewNodeToGraph(int[,] tempMatrix, GraphNode node)
        {
            if(!visitedList.Any(x=> compareArrays(x.NumbersArray, tempMatrix))) { 
            possibleMoves.Add(new GraphNode(tempMatrix,node));
            return true;
            }
            return false;
        }
        private void ActualMove()
        {
            var temp = possibleMoves.FirstOrDefault(x=>x.astar == (possibleMoves.Min(y => y.astar)));
            visitedList.Add(temp);
            queue.Enqueue(temp);
            possibleMoves.Remove(temp);
            
        }

        private int calculateDepth(GraphNode node)
        {

            int counter = 0;
            while (node != null)
            {
                node = node.backElement;
                counter++;
            }
            Console.WriteLine(counter);
            return counter;
        }
           
        public void Move(GraphNode node)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((node.NumbersArray[i, j] == 0))
                    {
                        if (i < 2) MoveRight(node, i, j);
                        if (i > 0) MoveLeft(node, i, j);
                        if (j < 2) MoveDown(node, i, j);
                        if (j > 0) MoveUp(node, i, j);
                        ActualMove();
                        return;
                    }
                }
            }
        }
    }
}
