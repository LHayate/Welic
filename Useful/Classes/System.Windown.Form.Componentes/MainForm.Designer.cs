namespace UseFul.Forms.Welic
{
    partial class MainForm
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
            this.TextBoxBuscaMenu = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lblUser = new System.Windows.Forms.Label();
            this.linkLblChangeUser = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabelAtualizarMenu = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxBuscaMenu
            // 
            this.TextBoxBuscaMenu.Location = new System.Drawing.Point(327, 144);
            this.TextBoxBuscaMenu.Name = "TextBoxBuscaMenu";
            this.TextBoxBuscaMenu.Size = new System.Drawing.Size(100, 20);
            this.TextBoxBuscaMenu.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.LineColor = System.Drawing.Color.Empty;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(62, 8);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 13);
            this.lblUser.TabIndex = 7;
            // 
            // linkLblChangeUser
            // 
            this.linkLblChangeUser.AutoSize = true;
            this.linkLblChangeUser.Location = new System.Drawing.Point(62, 27);
            this.linkLblChangeUser.Name = "linkLblChangeUser";
            this.linkLblChangeUser.Size = new System.Drawing.Size(55, 13);
            this.linkLblChangeUser.TabIndex = 10;
            this.linkLblChangeUser.TabStop = true;
            this.linkLblChangeUser.Text = "linkLabel1";
            this.linkLblChangeUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblChangeUser_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(62, 48);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(80, 13);
            this.linkLabel2.TabIndex = 11;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Sair do Sistema";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblClose_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabelAtualizarMenu);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.linkLblChangeUser);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 88);
            this.panel1.TabIndex = 0;
            // 
            // linkLabelAtualizarMenu
            // 
            this.linkLabelAtualizarMenu.AutoSize = true;
            this.linkLabelAtualizarMenu.Location = new System.Drawing.Point(62, 69);
            this.linkLabelAtualizarMenu.Name = "linkLabelAtualizarMenu";
            this.linkLabelAtualizarMenu.Size = new System.Drawing.Size(77, 13);
            this.linkLabelAtualizarMenu.TabIndex = 12;
            this.linkLabelAtualizarMenu.TabStop = true;
            this.linkLabelAtualizarMenu.Text = "Atualizar Menu";
            this.linkLabelAtualizarMenu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAtualizarMenu_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(176, 133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.TextBoxBuscaMenu);
            this.panel2.Location = new System.Drawing.Point(0, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 546);
            this.panel2.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 698);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabelAtualizarMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLblChangeUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox TextBoxBuscaMenu;
    }
}