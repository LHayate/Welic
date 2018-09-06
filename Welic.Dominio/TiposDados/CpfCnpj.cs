namespace Welic.Dominio.TiposDados
{
    public abstract class CpfCnpj
    {
        public string Valor { get; protected set; }
        public virtual string ValorFormatado { get; protected set; }
        public abstract bool Validar();
    }
}