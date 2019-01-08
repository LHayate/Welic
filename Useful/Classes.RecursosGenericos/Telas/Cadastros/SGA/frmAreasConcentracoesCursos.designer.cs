namespace Classes.RecursosGenericos.Telas.Cadastros.SGA
{
    partial class frmAreasConcentracoesCursos
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
            this.txtDescricao = new System.Windows.Forms.Uniube.TextBoxUniube();
            this.labelUniube2 = new System.Windows.Forms.Uniube.LabelUniube();
            this.txtResponsabilidade = new System.Windows.Forms.Uniube.TextBoxUniube();
            this.labelUniube1 = new System.Windows.Forms.Uniube.LabelUniube();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.InformacaoToolTipCaminho = null;
            this.txtDescricao.InformacaoToolTipDescricao = null;
            this.txtDescricao.LimpaCampo = true;
            this.txtDescricao.Location = new System.Drawing.Point(86, 61);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.NomeCampoDadosDataTable = "descricao";
            this.txtDescricao.ParteDecimal = 0;
            this.txtDescricao.ParteInteira = 0;
            this.txtDescricao.Size = new System.Drawing.Size(420, 48);
            this.txtDescricao.TabIndex = 1013;
            this.txtDescricao.TipoCampo = System.Windows.Forms.Uniube.TextBoxUniube.CTipoCampo.Obrigatorio;
            this.txtDescricao.TipoValor = System.Windows.Forms.Uniube.TextBoxUniube.CTipoValor.Geral;
            // 
            // labelUniube2
            // 
            this.labelUniube2.AutoSize = true;
            this.labelUniube2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUniube2.Location = new System.Drawing.Point(5, 61);
            this.labelUniube2.Name = "labelUniube2";
            this.labelUniube2.Size = new System.Drawing.Size(75, 13);
            this.labelUniube2.TabIndex = 1015;
            this.labelUniube2.Text = "Descrição:";
            // 
            // txtResponsabilidade
            // 
            this.txtResponsabilidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.txtResponsabilidade.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResponsabilidade.InformacaoToolTipCaminho = null;
            this.txtResponsabilidade.InformacaoToolTipDescricao = null;
            this.txtResponsabilidade.LimpaCampo = true;
            this.txtResponsabilidade.Location = new System.Drawing.Point(86, 34);
            this.txtResponsabilidade.Name = "txtResponsabilidade";
            this.txtResponsabilidade.NomeCampoDadosDataTable = "area";
            this.txtResponsabilidade.ParteDecimal = 0;
            this.txtResponsabilidade.ParteInteira = 0;
            this.txtResponsabilidade.Size = new System.Drawing.Size(64, 21);
            this.txtResponsabilidade.TabIndex = 1012;
            this.txtResponsabilidade.TipoCampo = System.Windows.Forms.Uniube.TextBoxUniube.CTipoCampo.ChaveAutoIncremento;
            this.txtResponsabilidade.TipoValor = System.Windows.Forms.Uniube.TextBoxUniube.CTipoValor.Numerico;
            // 
            // labelUniube1
            // 
            this.labelUniube1.AutoSize = true;
            this.labelUniube1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUniube1.Location = new System.Drawing.Point(38, 37);
            this.labelUniube1.Name = "labelUniube1";
            this.labelUniube1.Size = new System.Drawing.Size(42, 13);
            this.labelUniube1.TabIndex = 1014;
            this.labelUniube1.Text = "Área:";
            // 
            // frmCadastroAreasConcentracoesCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 139);
            this.CodigoSeguranca = "BASICO0004";
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.labelUniube2);
            this.Controls.Add(this.txtResponsabilidade);
            this.Controls.Add(this.labelUniube1);
            this.Name = "frmCadastroAreasConcentracoesCursos";
            this.Text = "Cadastro de Áreas de Concentrações de Cursos";
            this.Controls.SetChildIndex(this.labelUniube1, 0);
            this.Controls.SetChildIndex(this.txtResponsabilidade, 0);
            this.Controls.SetChildIndex(this.labelUniube2, 0);
            this.Controls.SetChildIndex(this.txtDescricao, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Uniube.TextBoxUniube txtDescricao;
        private System.Windows.Forms.Uniube.LabelUniube labelUniube2;
        private System.Windows.Forms.Uniube.TextBoxUniube txtResponsabilidade;
        private System.Windows.Forms.Uniube.LabelUniube labelUniube1;
    }
}