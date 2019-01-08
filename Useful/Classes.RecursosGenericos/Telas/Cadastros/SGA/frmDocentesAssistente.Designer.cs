namespace Classes.RecursosGenericos.Telas.Cadastros.SGA
{
    partial class frmDocentesAssistente
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
            this.colMatricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtAdmissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCargoDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.pnlBuscar.SuspendLayout();
            this.pnlFiltrosBottom.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMatricula,
            this.colNome,
            this.colDtAdmissao,
            this.colCargoDesc});
            this.dgv.ReadOnly = true;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick_1);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(360, 3);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // splitContainer1
            // 
            // 
            // panel2
            // 
            this.panel2.Visible = false;
            // 
            // colMatricula
            // 
            this.colMatricula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMatricula.DataPropertyName = "matricula";
            this.colMatricula.HeaderText = "Matrícula";
            this.colMatricula.Name = "colMatricula";
            this.colMatricula.ReadOnly = true;
            this.colMatricula.Width = 76;
            // 
            // colNome
            // 
            this.colNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNome.DataPropertyName = "nome";
            this.colNome.HeaderText = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            // 
            // colDtAdmissao
            // 
            this.colDtAdmissao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDtAdmissao.DataPropertyName = "dt_admissao";
            this.colDtAdmissao.HeaderText = "Admissão";
            this.colDtAdmissao.Name = "colDtAdmissao";
            this.colDtAdmissao.ReadOnly = true;
            this.colDtAdmissao.Width = 94;
            // 
            // colCargoDesc
            // 
            this.colCargoDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCargoDesc.DataPropertyName = "cargo_desc";
            this.colCargoDesc.FillWeight = 75F;
            this.colCargoDesc.HeaderText = "Cargo";
            this.colCargoDesc.Name = "colCargoDesc";
            this.colCargoDesc.ReadOnly = true;
            // 
            // frmDocentesAssistente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 393);
            this.CodigoSeguranca = "BASICO0005";
            this.Name = "frmDocentesAssistente";
            this.Text = "frmDocentesAssistente";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlBuscar.ResumeLayout(false);
            this.pnlFiltrosBottom.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colMatricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtAdmissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCargoDesc;

    }
}