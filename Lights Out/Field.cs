using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lights_Out
{
    class Field
    {
        static Cell[,] data;
        static bool[,] updateMask;

        static int[,] solutionMatrix;

        private static int[,] A5Matrix = new int[5, 5]
        {
            {0,0,0,1,1},
            {0,0,1,0,0},
            {0,1,1,0,1},
            {1,0,1,0,1},
            {1,1,0,0,0}
        };

        private static int[,] B5Matrix = new int[5, 5]
        {
            {0,1,0,0,1},
            {1,1,1,1,1},
            {0,0,1,1,1},
            {1,0,1,0,1},
            {1,0,0,1,0}
        };

        private static int[,] C5Matrix = new int[5, 5]
        {
            {0,0,0,1,0},
            {0,0,1,1,1},
            {0,1,0,0,0},
            {1,1,0,1,1},
            {0,1,0,0,0}
        };

        static Random r;

        static bool disabled;

        static int step;
        static int rotation;

        static int recCol = 0;
        static int recRow = 0;

        static bool solved;

        static int minSteps;

        static int totalSteps;

        public static void Init()
        {
            Clear();
            Randomize();
        }

        public static bool Disabled { get { return disabled; } }
        public static int Rotation { get { return rotation; } }
        public static int Step { get { return step; } }

        public static Cell[,] Data
        {
            get
            {
                return data.Clone() as Cell[,];
            }
        }

        public static bool Solved
        {
            get
            {
                return solved;
            }
        }

        public static Cell[,] DataCopy
        {
            get
            {
                Cell[,] output = new Cell[Constants.TileCount, Constants.TileCount];
                for (int i = 0; i < Constants.TileCount; i++)
                {
                    for (int j = 0; j < Constants.TileCount; j++)
                    {
                        output[i, j] = new Cell(data[i, j].Value);
                    }
                }
                return output;
            }
        }
        public static bool[,] Mask { get { return updateMask.Clone() as bool[,]; } }

        static bool RandomBool
        {
            get
            {
                return r.Next(0, 2) == 0;
            }
        }

        public static void FindSolution()
        {
            Cell[,] tmpField = DataCopy;
            solutionMatrix = Constants.EmptyMatrix;
            for (int i = 1; i < Constants.TileCount; i++)
            {
                for (int j = 0; j < Constants.TileCount; j++)
                {
                    if (tmpField[i - 1, j].Value)
                        solutionMatrix[i, j]++;
                }
                for (int j = 0; j < Constants.TileCount; j++)
                {
                    if (tmpField[i - 1, j].Value)
                        Click(tmpField, i, j, false);
                }
            }
            if (tmpField[4, 0].Value)
            {
                for (int i = 0; i < Constants.TileCount; i++)
                {
                    for (int j = 0; j < Constants.TileCount; j++)
                    {
                        solutionMatrix[i, j] += A5Matrix[i, j];
                    }
                }
            }
            if (tmpField[4, 1].Value)
            {
                for (int i = 0; i < Constants.TileCount; i++)
                {
                    for (int j = 0; j < Constants.TileCount; j++)
                    {
                        solutionMatrix[i, j] += B5Matrix[i, j];
                    }
                }
            }
            if (tmpField[4, 2].Value)
            {
                for (int i = 0; i < Constants.TileCount; i++)
                {
                    for (int j = 0; j < Constants.TileCount; j++)
                    {
                        solutionMatrix[i, j] += C5Matrix[i, j];
                    }
                }
            }
            for (int i = 0; i < Constants.TileCount; i++)
            {
                for (int j = 0; j < Constants.TileCount; j++)
                {
                    solutionMatrix[i, j] = solutionMatrix[i, j] % 2;
                }
            }
            if (minSteps == -1)
            {
                for (int i = 0; i < Constants.TileCount; i++)
                {
                    for (int j = 0; j < Constants.TileCount; j++)
                    {
                        minSteps += solutionMatrix[i, j];
                    }
                }
            }
            List<int> ri = new List<int>();
            List<int> rj = new List<int>();
            for (int i = 0; i < Constants.TileCount; i++)
            {
                for (int j = 0; j < Constants.TileCount; j++)
                {
                    if (solutionMatrix[i, j] == 1)
                    {
                        ri.Add(i);
                        rj.Add(j);
                    }
                }
            }
            if (ri.Count == 0) return;
            int index = r.Next(0, ri.Count);
            recRow = ri[index];
            recCol = rj[index];
        }

        public static int RecommendedColumn
        {
            get
            {
                return recCol;
            }
        }

        public static int RecommendedRow
        {
            get
            {
                return recRow;
            }
        }

        public static int TotalMoves
        {
            get
            {
                return totalSteps;
            }
        }

        public static int MinimumMoves
        {
            get
            {
                return minSteps;
            }
        }

        public static void Randomize()
        {
            
            for (int i = 0; i < Constants.TileCount; i ++)
            {
                for (int j = 0; j < Constants.TileCount; j++)
                {
                    int seed = r.Next(1, 6);
                    if (r.Next(0, seed) == 0) Click(data, i, j, false);
                }
            }
            FindSolution();
        }        

        public static void Update()
        {
            if (disabled)
            {
                if (step == Constants.AnimationSteps)
                {
                    disabled = false;
                    step = 0;
                    updateMask = Constants.EmptyMask;
                }
                else
                {
                    step++;
                }
            }
        }

        private static void Click(Cell[,] data, int i, int j, bool updateAnimation)
        {
            if (updateAnimation)
            {
                disabled = true;
                rotation = r.Next(0, 4);
                step = 0;
            }
            data[i, j].Turn();
            if (updateAnimation)
                updateMask[i, j] = true;
            if (i < Constants.TileCount - 1)
            {
                data[i + 1, j].Turn();
                if (updateAnimation)
                    updateMask[i + 1, j] = updateAnimation;
            }
            if (i > 0)
            {
                data[i - 1, j].Turn();
                if (updateAnimation)
                    updateMask[i - 1, j] = updateAnimation;
            }
            if (j < Constants.TileCount - 1)
            {
                data[i, j + 1].Turn();
                if (updateAnimation)
                    updateMask[i, j + 1] = updateAnimation;
            }
            if (j > 0)
            {
                data[i, j - 1].Turn();
                if (updateAnimation)
                    updateMask[i, j - 1] = updateAnimation;
            }
            if (updateAnimation)
                totalSteps++;
            CheckSolve();
        }

        static void CheckSolve()
        {
            for (int i = 0; i < Constants.TileCount; i++)
            {
                for (int j = 0; j < Constants.TileCount; j++)
                {
                    if (data[i, j].Value) return;
                }
            }
            solved = true;
        }

        public static void Clear()
        {
            minSteps = -1;
            totalSteps = 0;
            solved = false;
            data = Constants.EmptyField;
            updateMask = Constants.EmptyMask;
            solutionMatrix = Constants.EmptyMatrix;
            r = new Random();
        }

        public static void Click(int i, int j)
        {
            Click(data, i, j, true);
        }
    }
}
