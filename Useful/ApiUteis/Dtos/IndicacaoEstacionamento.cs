using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Welic.Infra.Context;
using Welic.Infra.Migrations;

namespace UseFul.ClientApi.Dtos
{
    public class IndicacaoEstacionamento
    {
        public int IdEstacionamento { get; set; }
        public string DescricaoEstacionamento { get; set; }
        public int TipoVaga { get; set; }
        public string TipoVagaDescricao  { get; set; }
        public int Quantidade { get; set; }
        public bool Manha { get; set; }
        public bool Tarde { get; set; }
        public bool Noite { get; set; }
        public int Situacao { get; set; }
        public string SituacaoDescricao { get; set; }
        public long? Vaga { get; set; }
        public string  Solicitacao { get; set; }

        public AuthContext _AuthContext { get; set; }

        public IndicacaoEstacionamento(AuthContext authContext)
        {
            _AuthContext = authContext;

        }
        public IndicacaoEstacionamento BuscaIndicacaoEstacionamento(int solicitacao)
        {
            var result = _AuthContext.SolicitacoesEstacionamento
                .Join(_AuthContext.Estacionamento, se => se.Estacionamento, e => e.IdEstacionamento,
                    (se, e) => new {se, e})
                .Join(_AuthContext.EstacionamentoVagas, @t => @t.e.IdEstacionamento, ev => ev.IdEstacionamento,
                    (@t, ev) => new {@t, ev})
                .Join(_AuthContext.SolicitacoesVagas, @t => @t.@t.se.Solicitacao, sv => sv.IdSolicitacao,
                    (@t, sv) => new {@t, sv})
                .Join(_AuthContext.Veiculos, @t => @t.sv.IdVeiculo, v => v.IdVeiculo,                 
                    (@t, v) => new {@t, v})
                .Select(x => new
                {
                    IdEstacionamento = x.t.t.t.se.Estacionamento,
                    DescricaoEstacionamento = x.t.t.t.e.Descricao,
                    x.t.t.t.se.TipoVaga,
                    x.t.t.t.se.Manha,
                    x.t.t.t.se.Tarde,
                    x.t.t.t.se.Noite,
                    x.t.t.t.se.Situacao,
                    x.t.t.t.se.Vaga,
                    x.t.t.t.se.Solicitacao,                    
                })
                .Where(x=> x.Solicitacao == solicitacao )
                .OrderBy(x=> x.IdEstacionamento);


                

            var indicacao = (IndicacaoEstacionamento)result;
            switch (indicacao.TipoVaga)
            {
                case 1:
                    indicacao.DescricaoEstacionamento = "Horista";
                    break;
                case 2:
                    indicacao.DescricaoEstacionamento = "Diarista";
                    break;
                case 3:
                    indicacao.DescricaoEstacionamento = "Mensal";
                    break;
            }

            switch (indicacao.Situacao)
            {
                case 1:
                    indicacao.SituacaoDescricao = "Pendente";
                    break;
                case 2:
                    indicacao.SituacaoDescricao = "Atendida";
                    break;
                case 3:
                    indicacao.SituacaoDescricao = "Cancelada";
                    break;
            }



            return (IndicacaoEstacionamento) indicacao;
        }





    }
}
