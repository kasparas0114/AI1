using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class GraphNode
    {
        public int[,] NumbersArray;
        public List<GraphNode> neighbours = new List<GraphNode>();
        public GraphNode backElement ;
        public int nodesCount;
        public int manhatanDistance;
        public int[,] correctMatrix = new int[3, 3] { {1, 2, 3 }, { 8, 0, 4 },
                                        {7,6, 5} };
        public int astar;

        public GraphNode(int[,] numbersArray, GraphNode node)
        {
            this.NumbersArray = numbersArray;
            this.backElement = node;
            this.nodesCount = countNodes();
            this.manhatanDistance = calculateManhatanDistance();
            astar = manhatanDistance + nodesCount;
            
        }
        private int calculateManhatanDistance()
        {
            int answer = 0;
            for (int x1 = 0; x1 < 3; x1++)
            {
                for (int y1 = 0; y1 < 3; y1++)
                {
                    if (NumbersArray[x1, y1] != 0)
                    {
                        for (int x2 = 0; x2 < 3; x2++)
                        {
                            for (int y2 = 0; y2 < 3; y2++)
                            {
                                if (NumbersArray[x1, y1] == correctMatrix[x2, y2])
                                    answer += Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
                            }
                        }
                    }
                }
            }
            return answer;
        }
        private int countNodes()
        {
            int counter = 0;
            var node = this;
            while (node != null)
            {
                node = node.backElement;
                counter++;
            }
            Console.WriteLine(counter);
            return counter;
        }
        public int[,] GetNodeMatrix()
        {
            return NumbersArray;
        }
        

        
    }
}