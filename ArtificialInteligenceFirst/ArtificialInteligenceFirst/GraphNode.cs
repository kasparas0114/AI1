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
        
        public GraphNode(int[,] numbersArray, GraphNode node)
        {
            this.NumbersArray = numbersArray;
            this.backElement = node;
            this.nodesCount = countNodes();
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