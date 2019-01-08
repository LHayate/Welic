using System;
using System.IO;
using System.Windows.Forms;

namespace UseFul.Uteis
{
    public static class AbriFormularioDinamicamente
    {
        /// <summary>
        /// Recebe uma string para Abrir o Formulario
        /// </summary>
        /// <param name="Namespace_FormName">Nome do Namespace.NomeForm Ex: teste.Form1</param>
        /// <param name="System_Modal">True = ShowDialog / False = Show</param>
        public static void OpenForm(string Namespace_FormName, bool System_Modal)
        {
            Type t = Type.GetType(Namespace_FormName);

            if (t != null)
            {
                System.Windows.Forms.Form f =
                (System.Windows.Forms.Form)Activator.CreateInstance(t);

                if (System_Modal)
                    f.ShowDialog();
                else
                    f.Show();
            }
        }

        /// <summary>
        /// Abre um formulário do FoxPro
        /// </summary>
        /// <param name="executavel">Objeto de referencia do executavel onde se encontra o formulário</param>
        /// <param name="comandoExecFox">Comando utilizado dentro do fox para executar o formulário (concatenar os parametros necessários), aspas no inicio e no fim da string</param>
        public static void OpenFormFoxPro(ExecutaveisFoxPro executavel, string comandoExecFox)
        {
            if (!System.IO.File.Exists(executavel.getCaminhoRede()))
            {
                MessageBox.Show("O caminho '" + executavel.getCaminhoRede() + "' não é válido. Por favor, contate o núcleo de TI.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!System.IO.File.Exists(executavel.getCaminhoLocal()))
                    File.Copy(executavel.getCaminhoRede(), executavel.getCaminhoLocal());
                else
                {
                    FileInfo rede = new FileInfo(executavel.getCaminhoRede());
                    FileInfo local = new FileInfo(executavel.getCaminhoLocal());
                    if (rede.LastWriteTime != local.LastWriteTime)
                    {
                        try
                        {
                            File.Delete(executavel.getCaminhoLocal());
                            File.Copy(executavel.getCaminhoRede(), executavel.getCaminhoLocal());
                        }
                        catch (Exception)
                        {
                            //Caso de algum erro ao deletar ou copiar utiliza a versão atual local
                            //Catch apenas para não lançar exceção
                        }
                    }
                }

                ////string usuario = Globals.Usuario.ToString();
                ////string senha = Globals.Login;
                ////string conexao = Globals.Conexao.Equals("ACAD_TESTE") ? "DBTESTE" : Globals.Conexao;
                ////string parametros = usuario + " " + senha + " " + conexao + " " + comandoExecFox;

                ////System.Diagnostics.Process process = System.Diagnostics.Process.Start(executavel.getCaminhoLocal(), parametros);

                //while (!process.HasExited)
                //{
                //    //http://msdn.microsoft.com/pt-br/library/system.windows.forms.application.doevents.aspx
                //    Application.DoEvents();
                //}
            }
        }
    }
}
