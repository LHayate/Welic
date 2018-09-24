namespace Welic.App.Services.ServicesViewModels
{
    public interface ICriptografia
    {
        string Encriptar(string chave, string vetorInicializacao, string textoNormal);
        string Decriptar(string chave, string vetorInicializacao, string textoEncriptado);
    }
}
