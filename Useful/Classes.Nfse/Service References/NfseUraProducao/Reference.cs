﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UseFul.Nfse.NfseUraProducao {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NfseUraProducao.INfseServices")]
    public interface INfseServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INfseServices/RecepcionarLoteRps", ReplyAction="http://tempuri.org/INfseServices/RecepcionarLoteRpsResponse")]
        string RecepcionarLoteRps(string cabec, string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INfseServices/ConsultarSituacaoLoteRps", ReplyAction="http://tempuri.org/INfseServices/ConsultarSituacaoLoteRpsResponse")]
        string ConsultarSituacaoLoteRps(string cabec, string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INfseServices/ConsultarNfsePorRps", ReplyAction="http://tempuri.org/INfseServices/ConsultarNfsePorRpsResponse")]
        string ConsultarNfsePorRps(string cabec, string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INfseServices/ConsultarNfse", ReplyAction="http://tempuri.org/INfseServices/ConsultarNfseResponse")]
        string ConsultarNfse(string cabec, string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INfseServices/ConsultarLoteRps", ReplyAction="http://tempuri.org/INfseServices/ConsultarLoteRpsResponse")]
        string ConsultarLoteRps(string cabec, string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INfseServices/CancelarNfse", ReplyAction="http://tempuri.org/INfseServices/CancelarNfseResponse")]
        string CancelarNfse(string cabec, string msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INfseServicesChannel : UseFul.Nfse.NfseUraProducao.INfseServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NfseServicesClient : System.ServiceModel.ClientBase<UseFul.Nfse.NfseUraProducao.INfseServices>, UseFul.Nfse.NfseUraProducao.INfseServices {
        
        public NfseServicesClient() {
        }
        
        public NfseServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NfseServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NfseServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NfseServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string RecepcionarLoteRps(string cabec, string msg) {
            return base.Channel.RecepcionarLoteRps(cabec, msg);
        }
        
        public string ConsultarSituacaoLoteRps(string cabec, string msg) {
            return base.Channel.ConsultarSituacaoLoteRps(cabec, msg);
        }
        
        public string ConsultarNfsePorRps(string cabec, string msg) {
            return base.Channel.ConsultarNfsePorRps(cabec, msg);
        }
        
        public string ConsultarNfse(string cabec, string msg) {
            return base.Channel.ConsultarNfse(cabec, msg);
        }
        
        public string ConsultarLoteRps(string cabec, string msg) {
            return base.Channel.ConsultarLoteRps(cabec, msg);
        }
        
        public string CancelarNfse(string cabec, string msg) {
            return base.Channel.CancelarNfse(cabec, msg);
        }
    }
}
