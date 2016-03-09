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
        public List<GraphNode> neighbours;
        public GraphNode backElement;
        public GraphNode(int[,] numbersArray)
        {
            this.NumbersArray = numbersArray;
        }

        public int[,] GetNodeMatrix()
        {
            return NumbersArray;
        }
    }
}
