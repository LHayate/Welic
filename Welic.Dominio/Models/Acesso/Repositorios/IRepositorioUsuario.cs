using System.Collections.Generic;
using Welic.Dominio.Models.Acesso.Comandos;
using Welic.Dominio.Models.Acesso.Entidade;

namespace Welic.Dominio.Models.Acesso.Repositorios
{
    public interface IRepositorioUsuario
    {
        void Criar(Usuario novoUsuario);
        Usuario ObterPorNomeUsuario(string nomeUsuario);
        Usuario ObterPorid(int id);
        List<Usuario> ObterUsuariosPorIdMenu(int idMenu);
        bool UsuarioEAprovadordeOrcamentodaObra(int id, int idObra);
        bool UsuarioEAprovadordaFolhadePagamentosdaObra(int idUsuario, int idObra);
        bool UsuarioEAprovadorRequisicaoObra(int idUsuario, int idObra);
        bool UsuarioEAprovadorFiscalObra(int idUsuario, int idObra);
        bool UsuarioEAprovadorFinanceiroObra(int idUsuario, int idObra);
        decimal ObterPercentualVariacaoEntradaDocumentos(string momeUsuario, int idObra);
        List<int> ObrasEntradaDocumento(int idUsuario);
        bool UsuarioEReclassificaItensOrdensCompra(int idUsuario, int idObra);
        bool UsuarioCancelaContratoVenda(int idUsuario, int idObra);
        void RegistrarAtividadeUsuario(ComandoRegistroAtividadeUsuario comando);
        List<int> ObterCodigosObraAcessoPorUsuario(int idUsuario);
        bool UsuarioAlteraContratoVenda(int idUsuario, int idObra);
    }
}