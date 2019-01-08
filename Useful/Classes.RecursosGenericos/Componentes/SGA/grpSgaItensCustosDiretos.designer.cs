namespace Classes.RecursosGenericos.Componentes.SGA
{
    partial class grpItensCustosDiretos
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtItemDesc = new System.Windows.Forms.Uniube.TextBoxUniube();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtItem = new System.Windows.Forms.Uniube.TextBoxUniube();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labelUniube1 = new System.Windows.Forms.Uniube.LabelUniube();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtItemDesc);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.txtItem);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 27);
            this.panel3.TabIndex = 0;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.txtItemDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItemDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtItemDesc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemDesc.InformacaoToolTipCaminho = null;
            this.txtItemDesc.InformacaoToolTipDescricao = null;
            this.txtItemDesc.LimpaCampo = true;
            this.txtItemDesc.Location = new System.Drawing.Point(129, 6);
            this.txtItemDesc.MaxLength = 50;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.NomeCampoDadosDataTable = "";
            this.txtItemDesc.ParteDecimal = 0;
            this.txtItemDesc.ParteInteira = 0;
            this.txtItemDesc.ReadOnly = true;
            this.txtItemDesc.Size = new System.Drawing.Size(435, 21);
            this.txtItemDesc.TabIndex = 0;
            this.txtItemDesc.TipoCampo = System.Windows.Forms.Uniube.TextBoxUniube.CTipoCampo.Normal;
            this.txtItemDesc.TipoValor = System.Windows.Forms.Uniube.TextBoxUniube.CTipoValor.Geral;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(121, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(8, 21);
            this.panel5.TabIndex = 1145;
            // 
            // txtItem
            // 
            this.txtItem.BackColor = System.Drawing.Color.White;
            this.txtItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItem.InformacaoToolTipCaminho = null;
            this.txtItem.InformacaoToolTipDescricao = null;
            this.txtItem.LimpaCampo = true;
            this.txtItem.Location = new System.Drawing.Point(57, 6);
            this.txtItem.MaxLength = 3;
            this.txtItem.Name = "txtItem";
            this.txtItem.NomeCampoDadosDataTable = "";
            this.txtItem.ParteDecimal = 0;
            this.txtItem.ParteInteira = 0;
            this.txtItem.Size = new System.Drawing.Size(64, 21);
            this.txtItem.TabIndex = 0;
            this.txtItem.TipoCampo = System.Windows.Forms.Uniube.TextBoxUniube.CTipoCampo.Normal;
            this.txtItem.TipoValor = System.Windows.Forms.Uniube.TextBoxUniube.CTipoValor.Numerico;
            this.txtItem.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            this.txtItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
            this.txtItem.Leave += new System.EventHandler(this.txtItem_Leave);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.labelUniube1);
            this.panel6.Controls.Add(this.panel13);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(57, 21);
            this.panel6.TabIndex = 1144;
            // 
            // labelUniube1
            // 
            this.labelUniube1.AutoSize = true;
            this.labelUniube1.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelUniube1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUniube1.Location = new System.Drawing.Point(9, 3);
            this.labelUniube1.Name = "labelUniube1";
            this.labelUniube1.Size = new System.Drawing.Size(42, 13);
            this.labelUniube1.TabIndex = 1149;
            this.labelUniube1.Text = "Item:";
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel13.Location = new System.Drawing.Point(51, 3);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(6, 18);
            this.panel13.TabIndex = 1150;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(57, 3);
            this.panel7.TabIndex = 1148;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(564, 6);
            this.panel8.TabIndex = 0;
            // 
            // grpItensCustosDiretos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Name = "grpItensCustosDiretos";
            this.Size = new System.Drawing.Size(564, 27);
            this.Load += new System.EventHandler(this.grpItensCustosDiretos_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Uniube.TextBoxUniube txtItem;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Uniube.LabelUniube labelUniube1;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        public System.Windows.Forms.Uniube.TextBoxUniube txtItemDesc;

    }
}
