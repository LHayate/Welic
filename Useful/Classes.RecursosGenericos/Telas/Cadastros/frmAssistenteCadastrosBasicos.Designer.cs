namespace Classes.RecursosGenericos.Telas.Cadastros
{
    partial class frmAssistenteCadastrosBasicos
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlTituloFormulario = new System.Windows.Forms.Panel();
            this.lblTituloFormulario = new System.Windows.Forms.Uniube.LabelUniube();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTituloFormulario.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(3, 411);
            this.panel4.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(976, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 411);
            this.panel3.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(979, 3);
            this.panel2.TabIndex = 9;
            // 
            // pnlTituloFormulario
            // 
            this.pnlTituloFormulario.Controls.Add(this.lblTituloFormulario);
            this.pnlTituloFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloFormulario.Location = new System.Drawing.Point(309, 3);
            this.pnlTituloFormulario.Name = "pnlTituloFormulario";
            this.pnlTituloFormulario.Size = new System.Drawing.Size(667, 17);
            this.pnlTituloFormulario.TabIndex = 16;
            // 
            // lblTituloFormulario
            // 
            this.lblTituloFormulario.AutoSize = true;
            this.lblTituloFormulario.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloFormulario.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloFormulario.Location = new System.Drawing.Point(0, 0);
            this.lblTituloFormulario.Name = "lblTituloFormulario";
            this.lblTituloFormulario.Size = new System.Drawing.Size(76, 16);
            this.lblTituloFormulario.TabIndex = 1;
            this.lblTituloFormulario.Text = "                 ";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(306, 408);
            this.treeView1.TabIndex = 19;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 411);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 3);
            this.panel1.TabIndex = 21;
            // 
            // frmAssistenteCadastrosBasicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 414);
            this.Controls.Add(this.pnlTituloFormulario);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.IsMdiContainer = true;
            this.Name = "frmAssistenteCadastrosBasicos";
            this.Text = "Assistente de Cadastros Básicos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAssistenteCadastrosBasicos_FormClosed);
            this.Load += new System.EventHandler(this.frmAssistenteCadastrosBasicos_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmAssistenteCadastrosBasicos_MdiChildActivate);
            this.pnlTituloFormulario.ResumeLayout(false);
            this.pnlTituloFormulario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlTituloFormulario;
        private System.Windows.Forms.Uniube.LabelUniube lblTituloFormulario;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
    }
}