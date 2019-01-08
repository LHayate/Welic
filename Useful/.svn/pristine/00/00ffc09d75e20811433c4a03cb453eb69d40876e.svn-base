using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;

namespace Classes.Uteis
{
    public static class GerarDocumentoWord
    {
        public static void GerarDocumento(string caminhoDoc, string[,] listaVariaveis)
        {
            //Objeto a ser usado nos parâmetros opcionais
            object missing = System.Reflection.Missing.Value;

            //Abre a aplicação Word e faz uma cópia do documento mapeado
            Word.Application oApp = new Word.Application();

            //Caminho onde se encontra o documento Template
            object template = caminhoDoc;//@"C:\novo.docx";

            Word.Document oDoc = oApp.Documents.Add(ref template, ref missing, ref missing, ref missing);

            //Alimenta do documento Word  
            Word.Range oRng = oDoc.Range(ref missing, ref missing);

            object MatchWholeWord = true;
            object Forward = true;

            for (int i = 0; i < listaVariaveis.Length / 3; i++)
            {
                string variavelSis = listaVariaveis[i, 0];
                string variavelWord = listaVariaveis[i, 1];
                string cabecalho = listaVariaveis[i, 2];

                if (cabecalho == "1")
                {
                    AlterarCabecalhoRodape(oApp, oDoc, variavelSis, variavelWord);
                }
                else
                {
                    if (variavelSis.Length >= 255)
                    {
                        GerarDocumentoWord.SubstituiVariavelLonga(variavelSis, variavelWord, missing, oRng, MatchWholeWord, Forward, oDoc);
                    }
                    else
                    {
                        if (i == 0)
                        {
                            //Metodo para substituir a primeira variavel
                            GerarDocumentoWord.SubstituiVariavel(variavelSis, variavelWord, missing, oRng, MatchWholeWord, Forward, oDoc, true);
                        }
                        else
                        {
                            //Metodo para substituir as demais variaveis
                            GerarDocumentoWord.SubstituiVariavel(variavelSis, variavelWord, missing, oRng, MatchWholeWord, Forward, oDoc, false);
                        }
                    }
                }
            }

            //Abre o documento após as subtituições
            oApp.Visible = true;
        }

        public enum Formato { Padrao, Doc, Docx, PDF }
        public static void GerarDocumento(string caminhoDoc, string[,] listaVariaveis, string caminhoDestino, bool abrirArquivo, Formato formato = Formato.Padrao)
        {
            //Objeto a ser usado nos parâmetros opcionais
            object missing = System.Reflection.Missing.Value;

            //Abre a aplicação Word e faz uma cópia do documento mapeado
            Word.Application app = new Word.Application();

            //Caminho onde se encontra o documento Template
            object template = caminhoDoc;//@"C:\novo.docx";

            Word.Document oDoc = app.Documents.Add(ref template, ref missing, ref missing, ref missing);
            
            try
            {                
                //Alimenta do documento Word  
                Word.Range oRng = oDoc.Range(ref missing, ref missing);

                object MatchWholeWord = true;
                object Forward = true;

                for (int i = 0; i < listaVariaveis.Length / 3; i++)
                {
                    string variavelSis = listaVariaveis[i, 0];
                    string variavelWord = listaVariaveis[i, 1];
                    string cabecalho = listaVariaveis[i, 2];

                    if (cabecalho == "1")
                    {
                        AlterarCabecalhoRodape(app, oDoc, variavelSis, variavelWord);
                    }
                    else
                    {
                        if (variavelSis.Length >= 255)
                        {
                            GerarDocumentoWord.SubstituiVariavelLonga(variavelSis, variavelWord, missing, oRng, MatchWholeWord, Forward, oDoc);
                        }
                        else
                        {
                            if (i == 0)
                            {
                                //Metodo para substituir a primeira variavel
                                GerarDocumentoWord.SubstituiVariavel(variavelSis, variavelWord, missing, oRng, MatchWholeWord, Forward, oDoc, true);
                            }
                            else
                            {
                                //Metodo para substituir as demais variaveis
                                GerarDocumentoWord.SubstituiVariavel(variavelSis, variavelWord, missing, oRng, MatchWholeWord, Forward, oDoc, false);
                            }
                        }
                    }
                }

                //Abre o documento após as subtituições
                //oApp.Visible = true;

                object fileName = caminhoDestino;

                object formatoSaida = null;
                switch (formato)
                {
                    case Formato.Doc:
                        formatoSaida = WdSaveFormat.wdFormatDocument97;
                        break;
                    case Formato.Docx:
                        formatoSaida = WdSaveFormat.wdFormatDocument;
                        break;
                    case Formato.PDF:
                        formatoSaida = WdSaveFormat.wdFormatPDF;
                        break;
                    default:
                        break;
                }


                oDoc.SaveAs2(ref fileName,
                    ref formatoSaida, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing);

                if (abrirArquivo)
                    Arquivos.AbrirArquivo(caminhoDestino);
            }
            catch (Exception)
            {

            }
            finally
            {
                app.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                oDoc.Close(null, null, null);
                app.Quit();
                oDoc = null;
                app = null;
                app = null;
                GC.Collect(); // force final cleanup!
            }
        }
        
