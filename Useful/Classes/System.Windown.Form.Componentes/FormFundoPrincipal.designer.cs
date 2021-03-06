﻿using System.Windows.Forms;

namespace UseFul.Forms.Welic
{
    partial class FormFundoPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFundoPrincipal));
            this.pnlFundo = new System.Windows.Forms.Panel();
            this.lbGerenciaEquipe = new System.Windows.Forms.Label();
            this.lbDuvidas = new System.Windows.Forms.Label();
            this.panelTituloSubTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubTitulo = new System.Windows.Forms.Label();
            this.pnlFundo.SuspendLayout();
            this.panelTituloSubTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFundo
            // 
            this.pnlFundo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlFundo.BackgroundImage")));
            this.pnlFundo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFundo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFundo.Controls.Add(this.lbGerenciaEquipe);
            this.pnlFundo.Controls.Add(this.lbDuvidas);
            this.pnlFundo.Controls.Add(this.panelTituloSubTitulo);
            this.pnlFundo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFundo.Location = new System.Drawing.Point(0, 0);
            this.pnlFundo.Name = "pnlFundo";
            this.pnlFundo.Size = new System.Drawing.Size(867, 546);
            this.pnlFundo.TabIndex = 0;
            // 
            // lbGerenciaEquipe
            // 
            this.lbGerenciaEquipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbGerenciaEquipe.AutoSize = true;
            this.lbGerenciaEquipe.BackColor = System.Drawing.Color.Transparent;
            this.lbGerenciaEquipe.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGerenciaEquipe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.lbGerenciaEquipe.Location = new System.Drawing.Point(22, 498);
            this.lbGerenciaEquipe.Name = "lbGerenciaEquipe";
            this.lbGerenciaEquipe.Size = new System.Drawing.Size(60, 15);
            this.lbGerenciaEquipe.TabIndex = 35;
            this.lbGerenciaEquipe.Text = "<Equipe>";
            // 
            // lbDuvidas
            // 
            this.lbDuvidas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDuvidas.AutoSize = true;
            this.lbDuvidas.BackColor = System.Drawing.Color.Transparent;
            this.lbDuvidas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDuvidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.lbDuvidas.Location = new System.Drawing.Point(22, 519);
            this.lbDuvidas.Name = "lbDuvidas";
            this.lbDuvidas.Size = new System.Drawing.Size(128, 15);
            this.lbDuvidas.TabIndex = 34;
            this.lbDuvidas.Text = "Dúvidas/Solicitações:";
            // 
            // panelTituloSubTitulo
            // 
            this.panelTituloSubTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelTituloSubTitulo.BackColor = System.Drawing.Color.Transparent;
            this.panelTituloSubTitulo.Controls.Add(this.lblTitulo);
            this.panelTituloSubTitulo.Controls.Add(this.lblSubTitulo);
            this.panelTituloSubTitulo.Location = new System.Drawing.Point(3, 134);
            this.panelTituloSubTitulo.Name = "panelTituloSubTitulo";
            this.panelTituloSubTitulo.Size = new System.Drawing.Size(859, 201);
            this.panelTituloSubTitulo.TabIndex = 31;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Black", 39F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.lblTitulo.Location = new System.Drawing.Point(2, 32);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(856, 65);
            this.lblTitulo.TabIndex = 28;
            this.lblTitulo.Text = "[Titulo]";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblSubTitulo
            // 
            this.lblSubTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitulo.Font = new System.Drawing.Font("Arial Black", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.lblSubTitulo.Location = new System.Drawing.Point(2, 98);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lblSubTitulo.Size = new System.Drawing.Size(857, 66);
            this.lblSubTitulo.TabIndex = 29;
            this.lblSubTitulo.Text = "[Sub_Titulo]";
            this.lblSubTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormFundoPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 546);
            this.Controls.Add(this.pnlFundo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFundoPrincipal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DTI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFundoPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormFundoPrincipal_Load);
            this.pnlFundo.ResumeLayout(false);
            this.pnlFundo.PerformLayout();
            this.panelTituloSubTitulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubTitulo;
        public Panel pnlFundo;
        public Panel panelTituloSubTitulo;
        private Label lbGerenciaEquipe;
        private Label lbDuvidas;
    }
}