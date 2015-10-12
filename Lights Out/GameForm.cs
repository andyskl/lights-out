using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lights_Out
{
    public partial class GameForm : Form
    {
        Graphics graphics;
        BufferedGraphicsContext bufferedGraphicsContext;
        BufferedGraphics bufferedGraphics;
        //
        int tileWidth;
        int tileHeight;
        //
        int yOffset = 40;
        //
        bool drawHint = false;

        public GameForm()
        {
            InitializeComponent();
            InitializeGraphics();
            Field.Init();
            tileWidth = Constants.FieldWidth / Constants.TileCount - Constants.BorderSize * 2;
            tileHeight = Constants.FieldHeight / Constants.TileCount - Constants.BorderSize * 2;
            timer.Start();
        }

        private void InitializeGraphics()
        {
            this.DoubleBuffered = true;
            graphics = this.CreateGraphics();
            bufferedGraphicsContext = new BufferedGraphicsContext();
            bufferedGraphics = bufferedGraphicsContext.Allocate(
                graphics, 
                new Rectangle(0, 
                    yOffset, 
                    Constants.FieldWidth + Constants.BorderSize, 
                    Constants.FieldHeight + Constants.BorderSize));
        }

        private void Draw()
        {
            lock (bufferedGraphics)
            {
                bufferedGraphics.Graphics.Clear(BackColor);
                if (!Field.Solved && drawHint)
                    DrawTip(Field.RecommendedRow, Field.RecommendedColumn);
                Brush brushA;
                Brush brushB;
                for (int i = 0; i < Constants.TileCount; i++)
                {
                    for (int j = 0; j < Constants.TileCount; j++)
                    {
                        if (Field.Data[i, j].Value)
                        {
                            brushA = Brushes.DeepSkyBlue;
                            brushB = Brushes.IndianRed;
                        }
                        else
                        {
                            brushB = Brushes.DeepSkyBlue;
                            brushA = Brushes.IndianRed;
                        }
                        if (Field.Disabled)
                        {
                            if (Field.Mask[i, j])
                            {
                                DrawSplit(i, j, Field.Rotation, Field.Step, brushA, brushB);
                            }
                            else
                            {
                                DrawTile(i, j, brushB);
                            }
                        }
                        else
                        {
                            DrawTile(i, j, brushB);
                        }
                    }
                }
            }
            try
            {
                bufferedGraphics.Render();
            }
            catch { }

        }

        private void DrawTile(int i, int j, Brush brush)
        {
            int x = tileWidth * j + Constants.BorderSize * (j + 1);
            int y = tileHeight * i + Constants.BorderSize * (i + 1) + yOffset;
            bufferedGraphics.Graphics.FillRectangle(brush, x, y, tileWidth, tileHeight);
        }

        private void DrawSplit(int i, int j, int r, int step, Brush brushA, Brush brushB)
        {
            int delta = step * tileWidth / Constants.AnimationSteps;
            int delta_2 = delta / 2;
            int x2 = tileWidth * j + Constants.BorderSize * (j + 1);
            int y2 = tileHeight * i + Constants.BorderSize * (i + 1) + yOffset;
            int x1 = x2 + delta_2;
            int y1 = y2 + delta_2;
            int width1 = tileWidth - delta;
            int height1 = tileHeight - delta;
            int width2 = tileWidth;
            int height2 = tileHeight;
            bufferedGraphics.Graphics.FillRectangle(brushB, x2, y2, width2, height2);
            bufferedGraphics.Graphics.FillRectangle(brushA, x1, y1, width1, height1);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Field.Update();
            minMoves.Text = (Field.MinimumMoves + 1).ToString(); ;
            totalMoves.Text = Field.TotalMoves.ToString();
            if (Field.Solved)
            {
                timer.Stop();
                MessageBox.Show("Уровень пройден.");
                Field.Init();
                timer.Start();
            }
            Draw();
        }

        private void GameForm_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y - yOffset;
            if (!Field.Disabled)
            {
                if (mouseX >= 0 &&
                    mouseX < Constants.FieldWidth &&
                    mouseY >= 0 &&
                    mouseY < Constants.FieldHeight)
                {
                    int j = mouseX / (tileWidth + Constants.BorderSize * 2);
                    int i = mouseY / (tileHeight + Constants.BorderSize * 2);
                    if (i == Field.RecommendedRow && j == Field.RecommendedColumn)
                    {
                        drawHint = false;
                    }
                    Field.Click(i, j);
                    Field.FindSolution();
                }
            }
        }

        private void DrawTip(int i, int j)
        {
            int x = tileWidth * j + Constants.BorderSize * (j + 1);
            int y = tileHeight * i + Constants.BorderSize * (i + 1) + yOffset;
            int offset = 8;
            Brush brush = Brushes.DarkOrange;
            bufferedGraphics.Graphics.FillRectangle(
                brush,
                x - offset / 2,
                y - offset / 2,
                tileWidth + offset,
                tileHeight + offset);
        }

        private void tipButton_Click(object sender, EventArgs e)
        {
            drawHint = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Field.Init();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Field.Clear();
        }
    }
}
