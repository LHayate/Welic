﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace Classes.Nfse
{
    public static class CertificadoDigital
    {
        //TODO: Atualizar o CNPJ Para o Atual
        private static string _CNPJ_Welic = "25452301000187";

        public static string CNPJ_Welic
        {
            get { return CertificadoDigital._CNPJ_Welic; }           
        }



        /// <summary>
        /// Busca o certificado para assinatura da NFSE
        /// </summary>
        /// <param name="filtroBuscaPeloNomeCertificado">Nome ou parte do nome (SubjectName) do certificado que será utilizado para assinatura</param>
        /// <returns></returns>
        public static X509Certificate2 BuscaCertificadoNfse(string filtroBuscaPeloNomeCertificado)
        {
            try
            {
                // Colocar o certificado no WebService
                X509Certificate2 X509Cert = new X509Certificate2();
                //Busca o certificado digital
                X509Store X509CertStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                // Abre o Store
                X509CertStore.Open(OpenFlags.ReadOnly);
                //Atribui o certificado encontrado ao certificado a ser utilizado para assinar            
                X509Cert = X509CertStore.Certificates.Find(X509FindType.FindBySubjectName, filtroBuscaPeloNomeCertificado, true)[0];

                //Fecha o store
                X509CertStore.Close();
                return X509Cert;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao buscar o Certificado Digital a partir do nome do certificado.\nEntre em contato com o NTI." +
                                    "\n\nErro:\n" + ex.Message + 
                                    (ex.InnerException != null ? "\n\nDetalhes do erro:\n" + ex.InnerException.Message : "") +
                                    (!string.IsNullOrEmpty(ex.Source) ? "\n\nObjeto:\n" + ex.Source : "") +
                                    (!string.IsNullOrEmpty(ex.StackTrace) ? "\n\nStackTrace:\n" + ex.StackTrace : "") +
                                    (!string.IsNullOrEmpty(ex.TargetSite.Name) ? "\n\nMétodo:\n" + ex.TargetSite.Name : ""));
            }
            
        }
    }
}
