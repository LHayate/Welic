using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Teste.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Implementando";

            ViewBag.AgendaPOne = "As midias sociais são atualmente, fundamentais para o desenvolvimento de qualquer tipo de negócio. " +
                "A utilização de marketing digital acelera o crescimento da sua empresa, o engajamento das pessoas com o seu negócio e isso aumenta as probabilidades de sucesso da sua empresa ou negócio digital. " +
                "O Summit Digital: Social Media World ’18 é a primeira edição de um evento internacional único, que tem como objetivo mostra-lhe as tendências para o marketing digital moderno. " +
                "Este fantástico evento, permitir-lhe-á colocar emprática as técnicas e utilizar as ferramentas apresentadas logo após. " +
                "É um evento que conta com a presença de oradores internacionais e de experiência comprovada em marketing digital.";
            ViewBag.AgendaPTwo = "Temáticasabordadas: ";
            ViewBag.AgendaDayOne = "Dia 1 – 17.09.2018 – Midias Sociais como fator dinamizador de empresas modernas; ";
            ViewBag.AgendaDayTwo = "Dia 2 – 18.09.2018 – Técnicas para transformar a sua empresa ou negócio;";
            ViewBag.AgendaDayTree = "Dia 3 – 19.09.2018 – Ferramentas que ajudam a impulsionar a sua empresa;";
            ViewBag.AgendaPTree = " O evento será gratuito e será cobrado um valor para usuários premium que desejarem rever o conteúdo mais tarde através da App Welic.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eget faucibus magna. Sed a est sem. Quisque tincidunt libero eu dolor sollicitudin, sit amet interdum justo bibendum. In nisl erat, feugiat in ex placerat, imperdiet rhoncus justo. Sed in massa sem. Aliquam ornare est sed tristique ultrices. Aliquam erat volutpat. Etiam pharetra quam quis velit mattis, bibendum lacinia nunc tempor. Maecenas arcu nulla, ullamcorper convallis malesuada eu, malesuada eget quam. Maecenas quis tempor odio. Suspendisse consequat volutpat eros vestibulum varius. In fringilla vestibulum risus, in tempus elit luctus nec.

Aliquam nibh augue, tincidunt sit amet dolor eget, finibus tempor mauris. Morbi a lorem eros. Nam diam dui, vulputate et nunc varius, vehicula molestie orci. Donec auctor elit ipsum, at dictum arcu egestas eu. Nam porta urna nunc, mattis lobortis dui venenatis quis. Nam gravida eros at enim tempus lobortis. Morbi a nibh malesuada, luctus tortor vel, eleifend felis. Etiam in magna ligula. Suspendisse id hendrerit est.

Cras facilisis turpis sed dignissim vulputate. Donec condimentum lacinia imperdiet. Praesent a pretium risus, et fermentum libero. Curabitur enim tellus, maximus tempor bibendum id, egestas efficitur tortor. Duis iaculis rhoncus orci vitae fermentum. Maecenas felis sem, commodo non pulvinar dictum, aliquet quis dolor. Praesent maximus leo eu blandit faucibus. Morbi est justo, cursus eget mollis nec, lobortis ut arcu. Morbi leo libero, aliquam vel tellus sed, ullamcorper malesuada magna. In a nunc sit amet mi tempus consectetur sit amet eu orci. Nulla facilisi. Sed a purus ultricies, molestie velit sodales, feugiat eros. In erat dolor, rhoncus eget justo sed, interdum suscipit ex.

Sed feugiat justo lobortis orci semper accumsan. Interdum et malesuada fames ac ante ipsum primis in faucibus. Vestibulum porta diam sed tincidunt luctus. Vivamus et felis vitae massa aliquam accumsan at eget tortor. Pellentesque neque augue, placerat in volutpat et, tristique a justo. Fusce volutpat, erat at ultrices luctus, ex magna ornare risus, vitae condimentum turpis eros sit amet arcu. Nulla hendrerit in neque in pharetra. Ut feugiat ipsum sit amet lobortis sagittis. Integer posuere elit non ex feugiat, a ullamcorper sapien placerat. In dui eros, iaculis sit amet lacus ut, tristique ultrices orci. Vestibulum at rutrum mi.

Phasellus risus nulla, fermentum vel urna eu, tempor feugiat libero. Suspendisse id lectus ullamcorper odio auctor vehicula non sed orci. In tincidunt vel quam id mollis. Sed in convallis magna, interdum rutrum metus. Phasellus iaculis mauris leo, sit amet pretium neque rutrum nec. Donec eget suscipit mauris. In nec risus id nunc viverra efficitur ut ac erat. Nunc cursus tempor neque, a vestibulum tortor volutpat ut. Praesent id euismod ligula. Ut ac libero pulvinar, volutpat urna a, interdum sem. Vivamus in dignissim justo. ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Live()
        {
            return View();
        }
 
        public void GetImagemBannerTop()
        {
            WebImage wbImage = new WebImage("~/Imagem/bannerdatamanagement.jpg")
            {
                FileName = "bannerdatamanagement.jpg"
            };
            wbImage.Write();
        }
        
        public void GetImagemCalendar()
        {
            WebImage imgCalendar = new WebImage("~/Imagem/calendario-2018.png")
            {
                FileName = "calendario-2018.png"
            };
            imgCalendar.Write();
        }
        public void GetIconWelic()
        {
            WebImage imgCalendar = new WebImage("~/Imagem/LogoWelic32x32.png")
            {
                FileName = "LogoWelic32x32.png"
            };
            imgCalendar.Write();
        }
    }
}