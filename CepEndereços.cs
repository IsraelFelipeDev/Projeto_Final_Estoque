using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projeto_FinalOficial
{
    public class CepEndereços
    {
        public string cep { get; set; }
        public string logradouro { get; set; } // Rua
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; } // Cidade
        public string uf { get; set; } // Estado
        public bool erro { get; set; }
    }
    public static class ViaCepService
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<CepEndereços> BuscarEndereco(string cep)
        {
            try
            {
                // Remove traços e pontos se houver
                cep = cep.Replace("-", "").Replace(".", "").Trim();

                if (cep.Length != 8)
                    return null;

                string url = $"https://viacep.com.br/ws/{cep}/json/";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // DESERIALIZAÇÃO (Converter Texto JSON para Objeto C#)

                // OPÇÃO A: Se estiver usando System.Text.Json (.NET Core / 5+):
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var endereco = JsonSerializer.Deserialize<CepEndereços>(responseBody, options);

                // OPÇÃO B: Se estiver usando Newtonsoft.Json (.NET Framework antigo):
                // var endereco = JsonConvert.DeserializeObject<EnderecoRes>(responseBody);

                if (endereco.erro) return null;

                return endereco;
            }
            catch (Exception)
            {
                return null; // Retorna nulo em caso de erro de conexão
            }
        }
    }
}

