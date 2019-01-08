namespace Welic.WinForm
{
    partial class Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.MenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.achadosEPerdidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarNovoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirBloquearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estacionamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosDeEstacionamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estacionamentoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mensalistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.User = new System.Windows.Forms.BindingSource(this.components);
            this.MenuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.User)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.achadosEPerdidosToolStripMenuItem,
            this.estacionamentoToolStripMenuItem});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(800, 24);
            this.MenuPrincipal.TabIndex = 0;
            this.MenuPrincipal.Text = "menuStrip1";
            // 
            // achadosEPerdidosToolStripMenuItem
            // 
            this.achadosEPerdidosToolStripMenuItem.Name = "achadosEPerdidosToolStripMenuItem";
            this.achadosEPerdidosToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.achadosEPerdidosToolStripMenuItem.Text = "Achados e Perdidos";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarNovoToolStripMenuItem,
            this.excluirBloquearToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
            this.clientesToolStripMenuItem.Image = global::Welic.WinForm.Properties.Resources.iUser;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // cadastrarNovoToolStripMenuItem
            // 
            this.cadastrarNovoToolStripMenuItem.Image = global::Welic.WinForm.Properties.Resources.iAddUser;
            this.cadastrarNovoToolStripMenuItem.Name = "cadastrarNovoToolStripMenuItem";
            this.cadastrarNovoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cadastrarNovoToolStripMenuItem.Tag = "1";
            this.cadastrarNovoToolStripMenuItem.Text = "Cadastrar Novo";
            this.cadastrarNovoToolStripMenuItem.Click += new System.EventHandler(this.cadastrarNovoToolStripMenuItem_Click);
            // 
            // excluirBloquearToolStripMenuItem
            // 
            this.excluirBloquearToolStripMenuItem.Image = global::Welic.WinForm.Properties.Resources.iDelete;
            this.excluirBloquearToolStripMenuItem.Name = "excluirBloquearToolStripMenuItem";
            this.excluirBloquearToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.excluirBloquearToolStripMenuItem.Tag = "2";
            this.excluirBloquearToolStripMenuItem.Text = "Excluir/Bloquear";
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.Image = global::Welic.WinForm.Properties.Resources.iPerformace;
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.relatóriosToolStripMenuItem.Tag = "3";
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // estacionamentoToolStripMenuItem
            // 
            this.estacionamentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosDeEstacionamentoToolStripMenuItem,
            this.processosToolStripMenuItem});
            this.estacionamentoToolStripMenuItem.Image = global::Welic.WinForm.Properties.Resources.icons8_estacionamento_208;
            this.estacionamentoToolStripMenuItem.Name = "estacionamentoToolStripMenuItem";
            this.estacionamentoToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.estacionamentoToolStripMenuItem.Text = "Estacionamento";
            // 
            // cadastrosDeEstacionamentoToolStripMenuItem
            // 
            this.cadastrosDeEstacionamentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estacionamentoToolStripMenuItem1,
            this.mensalistaToolStripMenuItem});
            this.cadastrosDeEstacionamentoToolStripMenuItem.Image = global::Welic.WinForm.Properties.Resources.iAdd;
            this.cadastrosDeEstacionamentoToolStripMenuItem.Name = "cadastrosDeEstacionamentoToolStripMenuItem";
            this.cadastrosDeEstacionamentoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastrosDeEstacionamentoToolStripMenuItem.Text = "Cadastros";
            // 
            // estacionamentoToolStripMenuItem1
            // 
            this.estacionamentoToolStripMenuItem1.Image = global::Welic.WinForm.Properties.Resources.icons8_estacionamento_208;
            this.estacionamentoToolStripMenuItem1.Name = "estacionamentoToolStripMenuItem1";
            this.estacionamentoToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.estacionamentoToolStripMenuItem1.Tag = "2";
            this.estacionamentoToolStripMenuItem1.Text = "Estacionamento";
            this.estacionamentoToolStripMenuItem1.Click += new System.EventHandler(this.estacionamentoToolStripMenuItem1_Click);
            // 
            // mensalistaToolStripMenuItem
            // 
            this.mensalistaToolStripMenuItem.Image = global::Welic.WinForm.Properties.Resources.iCalendarB;
            this.mensalistaToolStripMenuItem.Name = "mensalistaToolStripMenuItem";
            this.mensalistaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mensalistaToolStripMenuItem.Text = "Mensalista";
            this.mensalistaToolStripMenuItem.Click += new System.EventHandler(this.mensalistaToolStripMenuItem_Click);
            // 
            // processosToolStripMenuItem
            // 
            this.processosToolStripMenuItem.Image = global::Welic.WinForm.Properties.Resources.iSetting;
            this.processosToolStripMenuItem.Name = "processosToolStripMenuItem";
            this.processosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.processosToolStripMenuItem.Text = "Processos";
            // 
            // User
            // 
            this.User.DataSource = typeof(UseFul.ClientApi.Dtos.UserDto);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MenuPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuPrincipal;
            this.Name = "Principal";
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmL_Load);
            this.Controls.SetChildIndex(this.MenuPrincipal, 0);
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.User)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarNovoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirBloquearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem achadosEPerdidosToolStripMenuItem;
        private System.Windows.Forms.BindingSource User;
        private System.Windows.Forms.ToolStripMenuItem estacionamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosDeEstacionamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estacionamentoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem processosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mensalistaToolStripMenuItem;
    }
}

