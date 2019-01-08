using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using Welic.Dominio.Models.ConfigApp.Map;
using Welic.Dominio.Models.Curso.Map;
using Welic.Dominio.Models.Departamento.Map;
using Welic.Dominio.Models.EBook.Map;
using Welic.Dominio.Models.Empresa.Map;
using Welic.Dominio.Models.Estacionamento.Map;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.Dominio.Models.Menu.Mapeamentos;
using Welic.Dominio.Models.Schedule.Maps;
using Welic.Dominio.Models.Segurança.Map;
using Welic.Dominio.Models.Uploads.Maps;
using Welic.Dominio.Models.Users.Scope;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Users.Mapeamentos
{
    public partial class AspNetUser : Entity
    {


        public AspNetUser()
        {
            this.AspNetUserClaims = new List<AspNetUserClaim>();
            this.AspNetUserLogins = new List<AspNetUserLogin>();
            this.Listings = new List<Listing>();
            this.Messages = new List<Message>();
            this.MessageParticipants = new List<MessageParticipant>();
            this.MessageReadStates = new List<MessageReadState>();
            this.OrdersProvider = new List<Order>();
            this.OrdersReceiver = new List<Order>();
            this.ListingReviewsUserFrom = new List<ListingReview>();
            this.ListingReviewsUserTo = new List<ListingReview>();
            this.AspNetRoles = new List<AspNetRole>();
            this.Uploads = new List<UploadsMap>();
            this.SchedulesAluno = new List<ScheduleMap>();
            this.SchedulesTeacher = new List<ScheduleMap>();
            this.LivesClass = new List<LiveMap>();
            this.LivesTeacher = new List<LiveMap>();
        }
        
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
        [DefaultValue("https://welic.app/Arquivos/Icons/perfil_Padrao.png")]
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
        public bool Development { get; set; }
                
        public virtual ICollection<CursoMap> TeacherCursos { get; set; }
        public virtual ICollection<CursoMap> ClassCursos { get; set; }

        //public GroupUserMap GroupUserMap { get; set; }
        private ICollection<MenuMap> _menus;

        public ICollection<MenuMap> Menus
        {
            get => _menus;

            private set => _menus = new List<MenuMap>(value);
        }


        public virtual ICollection<ScheduleMap> SchedulesTeacher { get; set; }
        public virtual ICollection<ScheduleMap> SchedulesAluno { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<MessageParticipant> MessageParticipants { get; set; }
        public virtual ICollection<MessageReadState> MessageReadStates { get; set; }
        public virtual ICollection<Order> OrdersProvider { get; set; }
        public virtual ICollection<Order> OrdersReceiver { get; set; }
        public virtual ICollection<ListingReview> ListingReviewsUserFrom { get; set; }
        public virtual ICollection<ListingReview> ListingReviewsUserTo { get; set; }
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
        public virtual ICollection<UploadsMap> Uploads { get; set; }
        public virtual ICollection<LiveMap> LivesTeacher { get; set; }
        public virtual ICollection<LiveMap> LivesClass { get; set; }
        public virtual ICollection<EBookMap> EbookTeacher { get; set; }
        public virtual ICollection<EBookMap> EBookClass { get; set; }
        public virtual ICollection<FavoriteLiveMap> FavoriteUserLive { get; set; }
        [ForeignKey("EmpresaId")]
        public  virtual EmpresaMap Empresa { get; set; }
        [DefaultValue(3)]
        public int? EmpresaId { get; set; }
        public virtual ICollection<PermissionMap> Permission { get; set; }
        public virtual ICollection<DepartamentoMap> Departamentos { get; set; }
        public virtual ICollection<SolicitacoesVagasMap> SolicitacoesVagasCadastro { get; set; }
        public virtual ICollection<SolicitacoesVagasMap> SolicitacoesVagasCancel { get; set; }
        public ICollection<SolicitacoesVagasLiberadasMap> SolicitacoesVagasLiberadas { get; set; }
        public ICollection<SolicitacoesVagasLiberadasMap> SolicitacoesVagasLiberadasCancel { get; set; }
        public ICollection<SolicitacoesVagasLiberadasMap> SolicitacoesVagasLiberadasSuspensao { get; set; }


        public bool ValidarNomeUsuarioESenha(string nomeUsuario, string password)
        {
            return this.ValidarEscopoNomeUsuarioESenha(nomeUsuario, password);
        }
    }
}
