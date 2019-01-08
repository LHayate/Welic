namespace Classes.RecursosGenericos.Telas.Cadastros.SGA
{
    partial class frmCustosDiretosAssistente
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
            this.colCusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustoDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.colCusto,
            this.ColCustoDesc});
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(847, 321);
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick_1);
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Size = new System.Drawing.Size(853, 75);
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.Location = new System.Drawing.Point(0, 41);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(360, 3);
            // 
            // btnNovoRegistro
            // 
            this.btnNovoRegistro.Location = new System.Drawing.Point(669, 3);
            this.btnNovoRegistro.Size = new System.Drawing.Size(178, 28);
            this.btnNovoRegistro.Text = "         Novo Custo Direto";
            // 
            // panel9
            // 
            this.panel9.Size = new System.Drawing.Size(3, 389);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Panel1Collapsed = true;
            this.splitContainer1.SplitterDistance = 79;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3, 355);
            this.panel2.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Size = new System.Drawing.Size(3, 389);
            // 
            // colCusto
            // 
            this.colCusto.DataPropertyName = "custo";
            this.colCusto.HeaderText = "Custo";
            this.colCusto.Name = "colCusto";
            this.colCusto.ReadOnly = true;
            this.colCusto.Width = 67;
            // 
            // ColCustoDesc
            // 
            this.ColCustoDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColCustoDesc.DataPropertyName = "descricao";
            this.ColCustoDesc.HeaderText = "Descrição do Custo";
            this.ColCustoDesc.Name = "ColCustoDesc";
            this.ColCustoDesc.ReadOnly = true;
            // 
            // frmCadastroCustosDiretosAssistente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 393);
            this.CodigoSeguranca = "BASICO0001";
            this.Name = "frmCadastroCustosDiretosAssistente";
            this.Text = "Cadastro de Custos Diretos";
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

        private System.Windows.Forms.DataGridViewTextBoxColumn colCusto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustoDesc;


    }
}