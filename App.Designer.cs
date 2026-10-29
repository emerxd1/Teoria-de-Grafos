namespace Main
{
    partial class App
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            btnCrearGrafo = new Sunny.UI.UISymbolButton();
            btnReestablecer = new Sunny.UI.UISymbolButton();
            btnAnalizar = new Sunny.UI.UISymbolButton();
            uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            CheckPonderado = new Sunny.UI.UICheckBox();
            CheckNoDirigido = new Sunny.UI.UICheckBox();
            CheckDirigido = new Sunny.UI.UICheckBox();
            uiTitlePanel2 = new Sunny.UI.UITitlePanel();
            dgvVertices = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Grado = new DataGridViewTextBoxColumn();
            Conexiones = new DataGridViewTextBoxColumn();
            btnDeleteVertice = new Sunny.UI.UISymbolButton();
            btnAddVertice = new Sunny.UI.UISymbolButton();
            label3 = new Label();
            txtVertice = new Sunny.UI.UITextBox();
            uiTitlePanel3 = new Sunny.UI.UITitlePanel();
            dgvAristas = new DataGridView();
            Origen = new DataGridViewTextBoxColumn();
            Destino = new DataGridViewTextBoxColumn();
            Peso = new DataGridViewTextBoxColumn();
            label6 = new Label();
            cbDestino = new Sunny.UI.UIComboBox();
            label5 = new Label();
            cbOrigen = new Sunny.UI.UIComboBox();
            btnDeleteAristas = new Sunny.UI.UISymbolButton();
            btnAddAristas = new Sunny.UI.UISymbolButton();
            label4 = new Label();
            txtPeso = new Sunny.UI.UITextBox();
            Digrafo = new Sunny.UI.UITitlePanel();
            uiTitlePanel4 = new Sunny.UI.UITitlePanel();
            uiTitlePanel5 = new Sunny.UI.UITitlePanel();
            btnReiniciarAlg = new Sunny.UI.UISymbolButton();
            btnEjecutarAlg = new Sunny.UI.UISymbolButton();
            label9 = new Label();
            cbDestinoAlg = new Sunny.UI.UIComboBox();
            label8 = new Label();
            cbOrigenAlg = new Sunny.UI.UIComboBox();
            label7 = new Label();
            cbAlgoritmos = new Sunny.UI.UIComboBox();
            tabcontrolMatricez = new Sunny.UI.UITabControl();
            MatrizIncidencia = new TabPage();
            dgvMatrizI = new DataGridView();
            aMI = new DataGridViewTextBoxColumn();
            bMI = new DataGridViewTextBoxColumn();
            Matrizadyacencia = new TabPage();
            dgvMatrizA = new DataGridView();
            aMA = new DataGridViewTextBoxColumn();
            bMA = new DataGridViewTextBoxColumn();
            b = new DataGridViewTextBoxColumn();
            a = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            uiTitlePanel1.SuspendLayout();
            uiTitlePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVertices).BeginInit();
            uiTitlePanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAristas).BeginInit();
            uiTitlePanel5.SuspendLayout();
            tabcontrolMatricez.SuspendLayout();
            MatrizIncidencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMatrizI).BeginInit();
            Matrizadyacencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMatrizA).BeginInit();
            SuspendLayout();
            // 
            // nightControlBox1
            // 
            nightControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nightControlBox1.BackColor = Color.Transparent;
            nightControlBox1.CloseHoverColor = Color.FromArgb(199, 80, 80);
            nightControlBox1.CloseHoverForeColor = Color.White;
            nightControlBox1.DefaultLocation = true;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.EnableCloseColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMaximizeButton = true;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.Location = new Point(1422, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 40, 92);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(nightControlBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1561, 44);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(25, 40, 92);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(14, 3);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(571, 11);
            label1.Name = "label1";
            label1.Size = new Size(247, 28);
            label1.TabIndex = 1;
            label1.Text = "Matemática Discreta · UNI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(9, 55);
            label2.Name = "label2";
            label2.Size = new Size(384, 32);
            label2.TabIndex = 2;
            label2.Text = "Laboratorio de Teoría de Grafos ";
            // 
            // btnCrearGrafo
            // 
            btnCrearGrafo.FillColor = Color.FromArgb(79, 70, 229);
            btnCrearGrafo.FillDisableColor = Color.Silver;
            btnCrearGrafo.FillHoverColor = Color.FromArgb(52, 46, 152);
            btnCrearGrafo.FillPressColor = Color.Gray;
            btnCrearGrafo.FillSelectedColor = Color.FromArgb(52, 46, 152);
            btnCrearGrafo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnCrearGrafo.Location = new Point(1056, 55);
            btnCrearGrafo.Margin = new Padding(3, 4, 3, 4);
            btnCrearGrafo.MinimumSize = new Size(1, 1);
            btnCrearGrafo.Name = "btnCrearGrafo";
            btnCrearGrafo.Radius = 10;
            btnCrearGrafo.RectColor = Color.White;
            btnCrearGrafo.RectDisableColor = Color.White;
            btnCrearGrafo.RectHoverColor = Color.White;
            btnCrearGrafo.RectPressColor = Color.White;
            btnCrearGrafo.RectSelectedColor = Color.White;
            btnCrearGrafo.Size = new Size(160, 47);
            btnCrearGrafo.Symbol = 559206;
            btnCrearGrafo.TabIndex = 3;
            btnCrearGrafo.Text = "Crear grafo";
            btnCrearGrafo.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnCrearGrafo.Click += this.btnCrearGrafo_Click;
            // 
            // btnReestablecer
            // 
            btnReestablecer.FillColor = Color.FromArgb(221, 224, 238);
            btnReestablecer.FillDisableColor = Color.Silver;
            btnReestablecer.FillHoverColor = Color.FromArgb(91, 105, 145);
            btnReestablecer.FillPressColor = Color.Gray;
            btnReestablecer.FillSelectedColor = Color.FromArgb(91, 105, 145);
            btnReestablecer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnReestablecer.ForeColor = Color.FromArgb(26, 45, 98);
            btnReestablecer.Location = new Point(1223, 55);
            btnReestablecer.Margin = new Padding(3, 4, 3, 4);
            btnReestablecer.MinimumSize = new Size(1, 1);
            btnReestablecer.Name = "btnReestablecer";
            btnReestablecer.Radius = 10;
            btnReestablecer.RectColor = Color.White;
            btnReestablecer.RectDisableColor = Color.White;
            btnReestablecer.RectHoverColor = Color.White;
            btnReestablecer.RectPressColor = Color.White;
            btnReestablecer.RectSelectedColor = Color.White;
            btnReestablecer.Size = new Size(160, 47);
            btnReestablecer.Symbol = 558393;
            btnReestablecer.SymbolColor = Color.FromArgb(26, 45, 98);
            btnReestablecer.SymbolOffset = new Point(0, 3);
            btnReestablecer.SymbolSize = 26;
            btnReestablecer.TabIndex = 4;
            btnReestablecer.Text = "Restablecer";
            btnReestablecer.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnReestablecer.Click += this.btnReestablecer_Click;
            // 
            // btnAnalizar
            // 
            btnAnalizar.FillColor = Color.FromArgb(20, 184, 166);
            btnAnalizar.FillDisableColor = Color.Silver;
            btnAnalizar.FillHoverColor = Color.FromArgb(13, 122, 110);
            btnAnalizar.FillPressColor = Color.Gray;
            btnAnalizar.FillSelectedColor = Color.FromArgb(13, 122, 110);
            btnAnalizar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnAnalizar.Location = new Point(1390, 55);
            btnAnalizar.Margin = new Padding(3, 4, 3, 4);
            btnAnalizar.MinimumSize = new Size(1, 1);
            btnAnalizar.Name = "btnAnalizar";
            btnAnalizar.Radius = 10;
            btnAnalizar.RectColor = Color.White;
            btnAnalizar.RectDisableColor = Color.White;
            btnAnalizar.RectHoverColor = Color.White;
            btnAnalizar.RectPressColor = Color.White;
            btnAnalizar.RectSelectedColor = Color.White;
            btnAnalizar.Size = new Size(160, 47);
            btnAnalizar.Symbol = 61515;
            btnAnalizar.SymbolOffset = new Point(0, 2);
            btnAnalizar.SymbolSize = 20;
            btnAnalizar.TabIndex = 5;
            btnAnalizar.Text = "Analizar";
            btnAnalizar.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnAnalizar.Click += this.btnAnalizar_Click;
            // 
            // uiTitlePanel1
            // 
            uiTitlePanel1.Controls.Add(CheckPonderado);
            uiTitlePanel1.Controls.Add(CheckNoDirigido);
            uiTitlePanel1.Controls.Add(CheckDirigido);
            uiTitlePanel1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiTitlePanel1.ForeColor = Color.Gray;
            uiTitlePanel1.Location = new Point(15, 112);
            uiTitlePanel1.Margin = new Padding(5, 7, 5, 7);
            uiTitlePanel1.MinimumSize = new Size(1, 1);
            uiTitlePanel1.Name = "uiTitlePanel1";
            uiTitlePanel1.Padding = new Padding(1, 47, 1, 1);
            uiTitlePanel1.Radius = 10;
            uiTitlePanel1.RectColor = Color.FromArgb(224, 224, 224);
            uiTitlePanel1.ShowText = false;
            uiTitlePanel1.Size = new Size(417, 108);
            uiTitlePanel1.TabIndex = 7;
            uiTitlePanel1.Text = "Tipo de grafo";
            uiTitlePanel1.TextAlignment = ContentAlignment.MiddleLeft;
            uiTitlePanel1.TitleColor = Color.White;
            uiTitlePanel1.TitleForeColor = Color.FromArgb(64, 64, 64);
            // 
            // CheckPonderado
            // 
            CheckPonderado.CheckBoxColor = Color.FromArgb(79, 70, 229);
            CheckPonderado.Font = new Font("Microsoft Sans Serif", 12F);
            CheckPonderado.ForeColor = Color.FromArgb(48, 48, 48);
            CheckPonderado.Location = new Point(251, 42);
            CheckPonderado.MinimumSize = new Size(1, 1);
            CheckPonderado.Name = "CheckPonderado";
            CheckPonderado.Radius = 10;
            CheckPonderado.Size = new Size(127, 29);
            CheckPonderado.TabIndex = 10;
            CheckPonderado.Text = "Ponderado";
            // 
            // CheckNoDirigido
            // 
            CheckNoDirigido.CheckBoxColor = Color.FromArgb(79, 70, 229);
            CheckNoDirigido.Font = new Font("Microsoft Sans Serif", 12F);
            CheckNoDirigido.ForeColor = Color.FromArgb(48, 48, 48);
            CheckNoDirigido.Location = new Point(115, 42);
            CheckNoDirigido.MinimumSize = new Size(1, 1);
            CheckNoDirigido.Name = "CheckNoDirigido";
            CheckNoDirigido.Radius = 10;
            CheckNoDirigido.Size = new Size(130, 29);
            CheckNoDirigido.TabIndex = 9;
            CheckNoDirigido.Text = "No Dirigido";
            // 
            // CheckDirigido
            // 
            CheckDirigido.CheckBoxColor = Color.FromArgb(79, 70, 229);
            CheckDirigido.Font = new Font("Microsoft Sans Serif", 12F);
            CheckDirigido.ForeColor = Color.FromArgb(48, 48, 48);
            CheckDirigido.Location = new Point(4, 42);
            CheckDirigido.MinimumSize = new Size(1, 1);
            CheckDirigido.Name = "CheckDirigido";
            CheckDirigido.Radius = 10;
            CheckDirigido.Size = new Size(105, 29);
            CheckDirigido.TabIndex = 8;
            CheckDirigido.Text = "Dirigido";
            // 
            // uiTitlePanel2
            // 
            uiTitlePanel2.Controls.Add(dgvVertices);
            uiTitlePanel2.Controls.Add(btnDeleteVertice);
            uiTitlePanel2.Controls.Add(btnAddVertice);
            uiTitlePanel2.Controls.Add(label3);
            uiTitlePanel2.Controls.Add(txtVertice);
            uiTitlePanel2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiTitlePanel2.Location = new Point(15, 245);
            uiTitlePanel2.Margin = new Padding(5, 7, 5, 7);
            uiTitlePanel2.MinimumSize = new Size(1, 1);
            uiTitlePanel2.Name = "uiTitlePanel2";
            uiTitlePanel2.Padding = new Padding(1, 47, 1, 1);
            uiTitlePanel2.Radius = 10;
            uiTitlePanel2.RectColor = Color.FromArgb(224, 224, 224);
            uiTitlePanel2.ShowText = false;
            uiTitlePanel2.Size = new Size(417, 348);
            uiTitlePanel2.TabIndex = 8;
            uiTitlePanel2.Text = "Vertices";
            uiTitlePanel2.TextAlignment = ContentAlignment.MiddleLeft;
            uiTitlePanel2.TitleColor = Color.White;
            uiTitlePanel2.TitleForeColor = Color.FromArgb(64, 64, 64);
            uiTitlePanel2.Click += uiTitlePanel2_Click;
            // 
            // dgvVertices
            // 
            dgvVertices.AllowUserToAddRows = false;
            dgvVertices.AllowUserToDeleteRows = false;
            dgvVertices.AllowUserToResizeColumns = false;
            dgvVertices.AllowUserToResizeRows = false;
            dgvVertices.BackgroundColor = Color.White;
            dgvVertices.BorderStyle = BorderStyle.None;
            dgvVertices.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvVertices.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = Color.FromArgb(79, 70, 229);
            dataGridViewCellStyle17.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle17.ForeColor = Color.White;
            dataGridViewCellStyle17.SelectionBackColor = Color.FromArgb(79, 70, 229);
            dataGridViewCellStyle17.SelectionForeColor = Color.Black;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dgvVertices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dgvVertices.ColumnHeadersHeight = 29;
            dgvVertices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvVertices.Columns.AddRange(new DataGridViewColumn[] { Nombre, Grado, Conexiones });
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = Color.White;
            dataGridViewCellStyle18.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle18.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle18.SelectionBackColor = Color.FromArgb(215, 213, 249);
            dataGridViewCellStyle18.SelectionForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
            dgvVertices.DefaultCellStyle = dataGridViewCellStyle18;
            dgvVertices.EnableHeadersVisualStyles = false;
            dgvVertices.Location = new Point(18, 111);
            dgvVertices.Name = "dgvVertices";
            dgvVertices.ReadOnly = true;
            dgvVertices.RowHeadersVisible = false;
            dgvVertices.RowHeadersWidth = 51;
            dgvVertices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVertices.Size = new Size(367, 220);
            dgvVertices.TabIndex = 6;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 125;
            // 
            // Grado
            // 
            Grado.HeaderText = "Grado";
            Grado.MinimumWidth = 6;
            Grado.Name = "Grado";
            Grado.ReadOnly = true;
            Grado.Width = 125;
            // 
            // Conexiones
            // 
            Conexiones.HeaderText = "Conexiones";
            Conexiones.MinimumWidth = 6;
            Conexiones.Name = "Conexiones";
            Conexiones.ReadOnly = true;
            Conexiones.Width = 125;
            // 
            // btnDeleteVertice
            // 
            btnDeleteVertice.FillColor = Color.FromArgb(250, 233, 232);
            btnDeleteVertice.FillDisableColor = Color.Silver;
            btnDeleteVertice.FillHoverColor = Color.FromArgb(210, 112, 102);
            btnDeleteVertice.FillPressColor = Color.Gray;
            btnDeleteVertice.FillSelectedColor = Color.FromArgb(210, 112, 102);
            btnDeleteVertice.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnDeleteVertice.ForeColor = Color.FromArgb(191, 57, 43);
            btnDeleteVertice.Location = new Point(265, 68);
            btnDeleteVertice.MinimumSize = new Size(1, 1);
            btnDeleteVertice.Name = "btnDeleteVertice";
            btnDeleteVertice.Radius = 10;
            btnDeleteVertice.RectColor = Color.White;
            btnDeleteVertice.RectDisableColor = Color.White;
            btnDeleteVertice.RectHoverColor = Color.White;
            btnDeleteVertice.RectPressColor = Color.White;
            btnDeleteVertice.RectSelectedColor = Color.White;
            btnDeleteVertice.Size = new Size(120, 35);
            btnDeleteVertice.Symbol = 559506;
            btnDeleteVertice.SymbolColor = Color.FromArgb(191, 57, 43);
            btnDeleteVertice.SymbolOffset = new Point(0, 3);
            btnDeleteVertice.SymbolSize = 26;
            btnDeleteVertice.TabIndex = 5;
            btnDeleteVertice.Text = "Eliminar";
            btnDeleteVertice.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnDeleteVertice.Click += btnDeleteVertice_Click;
            // 
            // btnAddVertice
            // 
            btnAddVertice.FillColor = Color.FromArgb(79, 70, 229);
            btnAddVertice.FillDisableColor = Color.Silver;
            btnAddVertice.FillHoverColor = Color.FromArgb(52, 46, 152);
            btnAddVertice.FillPressColor = Color.Gray;
            btnAddVertice.FillSelectedColor = Color.FromArgb(52, 46, 152);
            btnAddVertice.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnAddVertice.Location = new Point(159, 68);
            btnAddVertice.MinimumSize = new Size(1, 1);
            btnAddVertice.Name = "btnAddVertice";
            btnAddVertice.Radius = 10;
            btnAddVertice.RectColor = Color.White;
            btnAddVertice.RectDisableColor = Color.White;
            btnAddVertice.RectHoverColor = Color.White;
            btnAddVertice.RectPressColor = Color.White;
            btnAddVertice.RectSelectedColor = Color.White;
            btnAddVertice.Size = new Size(108, 35);
            btnAddVertice.Symbol = 300043;
            btnAddVertice.SymbolOffset = new Point(0, 1);
            btnAddVertice.TabIndex = 4;
            btnAddVertice.Text = "Agregar";
            btnAddVertice.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnAddVertice.Click += btnAddVertice_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(18, 44);
            label3.Name = "label3";
            label3.Size = new Size(81, 25);
            label3.TabIndex = 3;
            label3.Text = "Nombre";
            // 
            // txtVertice
            // 
            txtVertice.Font = new Font("Microsoft Sans Serif", 12F);
            txtVertice.Location = new Point(18, 74);
            txtVertice.Margin = new Padding(4, 5, 4, 5);
            txtVertice.MinimumSize = new Size(1, 16);
            txtVertice.Name = "txtVertice";
            txtVertice.Padding = new Padding(5);
            txtVertice.RectColor = Color.Silver;
            txtVertice.ShowText = false;
            txtVertice.Size = new Size(132, 29);
            txtVertice.TabIndex = 0;
            txtVertice.TextAlignment = ContentAlignment.MiddleLeft;
            txtVertice.Watermark = "Ej: \"A\"";
            txtVertice.KeyDown += txtVertice_KeyDown;
            // 
            // uiTitlePanel3
            // 
            uiTitlePanel3.Controls.Add(dgvAristas);
            uiTitlePanel3.Controls.Add(label6);
            uiTitlePanel3.Controls.Add(cbDestino);
            uiTitlePanel3.Controls.Add(label5);
            uiTitlePanel3.Controls.Add(cbOrigen);
            uiTitlePanel3.Controls.Add(btnDeleteAristas);
            uiTitlePanel3.Controls.Add(btnAddAristas);
            uiTitlePanel3.Controls.Add(label4);
            uiTitlePanel3.Controls.Add(txtPeso);
            uiTitlePanel3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiTitlePanel3.Location = new Point(15, 607);
            uiTitlePanel3.Margin = new Padding(5, 7, 5, 7);
            uiTitlePanel3.MinimumSize = new Size(1, 1);
            uiTitlePanel3.Name = "uiTitlePanel3";
            uiTitlePanel3.Padding = new Padding(1, 47, 1, 1);
            uiTitlePanel3.Radius = 10;
            uiTitlePanel3.RectColor = Color.FromArgb(224, 224, 224);
            uiTitlePanel3.ShowText = false;
            uiTitlePanel3.Size = new Size(417, 399);
            uiTitlePanel3.TabIndex = 9;
            uiTitlePanel3.Text = "Aristas";
            uiTitlePanel3.TextAlignment = ContentAlignment.MiddleLeft;
            uiTitlePanel3.TitleColor = Color.White;
            uiTitlePanel3.TitleForeColor = Color.FromArgb(64, 64, 64);
            // 
            // dgvAristas
            // 
            dgvAristas.AllowUserToAddRows = false;
            dgvAristas.AllowUserToDeleteRows = false;
            dgvAristas.AllowUserToResizeColumns = false;
            dgvAristas.AllowUserToResizeRows = false;
            dgvAristas.BackgroundColor = Color.White;
            dgvAristas.BorderStyle = BorderStyle.None;
            dgvAristas.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvAristas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = Color.FromArgb(79, 70, 229);
            dataGridViewCellStyle19.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle19.ForeColor = Color.White;
            dataGridViewCellStyle19.SelectionBackColor = Color.FromArgb(79, 70, 229);
            dataGridViewCellStyle19.SelectionForeColor = Color.Black;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            dgvAristas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dgvAristas.ColumnHeadersHeight = 29;
            dgvAristas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAristas.Columns.AddRange(new DataGridViewColumn[] { Origen, Destino, Peso });
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = Color.White;
            dataGridViewCellStyle20.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle20.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle20.SelectionBackColor = Color.FromArgb(215, 213, 249);
            dataGridViewCellStyle20.SelectionForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle20.WrapMode = DataGridViewTriState.False;
            dgvAristas.DefaultCellStyle = dataGridViewCellStyle20;
            dgvAristas.EnableHeadersVisualStyles = false;
            dgvAristas.Location = new Point(18, 143);
            dgvAristas.Name = "dgvAristas";
            dgvAristas.ReadOnly = true;
            dgvAristas.RowHeadersVisible = false;
            dgvAristas.RowHeadersWidth = 51;
            dgvAristas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAristas.Size = new Size(367, 220);
            dgvAristas.TabIndex = 14;
            // 
            // Origen
            // 
            Origen.HeaderText = "Origen";
            Origen.MinimumWidth = 6;
            Origen.Name = "Origen";
            Origen.ReadOnly = true;
            Origen.Width = 125;
            // 
            // Destino
            // 
            Destino.HeaderText = "Destino";
            Destino.MinimumWidth = 6;
            Destino.Name = "Destino";
            Destino.ReadOnly = true;
            Destino.Width = 125;
            // 
            // Peso
            // 
            Peso.HeaderText = "Peso";
            Peso.MinimumWidth = 6;
            Peso.Name = "Peso";
            Peso.ReadOnly = true;
            Peso.Width = 125;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(3, 106);
            label6.Name = "label6";
            label6.Size = new Size(76, 25);
            label6.TabIndex = 13;
            label6.Text = "Destino";
            // 
            // cbDestino
            // 
            cbDestino.DataSource = null;
            cbDestino.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbDestino.FillColor = Color.White;
            cbDestino.Font = new Font("Microsoft Sans Serif", 12F);
            cbDestino.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbDestino.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbDestino.Location = new Point(84, 102);
            cbDestino.Margin = new Padding(4, 5, 4, 5);
            cbDestino.MinimumSize = new Size(63, 0);
            cbDestino.Name = "cbDestino";
            cbDestino.Padding = new Padding(0, 0, 30, 2);
            cbDestino.ReadOnly = true;
            cbDestino.RectColor = Color.Silver;
            cbDestino.Size = new Size(84, 29);
            cbDestino.SymbolSize = 24;
            cbDestino.TabIndex = 12;
            cbDestino.TextAlignment = ContentAlignment.MiddleLeft;
            cbDestino.Watermark = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(6, 63);
            label5.Name = "label5";
            label5.Size = new Size(70, 25);
            label5.TabIndex = 11;
            label5.Text = "Origen";
            // 
            // cbOrigen
            // 
            cbOrigen.DataSource = null;
            cbOrigen.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbOrigen.FillColor = Color.White;
            cbOrigen.Font = new Font("Microsoft Sans Serif", 12F);
            cbOrigen.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbOrigen.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbOrigen.Location = new Point(84, 59);
            cbOrigen.Margin = new Padding(4, 5, 4, 5);
            cbOrigen.MinimumSize = new Size(63, 0);
            cbOrigen.Name = "cbOrigen";
            cbOrigen.Padding = new Padding(0, 0, 30, 2);
            cbOrigen.ReadOnly = true;
            cbOrigen.RectColor = Color.Silver;
            cbOrigen.Size = new Size(84, 29);
            cbOrigen.SymbolSize = 24;
            cbOrigen.TabIndex = 10;
            cbOrigen.TextAlignment = ContentAlignment.MiddleLeft;
            cbOrigen.Watermark = "";
            // 
            // btnDeleteAristas
            // 
            btnDeleteAristas.FillColor = Color.FromArgb(250, 233, 232);
            btnDeleteAristas.FillDisableColor = Color.Silver;
            btnDeleteAristas.FillHoverColor = Color.FromArgb(210, 112, 102);
            btnDeleteAristas.FillPressColor = Color.Gray;
            btnDeleteAristas.FillSelectedColor = Color.FromArgb(210, 112, 102);
            btnDeleteAristas.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnDeleteAristas.ForeColor = Color.FromArgb(191, 57, 43);
            btnDeleteAristas.Location = new Point(177, 102);
            btnDeleteAristas.MinimumSize = new Size(1, 1);
            btnDeleteAristas.Name = "btnDeleteAristas";
            btnDeleteAristas.Radius = 10;
            btnDeleteAristas.RectColor = Color.White;
            btnDeleteAristas.RectDisableColor = Color.White;
            btnDeleteAristas.RectHoverColor = Color.White;
            btnDeleteAristas.RectPressColor = Color.White;
            btnDeleteAristas.RectSelectedColor = Color.White;
            btnDeleteAristas.Size = new Size(102, 35);
            btnDeleteAristas.Symbol = 559506;
            btnDeleteAristas.SymbolColor = Color.FromArgb(191, 57, 43);
            btnDeleteAristas.SymbolOffset = new Point(0, 3);
            btnDeleteAristas.SymbolSize = 26;
            btnDeleteAristas.TabIndex = 5;
            btnDeleteAristas.Text = "Eliminar";
            btnDeleteAristas.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnAddAristas
            // 
            btnAddAristas.FillColor = Color.FromArgb(79, 70, 229);
            btnAddAristas.FillDisableColor = Color.Silver;
            btnAddAristas.FillHoverColor = Color.FromArgb(52, 46, 152);
            btnAddAristas.FillPressColor = Color.Gray;
            btnAddAristas.FillSelectedColor = Color.FromArgb(52, 46, 152);
            btnAddAristas.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnAddAristas.Location = new Point(285, 102);
            btnAddAristas.MinimumSize = new Size(1, 1);
            btnAddAristas.Name = "btnAddAristas";
            btnAddAristas.Radius = 10;
            btnAddAristas.RectColor = Color.White;
            btnAddAristas.RectDisableColor = Color.White;
            btnAddAristas.RectHoverColor = Color.White;
            btnAddAristas.RectPressColor = Color.White;
            btnAddAristas.RectSelectedColor = Color.White;
            btnAddAristas.Size = new Size(100, 35);
            btnAddAristas.Symbol = 300043;
            btnAddAristas.SymbolOffset = new Point(0, 1);
            btnAddAristas.TabIndex = 4;
            btnAddAristas.Text = "Agregar";
            btnAddAristas.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnAddAristas.Click += btnAddAristas_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(184, 59);
            label4.Name = "label4";
            label4.Size = new Size(51, 25);
            label4.TabIndex = 3;
            label4.Text = "Peso";
            // 
            // txtPeso
            // 
            txtPeso.Font = new Font("Microsoft Sans Serif", 12F);
            txtPeso.Location = new Point(242, 59);
            txtPeso.Margin = new Padding(4, 5, 4, 5);
            txtPeso.MinimumSize = new Size(1, 16);
            txtPeso.Name = "txtPeso";
            txtPeso.Padding = new Padding(5);
            txtPeso.RectColor = Color.Silver;
            txtPeso.ShowText = false;
            txtPeso.Size = new Size(84, 29);
            txtPeso.TabIndex = 0;
            txtPeso.TextAlignment = ContentAlignment.MiddleLeft;
            txtPeso.Watermark = "Ej: \"3\"";
            // 
            // Digrafo
            // 
            Digrafo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Digrafo.Location = new Point(458, 112);
            Digrafo.Margin = new Padding(5, 7, 5, 7);
            Digrafo.MinimumSize = new Size(1, 1);
            Digrafo.Name = "Digrafo";
            Digrafo.Padding = new Padding(1, 47, 1, 1);
            Digrafo.Radius = 10;
            Digrafo.RectColor = Color.FromArgb(224, 224, 224);
            Digrafo.ShowText = false;
            Digrafo.Size = new Size(712, 481);
            Digrafo.TabIndex = 10;
            Digrafo.Text = "Digrafo";
            Digrafo.TextAlignment = ContentAlignment.MiddleLeft;
            Digrafo.TitleColor = Color.White;
            Digrafo.TitleForeColor = Color.FromArgb(64, 64, 64);
            // 
            // uiTitlePanel4
            // 
            uiTitlePanel4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiTitlePanel4.Location = new Point(1179, 112);
            uiTitlePanel4.Margin = new Padding(5, 7, 5, 7);
            uiTitlePanel4.MinimumSize = new Size(1, 1);
            uiTitlePanel4.Name = "uiTitlePanel4";
            uiTitlePanel4.Padding = new Padding(1, 47, 1, 1);
            uiTitlePanel4.Radius = 10;
            uiTitlePanel4.RectColor = Color.FromArgb(224, 224, 224);
            uiTitlePanel4.ShowText = false;
            uiTitlePanel4.Size = new Size(370, 329);
            uiTitlePanel4.TabIndex = 11;
            uiTitlePanel4.Text = "Analisis | Propiedades";
            uiTitlePanel4.TextAlignment = ContentAlignment.MiddleLeft;
            uiTitlePanel4.TitleColor = Color.White;
            uiTitlePanel4.TitleForeColor = Color.FromArgb(64, 64, 64);
            // 
            // uiTitlePanel5
            // 
            uiTitlePanel5.Controls.Add(btnReiniciarAlg);
            uiTitlePanel5.Controls.Add(btnEjecutarAlg);
            uiTitlePanel5.Controls.Add(label9);
            uiTitlePanel5.Controls.Add(cbDestinoAlg);
            uiTitlePanel5.Controls.Add(label8);
            uiTitlePanel5.Controls.Add(cbOrigenAlg);
            uiTitlePanel5.Controls.Add(label7);
            uiTitlePanel5.Controls.Add(cbAlgoritmos);
            uiTitlePanel5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiTitlePanel5.Location = new Point(1179, 460);
            uiTitlePanel5.Margin = new Padding(5, 7, 5, 7);
            uiTitlePanel5.MinimumSize = new Size(1, 1);
            uiTitlePanel5.Name = "uiTitlePanel5";
            uiTitlePanel5.Padding = new Padding(1, 47, 1, 1);
            uiTitlePanel5.Radius = 10;
            uiTitlePanel5.RectColor = Color.FromArgb(224, 224, 224);
            uiTitlePanel5.ShowText = false;
            uiTitlePanel5.Size = new Size(370, 545);
            uiTitlePanel5.TabIndex = 12;
            uiTitlePanel5.Text = "Algoritmos";
            uiTitlePanel5.TextAlignment = ContentAlignment.MiddleLeft;
            uiTitlePanel5.TitleColor = Color.White;
            uiTitlePanel5.TitleForeColor = Color.FromArgb(64, 64, 64);
            // 
            // btnReiniciarAlg
            // 
            btnReiniciarAlg.FillColor = Color.FromArgb(221, 224, 238);
            btnReiniciarAlg.FillDisableColor = Color.Silver;
            btnReiniciarAlg.FillHoverColor = Color.FromArgb(91, 105, 145);
            btnReiniciarAlg.FillPressColor = Color.Gray;
            btnReiniciarAlg.FillSelectedColor = Color.FromArgb(91, 105, 145);
            btnReiniciarAlg.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnReiniciarAlg.ForeColor = Color.FromArgb(26, 45, 98);
            btnReiniciarAlg.Location = new Point(210, 123);
            btnReiniciarAlg.MinimumSize = new Size(1, 1);
            btnReiniciarAlg.Name = "btnReiniciarAlg";
            btnReiniciarAlg.Radius = 10;
            btnReiniciarAlg.RectColor = Color.White;
            btnReiniciarAlg.RectDisableColor = Color.White;
            btnReiniciarAlg.RectHoverColor = Color.White;
            btnReiniciarAlg.RectPressColor = Color.White;
            btnReiniciarAlg.RectSelectedColor = Color.White;
            btnReiniciarAlg.Size = new Size(111, 35);
            btnReiniciarAlg.Symbol = 558393;
            btnReiniciarAlg.SymbolColor = Color.FromArgb(26, 45, 98);
            btnReiniciarAlg.SymbolOffset = new Point(0, 3);
            btnReiniciarAlg.SymbolSize = 26;
            btnReiniciarAlg.TabIndex = 21;
            btnReiniciarAlg.Text = "Reiniciar";
            btnReiniciarAlg.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnEjecutarAlg
            // 
            btnEjecutarAlg.FillColor = Color.FromArgb(20, 184, 166);
            btnEjecutarAlg.FillDisableColor = Color.Silver;
            btnEjecutarAlg.FillHoverColor = Color.FromArgb(13, 122, 110);
            btnEjecutarAlg.FillPressColor = Color.Gray;
            btnEjecutarAlg.FillSelectedColor = Color.FromArgb(13, 122, 110);
            btnEjecutarAlg.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnEjecutarAlg.Location = new Point(210, 82);
            btnEjecutarAlg.MinimumSize = new Size(1, 1);
            btnEjecutarAlg.Name = "btnEjecutarAlg";
            btnEjecutarAlg.Radius = 10;
            btnEjecutarAlg.RectColor = Color.White;
            btnEjecutarAlg.RectDisableColor = Color.White;
            btnEjecutarAlg.RectHoverColor = Color.White;
            btnEjecutarAlg.RectPressColor = Color.White;
            btnEjecutarAlg.RectSelectedColor = Color.White;
            btnEjecutarAlg.Size = new Size(111, 35);
            btnEjecutarAlg.Symbol = 61515;
            btnEjecutarAlg.SymbolOffset = new Point(0, 2);
            btnEjecutarAlg.SymbolSize = 20;
            btnEjecutarAlg.TabIndex = 20;
            btnEjecutarAlg.Text = "Ejecutar";
            btnEjecutarAlg.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(10, 121);
            label9.Name = "label9";
            label9.Size = new Size(76, 25);
            label9.TabIndex = 19;
            label9.Text = "Destino";
            // 
            // cbDestinoAlg
            // 
            cbDestinoAlg.DataSource = null;
            cbDestinoAlg.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbDestinoAlg.FillColor = Color.White;
            cbDestinoAlg.Font = new Font("Microsoft Sans Serif", 12F);
            cbDestinoAlg.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbDestinoAlg.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbDestinoAlg.Location = new Point(96, 123);
            cbDestinoAlg.Margin = new Padding(4, 5, 4, 5);
            cbDestinoAlg.MinimumSize = new Size(63, 0);
            cbDestinoAlg.Name = "cbDestinoAlg";
            cbDestinoAlg.Padding = new Padding(0, 0, 30, 2);
            cbDestinoAlg.ReadOnly = true;
            cbDestinoAlg.RectColor = Color.Silver;
            cbDestinoAlg.Size = new Size(107, 29);
            cbDestinoAlg.SymbolSize = 24;
            cbDestinoAlg.TabIndex = 18;
            cbDestinoAlg.TextAlignment = ContentAlignment.MiddleLeft;
            cbDestinoAlg.Watermark = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(10, 82);
            label8.Name = "label8";
            label8.Size = new Size(70, 25);
            label8.TabIndex = 17;
            label8.Text = "Origen";
            // 
            // cbOrigenAlg
            // 
            cbOrigenAlg.DataSource = null;
            cbOrigenAlg.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbOrigenAlg.FillColor = Color.White;
            cbOrigenAlg.Font = new Font("Microsoft Sans Serif", 12F);
            cbOrigenAlg.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbOrigenAlg.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbOrigenAlg.Location = new Point(87, 82);
            cbOrigenAlg.Margin = new Padding(4, 5, 4, 5);
            cbOrigenAlg.MinimumSize = new Size(63, 0);
            cbOrigenAlg.Name = "cbOrigenAlg";
            cbOrigenAlg.Padding = new Padding(0, 0, 30, 2);
            cbOrigenAlg.ReadOnly = true;
            cbOrigenAlg.RectColor = Color.Silver;
            cbOrigenAlg.Size = new Size(107, 29);
            cbOrigenAlg.SymbolSize = 24;
            cbOrigenAlg.TabIndex = 16;
            cbOrigenAlg.TextAlignment = ContentAlignment.MiddleLeft;
            cbOrigenAlg.Watermark = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(10, 48);
            label7.Name = "label7";
            label7.Size = new Size(96, 25);
            label7.TabIndex = 15;
            label7.Text = "Algoritmo";
            // 
            // cbAlgoritmos
            // 
            cbAlgoritmos.DataSource = null;
            cbAlgoritmos.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbAlgoritmos.FillColor = Color.White;
            cbAlgoritmos.Font = new Font("Microsoft Sans Serif", 12F);
            cbAlgoritmos.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbAlgoritmos.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbAlgoritmos.Location = new Point(113, 43);
            cbAlgoritmos.Margin = new Padding(4, 5, 4, 5);
            cbAlgoritmos.MinimumSize = new Size(63, 0);
            cbAlgoritmos.Name = "cbAlgoritmos";
            cbAlgoritmos.Padding = new Padding(0, 0, 30, 2);
            cbAlgoritmos.ReadOnly = true;
            cbAlgoritmos.RectColor = Color.Silver;
            cbAlgoritmos.Size = new Size(142, 29);
            cbAlgoritmos.SymbolSize = 24;
            cbAlgoritmos.TabIndex = 14;
            cbAlgoritmos.TextAlignment = ContentAlignment.MiddleLeft;
            cbAlgoritmos.Watermark = "";
            // 
            // tabcontrolMatricez
            // 
            tabcontrolMatricez.Controls.Add(MatrizIncidencia);
            tabcontrolMatricez.Controls.Add(Matrizadyacencia);
            tabcontrolMatricez.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcontrolMatricez.Font = new Font("Microsoft Sans Serif", 12F);
            tabcontrolMatricez.ItemSize = new Size(180, 40);
            tabcontrolMatricez.Location = new Point(440, 621);
            tabcontrolMatricez.MainPage = "";
            tabcontrolMatricez.Margin = new Padding(3, 4, 3, 4);
            tabcontrolMatricez.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            tabcontrolMatricez.Name = "tabcontrolMatricez";
            tabcontrolMatricez.SelectedIndex = 0;
            tabcontrolMatricez.Size = new Size(730, 379);
            tabcontrolMatricez.SizeMode = TabSizeMode.Fixed;
            tabcontrolMatricez.TabBackColor = Color.White;
            tabcontrolMatricez.TabIndex = 13;
            tabcontrolMatricez.TabSelectedColor = Color.FromArgb(224, 224, 224);
            tabcontrolMatricez.TabSelectedForeColor = Color.FromArgb(79, 70, 229);
            tabcontrolMatricez.TabSelectedHighColor = Color.FromArgb(79, 70, 229);
            tabcontrolMatricez.TabUnSelectedColor = Color.FromArgb(240, 240, 240);
            tabcontrolMatricez.TabUnSelectedForeColor = Color.FromArgb(48, 48, 48);
            tabcontrolMatricez.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // MatrizIncidencia
            // 
            MatrizIncidencia.Controls.Add(dgvMatrizI);
            MatrizIncidencia.Location = new Point(0, 40);
            MatrizIncidencia.Margin = new Padding(3, 4, 3, 4);
            MatrizIncidencia.Name = "MatrizIncidencia";
            MatrizIncidencia.Size = new Size(730, 339);
            MatrizIncidencia.TabIndex = 1;
            MatrizIncidencia.Text = "Matriz de Incidencia";
            MatrizIncidencia.UseVisualStyleBackColor = true;
            // 
            // dgvMatrizI
            // 
            dgvMatrizI.AllowUserToAddRows = false;
            dgvMatrizI.AllowUserToDeleteRows = false;
            dgvMatrizI.AllowUserToResizeColumns = false;
            dgvMatrizI.AllowUserToResizeRows = false;
            dgvMatrizI.BackgroundColor = Color.White;
            dgvMatrizI.BorderStyle = BorderStyle.None;
            dgvMatrizI.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvMatrizI.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = Color.FromArgb(79, 70, 229);
            dataGridViewCellStyle21.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle21.ForeColor = Color.White;
            dataGridViewCellStyle21.SelectionBackColor = Color.FromArgb(79, 70, 229);
            dataGridViewCellStyle21.SelectionForeColor = Color.Black;
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.True;
            dgvMatrizI.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            dgvMatrizI.ColumnHeadersHeight = 29;
            dgvMatrizI.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMatrizI.Columns.AddRange(new DataGridViewColumn[] { aMI, bMI });
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = Color.White;
            dataGridViewCellStyle22.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle22.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle22.SelectionBackColor = Color.FromArgb(215, 213, 249);
            dataGridViewCellStyle22.SelectionForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle22.WrapMode = DataGridViewTriState.False;
            dgvMatrizI.DefaultCellStyle = dataGridViewCellStyle22;
            dgvMatrizI.EnableHeadersVisualStyles = false;
            dgvMatrizI.Location = new Point(3, 16);
            dgvMatrizI.Margin = new Padding(3, 4, 3, 4);
            dgvMatrizI.Name = "dgvMatrizI";
            dgvMatrizI.ReadOnly = true;
            dgvMatrizI.RowHeadersVisible = false;
            dgvMatrizI.RowHeadersWidth = 51;
            dgvMatrizI.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMatrizI.Size = new Size(723, 292);
            dgvMatrizI.TabIndex = 17;
            // 
            // aMI
            // 
            aMI.HeaderText = "A";
            aMI.MinimumWidth = 6;
            aMI.Name = "aMI";
            aMI.ReadOnly = true;
            aMI.Width = 200;
            // 
            // bMI
            // 
            bMI.HeaderText = "B";
            bMI.MinimumWidth = 6;
            bMI.Name = "bMI";
            bMI.ReadOnly = true;
            bMI.Width = 200;
            // 
            // Matrizadyacencia
            // 
            Matrizadyacencia.Controls.Add(dgvMatrizA);
            Matrizadyacencia.Location = new Point(0, 40);
            Matrizadyacencia.Margin = new Padding(3, 4, 3, 4);
            Matrizadyacencia.Name = "Matrizadyacencia";
            Matrizadyacencia.Size = new Size(200, 60);
            Matrizadyacencia.TabIndex = 0;
            Matrizadyacencia.Text = "Matriz de adyacencia";
            Matrizadyacencia.UseVisualStyleBackColor = true;
            // 
            // dgvMatrizA
            // 
            dgvMatrizA.AllowUserToAddRows = false;
            dgvMatrizA.AllowUserToDeleteRows = false;
            dgvMatrizA.AllowUserToResizeColumns = false;
            dgvMatrizA.AllowUserToResizeRows = false;
            dgvMatrizA.BackgroundColor = Color.White;
            dgvMatrizA.BorderStyle = BorderStyle.None;
            dgvMatrizA.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvMatrizA.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = Color.FromArgb(79, 70, 229);
            dataGridViewCellStyle23.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle23.ForeColor = Color.White;
            dataGridViewCellStyle23.SelectionBackColor = Color.FromArgb(79, 70, 229);
            dataGridViewCellStyle23.SelectionForeColor = Color.Black;
            dataGridViewCellStyle23.WrapMode = DataGridViewTriState.True;
            dgvMatrizA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            dgvMatrizA.ColumnHeadersHeight = 29;
            dgvMatrizA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMatrizA.Columns.AddRange(new DataGridViewColumn[] { aMA, bMA });
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = Color.White;
            dataGridViewCellStyle24.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle24.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle24.SelectionBackColor = Color.FromArgb(215, 213, 249);
            dataGridViewCellStyle24.SelectionForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle24.WrapMode = DataGridViewTriState.False;
            dgvMatrizA.DefaultCellStyle = dataGridViewCellStyle24;
            dgvMatrizA.EnableHeadersVisualStyles = false;
            dgvMatrizA.Location = new Point(18, 16);
            dgvMatrizA.Margin = new Padding(3, 4, 3, 4);
            dgvMatrizA.Name = "dgvMatrizA";
            dgvMatrizA.ReadOnly = true;
            dgvMatrizA.RowHeadersVisible = false;
            dgvMatrizA.RowHeadersWidth = 51;
            dgvMatrizA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMatrizA.Size = new Size(694, 292);
            dgvMatrizA.TabIndex = 16;
            // 
            // aMA
            // 
            aMA.HeaderText = "A";
            aMA.MinimumWidth = 6;
            aMA.Name = "aMA";
            aMA.ReadOnly = true;
            aMA.Width = 200;
            // 
            // bMA
            // 
            bMA.HeaderText = "B";
            bMA.MinimumWidth = 6;
            bMA.Name = "bMA";
            bMA.ReadOnly = true;
            bMA.Width = 200;
            // 
            // b
            // 
            b.HeaderText = "B";
            b.MinimumWidth = 6;
            b.Name = "b";
            b.ReadOnly = true;
            b.Width = 125;
            // 
            // a
            // 
            a.HeaderText = "A";
            a.MinimumWidth = 6;
            a.Name = "a";
            a.ReadOnly = true;
            a.Width = 125;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1561, 1024);
            Controls.Add(tabcontrolMatricez);
            Controls.Add(uiTitlePanel5);
            Controls.Add(uiTitlePanel4);
            Controls.Add(Digrafo);
            Controls.Add(uiTitlePanel3);
            Controls.Add(uiTitlePanel2);
            Controls.Add(uiTitlePanel1);
            Controls.Add(btnAnalizar);
            Controls.Add(btnReestablecer);
            Controls.Add(btnCrearGrafo);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(1561, 1024);
            Name = "App";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.Fuchsia;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            uiTitlePanel1.ResumeLayout(false);
            uiTitlePanel2.ResumeLayout(false);
            uiTitlePanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVertices).EndInit();
            uiTitlePanel3.ResumeLayout(false);
            uiTitlePanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAristas).EndInit();
            uiTitlePanel5.ResumeLayout(false);
            uiTitlePanel5.PerformLayout();
            tabcontrolMatricez.ResumeLayout(false);
            MatrizIncidencia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMatrizI).EndInit();
            Matrizadyacencia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMatrizA).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Sunny.UI.UISymbolButton btnCrearGrafo;
        private Sunny.UI.UISymbolButton btnReestablecer;
        private Sunny.UI.UISymbolButton btnAnalizar;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UICheckBox CheckDirigido;
        private Sunny.UI.UICheckBox CheckPonderado;
        private Sunny.UI.UICheckBox CheckNoDirigido;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private Label label3;
        private Sunny.UI.UITextBox txtVertice;
        private Sunny.UI.UISymbolButton btnAddVertice;
        private Sunny.UI.UISymbolButton btnDeleteVertice;
        private Sunny.UI.UITitlePanel uiTitlePanel3;
        private Sunny.UI.UISymbolButton btnDeleteAristas;
        private Sunny.UI.UISymbolButton btnAddAristas;
        private Label label4;
        private Sunny.UI.UITextBox txtPeso;
        private Label label6;
        private Sunny.UI.UIComboBox cbDestino;
        private Label label5;
        private Sunny.UI.UIComboBox cbOrigen;
        private Sunny.UI.UITitlePanel Digrafo;
        private Sunny.UI.UITitlePanel uiTitlePanel4;
        private Sunny.UI.UITitlePanel uiTitlePanel5;
        private Sunny.UI.UISymbolButton btnReiniciarAlg;
        private Sunny.UI.UISymbolButton btnEjecutarAlg;
        private Label label9;
        private Sunny.UI.UIComboBox cbDestinoAlg;
        private Label label8;
        private Sunny.UI.UIComboBox cbOrigenAlg;
        private Label label7;
        private Sunny.UI.UIComboBox cbAlgoritmos;
        private ReaLTaiizor.Controls.PoisonDataGridView dgvAlgoritmos;
        private DataGridViewTextBoxColumn Visita;
        private Sunny.UI.UITabControl tabcontrolMatricez;
        private TabPage Matrizadyacencia;
        private TabPage MatrizIncidencia;
        private DataGridView dgvVertices;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Grado;
        private DataGridViewTextBoxColumn Conexiones;
        private DataGridView dgvAristas;
        private DataGridViewTextBoxColumn Origen;
        private DataGridViewTextBoxColumn Destino;
        private DataGridViewTextBoxColumn Peso;
        private DataGridViewTextBoxColumn a;
        private DataGridViewTextBoxColumn b;
        private DataGridView dgvMatrizA;
        private DataGridView dgvMatrizI;
        private DataGridViewTextBoxColumn aMI;
        private DataGridViewTextBoxColumn bMI;
        private DataGridViewTextBoxColumn aMA;
        private DataGridViewTextBoxColumn bMA;
    }
}
