using Console_RPG.Models.Drawers.Interfaces;
using System;
using System.Collections.Generic;

namespace Console_RPG.Models.Drawers
{
    public class FieldDrawer : IField
    {
        public string Field => throw new System.NotImplementedException();

        public void GenerateField()
        {
            char[,] matrix = new char[2, 2];

            int playerRow = 0;

            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] colsData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colsData[col];

                    if (matrix[row, col] == 'M')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

        }

        private string RandomFields()
        {
            Dictionary<int, string[,]> randomFields = new Dictionary<int, string[,]>();

            return "TODO, NOT COMPLETE";
        }
    }
}
