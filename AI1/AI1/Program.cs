﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI1
{
    class Program
    {
        public int[,] NumbersArray;
        public List<GraphNode> neighbours = new List<GraphNode>();
        public GraphNode backElement;
        public GraphNode(int[,] numbersArray)
        {
            this.NumbersArray = numbersArray;
        }

        public int[,] GetNodeMatrix()
        {
        }
    }
}
