using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using IterativeLayoutAlgorithm;

namespace Layout
{
    public partial class MainForm : Form
    {
        bool isExist = false;

        public static Bitmap bmp;

        public MainForm()
        {
            InitializeComponent();
        }

        private void NumberOfVerticesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            isExist = false;

            adjacencyMatrixDataGridView.Columns.Clear();

            adjacencyMatrixDataGridView.Columns.Add("Column", "R");
            adjacencyMatrixDataGridView.Columns[0].Width = 30;

            if (numberOfVerticesNumericUpDown.Value <= 0)
            {
                MessageBox.Show("Число вершин не может быть отрицательным или равным нулю.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                for (int i = 1; i <= numberOfVerticesNumericUpDown.Value; i++)
                {
                    adjacencyMatrixDataGridView.Columns.Add("Column", $"e{i}");
                    adjacencyMatrixDataGridView.Columns[i].Width = 30;
                    adjacencyMatrixDataGridView.Rows.Add();
                    adjacencyMatrixDataGridView.Rows[i - 1].Cells[0].Value = $"e{i}";
                    adjacencyMatrixDataGridView.Rows[i - 1].Cells[0].ReadOnly = true;
                }

                adjacencyMatrixDataGridView.Columns.Add("Alpha", "α");
                adjacencyMatrixDataGridView.Columns["Alpha"].Width = 30;
                adjacencyMatrixDataGridView.Columns["Alpha"].ReadOnly = true;
                adjacencyMatrixDataGridView.Columns["Alpha"].DefaultCellStyle =
                    new DataGridViewCellStyle(adjacencyMatrixDataGridView.Columns["Alpha"].DefaultCellStyle)
                    {
                        BackColor = System.Drawing.Color.AliceBlue
                    };

                for (int i = 0; i < numberOfVerticesNumericUpDown.Value; i++)
                {
                    for (int j = 1; j <= numberOfVerticesNumericUpDown.Value; j++)
                    {
                        adjacencyMatrixDataGridView.Rows[i].Cells[j].Value = 0;
                    }
                }
            }

            if (numberOfGroupsNumericUpDown.Value != 0)
            {
                NumberOfGroupsNumericUpDown_ValueChanged(sender, e);
            }

            isExist = true;
        }

        private void NumberOfGroupsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            infoAboutGroupsDataGridView.Columns.Clear();

            infoAboutGroupsDataGridView.Columns.Add("Номер группы", "Номер группы");
            infoAboutGroupsDataGridView.Columns.Add("Кол-во вершин", "Кол-во вершин");

            if (numberOfGroupsNumericUpDown.Value > numberOfVerticesNumericUpDown.Value ||
                numberOfGroupsNumericUpDown.Value == 0)
            {
                MessageBox.Show("");
                return;
            }

            int wholePart = (int)(numberOfVerticesNumericUpDown.Value / numberOfGroupsNumericUpDown.Value);
            int residualPart = (int)(numberOfVerticesNumericUpDown.Value - wholePart * numberOfGroupsNumericUpDown.Value);

            int[] group = new int[(int)numberOfGroupsNumericUpDown.Value];

            for (int i = 0; i < group.Length; i++)
            {
                group[i] = wholePart;
            }

            for (int i = 0; i < residualPart; i++)
            {
                group[i]++;
            }

            for (int i = 0; i < group.Length; i++)
            {
                infoAboutGroupsDataGridView.Rows.Add();
                infoAboutGroupsDataGridView.Rows[i].Cells[0].Value = $"Группа {i + 1}";
                infoAboutGroupsDataGridView.Rows[i].Cells[1].Value = group[i];
            }
        }

        private void InfoAboutAlgorithmОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В данной программе используется итерационный алгоритм компановки элементов электронной схемы. " +
                "Суть данного алгоритма заключается в том, что изначально заданный граф произвольно разбивается на " +
                "определённое количество частей, которые называются блоками. Затем, по определённому перечню правил " +
                "происходит перестановка вершин с целью минимизации числа разнотипных узлов или, другими словами, " +
                "уменьшению числа связей между рёбрами, что приводит к исключению лишних связей и улучшению функционирования " +
                "продукта.", "Информация об алгоритме", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InfoAboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа выполняет компановку графа итерационным алгоритмом.\n" +
                "Программу разработал:\n" +
                "Студент группы 846\n" +
                "Ефимов Дмитрий Михайлович.", "Информация о программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader(Path.Combine("..", "..", "Input", "Test.txt"));
            var list = new List<string>();

