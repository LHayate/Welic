﻿using System.Windows.Forms;

namespace UseFul.Forms.Welic
{
    partial class FormInputBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInputBox));
            this.lbTitulo = new UseFul.Forms.Welic.LabelWelic();
            this.txtTexto = new UseFul.Forms.Welic.TextBoxWelic();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btConfirma = new System.Windows.Forms.Button();
            this.pnlTexto = new System.Windows.Forms.Panel();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(8, 9);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(44, 13);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "Texto";
            // 
            // txtTexto
            // 
            this.txtTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTexto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.Location = new System.Drawing.Point(9, 23);
            this.txtTexto.Multiline = true;
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(512, 59);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Geral;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.pnlBotoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotoes.Controls.Add(this.btCancel);
            this.pnlBotoes.Controls.Add(this.btConfirma);
            this.pnlBotoes.Location = new System.Drawing.Point(2, 91);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(525, 37);
            this.pnlBotoes.TabIndex = 5;
            // 
            // btCancel
            // 
            this.btCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(404, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(114, 30);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "    Cancelar";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btConfirma
            // 
            this.btConfirma.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btConfirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConfirma.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirma.Image = ((System.Drawing.Image)(resources.GetObject("btConfirma.Image")));
            this.btConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btConfirma.Location = new System.Drawing.Point(287, 3);
            this.btConfirma.Name = "btConfirma";
            this.btConfirma.Size = new System.Drawing.Size(114, 30);
            this.btConfirma.TabIndex = 0;
            this.btConfirma.Text = "      Confirmar";
            this.btConfirma.UseVisualStyleBackColor = true;
            this.btConfirma.Click += new System.EventHandler(this.btConfirma_Click);
            // 
            // pnlTexto
            // 
            this.pnlTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTexto.Location = new System.Drawing.Point(2, 2);
            this.pnlTexto.Name = "pnlTexto";
            this.pnlTexto.Size = new System.Drawing.Size(525, 87);
            this.pnlTexto.TabIndex = 6;
            // 
            // FormInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(530, 131);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.pnlTexto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmInputBox_Load);
            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UseFul.Forms.Welic.LabelWelic lbTitulo;
        private UseFul.Forms.Welic.TextBoxWelic txtTexto;
        private Panel pnlBotoes;
        private Button btCancel;
        private Button btConfirma;
        private Panel pnlTexto;
    }
}