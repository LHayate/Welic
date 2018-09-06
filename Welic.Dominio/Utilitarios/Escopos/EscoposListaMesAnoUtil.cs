using System;
using Welic.Dominio.Utilitarios.Entidades;
using Welic.Dominio.Validacao;

namespace Welic.Dominio.Utilitarios.Escopos
{
    public static class EscoposListaMesAnoUtil
    {
        public static bool ValidarNovaLista(this ListarMesAnoUtil listarMesAnoUtil)
        {
            return
                Validador.SeSatisfazPor(
                    Validador.AssegurarMaiorQue(listarMesAnoUtil.QuantidadeMeses, 0,
                        "A Quantidade de meses deve ser maior que zero"),
                    Validador.AssegurarMenorOuIgualQue(listarMesAnoUtil.QuantidadeMeses, 1000,
                        "A quantidade de meses deve ser menor que 1000"),
                    Validador.AssegurarMaiorQue(listarMesAnoUtil.DataInicial, new DateTime(1900, 1, 1),
                        "A data inicial deve ser maior que 01/01/1900"),
                    Validador.AssegurarMenorOuIgualQue(listarMesAnoUtil.DataInicial, new DateTime(3000, 1, 1),
                        "A data inicial deve ser maior que 01/01/3000")
                );
        }
    }
}