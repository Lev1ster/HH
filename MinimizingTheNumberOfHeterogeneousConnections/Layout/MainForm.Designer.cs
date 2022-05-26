
namespace Layout
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoAboutAlgorithmОToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoAboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numberOfGroupsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numberOfVerticesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.adjacencyMatrixDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.infoAboutGroupsDataGridView = new System.Windows.Forms.DataGridView();
            this.buildOriginalGraphButton = new System.Windows.Forms.Button();
            this.buildComposedGraphButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfGroupsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfVerticesNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adjacencyMatrixDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoAboutGroupsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ReferenceToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.toolStripMenuItem2});
            this.FileToolStripMenuItem.Image = global::Layout.Properties.Resources.folder;
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // CreateToolStripMenuItem
            // 
            this.CreateToolStripMenuItem.Image = global::Layout.Properties.Resources.document;
            this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            this.CreateToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.CreateToolStripMenuItem.Text = "Создать";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(130, 6);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Image = global::Layout.Properties.Resources.open;
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.OpenToolStripMenuItem.Text = "Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Image = global::Layout.Properties.Resources.diskette;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(130, 6);
            // 
            // ReferenceToolStripMenuItem
            // 
            this.ReferenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoAboutAlgorithmОToolStripMenuItem,
            this.InfoAboutProgramToolStripMenuItem});
            this.ReferenceToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ReferenceToolStripMenuItem.Image = global::Layout.Properties.Resources.spravka;
            this.ReferenceToolStripMenuItem.Name = "ReferenceToolStripMenuItem";
            this.ReferenceToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.ReferenceToolStripMenuItem.Text = "Справка";
            // 
            // InfoAboutAlgorithmОToolStripMenuItem
            // 
            this.InfoAboutAlgorithmОToolStripMenuItem.Image = global::Layout.Properties.Resources.aboutprogram;
            this.InfoAboutAlgorithmОToolStripMenuItem.Name = "InfoAboutAlgorithmОToolStripMenuItem";
            this.InfoAboutAlgorithmОToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.InfoAboutAlgorithmОToolStripMenuItem.Text = "Инф. об алгоритме";
            this.InfoAboutAlgorithmОToolStripMenuItem.Click += new System.EventHandler(this.InfoAboutAlgorithmОToolStripMenuItem_Click);
            // 
            // InfoAboutProgramToolStripMenuItem
            // 
            this.InfoAboutProgramToolStripMenuItem.Image = global::Layout.Properties.Resources.info;
            this.InfoAboutProgramToolStripMenuItem.Name = "InfoAboutProgramToolStripMenuItem";
            this.InfoAboutProgramToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.InfoAboutProgramToolStripMenuItem.Text = "О программе";
            this.InfoAboutProgramToolStripMenuItem.Click += new System.EventHandler(this.InfoAboutProgramToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Image = global::Layout.Properties.Resources.logout;
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.numberOfGroupsNumericUpDown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numberOfVerticesNumericUpDown);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 107);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ввод данных";
            // 
            // numberOfGroupsNumericUpDown
            // 
            this.numberOfGroupsNumericUpDown.Location = new System.Drawing.Point(6, 79);
            this.numberOfGroupsNumericUpDown.Name = "numberOfGroupsNumericUpDown";
            this.numberOfGroupsNumericUpDown.Size = new System.Drawing.Size(162, 22);
            this.numberOfGroupsNumericUpDown.TabIndex = 3;
            this.numberOfGroupsNumericUpDown.ValueChanged += new System.EventHandler(this.NumberOfGroupsNumericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество групп:";
            // 
            // numberOfVerticesNumericUpDown
            // 
            this.numberOfVerticesNumericUpDown.Location = new System.Drawing.Point(6, 36);
            this.numberOfVerticesNumericUpDown.Name = "numberOfVerticesNumericUpDown";
            this.numberOfVerticesNumericUpDown.Size = new System.Drawing.Size(162, 22);
            this.numberOfVerticesNumericUpDown.TabIndex = 1;
            this.numberOfVerticesNumericUpDown.ValueChanged += new System.EventHandler(this.NumberOfVerticesNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество вершин:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.adjacencyMatrixDataGridView);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(192, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 414);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Матрица смежности (R)";
            // 
            // adjacencyMatrixDataGridView
            // 
            this.adjacencyMatrixDataGridView.AllowUserToAddRows = false;
            this.adjacencyMatrixDataGridView.AllowUserToDeleteRows = false;
            this.adjacencyMatrixDataGridView.AllowUserToResizeColumns = false;
            this.adjacencyMatrixDataGridView.AllowUserToResizeRows = false;
            this.adjacencyMatrixDataGridView.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.adjacencyMatrixDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adjacencyMatrixDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adjacencyMatrixDataGridView.Location = new System.Drawing.Point(3, 18);
            this.adjacencyMatrixDataGridView.Name = "adjacencyMatrixDataGridView";
            this.adjacencyMatrixDataGridView.RowHeadersVisible = false;
            this.adjacencyMatrixDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.adjacencyMatrixDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adjacencyMatrixDataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.adjacencyMatrixDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.adjacencyMatrixDataGridView.Size = new System.Drawing.Size(474, 393);
            this.adjacencyMatrixDataGridView.TabIndex = 0;
            this.adjacencyMatrixDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.AdjacencyMatrixDataGridView_CellValueChanged);
            this.adjacencyMatrixDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.infoAboutGroupsDataGridView);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 301);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Разбиение на группы";
            // 
            // infoAboutGroupsDataGridView
            // 
            this.infoAboutGroupsDataGridView.AllowUserToAddRows = false;
            this.infoAboutGroupsDataGridView.AllowUserToDeleteRows = false;
            this.infoAboutGroupsDataGridView.AllowUserToResizeColumns = false;
            this.infoAboutGroupsDataGridView.AllowUserToResizeRows = false;
            this.infoAboutGroupsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.infoAboutGroupsDataGridView.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.infoAboutGroupsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.infoAboutGroupsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoAboutGroupsDataGridView.Location = new System.Drawing.Point(3, 18);
            this.infoAboutGroupsDataGridView.Name = "infoAboutGroupsDataGridView";
            this.infoAboutGroupsDataGridView.ReadOnly = true;
            this.infoAboutGroupsDataGridView.RowHeadersVisible = false;
            this.infoAboutGroupsDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoAboutGroupsDataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.infoAboutGroupsDataGridView.Size = new System.Drawing.Size(168, 280);
            this.infoAboutGroupsDataGridView.TabIndex = 0;
            // 
            // buildOriginalGraphButton
            // 
            this.buildOriginalGraphButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.buildOriginalGraphButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buildOriginalGraphButton.ForeColor = System.Drawing.Color.White;
            this.buildOriginalGraphButton.Location = new System.Drawing.Point(12, 444);
            this.buildOriginalGraphButton.Name = "buildOriginalGraphButton";
            this.buildOriginalGraphButton.Size = new System.Drawing.Size(330, 55);
            this.buildOriginalGraphButton.TabIndex = 6;
            this.buildOriginalGraphButton.Text = "Построить оригинальный граф";
            this.buildOriginalGraphButton.UseVisualStyleBackColor = false;
            this.buildOriginalGraphButton.Click += new System.EventHandler(this.BuildOriginalGraphButton_Click);
            // 
            // buildComposedGraphButton
            // 
            this.buildComposedGraphButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.buildComposedGraphButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buildComposedGraphButton.ForeColor = System.Drawing.Color.White;
            this.buildComposedGraphButton.Location = new System.Drawing.Point(348, 444);
            this.buildComposedGraphButton.Name = "buildComposedGraphButton";
            this.buildComposedGraphButton.Size = new System.Drawing.Size(324, 55);
            this.buildComposedGraphButton.TabIndex = 7;
            this.buildComposedGraphButton.Text = "Построить скомпонованный граф";
            this.buildComposedGraphButton.UseVisualStyleBackColor = false;
            this.buildComposedGraphButton.Click += new System.EventHandler(this.BuildComposedGraphButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.buildComposedGraphButton);
            this.Controls.Add(this.buildOriginalGraphButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Алгоритм компоновки";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfGroupsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfVerticesNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adjacencyMatrixDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoAboutGroupsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ReferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InfoAboutAlgorithmОToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InfoAboutProgramToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numberOfVerticesNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numberOfGroupsNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView adjacencyMatrixDataGridView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView infoAboutGroupsDataGridView;
        private System.Windows.Forms.Button buildOriginalGraphButton;
        private System.Windows.Forms.Button buildComposedGraphButton;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
    }
}

