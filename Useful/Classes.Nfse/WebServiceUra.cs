using System;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.IO;
using System.Xml;
using System.Security.Cryptography.X509Certificates;

namespace Classes.Nfse
{
    public static class WebServiceUra
    {
        public static string Cabecalho_NFSe = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><cabecalho xmlns=\"http://www.abrasf.org.br/nfse.xsd\" versao=\"1.00\"><versaoDados>1.00</versaoDados></cabecalho>";

        public static XmlDocument SerializaObjetoEmXml(Object aSerSerializado)
        {
            System.Xml.XmlDocument docXml;
            //XmlDictionaryReaderQuotas 
             
   
            try
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(aSerSerializado.GetType());
                
                // Criar um XML com os dados do objeto
                docXml = new System.Xml.XmlDocument();

                using (var stream = new MemoryStream())
                {
                    serializer.Serialize(stream, aSerSerializado);
                    stream.Flush();
                    stream.Seek(0, SeekOrigin.Begin);

                    docXml.Load(stream);
                }
            }
            catch (Exception e)
            {
                docXml = null;
            }
            return docXml;
        }

        /// <summary>
        /// Método utilizado para chamar o processo de envio dos lotes do WebService
        /// </summary>
        /// <param name="lote">Lote a ser enviado</param>
        /// <param name="certificado">Certificado que será utilizado para o envio</param>
        /// <returns></returns>
        [SoapDocumentMethod("http://tempuri.org/INfseServices/RecepcionarLoteRps", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public static string RecepcionarLoteRps(EnviarLoteRpsEnvio lote, X509Certificate2 certificado, bool areaHomologacao)
        {
            if(areaHomologacao)
            {
                NfseUraHomologacao.NfseServicesClient WebServiceHomologacao = new NfseUraHomologacao.NfseServicesClient();
                WebServiceHomologacao.ClientCredentials.ClientCertificate.Certificate = certificado;
                return WebServiceHomologacao.RecepcionarLoteRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(lote).InnerXml);
            }
            else
            {
                NfseUraProducao.NfseServicesClient WebServiceProducao = new NfseUraProducao.NfseServicesClient();
                WebServiceProducao.ClientCredentials.ClientCertificate.Certificate = certificado;
                return WebServiceProducao.RecepcionarLoteRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(lote).InnerXml);
            }
        }

        /// <summary>
        /// Método utilizado para chamar o processo de envio dos lotes do WebService
        /// </summary>
        /// <param name="lote">Lote a ser enviado</param>
        /// <param name="certificado">Certificado que será utilizado para o envio</param>
        /// <returns></returns>
        [SoapDocumentMethod("http://tempuri.org/INfseServices/RecepcionarLoteRps", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public static string RecepcionarLoteRps(EnviarLoteRpsEnvio lote, bool areaHomologacao)
        {
            if (areaHomologacao)
            {
                NfseUraHomologacao.NfseServicesClient WebServiceHomologacao = new NfseUraHomologacao.NfseServicesClient();
                WebServiceHomologacao.ClientCredentials.ClientCertificate.Certificate = CertificadoDigital.BuscaCertificadoNfse(CertificadoDigital.CNPJ_Welic);
                return WebServiceHomologacao.RecepcionarLoteRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(lote).InnerXml);
            }
            else
            {
                NfseUraProducao.NfseServicesClient WebServiceProducao = new NfseUraProducao.NfseServicesClient();
                WebServiceProducao.ClientCredentials.ClientCertificate.Certificate = CertificadoDigital.BuscaCertificadoNfse(CertificadoDigital.CNPJ_Welic);
                return WebServiceProducao.RecepcionarLoteRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(lote).InnerXml);
            }
        }



