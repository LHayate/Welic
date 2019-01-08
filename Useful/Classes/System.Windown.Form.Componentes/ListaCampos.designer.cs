namespace UseFul.Forms.Welic
{
    partial class ListaCampos
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
            this.pnListaCampos = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listGeral = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCampo = new UseFul.Forms.Welic.TextBoxWelic();
            this.pnchkChek = new System.Windows.Forms.Panel();
            this.lbListaCampos = new UseFul.Forms.Welic.LabelWelic();
            this.chkListaCampos = new System.Windows.Forms.CheckBox();
            this.tltInformação = new System.Windows.Forms.ToolTip(this.components);
            this.pnListaCampos.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnchkChek.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnListaCampos
            // 
            this.pnListaCampos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnListaCampos.Controls.Add(this.panel2);
            this.pnListaCampos.Controls.Add(this.panel1);
            this.pnListaCampos.Controls.Add(this.pnchkChek);
            this.pnListaCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnListaCampos.Location = new System.Drawing.Point(0, 0);
            this.pnListaCampos.Margin = new System.Windows.Forms.Padding(0);
            this.pnListaCampos.Name = "pnListaCampos";
            this.pnListaCampos.Size = new System.Drawing.Size(136, 93);
            this.pnListaCampos.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listGeral);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(63, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(71, 72);
            this.panel2.TabIndex = 4;
            // 
            // listGeral
            // 
            this.listGeral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listGeral.Enabled = false;
            this.listGeral.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listGeral.FormattingEnabled = true;
            this.listGeral.Location = new System.Drawing.Point(0, 0);
            this.listGeral.Margin = new System.Windows.Forms.Padding(0);
            this.listGeral.Name = "listGeral";
            this.listGeral.ScrollAlwaysVisible = true;
            this.listGeral.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listGeral.Size = new System.Drawing.Size(71, 72);
            this.listGeral.TabIndex = 3;
            this.listGeral.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listGeral_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCampo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(63, 72);
            this.panel1.TabIndex = 3;
            // 
            // txtCampo
            // 
            this.txtCampo.BackColor = System.Drawing.Color.White;
            this.txtCampo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCampo.Enabled = false;
            this.txtCampo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCampo.LimpaCampo = true;
            this.txtCampo.Location = new System.Drawing.Point(0, 0);
            this.txtCampo.Name = "txtCampo";
            this.txtCampo.ParteDecimal = 0;
            this.txtCampo.ParteInteira = 0;
            this.txtCampo.Size = new System.Drawing.Size(63, 21);
            this.txtCampo.TabIndex = 4;
            this.txtCampo.TipoCampo = UseFul.Forms.Welic.TextBoxWelic.CTipoCampo.Normal;
            this.txtCampo.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Geral;
            this.tltInformação.SetToolTip(this.txtCampo, "Pressione(F3): para pesquisar");
            this.txtCampo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCampo_KeyDown);
            // 
            // pnchkChek
            // 
            this.pnchkChek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.pnchkChek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnchkChek.Controls.Add(this.lbListaCampos);
            this.pnchkChek.Controls.Add(this.chkListaCampos);
            this.pnchkChek.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnchkChek.Location = new System.Drawing.Point(0, 0);
            this.pnchkChek.Margin = new System.Windows.Forms.Padding(0);
            this.pnchkChek.Name = "pnchkChek";
            this.pnchkChek.Size = new System.Drawing.Size(134, 19);
            this.pnchkChek.TabIndex = 0;
            // 
            // lbListaCampos
            // 
            this.lbListaCampos.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbListaCampos.Location = new System.Drawing.Point(21, 1);
            this.lbListaCampos.Margin = new System.Windows.Forms.Padding(0);
            this.lbListaCampos.Name = "lbListaCampos";
            this.lbListaCampos.Size = new System.Drawing.Size(112, 13);
            this.lbListaCampos.TabIndex = 2;
            this.lbListaCampos.Text = "Lista Campos";
            // 
            // chkListaCampos
            // 
            this.chkListaCampos.AutoSize = true;
            this.chkListaCampos.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListaCampos.Location = new System.Drawing.Point(3, 1);
            this.chkListaCampos.Margin = new System.Windows.Forms.Padding(0);
            this.chkListaCampos.Name = "chkListaCampos";
            this.chkListaCampos.Size = new System.Drawing.Size(15, 14);
            this.chkListaCampos.TabIndex = 1;
            this.chkListaCampos.UseVisualStyleBackColor = true;
            this.chkListaCampos.CheckedChanged += new System.EventHandler(this.chkListaCampos_CheckedChanged);
            // 
            // tltInformação
            // 
            this.tltInformação.AutoPopDelay = 5000;
            this.tltInformação.InitialDelay = 50;
            this.tltInformação.ReshowDelay = 100;
            // 
            // ListaCampos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.pnListaCampos);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ListaCampos";
            this.Size = new System.Drawing.Size(136, 93);
            this.pnListaCampos.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnchkChek.ResumeLayout(false);
            this.pnchkChek.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnListaCampos;
        public UseFul.Forms.Welic.LabelWelic lbListaCampos;
        public System.Windows.Forms.CheckBox chkListaCampos;
        public System.Windows.Forms.Panel pnchkChek;
        private System.Windows.Forms.ToolTip tltInformação;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ListBox listGeral;
        private System.Windows.Forms.Panel panel1;
        public UseFul.Forms.Welic.TextBoxWelic txtCampo;
    }
}
