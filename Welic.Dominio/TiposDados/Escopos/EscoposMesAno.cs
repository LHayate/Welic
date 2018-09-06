using Welic.Dominio.Validacao;

namespace Welic.Dominio.TiposDados.Escopos
{
    public static class EscoposMesAno
    {
        public static bool ValidarNovoMesAno(this MesAno mesAno)
        {
            return
                Validador.SeSatisfazPor(
                    Validador.AssegurarMaiorQue(mesAno.Mes, 0,
                        "O mês deve ser maior que 0"),
                    Validador.AssegurarMenorOuIgualQue(mesAno.Mes, 12,
                        "O mês deve ser menor ou igual a 12"),
                    Validador.AssegurarMaiorOuIgualQue(mesAno.Ano, 1900,
                        "O ano deve ser maior ou igual a 1900"),
                    Validador.AssegurarMenorOuIgualQue(mesAno.Ano, 3000,
                        "O mes deve ser menor ou igual a 3000")
                );
        }
    }
}