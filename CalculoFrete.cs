using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Projeto_FinalOficial
{
    public class GeolocalizacaoService
    {
        

        public const string LojaNome = "Minha Loja - Matriz";
        public const string LojaCEP = "30130004"; // Sem traço

        // Coordenadas exatas da Rua Rio de Janeiro, 471 - Centro, BH
        public const double LojaLatitude = -19.924188;
        public const double LojaLongitude = -43.940465;

        // =============================================================
        // 2. ESTRUTURAS PARA A BRASIL API
        // =============================================================
        public class EnderecoBrasilApi
        {
            public string cep { get; set; }
            public Location location { get; set; }
        }

        public class Location
        {
            public string type { get; set; }
            public Coordinates coordinates { get; set; }
        }

        public class Coordinates
        {
            public double longitude { get; set; }
            public double latitude { get; set; }
        }

        // =============================================================
        // 3. MÉTODOS DE BUSCA E CÁLCULO
        // =============================================================

        // Busca Lat/Long de qualquer CEP na API
        public static async Task<(double lat, double lon)?> BuscarCoordenadas(string cep)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Remove traços e espaços para evitar erro na URL
                    string cepLimpo = cep.Replace("-", "").Trim();
                    string url = $"https://brasilapi.com.br/api/cep/v2/{cepLimpo}";

                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var dados = JsonConvert.DeserializeObject<EnderecoBrasilApi>(json);

                        if (dados.location != null && dados.location.coordinates != null)
                        {
                            return (dados.location.coordinates.latitude, dados.location.coordinates.longitude);
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        // Fórmula Matemática de Distância (Haversine)
        public static double CalcularDistanciaKm(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371; // Raio da Terra em KM
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Multiplicamos por 1.3 para simular rotas de rua (não linha reta perfeita)
            return (R * c) * 1.3;
        }

        // --- NOVO MÉTODO ATALHO ---
        // Calcula direto da LOJA até o destino, sem precisar passar as coordenadas da loja
        public static double CalcularDistanciaDaLoja(double latDestino, double lonDestino)
        {
            return CalcularDistanciaKm(LojaLatitude, LojaLongitude, latDestino, lonDestino);
        }

        private static double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}