        /// <summary>
        /// Método utilizado chamar o processo de cancelamento do WebService
        /// </summary>
        /// <param name="nfse">NFS-e que será cancelada</param>
        /// <param name="certificado">Certificado que será utilizado no envio para o WebService</param>
        /// <returns></returns>
        [SoapDocumentMethod("http://tempuri.org/INfseServices/RecepcionarLoteRps", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public static string CancelarNfse(CancelarNfseEnvio nfse, X509Certificate2 certificado, bool areaHomologacao)
        {
            // Se for área de teste envia para o WebService de teste
            if (areaHomologacao)
            {
                NfseUraHomologacao.NfseServicesClient WebServiceHomologacao = new NfseUraHomologacao.NfseServicesClient();
                WebServiceHomologacao.ClientCredentials.ClientCertificate.Certificate = certificado;
                return WebServiceHomologacao.CancelarNfse(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(nfse).InnerXml);
            }
            else
            {
                NfseUraProducao.NfseServicesClient WebServiceProducao = new NfseUraProducao.NfseServicesClient();
                WebServiceProducao.ClientCredentials.ClientCertificate.Certificate = certificado;
                return WebServiceProducao.CancelarNfse(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(nfse).InnerXml);
            }
        }

        /// <summary>
        /// Método utilizado chamar o processo de cancelamento do WebService
        /// </summary>
        /// <param name="nfse">NFS-e que será cancelada</param>
        /// <param name="certificado">Certificado que será utilizado no envio para o WebService</param>
        /// <returns></returns>
        [SoapDocumentMethod("http://tempuri.org/INfseServices/RecepcionarLoteRps", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public static string CancelarNfse(CancelarNfseEnvio nfse, bool areaHomologacao)
        {
            // Se for área de teste envia para o WebService de teste
            if (areaHomologacao)
            {
                NfseUraHomologacao.NfseServicesClient WebServiceHomologacao = new NfseUraHomologacao.NfseServicesClient();
                WebServiceHomologacao.ClientCredentials.ClientCertificate.Certificate = CertificadoDigital.BuscaCertificadoNfse(CertificadoDigital.CNPJ_Welic);
                return WebServiceHomologacao.CancelarNfse(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(nfse).InnerXml);
            }
            else
            {
                NfseUraProducao.NfseServicesClient WebServiceProducao = new NfseUraProducao.NfseServicesClient();
                WebServiceProducao.ClientCredentials.ClientCertificate.Certificate = CertificadoDigital.BuscaCertificadoNfse(CertificadoDigital.CNPJ_Welic);
                return WebServiceProducao.CancelarNfse(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(nfse).InnerXml);
            }
        }



        /// <summary>
        /// Método utilizado para chamar o processo de consulta de NFS-e por RPS do WebService
        /// </summary>
        /// <param name="rps">RPS que será consultado</param>
        /// <param name="certificado">Certificado que será utilizado na comunicação com o WebService</param>
        /// <returns></returns>
        [SoapDocumentMethod("http://tempuri.org/INfseServices/RecepcionarLoteRps", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public static string ConsultarNfsePorRps(ConsultarNfseRpsEnvio rps, X509Certificate2 certificado, bool areaHomologacao)
        {
            // Se for área de teste envia para o WebService de teste            
            if (areaHomologacao)
            {
                NfseUraHomologacao.NfseServicesClient WebServiceHomologacao = new NfseUraHomologacao.NfseServicesClient();
                WebServiceHomologacao.ClientCredentials.ClientCertificate.Certificate = certificado;
                return WebServiceHomologacao.ConsultarNfsePorRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(rps).InnerXml);
            }
            else
            {
                NfseUraProducao.NfseServicesClient WebServiceProducao = new NfseUraProducao.NfseServicesClient();
                WebServiceProducao.ClientCredentials.ClientCertificate.Certificate = certificado;
                return WebServiceProducao.ConsultarNfsePorRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(rps).InnerXml);
            }
        }

        /// <summary>
        /// Método utilizado para chamar o processo de consulta de NFS-e por RPS do WebService
        /// </summary>
        /// <param name="rps">RPS que será consultado</param>
        /// <param name="certificado">Certificado que será utilizado na comunicação com o WebService</param>
        /// <returns></returns>
        [SoapDocumentMethod("http://tempuri.org/INfseServices/RecepcionarLoteRps", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public static string ConsultarNfsePorRps(ConsultarNfseRpsEnvio rps, bool areaHomologacao)
        {
            // Se for área de teste envia para o WebService de teste            
            if (areaHomologacao)
            {
                NfseUraHomologacao.NfseServicesClient WebServiceHomologacao = new NfseUraHomologacao.NfseServicesClient();
                WebServiceHomologacao.ClientCredentials.ClientCertificate.Certificate = CertificadoDigital.BuscaCertificadoNfse(CertificadoDigital.CNPJ_Welic);
                return WebServiceHomologacao.ConsultarNfsePorRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(rps).InnerXml);
            }
            else
            {
                NfseUraProducao.NfseServicesClient WebServiceProducao = new NfseUraProducao.NfseServicesClient();
                WebServiceProducao.ClientCredentials.ClientCertificate.Certificate = CertificadoDigital.BuscaCertificadoNfse(CertificadoDigital.CNPJ_Welic);
                return WebServiceProducao.ConsultarNfsePorRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(rps).InnerXml);
            }
        }



        /// <summary>
        /// Método utilizado para chamar o processo de consulta da situação do lote de RPS do WebService
        /// </summary>
        /// <param name="loteRps">Lote que RPS que será consultado</param>
        /// <param name="certificado">Certificado que será utilizado na comunicação com o WebService</param>
        /// <returns></returns>
        [SoapDocumentMethod("http://tempuri.org/INfseServices/RecepcionarLoteRps", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public static string ConsultarSituacaoLoteRps(ConsultarSituacaoLoteRpsEnvio loteRps, X509Certificate2 certificado, bool areaHomologacao)
        {
            // Se for área de teste envia para o WebService de teste            
            if (areaHomologacao)
            {
                NfseUraHomologacao.NfseServicesClient WebServiceHomologacao = new NfseUraHomologacao.NfseServicesClient();
                WebServiceHomologacao.ClientCredentials.ClientCertificate.Certificate = certificado;
                return WebServiceHomologacao.ConsultarSituacaoLoteRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(loteRps).InnerXml);
            }
            else
            {
                NfseUraProducao.NfseServicesClient WebServiceProducao = new NfseUraProducao.NfseServicesClient();
                WebServiceProducao.ClientCredentials.ClientCertificate.Certificate = certificado;
                return WebServiceProducao.ConsultarSituacaoLoteRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(loteRps).InnerXml);
            }
        }

        /// <summary>
        /// Método utilizado para chamar o processo de consulta da situação do lote de RPS do WebService
        /// </summary>
        /// <param name="loteRps">Lote que RPS que será consultado</param>
        /// <param name="certificado">Certificado que será utilizado na comunicação com o WebService</param>
        /// <returns></returns>
        [SoapDocumentMethod("http://tempuri.org/INfseServices/RecepcionarLoteRps", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public static string ConsultarSituacaoLoteRps(ConsultarSituacaoLoteRpsEnvio loteRps, bool areaHomologacao)
        {
            // Se for área de teste envia para o WebService de teste            
            if (areaHomologacao)
            {
                NfseUraHomologacao.NfseServicesClient WebServiceHomologacao = new NfseUraHomologacao.NfseServicesClient();
                WebServiceHomologacao.ClientCredentials.ClientCertificate.Certificate = CertificadoDigital.BuscaCertificadoNfse(CertificadoDigital.CNPJ_Welic);
                return WebServiceHomologacao.ConsultarSituacaoLoteRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(loteRps).InnerXml);
            }
            else
            {
                NfseUraProducao.NfseServicesClient WebServiceProducao = new NfseUraProducao.NfseServicesClient();
                WebServiceProducao.ClientCredentials.ClientCertificate.Certificate = CertificadoDigital.BuscaCertificadoNfse(CertificadoDigital.CNPJ_Welic);
                return WebServiceProducao.ConsultarSituacaoLoteRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(loteRps).InnerXml);
            }
        }



        /// <summary>
        /// Método utilizado para chamar o processo de consulta do lote de RPS no WebService
        /// </summary>
        /// <param name="loteRps">Lote de RPS a ser consultado</param>
        /// <param name="certificado">Certificado que será utilizado na comunicação</param>
        /// <returns></returns>
        [SoapDocumentMethod("http://tempuri.org/INfseServices/RecepcionarLoteRps", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public static string ConsultarLoteRPS(ConsultarLoteRpsEnvio loteRps, X509Certificate2 certificado, bool areaHomologacao)
        {
            // Se for área de teste envia para o WebService de teste
            if (areaHomologacao)
            {
                NfseUraHomologacao.NfseServicesClient WebServiceHomologacao = new NfseUraHomologacao.NfseServicesClient();
                WebServiceHomologacao.ClientCredentials.ClientCertificate.Certificate = certificado;
                return WebServiceHomologacao.ConsultarLoteRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(loteRps).InnerXml);
            }
            else
            {
                NfseUraProducao.NfseServicesClient WebServiceProducao = new NfseUraProducao.NfseServicesClient();
                WebServiceProducao.ClientCredentials.ClientCertificate.Certificate = certificado;
                return WebServiceProducao.ConsultarLoteRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(loteRps).InnerXml);
            }
        }

        /// <summary>
        /// Método utilizado para chamar o processo de consulta do lote de RPS no WebService
        /// </summary>
        /// <param name="loteRps">Lote de RPS a ser consultado</param>
        /// <param name="certificado">Certificado que será utilizado na comunicação</param>
        /// <returns></returns>
        [SoapDocumentMethod("http://tempuri.org/INfseServices/RecepcionarLoteRps", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public static string ConsultarLoteRPS(ConsultarLoteRpsEnvio loteRps, bool areaHomologacao)
        {
            // Se for área de teste envia para o WebService de teste
            if (areaHomologacao)
            {
                NfseUraHomologacao.NfseServicesClient WebServiceHomologacao = new NfseUraHomologacao.NfseServicesClient();
                WebServiceHomologacao.ClientCredentials.ClientCertificate.Certificate = CertificadoDigital.BuscaCertificadoNfse(CertificadoDigital.CNPJ_Welic);
                return WebServiceHomologacao.ConsultarLoteRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(loteRps).InnerXml);
            }
            else
            {
                NfseUraProducao.NfseServicesClient WebServiceProducao = new NfseUraProducao.NfseServicesClient();
                WebServiceProducao.ClientCredentials.ClientCertificate.Certificate = CertificadoDigital.BuscaCertificadoNfse(CertificadoDigital.CNPJ_Welic);
                return WebServiceProducao.ConsultarLoteRps(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(loteRps).InnerXml);
            }
        }



        /// <summary>
        /// Método utilizado para chamar o processo de consulta da NFS-e do WebService
        /// </summary>
        /// <param name="nfse">NFS-e a ser consultada</param>
        /// <param name="certificado">Certificado que será utilizado na comunicação com o WebService</param>
        /// <returns></returns>
        [SoapDocumentMethod("http://tempuri.org/INfseServices/RecepcionarLoteRps", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public static string ConsultarNfse(ConsultarNfseEnvio nfse, X509Certificate2 certificado, bool areaHomologacao)
        {
            // Se for área de teste envia para o WebService de teste
            if (areaHomologacao)
            {
                NfseUraHomologacao.NfseServicesClient WebServiceHomologacao = new NfseUraHomologacao.NfseServicesClient();
                WebServiceHomologacao.ClientCredentials.ClientCertificate.Certificate = certificado;
                return WebServiceHomologacao.ConsultarNfse(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(nfse).InnerXml);
            }
            else
            {
                NfseUraProducao.NfseServicesClient WebServiceProducao = new NfseUraProducao.NfseServicesClient();
                WebServiceProducao.ClientCredentials.ClientCertificate.Certificate = certificado;
                return WebServiceProducao.ConsultarNfse(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(nfse).InnerXml);
            }
        }

        /// <summary>
        /// Método utilizado para chamar o processo de consulta da NFS-e do WebService
        /// </summary>
        /// <param name="nfse">NFS-e a ser consultada</param>
        /// <param name="certificado">Certificado que será utilizado na comunicação com o WebService</param>
        /// <returns></returns>
        [SoapDocumentMethod("http://tempuri.org/INfseServices/RecepcionarLoteRps", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public static string ConsultarNfse(ConsultarNfseEnvio nfse, bool areaHomologacao)
        {
            // Se for área de teste envia para o WebService de teste
            if (areaHomologacao)
            {
                NfseUraHomologacao.NfseServicesClient WebServiceHomologacao = new NfseUraHomologacao.NfseServicesClient();
                WebServiceHomologacao.ClientCredentials.ClientCertificate.Certificate = CertificadoDigital.BuscaCertificadoNfse(CertificadoDigital.CNPJ_Welic);
                return WebServiceHomologacao.ConsultarNfse(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(nfse).InnerXml);
            }
            else
            {
                NfseUraProducao.NfseServicesClient WebServiceProducao = new NfseUraProducao.NfseServicesClient();
                WebServiceProducao.ClientCredentials.ClientCertificate.Certificate = CertificadoDigital.BuscaCertificadoNfse(CertificadoDigital.CNPJ_Welic);
                return WebServiceProducao.ConsultarNfse(WebServiceUra.Cabecalho_NFSe, WebServiceUra.SerializaObjetoEmXml(nfse).InnerXml);
            }
        }
    }
}
