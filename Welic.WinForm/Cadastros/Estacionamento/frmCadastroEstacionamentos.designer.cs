namespace Welic.WinForm.Cadastros.Estacionamento
{
    partial class FrmCadastroEstacionamentos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroEstacionamentos));
            this.labelWelic1 = new UseFul.Forms.Welic.LabelWelic();
            this.txtEstacionamento = new UseFul.Forms.Welic.TextBoxWelic();
            this.labelWelic2 = new UseFul.Forms.Welic.LabelWelic();
            this.txtNome = new UseFul.Forms.Welic.TextBoxWelic();
            this.labelWelic3 = new UseFul.Forms.Welic.LabelWelic();
            this.txtRelacao = new UseFul.Forms.Welic.TextBoxWelic();
            this.dgvVagas = new UseFul.Forms.Welic.DataGridViewWelic();
            this.ColIdEstacionamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTipoVaga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTipoVeiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVagaExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.BindingVagas = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddVagas = new UseFul.Forms.Welic.ButtonWelic();
            this.pnBlocoVagaCurso = new UseFul.Forms.Welic.PanelWelic(this.components);
            this.pnEstacionamento = new UseFul.Forms.Welic.PanelWelic(this.components);
            this.chkValidaVencimento = new UseFul.Forms.Welic.CheckBoxWelic(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVagas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingVagas)).BeginInit();
            this.pnBlocoVagaCurso.SuspendLayout();
            this.pnEstacionamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWelic1
            // 
            this.labelWelic1.AutoSize = true;
            this.labelWelic1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelic1.Location = new System.Drawing.Point(3, 8);
            this.labelWelic1.Name = "labelWelic1";
            this.labelWelic1.Size = new System.Drawing.Size(115, 13);
            this.labelWelic1.TabIndex = 1001;
            this.labelWelic1.Text = "Estacionamento:";
            // 
            // txtEstacionamento
            // 
            this.txtEstacionamento._RecursosGenericosSqlF3 = null;
            this.txtEstacionamento._RecursosGenericosSqlLeave = null;
            this.txtEstacionamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.txtEstacionamento.ExibirIconePesquisa = false;
            this.txtEstacionamento.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstacionamento.InformacaoToolTipCaminho = null;
            this.txtEstacionamento.InformacaoToolTipDescricao = null;
            this.txtEstacionamento.LimpaCampo = true;
            this.txtEstacionamento.Location = new System.Drawing.Point(164, 5);
            this.txtEstacionamento.Name = "txtEstacionamento";
            this.txtEstacionamento.NomeCampoDadosDataTable = null;
            this.txtEstacionamento.ParteDecimal = 0;
            this.txtEstacionamento.ParteInteira = 0;
            this.txtEstacionamento.SegurancaCCusto = UseFul.Forms.Welic.TextBoxWelic.CSegurancaCentroCusto.NaoUtilizado;
            this.txtEstacionamento.Size = new System.Drawing.Size(67, 21);
            this.txtEstacionamento.TabIndex = 0;
            this.txtEstacionamento.TipoCampo = UseFul.Forms.Welic.TextBoxWelic.CTipoCampo.ChaveAutoIncremento;
            this.txtEstacionamento.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Numerico;
            this.txtEstacionamento.TextChanged += new System.EventHandler(this.txtEstacionamento_TextChanged);
            this.txtEstacionamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEstacionamento_KeyDown);
            this.txtEstacionamento.Leave += new System.EventHandler(this.txtEstacionamento_Leave);
            // 
            // labelWelic2
            // 
            this.labelWelic2.AutoSize = true;
            this.labelWelic2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelic2.Location = new System.Drawing.Point(3, 38);
            this.labelWelic2.Name = "labelWelic2";
            this.labelWelic2.Size = new System.Drawing.Size(48, 13);
            this.labelWelic2.TabIndex = 1003;
            this.labelWelic2.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome._RecursosGenericosSqlF3 = null;
            this.txtNome._RecursosGenericosSqlLeave = null;
            this.txtNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.ExibirIconePesquisa = false;
            this.txtNome.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.InformacaoToolTipCaminho = null;
            this.txtNome.InformacaoToolTipDescricao = null;
            this.txtNome.LimpaCampo = true;
            this.txtNome.Location = new System.Drawing.Point(164, 35);
            this.txtNome.Name = "txtNome";
            this.txtNome.NomeCampoDadosDataTable = null;
            this.txtNome.ParteDecimal = 0;
            this.txtNome.ParteInteira = 0;
            this.txtNome.SegurancaCCusto = UseFul.Forms.Welic.TextBoxWelic.CSegurancaCentroCusto.NaoUtilizado;
            this.txtNome.Size = new System.Drawing.Size(494, 21);
            this.txtNome.TabIndex = 1;
            this.txtNome.TipoCampo = UseFul.Forms.Welic.TextBoxWelic.CTipoCampo.Obrigatorio;
            this.txtNome.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Geral;
            // 
            // labelWelic3
            // 
            this.labelWelic3.AutoSize = true;
            this.labelWelic3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelic3.Location = new System.Drawing.Point(3, 65);
            this.labelWelic3.Name = "labelWelic3";
            this.labelWelic3.Size = new System.Drawing.Size(155, 13);
            this.labelWelic3.TabIndex = 1005;
            this.labelWelic3.Text = "Relação Motos/Carros:";
            // 
            // txtRelacao
            // 
            this.txtRelacao._RecursosGenericosSqlF3 = null;
            this.txtRelacao._RecursosGenericosSqlLeave = null;
            this.txtRelacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.txtRelacao.ExibirIconePesquisa = false;
            this.txtRelacao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRelacao.InformacaoToolTipCaminho = null;
            this.txtRelacao.InformacaoToolTipDescricao = null;
            this.txtRelacao.LimpaCampo = true;
            this.txtRelacao.Location = new System.Drawing.Point(164, 62);
            this.txtRelacao.Name = "txtRelacao";
            this.txtRelacao.NomeCampoDadosDataTable = null;
            this.txtRelacao.ParteDecimal = 0;
            this.txtRelacao.ParteInteira = 0;
            this.txtRelacao.SegurancaCCusto = UseFul.Forms.Welic.TextBoxWelic.CSegurancaCentroCusto.NaoUtilizado;
            this.txtRelacao.Size = new System.Drawing.Size(67, 21);
            this.txtRelacao.TabIndex = 2;
            this.txtRelacao.TipoCampo = UseFul.Forms.Welic.TextBoxWelic.CTipoCampo.Obrigatorio;
            this.txtRelacao.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Numerico;
            // 
            // dgvVagas
            // 
            this.dgvVagas._UtilizarShift = false;
            this.dgvVagas.AllowUserToAddRows = false;
            this.dgvVagas.AllowUserToDeleteRows = false;
            this.dgvVagas.AllowUserToResizeColumns = false;
            this.dgvVagas.AllowUserToResizeRows = false;
            this.dgvVagas.AutoGenerateColumns = false;
            this.dgvVagas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvVagas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVagas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVagas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVagas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVagas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIdEstacionamento,
            this.ColTipoVaga,
            this.ColQuantidade,
            this.ColTipoVeiculo,
            this.colVagaExcluir});
            this.dgvVagas.DataSource = this.BindingVagas;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVagas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVagas.EnableHeadersVisualStyles = false;
            this.dgvVagas.HabilitarColunasInvisiveisExportarExcel = false;
            this.dgvVagas.LimpaCampo = true;
            this.dgvVagas.Location = new System.Drawing.Point(6, 37);
            this.dgvVagas.Name = "dgvVagas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVagas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVagas.RowHeadersVisible = false;
            this.dgvVagas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvVagas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVagas.Size = new System.Drawing.Size(666, 133);
            this.dgvVagas.TabIndex = 4;
            this.dgvVagas.TabStop = false;
            this.dgvVagas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVagas_CellClick);
            // 
            // ColIdEstacionamento
            // 
            this.ColIdEstacionamento.DataPropertyName = "IdEstacionamento";
            this.ColIdEstacionamento.HeaderText = "IdEstacionamento";
            this.ColIdEstacionamento.Name = "ColIdEstacionamento";
            this.ColIdEstacionamento.Visible = false;
            this.ColIdEstacionamento.Width = 130;
            // 
            // ColTipoVaga
            // 
            this.ColTipoVaga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColTipoVaga.DataPropertyName = "TipoVaga";
            this.ColTipoVaga.HeaderText = "Tipo de Vaga";
            this.ColTipoVaga.Name = "ColTipoVaga";
            // 
            // ColQuantidade
            // 
            this.ColQuantidade.DataPropertyName = "Quantidade";
            this.ColQuantidade.HeaderText = "Quantidade";
            this.ColQuantidade.Name = "ColQuantidade";
            this.ColQuantidade.Width = 105;
            // 
            // ColTipoVeiculo
            // 
            this.ColTipoVeiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColTipoVeiculo.DataPropertyName = "TipoVeiculo";
            this.ColTipoVeiculo.HeaderText = "Tipo Veiculo";
            this.ColTipoVeiculo.Name = "ColTipoVeiculo";
            this.ColTipoVeiculo.Width = 150;
            // 
            // colVagaExcluir
            // 
            this.colVagaExcluir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colVagaExcluir.HeaderText = "";
            this.colVagaExcluir.Image = ((System.Drawing.Image)(resources.GetObject("colVagaExcluir.Image")));
            this.colVagaExcluir.MinimumWidth = 35;
            this.colVagaExcluir.Name = "colVagaExcluir";
            this.colVagaExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colVagaExcluir.Width = 35;
            // 
            // BindingVagas
            // 
            this.BindingVagas.DataSource = typeof(UseFul.ClientApi.Dtos.EstacionamentoVagaDto);
            // 
            // btnAddVagas
            // 
            this.btnAddVagas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.btnAddVagas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVagas.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVagas.Image = ((System.Drawing.Image)(resources.GetObject("btnAddVagas.Image")));
            this.btnAddVagas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddVagas.Location = new System.Drawing.Point(521, 8);
            this.btnAddVagas.Name = "btnAddVagas";
            this.btnAddVagas.Size = new System.Drawing.Size(151, 23);
            this.btnAddVagas.TabIndex = 7;
            this.btnAddVagas.Text = "Adicionar Vaga";
            this.btnAddVagas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddVagas.UseVisualStyleBackColor = true;
            this.btnAddVagas.Click += new System.EventHandler(this.btnAddVagas_Click);
            // 
            // pnBlocoVagaCurso
            // 
            this.pnBlocoVagaCurso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnBlocoVagaCurso.Controls.Add(this.btnAddVagas);
            this.pnBlocoVagaCurso.Controls.Add(this.dgvVagas);
            this.pnBlocoVagaCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBlocoVagaCurso.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnBlocoVagaCurso.Location = new System.Drawing.Point(0, 170);
            this.pnBlocoVagaCurso.Name = "pnBlocoVagaCurso";
            this.pnBlocoVagaCurso.Size = new System.Drawing.Size(680, 179);
            this.pnBlocoVagaCurso.TabIndex = 1013;
            // 
            // pnEstacionamento
            // 
            this.pnEstacionamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnEstacionamento.Controls.Add(this.chkValidaVencimento);
            this.pnEstacionamento.Controls.Add(this.labelWelic1);
            this.pnEstacionamento.Controls.Add(this.labelWelic3);
            this.pnEstacionamento.Controls.Add(this.txtNome);
            this.pnEstacionamento.Controls.Add(this.txtEstacionamento);
            this.pnEstacionamento.Controls.Add(this.txtRelacao);
            this.pnEstacionamento.Controls.Add(this.labelWelic2);
            this.pnEstacionamento.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnEstacionamento.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnEstacionamento.Location = new System.Drawing.Point(0, 31);
            this.pnEstacionamento.Name = "pnEstacionamento";
            this.pnEstacionamento.Size = new System.Drawing.Size(680, 139);
            this.pnEstacionamento.TabIndex = 1014;
            // 
            // chkValidaVencimento
            // 
            this.chkValidaVencimento.AutoSize = true;
            this.chkValidaVencimento.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkValidaVencimento.LimpaCampo = true;
            this.chkValidaVencimento.Location = new System.Drawing.Point(164, 98);
            this.chkValidaVencimento.Name = "chkValidaVencimento";
            this.chkValidaVencimento.NomeCampoDadosDataTable = null;
            this.chkValidaVencimento.Size = new System.Drawing.Size(146, 17);
            this.chkValidaVencimento.TabIndex = 4;
            this.chkValidaVencimento.Text = "Valida Vencimento";
            this.chkValidaVencimento.UseVisualStyleBackColor = true;
            // 
            // FrmCadastroEstacionamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 371);
            this.Controls.Add(this.pnBlocoVagaCurso);
            this.Controls.Add(this.pnEstacionamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IdProgram = "2";
            this.MaximizeBox = false;
            this.Name = "FrmCadastroEstacionamentos";
            this.Tag = "";
            this.Text = "Cadastro de Estacionamentos";
            this.Load += new System.EventHandler(this.LoadFormulario);
            this.Controls.SetChildIndex(this.pnEstacionamento, 0);
            this.Controls.SetChildIndex(this.pnBlocoVagaCurso, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVagas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingVagas)).EndInit();
            this.pnBlocoVagaCurso.ResumeLayout(false);
            this.pnEstacionamento.ResumeLayout(false);
            this.pnEstacionamento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UseFul.Forms.Welic.LabelWelic labelWelic1;
        private UseFul.Forms.Welic.TextBoxWelic txtEstacionamento;
        private UseFul.Forms.Welic.LabelWelic labelWelic2;
        private UseFul.Forms.Welic.TextBoxWelic txtNome;
        private UseFul.Forms.Welic.LabelWelic labelWelic3;
        private UseFul.Forms.Welic.TextBoxWelic txtRelacao;
        private UseFul.Forms.Welic.DataGridViewWelic dgvVagas;
        private UseFul.Forms.Welic.ButtonWelic btnAddVagas;
        private UseFul.Forms.Welic.PanelWelic pnBlocoVagaCurso;
        private UseFul.Forms.Welic.PanelWelic pnEstacionamento;
        private UseFul.Forms.Welic.CheckBoxWelic chkValidaVencimento;
        private System.Windows.Forms.BindingSource BindingVagas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdEstacionamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTipoVaga;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTipoVeiculo;
        private System.Windows.Forms.DataGridViewImageColumn colVagaExcluir;
    }
}