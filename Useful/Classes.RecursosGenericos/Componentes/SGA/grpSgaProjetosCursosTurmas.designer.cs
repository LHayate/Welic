namespace Classes.RecursosGenericos.Componentes.SGA
{
    partial class grpProjetosCursosTurmas
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
            this.txtEtapa = new System.Windows.Forms.Uniube.TextBoxUniube();
            this.lblEtapa = new System.Windows.Forms.Uniube.LabelUniube();
            this.txtTurma = new System.Windows.Forms.Uniube.TextBoxUniube();
            this.lblTurma = new System.Windows.Forms.Uniube.LabelUniube();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCursoDesc = new System.Windows.Forms.Uniube.TextBoxUniube();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtCurso = new System.Windows.Forms.Uniube.TextBoxUniube();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblCurso = new System.Windows.Forms.Uniube.LabelUniube();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPoloDesc = new System.Windows.Forms.Uniube.TextBoxUniube();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtPolo = new System.Windows.Forms.Uniube.TextBoxUniube();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblPolo = new System.Windows.Forms.Uniube.LabelUniube();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEtapa
            // 
            this.txtEtapa.BackColor = System.Drawing.Color.White;
            this.txtEtapa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEtapa.InformacaoToolTipCaminho = null;
            this.txtEtapa.InformacaoToolTipDescricao = null;
            this.txtEtapa.LimpaCampo = true;
            this.txtEtapa.Location = new System.Drawing.Point(179, 60);
            this.txtEtapa.MaxLength = 2;
            this.txtEtapa.Name = "txtEtapa";
            this.txtEtapa.NomeCampoDadosDataTable = "";
            this.txtEtapa.ParteDecimal = 0;
            this.txtEtapa.ParteInteira = 0;
            this.txtEtapa.Size = new System.Drawing.Size(64, 21);
            this.txtEtapa.TabIndex = 3;
            this.txtEtapa.TipoCampo = System.Windows.Forms.Uniube.TextBoxUniube.CTipoCampo.Normal;
            this.txtEtapa.TipoValor = System.Windows.Forms.Uniube.TextBoxUniube.CTipoValor.Numerico;
            this.txtEtapa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEtapa_KeyDown);
            this.txtEtapa.Leave += new System.EventHandler(this.txtEtapa_Leave);
            // 
            // lblEtapa
            // 
            this.lblEtapa.AutoSize = true;
            this.lblEtapa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtapa.Location = new System.Drawing.Point(125, 63);
            this.lblEtapa.Name = "lblEtapa";
            this.lblEtapa.Size = new System.Drawing.Size(48, 13);
            this.lblEtapa.TabIndex = 1142;
            this.lblEtapa.Text = "Etapa:";
            // 
            // txtTurma
            // 
            this.txtTurma.BackColor = System.Drawing.Color.White;
            this.txtTurma.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTurma.InformacaoToolTipCaminho = null;
            this.txtTurma.InformacaoToolTipDescricao = null;
            this.txtTurma.LimpaCampo = true;
            this.txtTurma.Location = new System.Drawing.Point(57, 60);
            this.txtTurma.MaxLength = 4;
            this.txtTurma.Name = "txtTurma";
            this.txtTurma.NomeCampoDadosDataTable = "";
            this.txtTurma.ParteDecimal = 0;
            this.txtTurma.ParteInteira = 0;
            this.txtTurma.Size = new System.Drawing.Size(64, 21);
            this.txtTurma.TabIndex = 2;
            this.txtTurma.TipoCampo = System.Windows.Forms.Uniube.TextBoxUniube.CTipoCampo.Normal;
            this.txtTurma.TipoValor = System.Windows.Forms.Uniube.TextBoxUniube.CTipoValor.Numerico;
            this.txtTurma.TextChanged += new System.EventHandler(this.txtTurma_TextChanged);
            this.txtTurma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTurma_KeyDown);
            this.txtTurma.Leave += new System.EventHandler(this.txtTurma_Leave);
            // 
            // lblTurma
            // 
            this.lblTurma.AutoSize = true;
            this.lblTurma.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurma.Location = new System.Drawing.Point(-2, 63);
            this.lblTurma.Name = "lblTurma";
            this.lblTurma.Size = new System.Drawing.Size(53, 13);
            this.lblTurma.TabIndex = 1140;
            this.lblTurma.Text = "Turma:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtCursoDesc);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.txtCurso);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 27);
            this.panel3.TabIndex = 0;
            // 
            // txtCursoDesc
            // 
            this.txtCursoDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.txtCursoDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCursoDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCursoDesc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCursoDesc.InformacaoToolTipCaminho = null;
            this.txtCursoDesc.InformacaoToolTipDescricao = null;
            this.txtCursoDesc.LimpaCampo = true;
            this.txtCursoDesc.Location = new System.Drawing.Point(129, 6);
            this.txtCursoDesc.MaxLength = 50;
            this.txtCursoDesc.Name = "txtCursoDesc";
            this.txtCursoDesc.NomeCampoDadosDataTable = "";
            this.txtCursoDesc.ParteDecimal = 0;
            this.txtCursoDesc.ParteInteira = 0;
            this.txtCursoDesc.ReadOnly = true;
            this.txtCursoDesc.Size = new System.Drawing.Size(435, 21);
            this.txtCursoDesc.TabIndex = 0;
            this.txtCursoDesc.TabStop = false;
            this.txtCursoDesc.TipoCampo = System.Windows.Forms.Uniube.TextBoxUniube.CTipoCampo.Normal;
            this.txtCursoDesc.TipoValor = System.Windows.Forms.Uniube.TextBoxUniube.CTipoValor.Geral;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(121, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(8, 21);
            this.panel5.TabIndex = 1145;
            // 
            // txtCurso
            // 
            this.txtCurso.BackColor = System.Drawing.Color.White;
            this.txtCurso.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCurso.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurso.InformacaoToolTipCaminho = null;
            this.txtCurso.InformacaoToolTipDescricao = null;
            this.txtCurso.LimpaCampo = true;
            this.txtCurso.Location = new System.Drawing.Point(57, 6);
            this.txtCurso.MaxLength = 4;
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.NomeCampoDadosDataTable = "";
            this.txtCurso.ParteDecimal = 0;
            this.txtCurso.ParteInteira = 0;
            this.txtCurso.Size = new System.Drawing.Size(64, 21);
            this.txtCurso.TabIndex = 0;
            this.txtCurso.TipoCampo = System.Windows.Forms.Uniube.TextBoxUniube.CTipoCampo.Normal;
            this.txtCurso.TipoValor = System.Windows.Forms.Uniube.TextBoxUniube.CTipoValor.Numerico;
            this.txtCurso.TextChanged += new System.EventHandler(this.txtCurso_TextChanged);
            this.txtCurso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurso_KeyDown);
            this.txtCurso.Leave += new System.EventHandler(this.txtCurso_Leave);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblCurso);
            this.panel6.Controls.Add(this.panel13);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(57, 21);
            this.panel6.TabIndex = 1144;
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCurso.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurso.Location = new System.Drawing.Point(3, 3);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(48, 13);
            this.lblCurso.TabIndex = 1149;
            this.lblCurso.Text = "Curso:";
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel13.Location = new System.Drawing.Point(51, 3);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(6, 18);
            this.panel13.TabIndex = 1150;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(57, 3);
            this.panel7.TabIndex = 1148;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(564, 6);
            this.panel8.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPoloDesc);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.txtPolo);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel14);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 27);
            this.panel1.TabIndex = 1;
            // 
            // txtPoloDesc
            // 
            this.txtPoloDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.txtPoloDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPoloDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPoloDesc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoloDesc.InformacaoToolTipCaminho = null;
            this.txtPoloDesc.InformacaoToolTipDescricao = null;
            this.txtPoloDesc.LimpaCampo = true;
            this.txtPoloDesc.Location = new System.Drawing.Point(129, 6);
            this.txtPoloDesc.MaxLength = 50;
            this.txtPoloDesc.Name = "txtPoloDesc";
            this.txtPoloDesc.NomeCampoDadosDataTable = "";
            this.txtPoloDesc.ParteDecimal = 0;
            this.txtPoloDesc.ParteInteira = 0;
            this.txtPoloDesc.ReadOnly = true;
            this.txtPoloDesc.Size = new System.Drawing.Size(435, 21);
            this.txtPoloDesc.TabIndex = 0;
            this.txtPoloDesc.TabStop = false;
            this.txtPoloDesc.TipoCampo = System.Windows.Forms.Uniube.TextBoxUniube.CTipoCampo.Normal;
            this.txtPoloDesc.TipoValor = System.Windows.Forms.Uniube.TextBoxUniube.CTipoValor.Geral;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(121, 6);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(8, 21);
            this.panel9.TabIndex = 1145;
            // 
            // txtPolo
            // 
            this.txtPolo.BackColor = System.Drawing.Color.White;
            this.txtPolo.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPolo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPolo.InformacaoToolTipCaminho = null;
            this.txtPolo.InformacaoToolTipDescricao = null;
            this.txtPolo.LimpaCampo = true;
            this.txtPolo.Location = new System.Drawing.Point(57, 6);
            this.txtPolo.MaxLength = 4;
            this.txtPolo.Name = "txtPolo";
            this.txtPolo.NomeCampoDadosDataTable = "";
            this.txtPolo.ParteDecimal = 0;
            this.txtPolo.ParteInteira = 0;
            this.txtPolo.Size = new System.Drawing.Size(64, 21);
            this.txtPolo.TabIndex = 0;
            this.txtPolo.TipoCampo = System.Windows.Forms.Uniube.TextBoxUniube.CTipoCampo.Normal;
            this.txtPolo.TipoValor = System.Windows.Forms.Uniube.TextBoxUniube.CTipoValor.Numerico;
            this.txtPolo.TextChanged += new System.EventHandler(this.txtPolo_TextChanged);
            this.txtPolo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPolo_KeyDown);
            this.txtPolo.Leave += new System.EventHandler(this.txtPolo_Leave);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.lblPolo);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 6);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(57, 21);
            this.panel10.TabIndex = 1144;
            // 
            // lblPolo
            // 
            this.lblPolo.AutoSize = true;
            this.lblPolo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPolo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPolo.Location = new System.Drawing.Point(12, 3);
            this.lblPolo.Name = "lblPolo";
            this.lblPolo.Size = new System.Drawing.Size(39, 13);
            this.lblPolo.TabIndex = 1149;
            this.lblPolo.Text = "Polo:";
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(51, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(6, 18);
            this.panel11.TabIndex = 1150;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(57, 3);
            this.panel12.TabIndex = 1148;
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(564, 6);
            this.panel14.TabIndex = 1146;
            // 
            // grpProjetosCursosTurmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtEtapa);
            this.Controls.Add(this.lblEtapa);
            this.Controls.Add(this.txtTurma);
            this.Controls.Add(this.lblTurma);
            this.Name = "grpProjetosCursosTurmas";
            this.Size = new System.Drawing.Size(564, 81);
            this.Load += new System.EventHandler(this.grpProjetosCursosTurmas_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Uniube.TextBoxUniube txtEtapa;
        public System.Windows.Forms.Uniube.TextBoxUniube txtTurma;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Uniube.TextBoxUniube txtCurso;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel9;
        public System.Windows.Forms.Uniube.TextBoxUniube txtPolo;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel14;
        public System.Windows.Forms.Uniube.TextBoxUniube txtCursoDesc;
        public System.Windows.Forms.Uniube.TextBoxUniube txtPoloDesc;
        public System.Windows.Forms.Uniube.LabelUniube lblEtapa;
        public System.Windows.Forms.Uniube.LabelUniube lblTurma;
        public System.Windows.Forms.Uniube.LabelUniube lblCurso;
        public System.Windows.Forms.Uniube.LabelUniube lblPolo;

    }
}