        /// <summary>
        /// Substituir variável - Quando existir um texto que ultrapassar 255 caracteres será obrigatorio utilizar esse método
        /// </summary>
        /// <param name="ValorTxt">Variável com valores do sistema</param>
        /// <param name="Variavel">Variável de substituição no Word</param>
        /// <param name="missing">Objeto do tipo "missing" desconhecido para passagem de parâmetros obrigatórios</param>
        /// <param name="oRng">Objeto Range "classe word"</param>
        /// <param name="MatchWholeWord">Objeto MatchWholeWord "procurar pela palavra"</param>
        /// <param name="Forward">Objeto Forward "busca sempre para a frente "</param>
        /// <param name="oDoc">Objeto Document "</param>
        private static void SubstituiVariavelLonga(string ValorTxt, string Variavel, object missing, Word.Range oRng, object MatchWholeWord, object Forward, Word.Document oDoc)
        {
            oRng = oDoc.Range(ref missing, ref missing);
            object valorVari = Variavel;
            object ReplaceValorVari = "";
            oRng.Find.Execute(ref valorVari, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward,
                ref missing, ref missing, ref ReplaceValorVari, ref missing, ref missing, ref missing, ref missing, ref missing);

            oRng.InsertAfter(ValorTxt);
        }

        /// <summary>
        /// Substituir variável - A primeira variavel dever ser substituída por esse método
        /// </summary>
        /// <param name="ValorTxt">Variavel com valores do sistema</param>
        /// <param name="Variavel">Variavel de subtiuição no Word</param>
        /// <param name="missing">Objeto do tipo "missing" desconhecido para passagem de parâmetros obrigatórios</param>
        /// <param name="oRng">Objeto Range "classe word"</param>
        /// <param name="MatchWholeWord">Objeto MatchWholeWord "procurar pela palavra"</param>
        /// <param name="Forward">Objeto Forward "busca sempre para a frente "</param>
        /// <param name="oDoc">Objeto Document "</param>
        private static void SubstituiVariavel(string ValorTxt, string Variavel, object missing, Word.Range oRng, object MatchWholeWord, object Forward, Word.Document oDoc, bool primeiraVar)
        {
            if (primeiraVar == false)
                oRng = oDoc.Range(ref missing, ref missing);

            object valorVari = Variavel;
            object ReplaceValorVari = ValorTxt;
            oRng.Find.Execute(ref valorVari, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceValorVari, ref missing, ref missing, ref missing, ref missing, ref missing);
        }

        /// <summary>
        /// Substituir variável - Esse método substituir as variáveis do Cabeçalho e Rodapé dos documentos.
        /// </summary>
        /// <param name="WordApp">Objeto Application</param>
        /// <param name="doc">Objeto Document</param>
        /// <param name="replace">Objeto substituir "variavel do Word"</param>
        /// <param name="replaceWith">Objeto o que substituir "variavel / informação aplicação"</param>
        private static void AlterarCabecalhoRodape(Word.Application WordApp, Word.Document doc, object replace, object replaceWith)
        {
            object wdFindContinue = (object)Word.WdFindWrap.wdFindContinue;
            object wdReplaceAll = (object)Word.WdReplace.wdReplaceAll;
            object wdMissing = System.Reflection.Missing.Value;

            WordApp.Selection.Find.ClearFormatting();
            WordApp.Selection.Find.Replacement.ClearFormatting();

            var junk = doc.Sections[1].Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.StoryType;

            foreach (Word.Range range in doc.StoryRanges)
            {
                Word.Range range2 = range;
                while (range2 != null)
                {
                    range2.Find.Execute(ref replace, ref wdMissing, ref wdMissing, ref wdMissing, ref wdMissing,
                    ref wdMissing, ref wdMissing, ref wdFindContinue,
                    ref wdMissing, ref replaceWith, ref wdReplaceAll, ref wdMissing, ref wdMissing, ref wdMissing, ref wdMissing);

                    foreach (Word.Shape shape in range2.ShapeRange)
                    {
                        if (shape.TextFrame.HasText != 0)
                        {
                            shape.TextFrame.TextRange.Find.Execute(ref replace, ref wdMissing, ref wdMissing, ref wdMissing, ref wdMissing,
                            ref wdMissing, ref wdMissing, ref wdFindContinue,
                            ref wdMissing, ref replaceWith, ref wdReplaceAll, ref wdMissing, ref wdMissing, ref wdMissing, ref wdMissing);
                        }
                    }

                    switch (range2.StoryType)
                    {
                        case Word.WdStoryType.wdMainTextStory:
                        case Word.WdStoryType.wdEvenPagesHeaderStory:
                        case Word.WdStoryType.wdPrimaryHeaderStory:
                        case Word.WdStoryType.wdEvenPagesFooterStory:
                        case Word.WdStoryType.wdPrimaryFooterStory:
                        case Word.WdStoryType.wdFirstPageHeaderStory:
                        case Word.WdStoryType.wdFirstPageFooterStory:
                            if (range.ShapeRange.Count > 0)
                            {
                                foreach (Word.Shape shape in range2.ShapeRange)
                                {
                                    if (shape.TextFrame.HasText != 0)
                                    {
                                        shape.TextFrame.TextRange.Find.Execute(ref replace, ref wdMissing, ref wdMissing, ref wdMissing, ref wdMissing,
                                        ref wdMissing, ref wdMissing, ref wdFindContinue,
                                        ref wdMissing, ref replaceWith, ref wdReplaceAll, ref wdMissing, ref wdMissing, ref wdMissing, ref wdMissing);
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    range2 = range2.NextStoryRange;
                }
            }
        }
    }
}
