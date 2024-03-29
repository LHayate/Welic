﻿
using System.Windows.Forms;
namespace UseFul.Forms.Welic
{
    partial class frmOrdenacaoGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenacaoGrid));
            this.listColunas = new System.Windows.Forms.ListBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBotoesUpDown = new System.Windows.Forms.Panel();
            this.btnMoverUp = new UseFul.Forms.Welic.ButtonWelic();
            this.btnMoverDown = new UseFul.Forms.Welic.ButtonWelic();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBotoesUpDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // listColunas
            // 
            this.listColunas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listColunas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listColunas.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listColunas.FormattingEnabled = true;
            this.listColunas.ItemHeight = 14;
            this.listColunas.Items.AddRange(new object[] {
            "Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5"});
            this.listColunas.Location = new System.Drawing.Point(5, 5);
            this.listColunas.Name = "listColunas";
            this.listColunas.Size = new System.Drawing.Size(192, 171);
            this.listColunas.TabIndex = 0;
            this.listColunas.DoubleClick += new System.EventHandler(this.listColunas_DoubleClick);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pictureBox1);
            this.pnlRight.Controls.Add(this.pnlBotoesUpDown);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(197, 5);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(36, 171);
            this.pnlRight.TabIndex = 1108;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 24);
            this.pictureBox1.TabIndex = 1115;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pnlBotoesUpDown
            // 
            this.pnlBotoesUpDown.Controls.Add(this.btnMoverUp);
            this.pnlBotoesUpDown.Controls.Add(this.btnMoverDown);
            this.pnlBotoesUpDown.Location = new System.Drawing.Point(4, 61);
            this.pnlBotoesUpDown.Name = "pnlBotoesUpDown";
            this.pnlBotoesUpDown.Size = new System.Drawing.Size(28, 72);
            this.pnlBotoesUpDown.TabIndex = 1114;
            // 
            // btnMoverUp
            // 
            this.btnMoverUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.btnMoverUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoverUp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoverUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoverUp.Image")));
            this.btnMoverUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMoverUp.Location = new System.Drawing.Point(0, 0);
            this.btnMoverUp.Name = "btnMoverUp";
            this.btnMoverUp.Size = new System.Drawing.Size(28, 33);
            this.btnMoverUp.TabIndex = 1083;
            this.btnMoverUp.UseVisualStyleBackColor = true;
            this.btnMoverUp.Click += new System.EventHandler(this.btnMoverUp_Click);
            // 
            // btnMoverDown
            // 
            this.btnMoverDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.btnMoverDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoverDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoverDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoverDown.Image")));
            this.btnMoverDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMoverDown.Location = new System.Drawing.Point(0, 39);
            this.btnMoverDown.Name = "btnMoverDown";
            this.btnMoverDown.Size = new System.Drawing.Size(28, 33);
            this.btnMoverDown.TabIndex = 1084;
            this.btnMoverDown.UseVisualStyleBackColor = true;
            this.btnMoverDown.Click += new System.EventHandler(this.btnMoverDown_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 171);
            this.panel2.TabIndex = 1112;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(233, 5);
            this.panel3.TabIndex = 1113;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 176);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(233, 5);
            this.pnlBottom.TabIndex = 1111;
            // 
            // frmOrdenacaoGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 181);
            this.Controls.Add(this.listColunas);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrdenacaoGrid";
            this.ShowInTaskbar = false;
            this.Text = "Ordenação";
            this.Load += new System.EventHandler(this.frmOrdenacaoGrid_Load);
            this.SizeChanged += new System.EventHandler(this.frmOrdenacaoGrid_SizeChanged);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBotoesUpDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listColunas;
        private System.Windows.Forms.Panel pnlRight;
        private UseFul.Forms.Welic.ButtonWelic btnMoverUp;
        private UseFul.Forms.Welic.ButtonWelic btnMoverDown;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlBotoesUpDown;
        private System.Windows.Forms.Panel pnlBottom;
        private PictureBox pictureBox1;
    }
}