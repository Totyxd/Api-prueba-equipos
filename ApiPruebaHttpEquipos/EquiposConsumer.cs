namespace ApiPruebaHttpEquipos
{
    public class EquiposConsumer
    {
        private readonly static HttpClient _httpClient = new HttpClient();

        public static async Task<string?> GetEquiposData(string url)
        {
            using (_httpClient)
            {
                _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Respuesta exitosa:");
                    Console.WriteLine(responseBody);

                    return responseBody;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
