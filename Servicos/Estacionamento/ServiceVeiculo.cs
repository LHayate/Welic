﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Estacionamento.Map;
using Welic.Dominio.Models.Estacionamento.Services;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Services.Estacionamento
{
    public class ServiceVeiculo : Service<VeiculosMap>, IServiceVeiculo
    {
        public ServiceVeiculo(IRepositoryAsync<VeiculosMap> repository) : base(repository)
        {
        }
    }
}
