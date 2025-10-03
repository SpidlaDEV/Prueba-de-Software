namespace Prueba_de_Software
{
   public class InteresCompuesto
    {

        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string base_url = "https://iso-2025.somee.com/test/Test";

        //PONER DIRECTAMENMTE EL VALOR O CALCULARLO? 

        public string InterCompuesto(double capital, double interes, int periodo, int anio)
        {
            // Convertimos porcentaje a decimal
            double tasaDecimal = interes / 100;

            // Fórmula: capital * (1 + r/n)^(n*t)
            double resultado = capital * Math.Pow(1 + tasaDecimal / periodo, periodo * anio);

            return resultado.ToString();
        }

        [Theory]
        [InlineData(10, 2, 2, 2)]
        [InlineData(111111111, 2, 3, 3)]
        [InlineData(0, 0, 0, 0)]
        public async void TestInterCompuesto(double capital, double interes, int periodo, int anio)
        {
            // Arra
            string url = $"{base_url}/InteresCompuesto?capitalInicial={capital}&tasaInteresAnual={interes}&periodosPorAnio={periodo}&anios={anio}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.True(response.IsSuccessStatusCode);

            string resultado = await response.Content.ReadAsStringAsync();


            string calculo = InterCompuesto(capital, interes, periodo, anio);
            Assert.Equal(calculo, resultado);


        }

        //CALCULA MAL EL INTERES LA API
    }
}