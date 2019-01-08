namespace UseFul.Forms.Welic
{
    partial class frmBuscaInformacaoGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaInformacaoGrid));
            this.labelWelic1 = new UseFul.Forms.Welic.LabelWelic();
            this.txtProcurar = new UseFul.Forms.Welic.TextBoxWelic();
            this.btnAnterior = new UseFul.Forms.Welic.ButtonWelic();
            this.btnProximo = new UseFul.Forms.Welic.ButtonWelic();
            this.lblContagemRegistros = new UseFul.Forms.Welic.LabelWelic();
            this.SuspendLayout();
            // 
            // labelWelic1
            // 
            this.labelWelic1.AutoSize = true;
            this.labelWelic1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelic1.Location = new System.Drawing.Point(3, 8);
            this.labelWelic1.Name = "labelWelic1";
            this.labelWelic1.Size = new System.Drawing.Size(55, 13);
            this.labelWelic1.TabIndex = 0;
            this.labelWelic1.Text = "Buscar:";
            // 
            // txtProcurar
            // 
            this.txtProcurar._RecursosGenericosSqlF3 = null;
            this.txtProcurar._RecursosGenericosSqlLeave = null;
            this.txtProcurar.BackColor = System.Drawing.Color.White;
            this.txtProcurar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProcurar.ExibirIconePesquisa = false;
            this.txtProcurar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcurar.InformacaoToolTipCaminho = null;
            this.txtProcurar.InformacaoToolTipDescricao = null;
            this.txtProcurar.LimpaCampo = true;
            this.txtProcurar.Location = new System.Drawing.Point(64, 5);
            this.txtProcurar.Name = "txtProcurar";
            this.txtProcurar.NomeCampoDadosDataTable = null;
            this.txtProcurar.ParteDecimal = 0;
            this.txtProcurar.ParteInteira = 0;
            this.txtProcurar.SegurancaCCusto = UseFul.Forms.Welic.TextBoxWelic.CSegurancaCentroCusto.NaoUtilizado;
            this.txtProcurar.Size = new System.Drawing.Size(325, 21);
            this.txtProcurar.TabIndex = 1;
            this.txtProcurar.TipoCampo = UseFul.Forms.Welic.TextBoxWelic.CTipoCampo.Normal;
            this.txtProcurar.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Geral;
            this.txtProcurar.TextChanged += new System.EventHandler(this.txtProcurar_TextChanged);
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
            this.btnAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnterior.Location = new System.Drawing.Point(199, 32);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(92, 23);
            this.btnAnterior.TabIndex = 2;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnProximo
            // 
            this.btnProximo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.btnProximo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProximo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProximo.Image = ((System.Drawing.Image)(resources.GetObject("btnProximo.Image")));
            this.btnProximo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProximo.Location = new System.Drawing.Point(297, 32);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(92, 23);
            this.btnProximo.TabIndex = 3;
            this.btnProximo.Text = "Próximo";
            this.btnProximo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProximo.UseVisualStyleBackColor = true;
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // lblContagemRegistros
            // 
            this.lblContagemRegistros.AutoSize = true;
            this.lblContagemRegistros.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContagemRegistros.Location = new System.Drawing.Point(3, 37);
            this.lblContagemRegistros.Name = "lblContagemRegistros";
            this.lblContagemRegistros.Size = new System.Drawing.Size(168, 13);
            this.lblContagemRegistros.TabIndex = 4;
            this.lblContagemRegistros.Text = "Registro 123456 de 123456.";
            // 
            // frmBuscaInformacaoGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 60);
            this.Controls.Add(this.lblContagemRegistros);
            this.Controls.Add(this.btnProximo);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.txtProcurar);
            this.Controls.Add(this.labelWelic1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBuscaInformacaoGrid";
            this.ShowInTaskbar = false;
            this.Text = "Buscar Informações";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelWelic labelWelic1;
        private TextBoxWelic txtProcurar;
        private ButtonWelic btnAnterior;
        private ButtonWelic btnProximo;
        private LabelWelic lblContagemRegistros;

    }
}