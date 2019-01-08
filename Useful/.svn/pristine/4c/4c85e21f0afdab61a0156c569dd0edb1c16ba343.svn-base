using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Classes.Uteis
{
    public static class EnviarEmail
    {
        /// <summary>
        /// Método de Enviar Email
        /// </summary>
        /// <param name="host">Host do Email</param>
        /// <param name="usuario">Usuário</param>
        /// <param name="senha">Senha</param>
        /// <param name="habilitarSsl">Habilitar Camada de Segurança</param>
        /// <param name="remetente">Remetente</param>
        /// <param name="destinatarios">Destinatários</param>
        /// <param name="comCopia">Destinatários com Copia</param>
        /// <param name="copiaOculta">Destinatários com Copia Oculta</param>
        /// <param name="assunto">Assunto do Email</param>
        /// <param name="corpo">Corpo do Email</param>
        /// <param name="corpoHtml">O Corpo do Email é HTML</param>
        /// <param name="prioridade">Prioridade do Email</param>
        /// <param name="anexos">Anexos do Email</param>
        public static void Enviar(string host, string usuario, string senha, bool habilitarSsl,
                                   MailAddress remetente, List<MailAddress> destinatarios,
                                   List<MailAddress> comCopia, List<MailAddress> copiaOculta,
                                   string assunto, string corpo, bool corpoHtml,
                                   MailPriority prioridade, List<Attachment> anexos)
        {
            EnviarEmail.Enviar(host, usuario, senha, habilitarSsl, remetente, destinatarios, comCopia, copiaOculta, assunto, corpo, corpoHtml, prioridade, anexos, new List<MailAddress>()); 
        }

        /// <summary>
        /// Método de Enviar Email
        /// </summary>
        /// <param name="host">Host do Email</param>
        /// <param name="usuario">Usuário</param>
        /// <param name="senha">Senha</param>
        /// <param name="habilitarSsl">Habilitar Camada de Segurança</param>
        /// <param name="remetente">Remetente</param>
        /// <param name="destinatarios">Destinatários</param>
        /// <param name="comCopia">Destinatários com Copia</param>
        /// <param name="copiaOculta">Destinatários com Copia Oculta</param>
        /// <param name="assunto">Assunto do Email</param>
        /// <param name="corpo">Corpo do Email</param>
        /// <param name="corpoHtml">O Corpo do Email é HTML</param>
        /// <param name="prioridade">Prioridade do Email</param>
        /// <param name="anexos">Anexos do Email</param>
        /// /// <param name="anexos">Email confirmação</param>
        public static void Enviar(string host, string usuario, string senha, bool habilitarSsl,
                                   MailAddress remetente, List<MailAddress> destinatarios,
                                   List<MailAddress> comCopia, List<MailAddress> copiaOculta,
                                   string assunto, string corpo, bool corpoHtml,
                                   MailPriority prioridade, List<Attachment> anexos, string emailConfirmacaoLeitura)
        {
            EnviarEmail.Enviar(host, usuario, senha, habilitarSsl, remetente, destinatarios, comCopia, copiaOculta, emailConfirmacaoLeitura, assunto, corpo, corpoHtml, prioridade, anexos, new List<MailAddress>());
        }

        /// <summary>
        /// Método de Enviar Email
        /// </summary>
        /// <param name="host">Host do Email</param>
        /// <param name="usuario">Usuário</param>
        /// <param name="senha">Senha</param>
        /// <param name="habilitarSsl">Habilitar Camada de Segurança</param>
        /// <param name="remetente">Remetente</param>
        /// <param name="destinatarios">Destinatários</param>
        /// <param name="comCopia">Destinatários com Copia</param>
        /// <param name="copiaOculta">Destinatários com Copia Oculta</param>
        /// <param name="assunto">Assunto do Email</param>
        /// <param name="corpo">Corpo do Email</param>
        /// <param name="corpoHtml">O Corpo do Email é HTML</param>
        /// <param name="prioridade">Prioridade do Email</param>
        /// <param name="anexos">Anexos do Email</param>
        /// <param name="emailsResposta">Lista de Endereços para Resposta</param>
        public static void Enviar(string host, string usuario, string senha, bool habilitarSsl,
                                   MailAddress remetente, List<MailAddress> destinatarios,
                                   List<MailAddress> comCopia, List<MailAddress> copiaOculta,
                                   string assunto, string corpo, bool corpoHtml,
                                   MailPriority prioridade, List<Attachment> anexos,
                                   List<MailAddress> emailsResposta)
        {
            SmtpClient client = new SmtpClient();
            client.Host = host;
            client.EnableSsl = habilitarSsl;
            client.Credentials = new NetworkCredential(usuario, senha);

            MailMessage message = new MailMessage();
            message.Sender = remetente;
            message.From = remetente;

            foreach (MailAddress destino in destinatarios)
            {
                message.To.Add(destino);
            }
            foreach (MailAddress copia in comCopia)
            {
                message.CC.Add(copia);
            }
            foreach (MailAddress oculta in copiaOculta)
            {
                message.Bcc.Add(oculta);
            }
            foreach (MailAddress replay in emailsResposta)
            {
                message.ReplyToList.Add(replay);
            }

            message.Subject = assunto;
            message.Body = corpo;
            message.IsBodyHtml = corpoHtml;
            message.Priority = prioridade;
            
            foreach (Attachment at in anexos)
            {
                message.Attachments.Add(at);
            }

            client.Send(message);
        }

        public static void Enviar(string host, string usuario, string senha, bool habilitarSsl,
                           MailAddress remetente, List<MailAddress> destinatarios,
                           List<MailAddress> comCopia, List<MailAddress> copiaOculta,
                           string emailConfirmacaoLeitura, string assunto, string corpo, bool corpoHtml,
                           MailPriority prioridade, List<Attachment> anexos,
                           List<MailAddress> emailsResposta)
        {
            SmtpClient client = new SmtpClient();
            client.Host = host;
            client.EnableSsl = habilitarSsl;
            client.Credentials = new NetworkCredential(usuario, senha);

            MailMessage message = new MailMessage();
            message.Sender = remetente;
            message.From = remetente;

            foreach (MailAddress destino in destinatarios)
            {
                message.To.Add(destino);
            }
            foreach (MailAddress copia in comCopia)
            {
                message.CC.Add(copia);
            }
            foreach (MailAddress oculta in copiaOculta)
            {
                message.Bcc.Add(oculta);
            }
            foreach (MailAddress replay in emailsResposta)
            {
                message.ReplyToList.Add(replay);
            }

            if (!string.IsNullOrEmpty(emailConfirmacaoLeitura))
                message.Headers.Add("Disposition-Notification-To", emailConfirmacaoLeitura);

            message.Subject = assunto;
            message.Body = corpo;
            message.IsBodyHtml = corpoHtml;
            message.Priority = prioridade;

            foreach (Attachment at in anexos)
            {
                message.Attachments.Add(at);
            }

            client.Send(message);
        }
    }
}
