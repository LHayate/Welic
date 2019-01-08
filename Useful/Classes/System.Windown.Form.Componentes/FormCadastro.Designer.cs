using System.Windows.Forms;
namespace UseFul.Forms.Welic
{
    partial class FormCadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastro));
            this.toolStripOpcoes = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorAcoes = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnGravar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnVoltar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnAjuda = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnAuditoria = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnPermissao = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorOutros = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnLocalizar = new System.Windows.Forms.ToolStripButton();
            this.statusStripRodape = new System.Windows.Forms.StatusStrip();
            this.toolStripStatuslblPrincipal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripOpcoes.SuspendLayout();
            this.statusStripRodape.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripOpcoes
            // 
            this.toolStripOpcoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.toolStripOpcoes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripOpcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNovo,
            this.toolStripBtnEditar,
            this.toolStripBtnExcluir,
            this.toolStripSeparatorAcoes,
            this.toolStripBtnGravar,
            this.toolStripBtnVoltar,
            this.toolStripBtnAjuda,
            this.toolStripBtnAuditoria,
            this.toolStripBtnPermissao,
            this.toolStripSeparatorOutros,
            this.toolStripBtnImprimir,
            this.toolStripBtnLocalizar});
            this.toolStripOpcoes.Location = new System.Drawing.Point(0, 0);
            this.toolStripOpcoes.Name = "toolStripOpcoes";
            this.toolStripOpcoes.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripOpcoes.Size = new System.Drawing.Size(525, 31);
            this.toolStripOpcoes.Stretch = true;
            this.toolStripOpcoes.TabIndex = 1000;
            this.toolStripOpcoes.TabStop = true;
            this.toolStripOpcoes.Text = "toolStripOpcoes";
            // 
            // toolStripBtnNovo
            // 
            this.toolStripBtnNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnNovo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnNovo.Image")));
            this.toolStripBtnNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnNovo.ImageTransparentColor = System.Drawing.Color.Maroon;
            this.toolStripBtnNovo.Name = "toolStripBtnNovo";
            this.toolStripBtnNovo.Size = new System.Drawing.Size(26, 28);
            this.toolStripBtnNovo.Text = "Novo";
            this.toolStripBtnNovo.ToolTipText = "Novo";
            this.toolStripBtnNovo.Click += new System.EventHandler(this.toolStripBtnNovo_Click);
            // 
            // toolStripBtnEditar
            // 
            this.toolStripBtnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnEditar.Image")));
            this.toolStripBtnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnEditar.Name = "toolStripBtnEditar";
            this.toolStripBtnEditar.Size = new System.Drawing.Size(26, 28);
            this.toolStripBtnEditar.Text = "Editar";
            this.toolStripBtnEditar.ToolTipText = "Editar";
            this.toolStripBtnEditar.Click += new System.EventHandler(this.toolStripBtnEditar_Click);
            // 
            // toolStripBtnExcluir
            // 
            this.toolStripBtnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnExcluir.Image")));
            this.toolStripBtnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnExcluir.Name = "toolStripBtnExcluir";
            this.toolStripBtnExcluir.Size = new System.Drawing.Size(26, 28);
            this.toolStripBtnExcluir.Text = "Excluir";
            this.toolStripBtnExcluir.ToolTipText = "Excluir";
            this.toolStripBtnExcluir.Click += new System.EventHandler(this.toolStripBtnExcluir_Click);
            // 
            // toolStripSeparatorAcoes
            // 
            this.toolStripSeparatorAcoes.Name = "toolStripSeparatorAcoes";
            this.toolStripSeparatorAcoes.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripBtnGravar
            // 
            this.toolStripBtnGravar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnGravar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnGravar.Image")));
            this.toolStripBtnGravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnGravar.Name = "toolStripBtnGravar";
            this.toolStripBtnGravar.Size = new System.Drawing.Size(26, 28);
            this.toolStripBtnGravar.Text = "Gravar";
            this.toolStripBtnGravar.ToolTipText = "Gravar";
            this.toolStripBtnGravar.Click += new System.EventHandler(this.toolStripBtnGravar_Click);
            // 
            // toolStripBtnVoltar
            // 
            this.toolStripBtnVoltar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnVoltar.Image")));
            this.toolStripBtnVoltar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnVoltar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnVoltar.Name = "toolStripBtnVoltar";
            this.toolStripBtnVoltar.Size = new System.Drawing.Size(28, 28);
            this.toolStripBtnVoltar.Text = "Voltar";
            this.toolStripBtnVoltar.ToolTipText = "Voltar";
            this.toolStripBtnVoltar.Click += new System.EventHandler(this.toolStripBtnVoltar_Click);
            // 
            // toolStripBtnAjuda
            // 
            this.toolStripBtnAjuda.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripBtnAjuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnAjuda.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAjuda.Image")));
            this.toolStripBtnAjuda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnAjuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAjuda.Name = "toolStripBtnAjuda";
            this.toolStripBtnAjuda.Size = new System.Drawing.Size(26, 28);
            this.toolStripBtnAjuda.Text = "Ajuda";
            this.toolStripBtnAjuda.Click += new System.EventHandler(this.toolStripBtnAjuda_Click);
            // 
            // toolStripBtnAuditoria
            // 
            this.toolStripBtnAuditoria.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripBtnAuditoria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnAuditoria.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAuditoria.Image")));
            this.toolStripBtnAuditoria.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnAuditoria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAuditoria.Name = "toolStripBtnAuditoria";
            this.toolStripBtnAuditoria.Size = new System.Drawing.Size(28, 28);
            this.toolStripBtnAuditoria.Text = "Auditoria";
            this.toolStripBtnAuditoria.Click += new System.EventHandler(this.toolStripBtnAuditoria_Click);
            // 
            // toolStripBtnPermissao
            // 
            this.toolStripBtnPermissao.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripBtnPermissao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnPermissao.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnPermissao.Image")));
            this.toolStripBtnPermissao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnPermissao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPermissao.Name = "toolStripBtnPermissao";
            this.toolStripBtnPermissao.Size = new System.Drawing.Size(28, 28);
            this.toolStripBtnPermissao.Text = "Permissões";
            this.toolStripBtnPermissao.Click += new System.EventHandler(this.toolStripBtnPermissao_Click);
            // 
            // toolStripSeparatorOutros
            // 
            this.toolStripSeparatorOutros.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparatorOutros.Name = "toolStripSeparatorOutros";
            this.toolStripSeparatorOutros.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripBtnImprimir
            // 
            this.toolStripBtnImprimir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripBtnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnImprimir.Image")));
            this.toolStripBtnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnImprimir.Name = "toolStripBtnImprimir";
            this.toolStripBtnImprimir.Size = new System.Drawing.Size(26, 28);
            this.toolStripBtnImprimir.Text = "Imprimir";
            this.toolStripBtnImprimir.Click += new System.EventHandler(this.toolStripBtnImprimir_Click);
            // 
            // toolStripBtnLocalizar
            // 
            this.toolStripBtnLocalizar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripBtnLocalizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnLocalizar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnLocalizar.Image")));
            this.toolStripBtnLocalizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnLocalizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnLocalizar.Name = "toolStripBtnLocalizar";
            this.toolStripBtnLocalizar.Size = new System.Drawing.Size(28, 28);
            this.toolStripBtnLocalizar.Text = "Localizar";
            this.toolStripBtnLocalizar.Click += new System.EventHandler(this.toolStripBtnLocalizar_Click);
            // 
            // statusStripRodape
            // 
            this.statusStripRodape.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.statusStripRodape.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatuslblPrincipal});
            this.statusStripRodape.Location = new System.Drawing.Point(0, 340);
            this.statusStripRodape.Name = "statusStripRodape";
            this.statusStripRodape.ShowItemToolTips = true;
            this.statusStripRodape.Size = new System.Drawing.Size(525, 22);
            this.statusStripRodape.SizingGrip = false;
            this.statusStripRodape.TabIndex = 1000;
            // 
            // toolStripStatuslblPrincipal
            // 
            this.toolStripStatuslblPrincipal.Name = "toolStripStatuslblPrincipal";
            this.toolStripStatuslblPrincipal.Size = new System.Drawing.Size(0, 17);
            // 
            // FormCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 362);
            this.Controls.Add(this.statusStripRodape);
            this.Controls.Add(this.toolStripOpcoes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormCadastro";
            this.Text = "Título do Cadastro";
            this.Load += new System.EventHandler(this.FormCadastro_Load);
            this.toolStripOpcoes.ResumeLayout(false);
            this.toolStripOpcoes.PerformLayout();
            this.statusStripRodape.ResumeLayout(false);
            this.statusStripRodape.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ToolStrip toolStripOpcoes;
        public ToolStripButton toolStripBtnNovo;
        public ToolStripButton toolStripBtnGravar;
        public ToolStripButton toolStripBtnEditar;
        public ToolStripButton toolStripBtnVoltar;
        public ToolStripButton toolStripBtnExcluir;
        public ToolStripButton toolStripBtnLocalizar;
        public ToolStripButton toolStripBtnAjuda;
        public ToolStripButton toolStripBtnAuditoria;
        public ToolStripButton toolStripBtnImprimir;
        public StatusStrip statusStripRodape;
        public ToolStripSeparator toolStripSeparatorAcoes;
        public ToolStripSeparator toolStripSeparatorOutros;
        public ToolStripStatusLabel toolStripStatuslblPrincipal;
        public ToolStripButton toolStripBtnPermissao;
    }
}