            try
            {
                while (streamReader.Peek() != -1)
                {
                    list.Add(streamReader.ReadLine());
                }
            }
            finally
            {
                streamReader.Dispose();
            }

            numberOfVerticesNumericUpDown.Value = list[0][0] - '0';
            numberOfGroupsNumericUpDown.Value = list[0][2] - '0';

            for (int i = 2; i < list.Count; i++)
            {
                int j = 1;
                foreach (var element in list[i].Split(','))
                {
                    adjacencyMatrixDataGridView.Rows[i - 2].Cells[j].Value = int.Parse(element);
                    j++;
                }
            }
        }

        public static int[,] ConvertMatrix(DataGridViewRowCollection rows)
        {
            int[,] newMatrix = new int[rows.Count, rows.Count];

            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 1; j < rows[i].Cells.Count - 1; j++)
                {
                    newMatrix[i, j - 1] = int.Parse(rows[i].Cells[j].Value.ToString());
                }
            }

            return newMatrix;
        }

        public static int[] ConvertToGroup(DataGridViewRowCollection rows)
        {
            int[] newMatrix = new int[rows.Count];

            for (int i = 0; i < rows.Count; i++)
            {
                newMatrix[i] = (int)rows[i].Cells[1].Value;
            }

            return newMatrix;
        }

        private void AdjacencyMatrixDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != adjacencyMatrixDataGridView.Columns.Count - 1)
            {
                if (e.ColumnIndex != 0 && (!int.TryParse(adjacencyMatrixDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),
                    out var o) || o < 0 || e.ColumnIndex - 1 == e.RowIndex))
                {
                    adjacencyMatrixDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }

                if (e.ColumnIndex < adjacencyMatrixDataGridView.Columns.Count - 1 && e.ColumnIndex != 0)
                {
                    adjacencyMatrixDataGridView.Rows[e.ColumnIndex - 1].Cells[e.RowIndex + 1].Value =
                    adjacencyMatrixDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }


                if (isExist == true && infoAboutGroupsDataGridView.Rows.Count != 0)
                {
                    IterativeLayout.FormSubmatrices(ConvertMatrix(adjacencyMatrixDataGridView.Rows),
                    out var firstGraphPart, out var secondGraphPart, ConvertToGroup(infoAboutGroupsDataGridView.Rows)[0]);

                    var arrayOfVertexConnectivityCoefficients = IterativeLayout.CalculateVertexConnectivityCoefficient(
                        ConvertMatrix(adjacencyMatrixDataGridView.Rows), firstGraphPart, secondGraphPart);

                    int indexI = adjacencyMatrixDataGridView.Columns["Alpha"].Index;

                    for (int i = 0; i <= numberOfVerticesNumericUpDown.Value - 1; i++)
                    {
                        adjacencyMatrixDataGridView.Rows[i].Cells[indexI].Value = arrayOfVertexConnectivityCoefficients[i];
                    }
                }
            }
        }

        private void BuildOriginalGraphButton_Click(object sender, EventArgs e)
        {
            OriginalGraph originalGraph = new OriginalGraph(ConvertMatrix(adjacencyMatrixDataGridView.Rows),
                ConvertToGroup(infoAboutGroupsDataGridView.Rows));
            originalGraph.ShowDialog();
        }

        private void BuildComposedGraphButton_Click(object sender, EventArgs e)
        {
            LayoutGraph layoutGraph = new LayoutGraph(ConvertMatrix(adjacencyMatrixDataGridView.Rows),
                ConvertToGroup(infoAboutGroupsDataGridView.Rows));

            layoutGraph.ShowDialog();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                bmp.Save(Path.Combine("..", "..", "Output", "Test.png"));
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G)
            {
                var rnd = new Random();

                for (int i = 0; i < adjacencyMatrixDataGridView.Rows.Count; i++)
                {
                    for (int j = 1; j < adjacencyMatrixDataGridView.Columns.Count - 1; j++)
                    {
                        adjacencyMatrixDataGridView.Rows[i].Cells[j].Value = rnd.Next(0, 20);
                    }
                }
            }
        }
    }
}
