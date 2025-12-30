using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class UC_Base : UserControl
    {
        public UC_Base()
        {
            InitializeComponent();
        }
    }
}


      /*  public UC_Base()
        {
            InitializeComponent();
            this.Load += (s, e) =>
            {
                // Se o controle tiver um nome (ex: Cadastro de Funcionários), ele grava
                Logger.Gravar("Navegação", $"Entrou na tela: {this.Name}");
            };
        }
        public UserControlBase()
        {
            // Evento que dispara quando o controle é exibido na tela
            this.Load += (s, e) => {
                // 'this.Name' ou uma propriedade personalizada para identificar a tela
                Logger.Gravar("Navegação", $"Abriu o controle: {this.Tag ?? this.Name}");
            };
        }

        // Método para os botões internos (Cadastrar, Limpar, etc)
        protected void RegistrarAcao(string descricao)
        {
            Logger.Gravar(this.Tag?.ToString() ?? "Sistema", descricao);
        }
    }
}
      */
