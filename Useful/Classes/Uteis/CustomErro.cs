using System;

namespace UseFul.Uteis
{
    public class CustomErro
    {
        public static Exception Erro(string mensagem)
        {
            throw new CustomException(mensagem);
        }
    }
}