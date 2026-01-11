using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_FinalOficial
{
    public class Conexao
    {
        static private string servidor = "localhost";
        static private string banco = "Projeto_Final";
        static private string usuario = "root";
        //static private string PWD = "Sen@i13042501";
        static private string PWD = "13042501@If";

        // ALTERAÇÃO AQUI: Adicionados "SslMode=None" e "AllowPublicKeyRetrieval=True"
        static public string ConexãoServidor = $"Server={servidor};Database={banco};User id={usuario};PWD={PWD};";
    }
}