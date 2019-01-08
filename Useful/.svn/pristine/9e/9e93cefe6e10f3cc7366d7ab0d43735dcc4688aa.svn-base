using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Classes.Interface.VFP
{
    public class RtfToImage : System.EnterpriseServices.ServicedComponent
    {
        public RtfToImage() { }

        /// <summary>
        /// Converte um arquivo RTF em um arquivo Imagem
        /// </summary>
        /// <param name="rtfFile">Arquivo RTF</param>
        /// <param name="imageFile">Arquivo Imagem</param>
        /// <param name="width">Largura da imagem</param>
        /// <param name="height">Altura da imagem</param>
        /// <returns></returns>
        public bool Convert(String rtfFile, String imageFile,int width, int height)
        {
            bool retorno = false;

            try
            {
                // Carregar o arquivo RTF
                RichTextBoxPrintCtrl richTextBox = new RichTextBoxPrintCtrl();
                richTextBox.LoadFile(@rtfFile);

                // Converter o conteúdo do RTF em imagem
                Image image = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(image);
                richTextBox.PrintImage(0, g);
                g.Dispose();
                image.Save(@imageFile);

                retorno = true;
            }
            catch (Exception e)
            {}

            return retorno;            
        }
    }
}
