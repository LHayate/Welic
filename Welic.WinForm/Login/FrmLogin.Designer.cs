namespace Welic.WinForm
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.lblVersion = new UseFul.Forms.Welic.LabelWelic();
            this.Empresa = new UseFul.Forms.Welic.LabelWelic();
            this.CboEmpresa = new UseFul.Forms.Welic.ComboBoxWelic(this.components);
            this.labelWelic2 = new UseFul.Forms.Welic.LabelWelic();
            this.labelWelic1 = new UseFul.Forms.Welic.LabelWelic();
            this.txtSenha = new UseFul.Forms.Welic.TextBoxWelic();
            this.txtUsuario = new UseFul.Forms.Welic.TextBoxWelic();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btEntrar = new System.Windows.Forms.PictureBox();
            this.btFechar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BindingComboEmpresa = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEntrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingComboEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(426, 502);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(56, 13);
            this.lblVersion.TabIndex = 32;
            this.lblVersion.Text = "Versão:";
            // 
            // Empresa
            // 
            this.Empresa.AutoSize = true;
            this.Empresa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Empresa.Location = new System.Drawing.Point(161, 172);
            this.Empresa.Name = "Empresa";
            this.Empresa.Size = new System.Drawing.Size(64, 13);
            this.Empresa.TabIndex = 31;
            this.Empresa.Text = "Empresa";
            // 
            // CboEmpresa
            // 
            this.CboEmpresa.DataSource = this.BindingComboEmpresa;
            this.CboEmpresa.DisplayMember = "RazaoSocial";
            this.CboEmpresa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboEmpresa.FormattingEnabled = true;
            this.CboEmpresa.LimpaCampo = true;
            this.CboEmpresa.Location = new System.Drawing.Point(133, 188);
            this.CboEmpresa.Name = "CboEmpresa";
            this.CboEmpresa.NomeCampoDadosDataTable = null;
            this.CboEmpresa.Size = new System.Drawing.Size(121, 21);
            this.CboEmpresa.TabIndex = 30;
            this.CboEmpresa.ValueMember = "IdEmpresa";
            // 
            // labelWelic2
            // 
            this.labelWelic2.AutoSize = true;
            this.labelWelic2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelic2.Location = new System.Drawing.Point(168, 291);
            this.labelWelic2.Name = "labelWelic2";
            this.labelWelic2.Size = new System.Drawing.Size(51, 13);
            this.labelWelic2.TabIndex = 28;
            this.labelWelic2.Text = "Senha:";
            // 
            // labelWelic1
            // 
            this.labelWelic1.AutoSize = true;
            this.labelWelic1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelic1.Location = new System.Drawing.Point(163, 230);
            this.labelWelic1.Name = "labelWelic1";
            this.labelWelic1.Size = new System.Drawing.Size(61, 13);
            this.labelWelic1.TabIndex = 27;
            this.labelWelic1.Text = "Usuario:";
            // 
            // txtSenha
            // 
            this.txtSenha._RecursosGenericosSqlF3 = null;
            this.txtSenha._RecursosGenericosSqlLeave = null;
            this.txtSenha.BackColor = System.Drawing.Color.White;
            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSenha.ExibirIconePesquisa = false;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.InformacaoToolTipCaminho = null;
            this.txtSenha.InformacaoToolTipDescricao = null;
            this.txtSenha.LimpaCampo = true;
            this.txtSenha.Location = new System.Drawing.Point(131, 307);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.NomeCampoDadosDataTable = null;
            this.txtSenha.ParteDecimal = 0;
            this.txtSenha.ParteInteira = 0;
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.SegurancaCCusto = UseFul.Forms.Welic.TextBoxWelic.CSegurancaCentroCusto.NaoUtilizado;
            this.txtSenha.Size = new System.Drawing.Size(124, 22);
            this.txtSenha.TabIndex = 23;
            this.txtSenha.TipoCampo = UseFul.Forms.Welic.TextBoxWelic.CTipoCampo.Normal;
            this.txtSenha.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Geral;
            // 
            // txtUsuario
            // 
            this.txtUsuario._RecursosGenericosSqlF3 = null;
            this.txtUsuario._RecursosGenericosSqlLeave = null;
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.ExibirIconePesquisa = false;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.InformacaoToolTipCaminho = null;
            this.txtUsuario.InformacaoToolTipDescricao = null;
            this.txtUsuario.LimpaCampo = true;
            this.txtUsuario.Location = new System.Drawing.Point(131, 246);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.NomeCampoDadosDataTable = null;
            this.txtUsuario.ParteDecimal = 0;
            this.txtUsuario.ParteInteira = 0;
            this.txtUsuario.SegurancaCCusto = UseFul.Forms.Welic.TextBoxWelic.CSegurancaCentroCusto.NaoUtilizado;
            this.txtUsuario.Size = new System.Drawing.Size(124, 22);
            this.txtUsuario.TabIndex = 22;
            this.txtUsuario.TipoCampo = UseFul.Forms.Welic.TextBoxWelic.CTipoCampo.Normal;
            this.txtUsuario.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Geral;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Welic.WinForm.Properties.Resources.LogoWelic128x128;
            this.pictureBox2.Location = new System.Drawing.Point(127, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(133, 130);
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // btEntrar
            // 
            this.btEntrar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btEntrar.Image = ((System.Drawing.Image)(resources.GetObject("btEntrar.Image")));
            this.btEntrar.Location = new System.Drawing.Point(151, 345);
            this.btEntrar.Name = "btEntrar";
            this.btEntrar.Size = new System.Drawing.Size(85, 28);
            this.btEntrar.TabIndex = 24;
            this.btEntrar.TabStop = false;
            this.btEntrar.Click += new System.EventHandler(this.btEntrar_Click);
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.Location = new System.Drawing.Point(521, -65);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(32, 16);
            this.btFechar.TabIndex = 25;
            this.btFechar.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(139, 396);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 14);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // BindingComboEmpresa
            // 
            this.BindingComboEmpresa.DataSource = typeof(UseFul.ClientApi.Dtos.EmpresaDto);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 450);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.Empresa);
            this.Controls.Add(this.CboEmpresa);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelWelic2);
            this.Controls.Add(this.labelWelic1);
            this.Controls.Add(this.btEntrar);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtUsuario);
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEntrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingComboEmpresa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UseFul.Forms.Welic.LabelWelic lblVersion;
        private UseFul.Forms.Welic.LabelWelic Empresa;
        private UseFul.Forms.Welic.ComboBoxWelic CboEmpresa;
        private System.Windows.Forms.PictureBox pictureBox2;
        private UseFul.Forms.Welic.LabelWelic labelWelic2;
        private UseFul.Forms.Welic.LabelWelic labelWelic1;
        private System.Windows.Forms.PictureBox btEntrar;
        private System.Windows.Forms.PictureBox btFechar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private UseFul.Forms.Welic.TextBoxWelic txtSenha;
        private UseFul.Forms.Welic.TextBoxWelic txtUsuario;
        private System.Windows.Forms.BindingSource BindingComboEmpresa;
    }
}