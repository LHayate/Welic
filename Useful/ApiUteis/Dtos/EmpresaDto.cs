﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseFul.ClientApi.Dtos
{
    public class EmpresaDto
    {
        public int IdEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public decimal Fone { get; set; }
        public decimal? Fone1 { get; set; }
        public decimal? FoneFax { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public byte[] Imagem { get; set; }
        public string ConfigMailUser { get; set; }
        public string ConfigMailSenha { get; set; }
        public string ConfigMailSmtp { get; set; }
        public int? ConfigMailPorta { get; set; }
        public string InfFaturamento { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public bool? ConfigMailEnableSsl { get; set; }        
    }
}
