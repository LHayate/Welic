using System.Windows.Forms;

namespace UseFul.Forms.Welic
{
    partial class FormAssistenteRelatorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAssistenteRelatorio));
            this.txtOpcaoVisualizacao = new System.Windows.Forms.TextBox();
            this.lblOpcaoVisualizacao = new System.Windows.Forms.Label();
            this.pnlOpcaoVisualizacao = new System.Windows.Forms.Panel();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnGerar = new System.Windows.Forms.Button();
            this.toolStripBtnTela = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnImpressora = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnWord = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnPDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripOpcoes = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparatorOpcoes = new System.Windows.Forms.ToolStripSeparator();
            this.pnlOpcaoVisualizacao.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            this.toolStripOpcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOpcaoVisualizacao
            // 
            this.txtOpcaoVisualizacao.BackColor = System.Drawing.Color.Gainsboro;
            this.txtOpcaoVisualizacao.Enabled = false;
            this.txtOpcaoVisualizacao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpcaoVisualizacao.ForeColor = System.Drawing.Color.Black;
            this.txtOpcaoVisualizacao.Location = new System.Drawing.Point(170, 8);
            this.txtOpcaoVisualizacao.Name = "txtOpcaoVisualizacao";
            this.txtOpcaoVisualizacao.Size = new System.Drawing.Size(129, 21);
            this.txtOpcaoVisualizacao.TabIndex = 15;
            // 
            // lblOpcaoVisualizacao
            // 
            this.lblOpcaoVisualizacao.AutoSize = true;
            this.lblOpcaoVisualizacao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcaoVisualizacao.Location = new System.Drawing.Point(14, 11);
            this.lblOpcaoVisualizacao.Name = "lblOpcaoVisualizacao";
            this.lblOpcaoVisualizacao.Size = new System.Drawing.Size(156, 13);
            this.lblOpcaoVisualizacao.TabIndex = 16;
            this.lblOpcaoVisualizacao.Text = "Opção de Visualização:";
            // 
            // pnlOpcaoVisualizacao
            // 
            this.pnlOpcaoVisualizacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOpcaoVisualizacao.Controls.Add(this.txtOpcaoVisualizacao);
            this.pnlOpcaoVisualizacao.Controls.Add(this.lblOpcaoVisualizacao);
            this.pnlOpcaoVisualizacao.Location = new System.Drawing.Point(3, 41);
            this.pnlOpcaoVisualizacao.Name = "pnlOpcaoVisualizacao";
            this.pnlOpcaoVisualizacao.Size = new System.Drawing.Size(315, 38);
            this.pnlOpcaoVisualizacao.TabIndex = 18;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.pnlBotoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotoes.Controls.Add(this.btnGerar);
            this.pnlBotoes.Location = new System.Drawing.Point(3, 81);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(315, 37);
            this.pnlBotoes.TabIndex = 19;
            // 
            // btnGerar
            // 
            this.btnGerar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGerar.Image")));
            this.btnGerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerar.Location = new System.Drawing.Point(201, 3);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(107, 30);
            this.btnGerar.TabIndex = 0;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // toolStripBtnTela
            // 
            this.toolStripBtnTela.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnTela.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnTela.Image")));
            this.toolStripBtnTela.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnTela.ImageTransparentColor = System.Drawing.Color.Maroon;
            this.toolStripBtnTela.Name = "toolStripBtnTela";
            this.toolStripBtnTela.Size = new System.Drawing.Size(36, 36);
            this.toolStripBtnTela.Text = "Tela";
            this.toolStripBtnTela.ToolTipText = "Tela";
            this.toolStripBtnTela.Click += new System.EventHandler(this.toolStripBtnTela_Click);
            // 
            // toolStripBtnImpressora
            // 
            this.toolStripBtnImpressora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnImpressora.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnImpressora.Image")));
            this.toolStripBtnImpressora.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnImpressora.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnImpressora.Name = "toolStripBtnImpressora";
            this.toolStripBtnImpressora.Size = new System.Drawing.Size(36, 36);
            this.toolStripBtnImpressora.Text = "Impressora";
            this.toolStripBtnImpressora.ToolTipText = "Impressora";
            this.toolStripBtnImpressora.Click += new System.EventHandler(this.toolStripBtnImpressora_Click);
            // 
            // toolStripBtnExcel
            // 
            this.toolStripBtnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnExcel.Image")));
            this.toolStripBtnExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnExcel.Name = "toolStripBtnExcel";
            this.toolStripBtnExcel.Size = new System.Drawing.Size(36, 36);
            this.toolStripBtnExcel.Text = "Microsoft Excel";
            this.toolStripBtnExcel.ToolTipText = "Microsoft Excel";
            this.toolStripBtnExcel.Click += new System.EventHandler(this.toolStripBtnExcel_Click);
            // 
            // toolStripBtnWord
            // 
            this.toolStripBtnWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnWord.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnWord.Image")));
            this.toolStripBtnWord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnWord.Name = "toolStripBtnWord";
            this.toolStripBtnWord.Size = new System.Drawing.Size(36, 36);
            this.toolStripBtnWord.Text = "Microsoft Word";
            this.toolStripBtnWord.ToolTipText = "Microsoft Word";
            this.toolStripBtnWord.Click += new System.EventHandler(this.toolStripBtnWord_Click);
            // 
            // toolStripBtnPDF
            // 
            this.toolStripBtnPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnPDF.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnPDF.Image")));
            this.toolStripBtnPDF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPDF.Name = "toolStripBtnPDF";
            this.toolStripBtnPDF.Size = new System.Drawing.Size(36, 36);
            this.toolStripBtnPDF.Text = "PDF";
            this.toolStripBtnPDF.ToolTipText = "PDF";
            this.toolStripBtnPDF.Click += new System.EventHandler(this.toolStripBtnPDF_Click);
            // 
            // toolStripOpcoes
            // 
            this.toolStripOpcoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.toolStripOpcoes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripOpcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnTela,
            this.toolStripBtnImpressora,
            this.toolStripSeparatorOpcoes,
            this.toolStripBtnExcel,
            this.toolStripBtnWord,
            this.toolStripBtnPDF});
            this.toolStripOpcoes.Location = new System.Drawing.Point(0, 0);
            this.toolStripOpcoes.Name = "toolStripOpcoes";
            this.toolStripOpcoes.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripOpcoes.Size = new System.Drawing.Size(321, 39);
            this.toolStripOpcoes.Stretch = true;
            this.toolStripOpcoes.TabIndex = 5;
            this.toolStripOpcoes.Text = "toolStripOpcoes";
            // 
            // toolStripSeparatorOpcoes
            // 
            this.toolStripSeparatorOpcoes.Name = "toolStripSeparatorOpcoes";
            this.toolStripSeparatorOpcoes.Size = new System.Drawing.Size(6, 39);
            // 
            // FormAssistenteRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 120);
            this.Controls.Add(this.toolStripOpcoes);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlOpcaoVisualizacao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAssistenteRelatorio";
            this.Text = "Assistente de Relatório";
            this.pnlOpcaoVisualizacao.ResumeLayout(false);
            this.pnlOpcaoVisualizacao.PerformLayout();
            this.pnlBotoes.ResumeLayout(false);
            this.toolStripOpcoes.ResumeLayout(false);
            this.toolStripOpcoes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtOpcaoVisualizacao;
        private Label lblOpcaoVisualizacao;
        private Panel pnlOpcaoVisualizacao;
        private Panel pnlBotoes;
        private Button btnGerar;
        private ToolStripButton toolStripBtnTela;
        private ToolStripButton toolStripBtnImpressora;
        private ToolStripButton toolStripBtnExcel;
        private ToolStripButton toolStripBtnWord;
        private ToolStripButton toolStripBtnPDF;
        private ToolStrip toolStripOpcoes;
        private ToolStripSeparator toolStripSeparatorOpcoes;
    }
}