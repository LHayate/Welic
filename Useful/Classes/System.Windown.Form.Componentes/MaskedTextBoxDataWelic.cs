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
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\iMasktextbox.ico")]
    public partial class MaskedTextBoxDataWelic : MaskedTextBox
    {
        public MaskedTextBoxDataWelic()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            if (base.ReadOnly)
                base.BackColor = Color.FromArgb(231, 231, 231);
        }

        public MaskedTextBoxDataWelic(IContainer container)
        {
            container.Add(this);
            base.Mask = "00/00/0000";
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

        public static string VerificaAno(string Data)
        {
            string ano = Data;
            string retorno = ano = ano.Substring(6, 4);
            int year = Convert.ToInt32(ano);

            if (year < 1753)
                retorno = "1753";

            if (year > 9998)
                retorno = "9998";

            return retorno;
        }

        public static string VerificaMes(string Data)
        {
            string mes = Data;
            string retorno = mes = mes.Substring(3, 2);
            int month = Convert.ToInt32(mes);

            if (month < 0)
                retorno = "01";

            if (month > 12)
                retorno = "12";

            return retorno;
        }

        public static string VerificaDia(string Data)
        {
            string mes = Data;
            string dia = Data;
            string ano = Data;
            string retorno =  dia = dia.Substring(0, 2);
            mes = mes.Substring(3, 2);
            ano = ano.Substring(6, 4);
            int day = Convert.ToInt32(dia);
            int month = Convert.ToInt32(mes);
            int year = Convert.ToInt32(ano);

            if (day > 31)
            {
                day = 31;
                retorno = day.ToString().PadLeft(2,'0');
            }

            if (day < 1)
            {
                day = 01;
                retorno = "0" + day.ToString();
            }

            if ((month == 02))
            {
                if (day >= 29)
                {
                    if (year % 4 == 0 && day == 29)
                    {
                        retorno = day.ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        if (year % 4 != 0)
                        {
                            retorno = "28";
                        }
                        else
                        {
                            retorno = "29";
                        }
                    }
                }
            }

            if ((month == 04))
            {
                if (day > 30)
                {
                    retorno = "30";
                }
                else
                {
                    retorno = day.ToString().PadLeft(2, '0');
                }
            }

            if ((month == 06))
            {
                if (day > 30)
                {
                    retorno = "30";
                }
                else
                {
                    retorno = day.ToString().PadLeft(2, '0');
                }
            }

            if ((month == 09))
            {
                if (day > 30)
                {
                    retorno = "30";
                }
                else
                {
                    retorno = day.ToString().PadLeft(2, '0');
                }
            }

            if ((month == 11))
            {
                if (day > 30)
                {
                    retorno = "30";
                }
                else
                {
                    retorno = day.ToString().PadLeft(2, '0');
                }
            }

            return retorno;
        }

        public enum CTipoCampo { Normal, Chave, ChaveAutoIncremento, Obrigatorio };
        private CTipoCampo _tipoCampo = CTipoCampo.Normal;
        public CTipoCampo TipoCampo
        {
            get { return _tipoCampo; }
            set
            {
                _tipoCampo = value;
                if (!base.ReadOnly)
                {
                    if (_tipoCampo != CTipoCampo.Normal)
                        base.BackColor = Color.FromArgb(221, 236, 255);
                    else
                        base.BackColor = Color.White;
                }
                else
                    base.BackColor = Color.FromArgb(231, 231, 231);
            }
        }

        private bool _limpaCampo = true;

        public bool LimpaCampo
        {
            get { return _limpaCampo; }
            set { _limpaCampo = value; }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!base.ReadOnly)
                base.BackColor = Color.LemonChiffon;
            else
                base.BackColor = Color.FromArgb(231, 231, 231);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (!base.ReadOnly)
            {
                if (_tipoCampo != CTipoCampo.Normal)
                    base.BackColor = Color.FromArgb(221, 236, 255);
                else
                    base.BackColor = Color.White;
            }
            else
                base.BackColor = Color.FromArgb(231, 231, 231);
            ValidaMask();
        }

        private string data = "";

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            //if (base.MaskFull == true)
            //    SendKeys.Send("{TAB}");


            //if (data.Length == 0 && base.Text.Substring(0, 1) != "_")
            //{
            //    data += base.Text.Substring(0, 1);
            //}
            //else
            //{
            //    if (data.Length == 1)
            //        data += base.Text.Substring(1, 1);
            //}
            
            //if (data.Length == 2)
            //{
            //    data += DateTime.Now.Month.ToString().PadLeft(2,'0') + DateTime.Now.Year;
            //    base.Text = data;
            //}

            if (base.MaskFull == true)
            {
                string retornoDia = VerificaDia(base.Text);
                string retornoMes = VerificaMes(base.Text);
                string retornoAno = VerificaAno(base.Text);

                string dia = "";
                string mes = "";
                string ano = "";

                string teste = "";

                data = base.Text;
                dia = data.Substring(0, 2);
                base.Text = data.Replace(dia, retornoDia);
                teste = base.Text;
                data = base.Text;
                mes = data.Substring(3, 2);
                base.Text = data.Replace(mes, retornoMes);

                data = base.Text;
                ano = data.Substring(6, 4);
                base.Text = data.Replace(ano, retornoAno);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            ExecutaTabPressionaEnter(e);
        }

        protected void ValidaMask()
        {
            var Digitos = "0123456789";
            for (int i = 0; i < base.Text.Length; i++)
            {
                string stv = base.Text.Substring(i, 1);
                if (stv != " " || string.IsNullOrEmpty(base.Text))
                {
                    if (Digitos.IndexOf(stv) >= 0)
                    {
                        if (base.MaskFull == false)
                        {
                            MessageBox.Show("Favor informe o campo completo.", "Atenção!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            base.Focus();
                            return;
                        }
                    }
                }
            }
        }

        private void ExecutaTabPressionaEnter(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send((e.Shift ? "+" : "") + "{TAB}");
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (!base.ReadOnly)
            {
                if (base.Enabled == false)
                    base.BackColor = Color.FromArgb(231, 231, 231);
                else
                {
                    if (_tipoCampo != CTipoCampo.Normal)
                        base.BackColor = Color.FromArgb(221, 236, 255);
                    else
                        base.BackColor = Color.White;
                }
            }
            else
                base.BackColor = Color.FromArgb(231, 231, 231);
        }

        protected override void OnReadOnlyChanged(EventArgs e)
        {
            base.OnReadOnlyChanged(e);
            if (base.ReadOnly)
                base.BackColor = Color.FromArgb(231, 231, 231);
            else
            {
                if (_tipoCampo != CTipoCampo.Normal)
                    base.BackColor = Color.FromArgb(221, 236, 255);
                else
                    base.BackColor = Color.White;
            }
        }
    }
}
