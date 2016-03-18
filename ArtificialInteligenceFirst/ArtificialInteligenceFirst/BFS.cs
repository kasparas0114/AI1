using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class BFS : SearchAlgorithms
    {


        public Queue<GraphNode> queue = new Queue<GraphNode>(); public BFS()
        {
            Calculate();
        }

        public void Calculate()
        {
            bool k = true;
            var startNode = (new CreateNodeConsole()).GetNode();
            visitedList.Add(startNode.NumbersArray);
            queue.Enqueue(startNode);
            int counter = 0;
            while (queue.Count >0)
            {
                var item = queue.Dequeue();
                if (compareArrays(correctMatrix, item.NumbersArray))
                {
                    Console.WriteLine("Found");
                    k = false;
                    PrintPath(item);

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


            // if (!(node.NumbersArray.Equals(tempMatrix))&&(visitedList.FirstOrDefault(x=>x.Equals(tempMatrix))==null))
            //&&)
            if (!(visitedList.Any(x => compareArrays(x, tempMatrix))))
            {
                GraphNode newItem = new GraphNode(tempMatrix,node);
                visitedList.Add(tempMatrix);
                queue.Enqueue(newItem);
                return true;
            }
            return false;
        }
        private int calculateDepth(GraphNode node)
        {
            
                int counter = 1;
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
                    if ((node.NumbersArray[i, j] == 0)&&((calculateDepth(node)<26)))
                    {
                        if (i < 2) MoveRight(node, i, j);
                        if (i > 0) MoveLeft(node, i, j);
                        if (j < 2) MoveDown(node, i, j);
                        if (j > 0) MoveUp(node, i, j);
                        return;
                    }
                }
            }
        }
    }
}
