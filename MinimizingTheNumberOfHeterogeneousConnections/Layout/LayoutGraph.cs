using IterativeLayoutAlgorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layout
{
    public partial class LayoutGraph : Form
    {
        Point[] listPoint;
        List<(int eX, int eY, bool right)> graphLink
                = new List<(int eX, int eY, bool right)>();

        List<int> orderVertices = new List<int>();

        public LayoutGraph(int[,] matrix, int[] groups)
        {
            InitializeComponent();

            MainForm.bmp = new Bitmap(graphPictureBox.Width, graphPictureBox.Height);

            var resultGroups = IterativeLayout.StartLayout(matrix, groups);
            var resultMatrix = IterativeLayout.IterativeLayoutGraph(matrix, resultGroups);

            for (int i = 0; i < resultGroups.GetLength(0); i++)
            {
                for (int j = 0; j < resultGroups[i].Length; j++)
                {
                    orderVertices.Add(resultGroups[i][j]);
                }
            }

            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    if (resultMatrix[i, j] != 0 && !graphLink.Exists(u => (u.eX == j && u.eY == i)))
                    {
                        if (groups[0] > i)
                        {
                            graphLink.Add((i, j, false));
                        }
                        else if (i < groups[groups.Length - 1])
                        {
                            Random rnd = new Random();

                            if (rnd.NextDouble() < 0.5)
                                graphLink.Add((i, j, false));
                            else
                                graphLink.Add((i, j, true));
                        }
                        else
                        {
                            graphLink.Add((i, j, true));
                        }
                    }
                }
            }

            int count = 0;
            int widthGroup = graphPictureBox.Width / groups.Length;

            listPoint = new Point[resultMatrix.GetLength(0)];

            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = 0; j < groups[i]; j++)
                {
                    listPoint[count] = new Point(widthGroup / 2 - 20 + widthGroup * i,
                        (graphPictureBox.Height / groups[i]) / 2 + (graphPictureBox.Height / groups[i]) * j
                        - 25);

                    count++;
                }
            }
        }

        private void LayoutGraph_Click(object sender, EventArgs e)
        {
            Refresh();

            using (Graphics graph = Graphics.FromImage(MainForm.bmp))
            {
                using (Pen myPen = new Pen(Color.AliceBlue, 3))
                {
                    graph.Clear(Color.LightSlateGray);

                    int i = 0;
                    graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    var myFont = new Font("Arial", 20, FontStyle.Bold);
                    var myBrush = new SolidBrush(Color.White);

                    foreach (var item in listPoint)
                    {
                        graph.DrawEllipse(myPen, item.X, item.Y, 50, 50);
                        graph.DrawString($"e{orderVertices[i] + 1}", myFont, myBrush, new Point(item.X + 7, item.Y + 10));

                        i++;
                    }

                    i = 0;

                    foreach (var item in graphLink)
                    {
                        var verticesA = listPoint[item.eX];
                        var verticesB = listPoint[item.eY];

                        if (listPoint[item.eX].X == listPoint[item.eY].X && Math.Abs(listPoint[item.eX].Y - listPoint[item.eY].Y) > 150)
                        {
                            verticesA.X += 25;
                            verticesB.X += 25;
                            verticesA.Y += 50;
                            DrawBezier(graph, myPen, verticesA, verticesB, item.right);
                        }
                        else
                        {
                            if (verticesA.X == verticesB.X)
                            {
                                verticesA.X += 25;
                                verticesB.X += 25;
                                verticesA.Y += 50;
                            }
                            else
                            {
                                i++;

                                verticesA.X += 50;
                                verticesA.Y += 25;
                                verticesB.Y += 25;
                            }

                            graph.DrawLine(myPen, verticesA, verticesB);
                        }
                    }

                    graphPictureBox.Image = MainForm.bmp;

                    myBrush.Dispose();
                    myFont.Dispose();

                    label1.Text = label1.Text + $" {i}";
                }
            }
        }

        private void LayoutGraph_Activated(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private static void DrawBezier(Graphics g, Pen pen, Point a, Point b, bool isRight)
        {
            const int bezierOffset = 50;
            Point bz1;
            Point bz2;

            if (isRight)
            {
                bz1 = new Point(a.X + bezierOffset, a.Y);
                bz2 = new Point(b.X + bezierOffset, b.Y);
            }
            else
            {
                bz1 = new Point(a.X - bezierOffset, a.Y);
                bz2 = new Point(b.X - bezierOffset, b.Y);
            }

            g.DrawBezier(pen, a, bz1, bz2, b);
        }
    }
}
