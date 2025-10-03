using System.Globalization;

namespace Prueba_de_Software
{
    public class CategoriaIMC
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string base_url = "https://iso-2025.somee.com/test/Test";


        [Theory]
        // Casos borde de Bajo peso / Normal
        [InlineData(50, 1.70, "Bajo peso")]   // IMC ≈ 17.3
        [InlineData(53.5, 1.70, "Normal")]   // IMC ≈ 18.5

        // Casos borde de Normal / Sobrepeso
        [InlineData(72, 1.70, "Normal")]     // IMC ≈ 24.9
        [InlineData(72.5, 1.70, "Sobrepeso")]// IMC ≈ 25.1

        // Casos borde de Sobrepeso / Obesidad
        [InlineData(86, 1.70, "Sobrepeso")]  // IMC ≈ 29.7
        [InlineData(87, 1.70, "Obesidad")]   // IMC ≈ 30.1
        public async Task TestCategoriasValidas(double peso, double altura, string esperado)
        {
            // Arrange
            
            string url = $"{base_url}/CategoriaIMC?pesoKg={peso.ToString(CultureInfo.InvariantCulture)}&alturaM={altura.ToString(CultureInfo.InvariantCulture)}";


            // Act
            var response = await httpClient.GetAsync(url);


            // Assert
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(esperado, await response.Content.ReadAsStringAsync());
        }

        // Casos de error (peso o altura inválida)
        [Theory]
        [InlineData(0, 1.70)]
        [InlineData(-10, 1.70)]
        [InlineData(70, -1.75)]
        public async Task TestEntradasInvalidas(double peso, double altura)
        {
            // Arrange
            string url = $"{base_url}/CategoriaIMC?pesoKg={peso.ToString(CultureInfo.InvariantCulture)}&alturaM={altura.ToString(CultureInfo.InvariantCulture)}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assert → en este caso espero que el endpoint devuelva 500
            Assert.Equal("InternalServerError", response.StatusCode.ToString());
        }
    }
}