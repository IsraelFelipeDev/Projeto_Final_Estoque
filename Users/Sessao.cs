using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_FinalOficial
{
    public class Sessao
    {

        public class Sessão
        {
            public static int Id { get; set; }
            public static string Nome { get; set; }
            public static string Cargo { get; set; }

            public static void Logout()
            {
                Id = 0;
                Nome = " ";
                Cargo = " ";
            }
        }
    }
}
