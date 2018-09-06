namespace Welic.Dominio.Models.Acesso.Comandos.ComandoUsuario
{
    public class ComandoCriaUsuario
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }

        public ComandoCriaUsuario()
        {
        }

        public ComandoCriaUsuario(string nomeUsuario, string senha)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }
    }
}