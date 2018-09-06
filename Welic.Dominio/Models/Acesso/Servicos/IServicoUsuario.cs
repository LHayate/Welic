using Welic.Dominio.Models.Acesso.Comandos;
using Welic.Dominio.Models.Acesso.Comandos.ComandoUsuario;
using Welic.Dominio.Models.Acesso.Entidade;

namespace Welic.Dominio.Models.Acesso.Servicos
{
    public interface IServicoUsuario
    {
        void RegistrarAtividadeUsuario(ComandoRegistroAtividadeUsuario comando);
        Usuario Criar(ComandoCriaUsuario comando);
        Usuario Autenticar(ComandoCriaUsuario comando);
        ComandoConsultaUsuario ObterPorId(int id);        
    }
}