using System.Globalization;

namespace Prueba_de_Software
{
    public class CalcularTarifaEnvio
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string base_url = "https://iso-2025.somee.com/test/Test";
        // Teniendo en cuenta los valores de la tabla
        [Theory]
        [InlineData(100, 0.5, 105)]   // ≤ 1Kg → +5% → 105
        [InlineData(100, 1, 105)]     // ≤ 1Kg → +5% → 105
        [InlineData(100, 3, 110)]     // ≤ 5Kg → +10% → 110
        [InlineData(100, 5, 110)]     // ≤ 5Kg → +10% → 110
        [InlineData(100, 6, 120)]     // > 5Kg → +20% → 120
        [InlineData(100, 20, 120)]    // > 5Kg → +20% → 120
        public async Task TestTarifasValidas(double precioBase, double peso, double esperado)
        {
            string url = $"{base_url}/CalcularTarifaEnvio?precioBase={precioBase.ToString(CultureInfo.InvariantCulture)}&pesoKg={peso.ToString(CultureInfo.InvariantCulture)}";

            var response = await httpClient.GetAsync(url);
            string actual = await response.Content.ReadAsStringAsync();

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(esperado.ToString(CultureInfo.InvariantCulture), actual);
        }

        [Theory]
        [InlineData(100, -1)]
        [InlineData(100, 0)]
        public async Task TestEntradasInvalidas(double precioBase, double peso)
        {
            string url = $"{base_url}/CalcularTarifaEnvio?precioBase={precioBase.ToString(CultureInfo.InvariantCulture)}&pesoKg={peso.ToString(CultureInfo.InvariantCulture)}";

            var response = await httpClient.GetAsync(url);

            // En este caso se espera error del servidor (500)
            Assert.Equal("InternalServerError", response.StatusCode.ToString());
        }
    }
}