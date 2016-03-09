﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class Graph
    {
        GraphNode nodea;
        public GraphNode ElementA;
        private List<GraphNode> nodeList;

        public void addNode(GraphNode node)
        {
            nodeList.Add(node);
        }
        public void addNode(int[,] node)
        {
            nodeList.Add(new GraphNode(node));
        }
        public void addVertex(GraphNode from, GraphNode to)
        {
            from.neighbours.Add(to);
        }
    }
}