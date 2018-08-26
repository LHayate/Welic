using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Teste.Models;

namespace Teste.Controllers
{
    public class SendMailerController : Controller
    {
        // GET: SendMailer
        public ActionResult Index()
        {
            return View();
        }
  
        [HttpPost]
        public ViewResult Index(MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                //Instância classe email
                MailMessage mail = new MailMessage();
                mail.To.Add("welic@welic.app");
                mail.From = new MailAddress("contato@welic.app");
                mail.Subject = $"Olá Welic! Quero seguir suas notícias";
                string Body = $"Meu Nome é {_objModelMail.Nome} {_objModelMail.LastName} e meu e-mail: {_objModelMail.Email}. Gostaria de Receber suas noticias. Aguardo seu contato! Obrigado";
                mail.Body = Body;
                mail.IsBodyHtml = true;

                //Instância smtp do servidor, neste caso o gmail.
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.zoho.com",
                    Port = 465,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential
                    ("welic@welic.app", "!EUsouwelic"),// Login e senha do e-mail.
                    EnableSsl = true
                };
                smtp.Send(mail);
                return View("Index", _objModelMail);
            }
            else
            {
                return View();
            }
        }
    }
}