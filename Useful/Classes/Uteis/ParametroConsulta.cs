namespace UseFul.Uteis
{
    public class ParametroConsulta
    {
        public string Nome { get; }

        public object Valor { get; set; }

        public ParametroConsulta(string nome, object valor)
        {
            Nome = nome;
            Valor = valor;
        }
    }
}