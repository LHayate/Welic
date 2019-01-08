using System.Windows.Forms;

namespace UseFul.Forms.Welic
{
    partial class FormBuscaPaginacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuscaPaginacao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnPrimeiraPagina = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAnterior = new System.Windows.Forms.ToolStripButton();
            this.tstxtPagina = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsLabelTotalPaginas = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnProximo = new System.Windows.Forms.ToolStripButton();
            this.tsBtnUltimaPagina = new System.Windows.Forms.ToolStripButton();
            this.tsLabelResultadoBusca = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtRegistrosPorPagina = new System.Windows.Forms.ToolStripTextBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.toolStripOpcoes = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSelecionar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorOpcoes = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnExcel = new System.Windows.Forms.ToolStripButton();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.lblColuna = new System.Windows.Forms.Label();
            this.cboColuna = new System.Windows.Forms.ComboBox();
            this.lblCondicao = new System.Windows.Forms.Label();
            this.cboCondicao = new System.Windows.Forms.ComboBox();
            this.lbEntreData = new System.Windows.Forms.Label();
            this.dtpFiltroEntre = new System.Windows.Forms.DateTimePicker();
            this.dtpFiltro = new System.Windows.Forms.DateTimePicker();
            this.lbEntreTexto = new System.Windows.Forms.Label();
            this.txtFiltro = new UseFul.Forms.Welic.TextBoxWelic();
            this.txtFiltroEntre2 = new UseFul.Forms.Welic.TextBoxWelic();
            this.txtFiltroEntre1 = new UseFul.Forms.Welic.TextBoxWelic();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.toolStripOpcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.dgvLista);
            this.panel1.Location = new System.Drawing.Point(12, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 462);
            this.panel1.TabIndex = 54;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnPrimeiraPagina,
            this.tsBtnAnterior,
            this.tstxtPagina,
            this.toolStripLabel1,
            this.tsLabelTotalPaginas,
            this.tsBtnProximo,
            this.tsBtnUltimaPagina,
            this.tsLabelResultadoBusca,
            this.toolStripLabel2,
            this.tstxtRegistrosPorPagina});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(763, 31);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnPrimeiraPagina
            // 
            this.tsBtnPrimeiraPagina.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPrimeiraPagina.Enabled = false;
            this.tsBtnPrimeiraPagina.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnPrimeiraPagina.Image")));
            this.tsBtnPrimeiraPagina.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBtnPrimeiraPagina.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrimeiraPagina.Name = "tsBtnPrimeiraPagina";
            this.tsBtnPrimeiraPagina.Size = new System.Drawing.Size(28, 28);
            this.tsBtnPrimeiraPagina.Text = "Início";
            this.tsBtnPrimeiraPagina.Click += new System.EventHandler(this.tsBtnPrimeiraPagina_Click);
            // 
            // tsBtnAnterior
            // 
            this.tsBtnAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAnterior.Enabled = false;
            this.tsBtnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAnterior.Image")));
            this.tsBtnAnterior.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBtnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAnterior.Name = "tsBtnAnterior";
            this.tsBtnAnterior.Size = new System.Drawing.Size(28, 28);
            this.tsBtnAnterior.Text = "Anterior";
            this.tsBtnAnterior.Click += new System.EventHandler(this.tsBtnAnterior_Click);
            // 
            // tstxtPagina
            // 
            this.tstxtPagina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstxtPagina.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.tstxtPagina.Name = "tstxtPagina";
            this.tstxtPagina.Size = new System.Drawing.Size(50, 31);
            this.tstxtPagina.Text = "0";
            this.tstxtPagina.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tstxtPagina.Leave += new System.EventHandler(this.tstxtPagina_Leave);
            this.tstxtPagina.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstxtPagina_KeyDown);
            this.tstxtPagina.TextChanged += new System.EventHandler(this.tstxtPagina_TextChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(23, 28);
            this.toolStripLabel1.Text = "de";
            // 
            // tsLabelTotalPaginas
            // 
            this.tsLabelTotalPaginas.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsLabelTotalPaginas.Name = "tsLabelTotalPaginas";
            this.tsLabelTotalPaginas.Size = new System.Drawing.Size(15, 28);
            this.tsLabelTotalPaginas.Text = "1";
            // 
            // tsBtnProximo
            // 
            this.tsBtnProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnProximo.Enabled = false;
            this.tsBtnProximo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnProximo.Image")));
            this.tsBtnProximo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBtnProximo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnProximo.Name = "tsBtnProximo";
            this.tsBtnProximo.Size = new System.Drawing.Size(28, 28);
            this.tsBtnProximo.Text = "Próximo";
            this.tsBtnProximo.Click += new System.EventHandler(this.tsBtnProximo_Click);
            // 
            // tsBtnUltimaPagina
            // 
            this.tsBtnUltimaPagina.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnUltimaPagina.Enabled = false;
            this.tsBtnUltimaPagina.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUltimaPagina.Image")));
            this.tsBtnUltimaPagina.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBtnUltimaPagina.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUltimaPagina.Name = "tsBtnUltimaPagina";
            this.tsBtnUltimaPagina.Size = new System.Drawing.Size(28, 28);
            this.tsBtnUltimaPagina.Text = "Ultimo";
            this.tsBtnUltimaPagina.Click += new System.EventHandler(this.tsBtnUltimaPagina_Click);
            // 
            // tsLabelResultadoBusca
            // 
            this.tsLabelResultadoBusca.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLabelResultadoBusca.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsLabelResultadoBusca.Name = "tsLabelResultadoBusca";
            this.tsLabelResultadoBusca.Size = new System.Drawing.Size(270, 28);
            this.tsLabelResultadoBusca.Text = "Resultado da busca: 0 itens encontrados";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(146, 28);
            this.toolStripLabel2.Text = "Registros por Página:";
            // 
            // tstxtRegistrosPorPagina
            // 
            this.tstxtRegistrosPorPagina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstxtRegistrosPorPagina.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.tstxtRegistrosPorPagina.Name = "tstxtRegistrosPorPagina";
            this.tstxtRegistrosPorPagina.Size = new System.Drawing.Size(45, 31);
            this.tstxtRegistrosPorPagina.Text = "20";
            this.tstxtRegistrosPorPagina.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tstxtRegistrosPorPagina.Leave += new System.EventHandler(this.tstxtRegistrosPorPagina_Leave);
            this.tstxtRegistrosPorPagina.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstxtRegistrosPorPagina_KeyDown);
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AllowUserToResizeRows = false;
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLista.BackgroundColor = System.Drawing.Color.White;
            this.dgvLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLista.EnableHeadersVisualStyles = false;
            this.dgvLista.Location = new System.Drawing.Point(3, 34);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(757, 426);
            this.dgvLista.TabIndex = 53;
            this.dgvLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellDoubleClick);
            this.dgvLista.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvLista_RowsAdded);
            this.dgvLista.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvLista_RowsRemoved);
            this.dgvLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLista_KeyDown);
            // 
            // toolStripOpcoes
            // 
            this.toolStripOpcoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.toolStripOpcoes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripOpcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnFiltrar,
            this.toolStripBtnSelecionar,
            this.toolStripSeparatorOpcoes,
            this.toolStripBtnExcel});
            this.toolStripOpcoes.Location = new System.Drawing.Point(0, 0);
            this.toolStripOpcoes.Name = "toolStripOpcoes";
            this.toolStripOpcoes.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripOpcoes.Size = new System.Drawing.Size(784, 31);
            this.toolStripOpcoes.Stretch = true;
            this.toolStripOpcoes.TabIndex = 52;
            this.toolStripOpcoes.Text = "toolStripOpcoes";
            // 
            // toolStripBtnFiltrar
            // 
            this.toolStripBtnFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnFiltrar.Image")));
            this.toolStripBtnFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnFiltrar.ImageTransparentColor = System.Drawing.Color.Maroon;
            this.toolStripBtnFiltrar.Name = "toolStripBtnFiltrar";
            this.toolStripBtnFiltrar.Size = new System.Drawing.Size(28, 28);
            this.toolStripBtnFiltrar.ToolTipText = "Filtar de Acordo com a Condição";
            this.toolStripBtnFiltrar.Click += new System.EventHandler(this.toolStripBtnFiltrar_Click);
            // 
            // toolStripBtnSelecionar
            // 
            this.toolStripBtnSelecionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSelecionar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSelecionar.Image")));
            this.toolStripBtnSelecionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnSelecionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSelecionar.Name = "toolStripBtnSelecionar";
            this.toolStripBtnSelecionar.Size = new System.Drawing.Size(28, 28);
            this.toolStripBtnSelecionar.ToolTipText = "Confirma Linha Selecionada";
            this.toolStripBtnSelecionar.Click += new System.EventHandler(this.toolStripBtnSelecionar_Click);
            // 
            // toolStripSeparatorOpcoes
            // 
            this.toolStripSeparatorOpcoes.Name = "toolStripSeparatorOpcoes";
            this.toolStripSeparatorOpcoes.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripBtnExcel
            // 
            this.toolStripBtnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnExcel.Image")));
            this.toolStripBtnExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnExcel.Name = "toolStripBtnExcel";
            this.toolStripBtnExcel.Size = new System.Drawing.Size(26, 28);
            this.toolStripBtnExcel.ToolTipText = "Exportar Lista no Formato Microsoft Excel";
            this.toolStripBtnExcel.Click += new System.EventHandler(this.toolStripBtnExcel_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(12, 71);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(46, 13);
            this.lblFiltro.TabIndex = 45;
            this.lblFiltro.Text = "Filtro:";
            // 
            // lblColuna
            // 
            this.lblColuna.AutoSize = true;
            this.lblColuna.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColuna.Location = new System.Drawing.Point(12, 44);
            this.lblColuna.Name = "lblColuna";
            this.lblColuna.Size = new System.Drawing.Size(55, 13);
            this.lblColuna.TabIndex = 43;
            this.lblColuna.Text = "Coluna:";
            // 
            // cboColuna
            // 
            this.cboColuna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColuna.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboColuna.FormattingEnabled = true;
            this.cboColuna.Location = new System.Drawing.Point(67, 41);
            this.cboColuna.Name = "cboColuna";
            this.cboColuna.Size = new System.Drawing.Size(155, 21);
            this.cboColuna.TabIndex = 41;
            this.cboColuna.SelectedIndexChanged += new System.EventHandler(this.cboColuna_SelectedIndexChanged);
            // 
            // lblCondicao
            // 
            this.lblCondicao.AutoSize = true;
            this.lblCondicao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondicao.Location = new System.Drawing.Point(226, 44);
            this.lblCondicao.Name = "lblCondicao";
            this.lblCondicao.Size = new System.Drawing.Size(70, 13);
            this.lblCondicao.TabIndex = 42;
            this.lblCondicao.Text = "Condição:";
            // 
            // cboCondicao
            // 
            this.cboCondicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCondicao.FormattingEnabled = true;
            this.cboCondicao.Location = new System.Drawing.Point(296, 41);
            this.cboCondicao.Name = "cboCondicao";
            this.cboCondicao.Size = new System.Drawing.Size(152, 21);
            this.cboCondicao.TabIndex = 42;
            this.cboCondicao.SelectedIndexChanged += new System.EventHandler(this.cboCondicao_SelectedIndexChanged);
            // 
            // lbEntreData
            // 
            this.lbEntreData.AutoSize = true;
            this.lbEntreData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEntreData.Location = new System.Drawing.Point(196, 71);
            this.lbEntreData.Name = "lbEntreData";
            this.lbEntreData.Size = new System.Drawing.Size(15, 13);
            this.lbEntreData.TabIndex = 51;
            this.lbEntreData.Text = "a";
            // 
            // dtpFiltroEntre
            // 
            this.dtpFiltroEntre.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFiltroEntre.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFiltroEntre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroEntre.Location = new System.Drawing.Point(216, 68);
            this.dtpFiltroEntre.Name = "dtpFiltroEntre";
            this.dtpFiltroEntre.Size = new System.Drawing.Size(123, 21);
            this.dtpFiltroEntre.TabIndex = 50;
            this.dtpFiltroEntre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFiltroEntre_KeyPress);
            // 
            // dtpFiltro
            // 
            this.dtpFiltro.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFiltro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltro.Location = new System.Drawing.Point(67, 68);
            this.dtpFiltro.Name = "dtpFiltro";
            this.dtpFiltro.Size = new System.Drawing.Size(123, 21);
            this.dtpFiltro.TabIndex = 49;
            this.dtpFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFiltro_KeyPress);
            // 
            // lbEntreTexto
            // 
            this.lbEntreTexto.AutoSize = true;
            this.lbEntreTexto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEntreTexto.Location = new System.Drawing.Point(306, 71);
            this.lbEntreTexto.Name = "lbEntreTexto";
            this.lbEntreTexto.Size = new System.Drawing.Size(15, 13);
            this.lbEntreTexto.TabIndex = 48;
            this.lbEntreTexto.Text = "a";
            // 
            // txtFiltro
            // 
            this.txtFiltro._RecursosGenericosSqlF3 = null;
            this.txtFiltro._RecursosGenericosSqlLeave = null;
            this.txtFiltro.BackColor = System.Drawing.Color.White;
            this.txtFiltro.ExibirIconePesquisa = false;
            this.txtFiltro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.InformacaoToolTipCaminho = null;
            this.txtFiltro.InformacaoToolTipDescricao = null;
            this.txtFiltro.LimpaCampo = true;
            this.txtFiltro.Location = new System.Drawing.Point(67, 68);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.NomeCampoDadosDataTable = null;
            this.txtFiltro.ParteDecimal = 0;
            this.txtFiltro.ParteInteira = 0;
            this.txtFiltro.SegurancaCCusto = UseFul.Forms.Welic.TextBoxWelic.CSegurancaCentroCusto.NaoUtilizado;
            this.txtFiltro.Size = new System.Drawing.Size(506, 21);
            this.txtFiltro.TabIndex = 40;
            this.txtFiltro.TipoCampo = UseFul.Forms.Welic.TextBoxWelic.CTipoCampo.Normal;
            this.txtFiltro.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Geral;
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            this.txtFiltro.Leave += new System.EventHandler(this.txtFiltro_Leave);
            // 
            // txtFiltroEntre2
            // 
            this.txtFiltroEntre2._RecursosGenericosSqlF3 = null;
            this.txtFiltroEntre2._RecursosGenericosSqlLeave = null;
            this.txtFiltroEntre2.BackColor = System.Drawing.Color.White;
            this.txtFiltroEntre2.ExibirIconePesquisa = false;
            this.txtFiltroEntre2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroEntre2.InformacaoToolTipCaminho = null;
            this.txtFiltroEntre2.InformacaoToolTipDescricao = null;
            this.txtFiltroEntre2.LimpaCampo = true;
            this.txtFiltroEntre2.Location = new System.Drawing.Point(327, 68);
            this.txtFiltroEntre2.Name = "txtFiltroEntre2";
            this.txtFiltroEntre2.NomeCampoDadosDataTable = null;
            this.txtFiltroEntre2.ParteDecimal = 0;
            this.txtFiltroEntre2.ParteInteira = 0;
            this.txtFiltroEntre2.SegurancaCCusto = UseFul.Forms.Welic.TextBoxWelic.CSegurancaCentroCusto.NaoUtilizado;
            this.txtFiltroEntre2.Size = new System.Drawing.Size(246, 21);
            this.txtFiltroEntre2.TabIndex = 47;
            this.txtFiltroEntre2.TipoCampo = UseFul.Forms.Welic.TextBoxWelic.CTipoCampo.Normal;
            this.txtFiltroEntre2.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Geral;
            this.txtFiltroEntre2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltroEntre2_KeyPress);
            // 
            // txtFiltroEntre1
            // 
            this.txtFiltroEntre1._RecursosGenericosSqlF3 = null;
            this.txtFiltroEntre1._RecursosGenericosSqlLeave = null;
            this.txtFiltroEntre1.BackColor = System.Drawing.Color.White;
            this.txtFiltroEntre1.ExibirIconePesquisa = false;
            this.txtFiltroEntre1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroEntre1.InformacaoToolTipCaminho = null;
            this.txtFiltroEntre1.InformacaoToolTipDescricao = null;
            this.txtFiltroEntre1.LimpaCampo = true;
            this.txtFiltroEntre1.Location = new System.Drawing.Point(67, 68);
            this.txtFiltroEntre1.Name = "txtFiltroEntre1";
            this.txtFiltroEntre1.NomeCampoDadosDataTable = null;
            this.txtFiltroEntre1.ParteDecimal = 0;
            this.txtFiltroEntre1.ParteInteira = 0;
            this.txtFiltroEntre1.SegurancaCCusto = UseFul.Forms.Welic.TextBoxWelic.CSegurancaCentroCusto.NaoUtilizado;
            this.txtFiltroEntre1.Size = new System.Drawing.Size(233, 21);
            this.txtFiltroEntre1.TabIndex = 46;
            this.txtFiltroEntre1.TipoCampo = UseFul.Forms.Welic.TextBoxWelic.CTipoCampo.Normal;
            this.txtFiltroEntre1.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Geral;
            this.txtFiltroEntre1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltroEntre1_KeyPress);
            // 
            // FormBuscaPaginacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripOpcoes);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.lblColuna);
            this.Controls.Add(this.cboColuna);
            this.Controls.Add(this.lblCondicao);
            this.Controls.Add(this.cboCondicao);
            this.Controls.Add(this.lbEntreData);
            this.Controls.Add(this.lbEntreTexto);
            this.Controls.Add(this.txtFiltroEntre2);
            this.Controls.Add(this.txtFiltroEntre1);
            this.Controls.Add(this.dtpFiltroEntre);
            this.Controls.Add(this.dtpFiltro);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FormBuscaPaginacao";
            this.Text = "FormBuscaPaginacao";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.toolStripOpcoes.ResumeLayout(false);
            this.toolStripOpcoes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblColuna;
        private ComboBox cboColuna;
        private Label lblCondicao;
        private ComboBox cboCondicao;
        private TextBoxWelic txtFiltroEntre2;
        private Label lbEntreTexto;
        private TextBoxWelic txtFiltroEntre1;
        private Label lbEntreData;
        private DateTimePicker dtpFiltroEntre;
        private DateTimePicker dtpFiltro;
        private Label lblFiltro;
        private TextBoxWelic txtFiltro;
        public ToolStripButton toolStripBtnFiltrar;
        private ToolStripButton toolStripBtnSelecionar;
        private ToolStripSeparator toolStripSeparatorOpcoes;
        private ToolStripButton toolStripBtnExcel;
        public ToolStrip toolStripOpcoes;
        private Panel panel1;
        private ToolStrip toolStrip1;
        public ToolStripButton tsBtnPrimeiraPagina;
        public ToolStripButton tsBtnAnterior;
        public ToolStripTextBox tstxtPagina;
        private ToolStripLabel tsLabelTotalPaginas;
        public ToolStripButton tsBtnProximo;
        public ToolStripButton tsBtnUltimaPagina;
        private ToolStripLabel tsLabelResultadoBusca;
        private DataGridView dgvLista;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox tstxtRegistrosPorPagina;
    }
}