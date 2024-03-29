﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UseFul.Forms.Welic
{
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\iRadiobutton.ico")]
    public partial class RadioButtonWelic : RadioButton
    {
        public RadioButtonWelic()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        public RadioButtonWelic(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        /// <summary>
        /// Nome da coluna no DataTable, utilizado pelo método PreencherCampos(ControlCollection controls, DataTable dtDados)
        /// </summary>
        private string _NomeCampoDadosDataTable;
        public string NomeCampoDadosDataTable
        {
            get { return _NomeCampoDadosDataTable; }
            set
            { _NomeCampoDadosDataTable = value; }
        }
        /// <summary>
        /// O RadioButton só será marcado quando o valor da propriedade NomeCampoDadosDataTable corresponder ao valor da propriedade ValorNomeCampoDadosDataTable
        /// </summary>
        private string _ValorNomeCampoDadosDataTable;
        public string ValorNomeCampoDadosDataTable
        {
            get { return _ValorNomeCampoDadosDataTable; }
            set
            { _ValorNomeCampoDadosDataTable = value; }
        }
        /// <summary>
        /// O valor true para a propriedade faz com que o RadioButton seja ignorado no filtro automático (MontarFiltros) do Form RelatórioCompleto.
        /// A utilização é destinada a ignorar o RadioButton quando este fizer referência a algum tipo "geral", ou seja, não for informada condição.
        /// Por exemplo: Supondo que um GroupBox tenha 3 Radio's, Ativo, Inativo e Geral ou Todos, a opção deve ser utilizada no Geral/Todos,
        /// dessa forma, não apareceça/ocupará espaço no relatório na parte de filtro, visto que de fato não foi filtrado.
        /// </summary>
        private bool _OcultarFiltro;
        public bool OcultarFiltro
        {
            get { return _OcultarFiltro; }
            set { _OcultarFiltro = value; }
        }

        private bool _limpaCampo = true;

        public bool LimpaCampo
        {
            get { return _limpaCampo; }
            set { _limpaCampo = value; }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.Enabled)
            {
                this.Font = new Font(this.Font, FontStyle.Bold);
            }
            else
            {
                this.Font = new Font(this.Font, FontStyle.Regular);
                this.BackColor = Color.Transparent;
            }
        }
    }
}