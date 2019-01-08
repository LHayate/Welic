namespace Componentes
{
    partial class IntervaloCompetencias
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
            this.cbFinal = new UseFul.Forms.Welic.ComboBoxWelic(this.components);
            this.cbInicial = new UseFul.Forms.Welic.ComboBoxWelic(this.components);
            this.dtpAnoFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpAnoInicial = new System.Windows.Forms.DateTimePicker();
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
            this.pnIntervaloCampos.Controls.Add(this.cbFinal);
            this.pnIntervaloCampos.Controls.Add(this.cbInicial);
            this.pnIntervaloCampos.Controls.Add(this.dtpAnoFinal);
            this.pnIntervaloCampos.Controls.Add(this.dtpAnoInicial);
            this.pnIntervaloCampos.Controls.Add(this.lbFinal);
            this.pnIntervaloCampos.Controls.Add(this.lbInicial);
            this.pnIntervaloCampos.Controls.Add(this.pnTitulo);
            this.pnIntervaloCampos.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnIntervaloCampos.Location = new System.Drawing.Point(0, 0);
            this.pnIntervaloCampos.Margin = new System.Windows.Forms.Padding(0);
            this.pnIntervaloCampos.Name = "pnIntervaloCampos";
            this.pnIntervaloCampos.Size = new System.Drawing.Size(136, 93);
            this.pnIntervaloCampos.TabIndex = 2;
            // 
            // cbFinal
            // 
            this.cbFinal.Enabled = false;
            this.cbFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFinal.FormattingEnabled = true;
            this.cbFinal.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbFinal.LimpaCampo = false;
            this.cbFinal.Location = new System.Drawing.Point(97, 57);
            this.cbFinal.MaxLength = 2;
            this.cbFinal.Name = "cbFinal";
            this.cbFinal.NomeCampoDadosDataTable = null;
            this.cbFinal.Size = new System.Drawing.Size(36, 21);
            this.cbFinal.TabIndex = 4;
            this.cbFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFinal_KeyPress);
            this.cbFinal.Leave += new System.EventHandler(this.cbFinal_Leave);
            // 
            // cbInicial
            // 
            this.cbInicial.Enabled = false;
            this.cbInicial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInicial.FormattingEnabled = true;
            this.cbInicial.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbInicial.LimpaCampo = false;
            this.cbInicial.Location = new System.Drawing.Point(97, 25);
            this.cbInicial.MaxLength = 2;
            this.cbInicial.Name = "cbInicial";
            this.cbInicial.NomeCampoDadosDataTable = null;
            this.cbInicial.Size = new System.Drawing.Size(36, 21);
            this.cbInicial.TabIndex = 2;
            this.cbInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbInicial_KeyPress);
            this.cbInicial.Leave += new System.EventHandler(this.cbInicial_Leave);
            // 
            // dtpAnoFinal
            // 
            this.dtpAnoFinal.CustomFormat = "yyyy";
            this.dtpAnoFinal.Enabled = false;
            this.dtpAnoFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAnoFinal.Location = new System.Drawing.Point(46, 57);
            this.dtpAnoFinal.Name = "dtpAnoFinal";
            this.dtpAnoFinal.Size = new System.Drawing.Size(49, 21);
            this.dtpAnoFinal.TabIndex = 3;
            // 
            // dtpAnoInicial
            // 
            this.dtpAnoInicial.CustomFormat = "yyyy";
            this.dtpAnoInicial.Enabled = false;
            this.dtpAnoInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAnoInicial.Location = new System.Drawing.Point(46, 25);
            this.dtpAnoInicial.Name = "dtpAnoInicial";
            this.dtpAnoInicial.Size = new System.Drawing.Size(49, 21);
            this.dtpAnoInicial.TabIndex = 1;
            // 
            // lbFinal
            // 
            this.lbFinal.AutoSize = true;
            this.lbFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFinal.Location = new System.Drawing.Point(7, 60);
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
            this.chkTitulo.NomeCampoDadosDataTable = null;
            this.chkTitulo.Size = new System.Drawing.Size(131, 19);
            this.chkTitulo.TabIndex = 0;
            this.chkTitulo.Text = "Inter. Comp.";
            this.chkTitulo.UseVisualStyleBackColor = false;
            this.chkTitulo.CheckedChanged += new System.EventHandler(this.chkTitulo_CheckedChanged);
            // 
            // IntervaloCompetencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.pnIntervaloCampos);
            this.Name = "IntervaloCompetencias";
            this.Size = new System.Drawing.Size(136, 93);
            this.pnIntervaloCampos.ResumeLayout(false);
            this.pnIntervaloCampos.PerformLayout();
            this.pnTitulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public UseFul.Forms.Welic.PanelWelic pnIntervaloCampos;
        public System.Windows.Forms.DateTimePicker dtpAnoFinal;
        public System.Windows.Forms.DateTimePicker dtpAnoInicial;
        private UseFul.Forms.Welic.LabelWelic lbFinal;
        private UseFul.Forms.Welic.LabelWelic lbInicial;
        private UseFul.Forms.Welic.PanelWelic pnTitulo;
        public UseFul.Forms.Welic.CheckBoxWelic chkTitulo;
        public UseFul.Forms.Welic.ComboBoxWelic cbFinal;
        public UseFul.Forms.Welic.ComboBoxWelic cbInicial;
    }
}
