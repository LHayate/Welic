namespace IntervaloCampos
{
    partial class IntervaloCampos2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelWelic1 = new UseFul.Forms.Welic.PanelWelic(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelWelic2 = new UseFul.Forms.Welic.PanelWelic(this.components);
            this.chkTitulo = new UseFul.Forms.Welic.CheckBoxWelic(this.components);
            this.txtFinal = new UseFul.Forms.Welic.TextBoxWelic();
            this.labelWelic2 = new UseFul.Forms.Welic.LabelWelic();
            this.txtInicial = new UseFul.Forms.Welic.TextBoxWelic();
            this.labelWelic1 = new UseFul.Forms.Welic.LabelWelic();
            this.panelWelic1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWelic1
            // 
            this.panelWelic1.BackColor = System.Drawing.Color.GhostWhite;
            this.panelWelic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWelic1.Controls.Add(this.panel1);
            this.panelWelic1.Controls.Add(this.txtFinal);
            this.panelWelic1.Controls.Add(this.labelWelic2);
            this.panelWelic1.Controls.Add(this.txtInicial);
            this.panelWelic1.Controls.Add(this.labelWelic1);
            this.panelWelic1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWelic1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelWelic1.Location = new System.Drawing.Point(0, 0);
            this.panelWelic1.Name = "panelWelic1";
            this.panelWelic1.Size = new System.Drawing.Size(182, 62);
            this.panelWelic1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.panelWelic2);
            this.panel1.Controls.Add(this.chkTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 20);
            this.panel1.TabIndex = 9;
            // 
            // panelWelic2
            // 
            this.panelWelic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWelic2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelWelic2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelWelic2.Location = new System.Drawing.Point(0, 19);
            this.panelWelic2.Name = "panelWelic2";
            this.panelWelic2.Size = new System.Drawing.Size(180, 1);
            this.panelWelic2.TabIndex = 11;
            // 
            // chkTitulo
            // 
            this.chkTitulo.AutoSize = true;
            this.chkTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTitulo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTitulo.LimpaCampo = true;
            this.chkTitulo.Location = new System.Drawing.Point(0, 0);
            this.chkTitulo.Name = "chkTitulo";
            this.chkTitulo.Size = new System.Drawing.Size(180, 20);
            this.chkTitulo.TabIndex = 1;
            this.chkTitulo.Text = "Inter. Campos";
            this.chkTitulo.UseVisualStyleBackColor = true;
            this.chkTitulo.CheckedChanged += new System.EventHandler(this.chkTitulo_CheckedChanged);
            // 
            // txtFinal
            // 
            this.txtFinal.BackColor = System.Drawing.Color.White;
            this.txtFinal.Enabled = false;
            this.txtFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinal.LimpaCampo = true;
            this.txtFinal.Location = new System.Drawing.Point(107, 28);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(56, 21);
            this.txtFinal.TabIndex = 8;
            this.txtFinal.TipoCampo = UseFul.Forms.Welic.TextBoxWelic.CTipoCampo.Normal;
            this.txtFinal.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Geral;
            // 
            // labelWelic2
            // 
            this.labelWelic2.AutoSize = true;
            this.labelWelic2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelic2.Location = new System.Drawing.Point(88, 31);
            this.labelWelic2.Name = "labelWelic2";
            this.labelWelic2.Size = new System.Drawing.Size(15, 13);
            this.labelWelic2.TabIndex = 7;
            this.labelWelic2.Text = "a";
            // 
            // txtInicial
            // 
            this.txtInicial.BackColor = System.Drawing.Color.White;
            this.txtInicial.Enabled = false;
            this.txtInicial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicial.LimpaCampo = true;
            this.txtInicial.Location = new System.Drawing.Point(29, 28);
            this.txtInicial.Name = "txtInicial";
            this.txtInicial.Size = new System.Drawing.Size(56, 21);
            this.txtInicial.TabIndex = 6;
            this.txtInicial.TipoCampo = UseFul.Forms.Welic.TextBoxWelic.CTipoCampo.Normal;
            this.txtInicial.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Geral;
            this.txtInicial.TextChanged += new System.EventHandler(this.txtInicial_TextChanged);
            this.txtInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInicial_KeyDown);
            this.txtInicial.Leave += new System.EventHandler(this.txtInicial_Leave);
            // 
            // labelWelic1
            // 
            this.labelWelic1.AutoSize = true;
            this.labelWelic1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelic1.Location = new System.Drawing.Point(3, 31);
            this.labelWelic1.Name = "labelWelic1";
            this.labelWelic1.Size = new System.Drawing.Size(23, 13);
            this.labelWelic1.TabIndex = 5;
            this.labelWelic1.Text = "de";
            // 
            // IntervaloCampos2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelWelic1);
            this.Name = "IntervaloCampos2";
            this.Size = new System.Drawing.Size(182, 62);
            this.panelWelic1.ResumeLayout(false);
            this.panelWelic1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UseFul.Forms.Welic.PanelWelic panelWelic1;
        private UseFul.Forms.Welic.LabelWelic labelWelic2;
        private UseFul.Forms.Welic.LabelWelic labelWelic1;
        public UseFul.Forms.Welic.TextBoxWelic txtFinal;
        public UseFul.Forms.Welic.TextBoxWelic txtInicial;
        private System.Windows.Forms.Panel panel1;
        private UseFul.Forms.Welic.PanelWelic panelWelic2;
        public UseFul.Forms.Welic.CheckBoxWelic chkTitulo;
    }
}
