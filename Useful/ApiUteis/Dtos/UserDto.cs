using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UseFul.Uteis;
using Welic.Dominio.Models.Users.Mapeamentos;
using static UseFul.ClientApi.Adaptador;

namespace UseFul.ClientApi.Dtos
{
    public class UserDto : BaseDto<UserDto>
    {
        public string Id { get; set; }
        public Guid Guid { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Profession { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        
        public string ImagePerfil { get; set; }
        public string Identity { get; set; }
        public DateTime LastAccessDate { get; set; }
        public string LastAccessIP { get; set; }
        public System.DateTime RegisterDate { get; set; }
        public string RegisterIP { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int LeadSourceID { get; set; }
        public bool AcceptEmail { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool Disabled { get; set; }
        public double Rating { get; set; }        
        public int IdEmpresa { get; set; }

        

        public UserDto()
        {
            
        }

        public async void AlterarSenhaUsuario(int idUsuario, string novaSenha, string token)
        {
            Task<HttpResponseMessage> response =
                ClienteApi.Instance.RequisicaoGetAsync($"user/getbyid/{idUsuario}");
            var usuario =
                ClienteApi.Instance.ObterRespostaAsync<UserDto>(await response);            

            if (usuario == null)
            {
                throw CustomErro.Erro("Usuário não encontrado pelo código informado.");
            }

            usuario.Result.Password = novaSenha;            

            HttpResponseMessage
                response1 = ClienteApi.Instance.RequisicaoPost($"user/ResetPassword/{token}", usuario);
            
                ClienteApi.Instance.ObterResposta(response1);
                
                        
        }
        public void AssociarPermissaoUsuario(string idUsuario, List<int> listIdDepartamento)
        {
            var deletedeDepartamentos =
                AdaptadorGeneric<Welic.Dominio.Models.Departamento.Map.DepartamentoUsuario, DepartamentoUsuario>(
                        Context.DepartamentoUsuario.Select(x => x).Where(p => p.UserId == idUsuario).ToList());
            foreach (var deletePermissaoDepartamentos in from item in deletedeDepartamentos
                let idUsuarioLet = item.UserId
                let idDepartamento =
                    item.IdDepartamento
                select
                    Context.DepartamentoUsuario
                        .First(
                            p =>
                                p
                                    .IdDepartamento ==
                                idDepartamento &&
                                p.UserId ==
                                idUsuarioLet))
            {
                Context.DepartamentoUsuario.Remove(deletePermissaoDepartamentos);
            }
            foreach (int departamentoChecado in listIdDepartamento)
            {
                Context.DepartamentoUsuario.Add(
                    AdaptadorGeneric<DepartamentoUsuario, Welic.Dominio.Models.Departamento.Map.DepartamentoUsuario
                        >(new DepartamentoUsuario()
                        {
                            IdDepartamento = departamentoChecado,
                            UserId = idUsuario
                        }));
            }
            Context.SaveChanges();
        }
        public bool ExisteUsuarioPorUsuario(string usuario)
        {
            return Context.User.Any(u => u.Id == usuario);
        }

        public List<int> ConsultaPermissoesIdDepartamentoIdPorUsuario(string idUsuario)
        {
            return Context.DepartamentoUsuario.Where(
                    p => p.UserId == idUsuario)
                .Select(
                    p => p.IdDepartamento).ToList();
        }

        public UserDto ConsultaUsuarioPorIdUsuario(string idUsuario, bool somenteAtivos = true)
        {
            //var usuarioConsultado =
            //    Context.User.Include("Departamentos")
            //        .FirstOrDefault(u => u.Id == idUsuario);

            HttpResponseMessage response = ClienteApi.Instance.RequisicaoGet($"user/getbyId/{idUsuario}");
            var usuarioConsultado = ClienteApi.Instance.ObterResposta<UserDto>(response);

            if (usuarioConsultado == null)
            {
                throw CustomErro.Erro("Usuário ou senha inválidos.");
            }

            if (somenteAtivos)
            {
                if (!usuarioConsultado.Disabled)
                {
                    throw CustomErro.Erro("O usuário não possui permissões de acesso ao sistema.");
                }
            }

            return usuarioConsultado;
        }

        public UserDto ConsultaUsuarioPorNomeUsuario(string usuario, bool somenteAtivos = true)
        {
            //var usuarioConsultado =
            //    Context.User.Include("Departamentos")
            //        .FirstOrDefault(u => u.FullName == usuario);

            HttpResponseMessage response = ClienteApi.Instance.RequisicaoGet($"user/getbynome/{usuario}");
            var usuarioConsultado = ClienteApi.Instance.ObterResposta<UserDto>(response);


            if (usuarioConsultado == null)
            {
                throw CustomErro.Erro("Usuário ou senha inválidos.");
            }
            if (somenteAtivos)
            {
                if (usuarioConsultado.Disabled)
                {
                    throw CustomErro.Erro("O usuário não possui permissões de acesso ao sistema.");
                }
            }
            return usuarioConsultado;
        }
        public UserDto ConsultaUsuarioPorEmail(string usuario, bool somenteAtivos = true)
        {
            //var usuarioConsultado =
            //    Context.User.Include("Departamentos")
            //        .FirstOrDefault(u => u.Email == usuario);

            HttpResponseMessage response = ClienteApi.Instance.RequisicaoGet($"user/getbyemail?email={usuario}");
            var usuarioConsultado = ClienteApi.Instance.ObterResposta<UserDto>(response);               

            if (usuarioConsultado == null)
            {
                throw CustomErro.Erro("Usuário ou senha inválidos.");
            }
            if (somenteAtivos)
            {
                if (usuarioConsultado.Disabled)
                {
                    throw CustomErro.Erro("O usuário não possui permissões de acesso ao sistema.");
                }
            }
            return usuarioConsultado;
        }

       
        public List<int> ConsultaPermissoesUsuario(string idUsuario)
        {
            List<int> permissoes =
                Context.DepartamentoUsuario.Where(
                        p => p.UserId == idUsuario)
                    .Select(p => p.IdDepartamento)
                    .ToList();
            if (permissoes.Count == 0)
            {
                throw CustomErro.Erro("Usuário não possui permissões para outros departamentos.");
            }
            return permissoes;
        }

        public bool VerificaUsuarioPossuiDepartamentoPermissao(string idUsuario, string descricaoDepartamento)
        {
            int idDepartamento = DepartamentoDto.Instance.BuscaCodigoDepartamentoPorDescricao(descricaoDepartamento);
            var usuarioPermissao = Context.DepartamentoUsuario
                .FirstOrDefault(
                    p =>
                        p.IdDepartamento == idDepartamento &&
                        p.UserId == idUsuario);
            return usuarioPermissao != null;
        }

        public void AdicionarUsuario(UserDto usuario)
        {
            Context.User.Add(AdaptadorGeneric<UserDto,AspNetUser>(usuario));
            Context.SaveChanges();
        }

        public List<UserDto> ConsultaUsuarios()
        {
            //List<UserDto> listaUsuarios =
            //    AdaptadorGeneric<AspNetUser, UserDto>(Context.User.Include("Departamentos").Select(x=> x).ToList());

            HttpResponseMessage response = ClienteApi.Instance.RequisicaoGet($"user/getall");
            var listaUsuarios = ClienteApi.Instance.ObterResposta<List<UserDto>>(response);

            if (!listaUsuarios.Any())
            {
                throw CustomErro.Erro("Nenhum usuário encontrado.");
            }

            return listaUsuarios;
        }
        

        public void Delete(string idUsuario)
        {
            HttpResponseMessage
                response1 = ClienteApi.Instance.RequisicaoPost($"user/delete/{idUsuario}");

            ClienteApi.Instance.ObterResposta(response1);
        }
    }
}
