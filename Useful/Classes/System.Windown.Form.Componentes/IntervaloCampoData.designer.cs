﻿namespace Componentes
{
    partial class IntervaloCampoData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnIntervaloCampos = new UseFul.Forms.Welic.PanelWelic(this.components);
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.lbFinal = new UseFul.Forms.Welic.LabelWelic();
            this.lbInicial = new UseFul.Forms.Welic.LabelWelic();
            this.pnTitulo = new UseFul.Forms.Welic.PanelWelic(this.components);
            this.chkTitulo = new UseFul.Forms.Welic.CheckBoxWelic(this.components);
            this.pnIntervaloCampos.SuspendLayout();
            this.pnTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnIntervaloCampos
            // 
            this.pnIntervaloCampos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnIntervaloCampos.Controls.Add(this.dtpFinal);
            this.pnIntervaloCampos.Controls.Add(this.dtpInicial);
            this.pnIntervaloCampos.Controls.Add(this.lbFinal);
            this.pnIntervaloCampos.Controls.Add(this.lbInicial);
            this.pnIntervaloCampos.Controls.Add(this.pnTitulo);
            this.pnIntervaloCampos.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnIntervaloCampos.Location = new System.Drawing.Point(0, 0);
            this.pnIntervaloCampos.Margin = new System.Windows.Forms.Padding(0);
            this.pnIntervaloCampos.Name = "pnIntervaloCampos";
            this.pnIntervaloCampos.Size = new System.Drawing.Size(136, 93);
            this.pnIntervaloCampos.TabIndex = 1;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Enabled = false;
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(46, 57);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(87, 21);
            this.dtpFinal.TabIndex = 6;
            // 
            // dtpInicial
            // 
            this.dtpInicial.CustomFormat = "";
            this.dtpInicial.Enabled = false;
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicial.Location = new System.Drawing.Point(46, 25);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(87, 21);
            this.dtpInicial.TabIndex = 5;
            // 
            // lbFinal
            // 
            this.lbFinal.AutoSize = true;
            this.lbFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFinal.Location = new System.Drawing.Point(-2, 60);
            this.lbFinal.Name = "lbFinal";
            this.lbFinal.Size = new System.Drawing.Size(43, 13);
            this.lbFinal.TabIndex = 4;
            this.lbFinal.Text = "Final:";
            // 
            // lbInicial
            // 
            this.lbInicial.AutoSize = true;
            this.lbInicial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInicial.Location = new System.Drawing.Point(-2, 28);
            this.lbInicial.Name = "lbInicial";
            this.lbInicial.Size = new System.Drawing.Size(52, 13);
            this.lbInicial.TabIndex = 2;
            this.lbInicial.Text = "Inicial:";
            // 
            // pnTitulo
            // 
            this.pnTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTitulo.Controls.Add(this.chkTitulo);
            this.pnTitulo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnTitulo.Location = new System.Drawing.Point(-1, -1);
            this.pnTitulo.Name = "pnTitulo";
            this.pnTitulo.Size = new System.Drawing.Size(136, 19);
            this.pnTitulo.TabIndex = 0;
            // 
            // chkTitulo
            // 
            this.chkTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.chkTitulo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTitulo.LimpaCampo = true;
            this.chkTitulo.Location = new System.Drawing.Point(2, 0);
            this.chkTitulo.Margin = new System.Windows.Forms.Padding(0);
            this.chkTitulo.Name = "chkTitulo";
            this.chkTitulo.Size = new System.Drawing.Size(131, 19);
            this.chkTitulo.TabIndex = 0;
            this.chkTitulo.Text = "Inter. Campo Dt";
            this.chkTitulo.UseVisualStyleBackColor = false;
            this.chkTitulo.CheckedChanged += new System.EventHandler(this.chkTitulo_CheckedChanged);
            // 
            // IntervaloCampoData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.pnIntervaloCampos);
            this.Name = "IntervaloCampoData";
            this.Size = new System.Drawing.Size(136, 93);
            this.pnIntervaloCampos.ResumeLayout(false);
            this.pnIntervaloCampos.PerformLayout();
            this.pnTitulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public UseFul.Forms.Welic.PanelWelic pnIntervaloCampos;
        private UseFul.Forms.Welic.LabelWelic lbFinal;
        private UseFul.Forms.Welic.LabelWelic lbInicial;
        private UseFul.Forms.Welic.PanelWelic pnTitulo;
        public UseFul.Forms.Welic.CheckBoxWelic chkTitulo;
        public System.Windows.Forms.DateTimePicker dtpFinal;
        public System.Windows.Forms.DateTimePicker dtpInicial;
    }
}
