using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class CreateNodeConsole
    {

        public GraphNode GetNode()
        {
            int[,] matrix = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string input = Console.ReadLine();
                    int number = Int32.Parse(input);
                    matrix[i, j] = number;
                }
            }

            return new GraphNode(matrix);
        }
    }
}