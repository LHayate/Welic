using System.Windows.Forms;

namespace UseFul.Forms.Welic
{
    partial class FormConsulta
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsulta));
            this.toolStripOpcoes = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnBusca = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnLimpar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDetalhar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorOpcoes = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnPermissao = new System.Windows.Forms.ToolStripButton();
            this.pnGrid = new System.Windows.Forms.Panel();
            this.txtTotais = new UseFul.Forms.Welic.LabelGroupWelic(this.components);
            this.pnFiltros = new System.Windows.Forms.Panel();
            this.toolStripOpcoes.SuspendLayout();
            this.pnGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripOpcoes
            // 
            this.toolStripOpcoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.toolStripOpcoes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripOpcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnBusca,
            this.toolStripBtnLimpar,
            this.toolStripBtnDetalhar,
            this.toolStripSeparatorOpcoes,
            this.toolStripBtnExcel,
            this.toolStripBtnPermissao});
            this.toolStripOpcoes.Location = new System.Drawing.Point(0, 0);
            this.toolStripOpcoes.Name = "toolStripOpcoes";
            this.toolStripOpcoes.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripOpcoes.Size = new System.Drawing.Size(684, 31);
            this.toolStripOpcoes.Stretch = true;
            this.toolStripOpcoes.TabIndex = 7;
            this.toolStripOpcoes.Text = "toolStripOpcoes";
            // 
            // toolStripBtnBusca
            // 
            this.toolStripBtnBusca.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnBusca.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnBusca.Image")));
            this.toolStripBtnBusca.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnBusca.ImageTransparentColor = System.Drawing.Color.Maroon;
            this.toolStripBtnBusca.Name = "toolStripBtnBusca";
            this.toolStripBtnBusca.Size = new System.Drawing.Size(28, 28);
            this.toolStripBtnBusca.Text = "Buscar";
            this.toolStripBtnBusca.ToolTipText = "Buscar";
            this.toolStripBtnBusca.Click += new System.EventHandler(this.toolStripBtnBusca_Click);
            // 
            // toolStripBtnLimpar
            // 
            this.toolStripBtnLimpar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnLimpar.Image")));
            this.toolStripBtnLimpar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnLimpar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnLimpar.Name = "toolStripBtnLimpar";
            this.toolStripBtnLimpar.Size = new System.Drawing.Size(26, 28);
            this.toolStripBtnLimpar.Text = "Limpar";
            this.toolStripBtnLimpar.ToolTipText = "Limpar";
            this.toolStripBtnLimpar.Click += new System.EventHandler(this.toolStripBtnLimpar_Click);
            // 
            // toolStripBtnDetalhar
            // 
            this.toolStripBtnDetalhar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnDetalhar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnDetalhar.Image")));
            this.toolStripBtnDetalhar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnDetalhar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDetalhar.Name = "toolStripBtnDetalhar";
            this.toolStripBtnDetalhar.Size = new System.Drawing.Size(28, 28);
            this.toolStripBtnDetalhar.Text = "Detalhar";
            this.toolStripBtnDetalhar.ToolTipText = "Detalhar";
            this.toolStripBtnDetalhar.Click += new System.EventHandler(this.toolStripBtnDetalhar_Click);
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
            this.toolStripBtnExcel.Text = "Gerar Excel";
            this.toolStripBtnExcel.Click += new System.EventHandler(this.toolStripBtnExcel_Click);
            // 
            // toolStripBtnPermissao
            // 
            this.toolStripBtnPermissao.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripBtnPermissao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnPermissao.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnPermissao.Image")));
            this.toolStripBtnPermissao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnPermissao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPermissao.Name = "toolStripBtnPermissao";
            this.toolStripBtnPermissao.Size = new System.Drawing.Size(28, 28);
            this.toolStripBtnPermissao.Text = "Permissões";
            this.toolStripBtnPermissao.ToolTipText = "Permissões";
            this.toolStripBtnPermissao.Click += new System.EventHandler(this.toolStripBtnPermissao_Click);
            // 
            // pnGrid
            // 
            this.pnGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnGrid.Controls.Add(this.txtTotais);
            this.pnGrid.Location = new System.Drawing.Point(3, 160);
            this.pnGrid.Name = "pnGrid";
            this.pnGrid.Size = new System.Drawing.Size(678, 249);
            this.pnGrid.TabIndex = 66;
            // 
            // txtTotais
            // 
            this.txtTotais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.txtTotais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotais.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotais.Location = new System.Drawing.Point(3, 190);
            this.txtTotais.Name = "txtTotais";
            this.txtTotais.Padding = new System.Windows.Forms.Padding(1);
            this.txtTotais.Size = new System.Drawing.Size(669, 22);
            this.txtTotais.TabIndex = 66;
            this.txtTotais.Text = "Totais:";
            // 
            // pnFiltros
            // 
            this.pnFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnFiltros.Location = new System.Drawing.Point(3, 33);
            this.pnFiltros.Name = "pnFiltros";
            this.pnFiltros.Size = new System.Drawing.Size(678, 124);
            this.pnFiltros.TabIndex = 65;
            // 
            // FormConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 412);
            this.Controls.Add(this.pnGrid);
            this.Controls.Add(this.pnFiltros);
            this.Controls.Add(this.toolStripOpcoes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConsulta";
            this.Text = "Título Formulário";
            this.Load += new System.EventHandler(this.FormConsulta_Load);
            this.toolStripOpcoes.ResumeLayout(false);
            this.toolStripOpcoes.PerformLayout();
            this.pnGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ToolStrip toolStripOpcoes;
        public ToolStripButton toolStripBtnBusca;
        public ToolStripSeparator toolStripSeparatorOpcoes;
        public ToolStripButton toolStripBtnExcel;
        public ToolStripButton toolStripBtnLimpar;
        public ToolStripButton toolStripBtnDetalhar;
        public Panel pnGrid;
        public Panel pnFiltros;
        public LabelGroupWelic txtTotais;
        public ToolStripButton toolStripBtnPermissao;
    }
}