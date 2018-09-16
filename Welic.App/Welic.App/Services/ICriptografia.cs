using System;
using System.Collections.Generic;
using System.Text;

namespace Welic.App.Services
{
    public interface ICriptografia
    {
        string Encriptar(string chave, string vetorInicializacao, string textoNormal);
        string Decriptar(string chave, string vetorInicializacao, string textoEncriptado);
    }
}
