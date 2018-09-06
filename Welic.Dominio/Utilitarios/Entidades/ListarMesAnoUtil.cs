using System;
using System.Collections.Generic;
using Welic.Dominio.TiposDados;
using Welic.Dominio.Utilitarios.Escopos;

namespace Welic.Dominio.Utilitarios.Entidades
{
    public class ListarMesAnoUtil
    {
        public DateTime DataInicial { get; set; }
        public int QuantidadeMeses { get; set; }

        public ListarMesAnoUtil(DateTime dataInicial, int quantidadeMeses)
        {
            DataInicial = dataInicial;
            QuantidadeMeses = quantidadeMeses;
        }

        public void Validar()
        {
            this.ValidarNovaLista();
        }

        public List<MesAno> Listar()
        {
            List<MesAno> listaMesAno = new List<MesAno>();

            DateTime dataFinal = DataInicial.AddMonths(QuantidadeMeses);

            listaMesAno.Add(new MesAno(DataInicial.Month, DataInicial.Year));

            while (DataInicial <= dataFinal)
            {
                DataInicial = DataInicial.AddMonths(1);

                MesAno mesAno = new MesAno(DataInicial.Month, DataInicial.Year);
                mesAno.Validar();

                listaMesAno.Add(mesAno);
            }

            return listaMesAno;
        }
    }
}