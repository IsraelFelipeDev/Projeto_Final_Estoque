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
        static private string banco = "projeto_final";
        static private string usuario = "root";

        static public string ConexãoServidor = $"Server = {servidor}; Database = {banco}; User id = {usuario}";
    }
}
