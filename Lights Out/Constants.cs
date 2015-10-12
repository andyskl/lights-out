using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lights_Out
{
    class Constants
    {
        private static int fieldWidth = 500;
        private static int fieldHeight = 500;
        private static int tileCount = 5;
        private static int borderSize = 4;
        private static Cell[,] emptyField = new Cell[tileCount, tileCount];
        private static bool[,] emptyMask = new bool[tileCount, tileCount];
        private static int[,] emptyMatrix = new int[tileCount, tileCount];
        private static int animationSteps = 10; 
        public static int FieldWidth { get { return fieldWidth; } }
        public static int FieldHeight { get { return fieldHeight; } }
        public static int TileCount { get { return tileCount; } }
        public static int BorderSize { get { return borderSize; } }
        public static Cell[,] EmptyField
        {
            get
            {

                for (int i = 0; i < tileCount; i++)
                {
                    for (int j = 0; j < tileCount; j++)
                    {
                        emptyField[i, j] = new Cell();
                    }
                }
                return emptyField.Clone() as Cell[,];
            }
        }
        public static bool[,] EmptyMask { get { return emptyMask.Clone() as bool[,]; } }
        public static int[,] EmptyMatrix { get { return emptyMatrix.Clone() as int[,]; } }
        public static int AnimationSteps { get { return animationSteps; } }
    }
}
