namespace UseFul.Forms.Welic
{
    partial class FormMensagem
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
            this.lblMensagem = new System.Windows.Forms.Label();
            this.pictureBoxPersonalizado1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPersonalizado1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblMensagem.Location = new System.Drawing.Point(45, 15);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(88, 13);
            this.lblMensagem.TabIndex = 1;
            this.lblMensagem.Text = "[Mensagem]";
            this.lblMensagem.MouseEnter += new System.EventHandler(this.FormMensagem_MouseEnter);
            this.lblMensagem.MouseLeave += new System.EventHandler(this.FormMensagem_MouseLeave);
            // 
            // pictureBoxPersonalizado1
            // 
            this.pictureBoxPersonalizado1.Location = new System.Drawing.Point(7, 4);
            this.pictureBoxPersonalizado1.Name = "pictureBoxPersonalizado1";
            this.pictureBoxPersonalizado1.Size = new System.Drawing.Size(32, 33);
            this.pictureBoxPersonalizado1.TabIndex = 0;
            this.pictureBoxPersonalizado1.TabStop = false;
            this.pictureBoxPersonalizado1.MouseEnter += new System.EventHandler(this.FormMensagem_MouseEnter);
            this.pictureBoxPersonalizado1.MouseLeave += new System.EventHandler(this.FormMensagem_MouseLeave);
            // 
            // FormMensagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(200, 52);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.pictureBoxPersonalizado1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMensagem";
            this.Text = "FormMensagem";
            this.Load += new System.EventHandler(this.FormMensagem_Load);
            this.MouseEnter += new System.EventHandler(this.FormMensagem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FormMensagem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPersonalizado1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPersonalizado1;
        private System.Windows.Forms.Label lblMensagem;
    }
}