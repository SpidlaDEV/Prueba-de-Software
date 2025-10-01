namespace Prueba_de_Software
{
    public class TipoDeTrianguloTest
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string base_url = "https://iso-2025.somee.com/test/Test";

        [Theory]
        [InlineData(100, 100, 1)]
        [InlineData(3, 3, 4)]
        [InlineData(8, 4, 8)]
        public async void TestIsosceles(int lado1, int lado2, int lado3)
        {
            // Arrange
            string url = $"{base_url}/TipoDeTriangulo?lado1={lado1}&lado2={lado2}&lado3={lado3}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("Isósceles", await response.Content.ReadAsStringAsync());
        }

        [Theory]
        [InlineData(100, 100, 1)]
        [InlineData(3, 3, 4)]
        [InlineData(8, 4, 8)]
        public async void TestIsosceles(int lado1, int lado2, int lado3)
        {
            // Arrange
            string url = $"{base_url}/TipoDeTriangulo?lado1={lado1}&lado2={lado2}&lado3={lado3}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("Isósceles", await response.Content.ReadAsStringAsync());
        }

        [Theory]
        [InlineData(15, 15, 15)]
        public async void TestEquilatero(int lado1, int lado2, int lado3)
        {
            // Arrange
            string url = $"{base_url}/TipoDeTriangulo?lado1={lado1}&lado2={lado2}&lado3={lado3}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("Equilátero", await response.Content.ReadAsStringAsync());
        }

        [Theory]
        [InlineData(34, 87, 12)]
        [InlineData(34, 12, 87)]
        [InlineData(87, 34, 12)]
        [InlineData(87, 12, 34)]
        [InlineData(12, 87, 34)]
        [InlineData(12, 34, 87)]
        [InlineData(3, 1, 2)]
        [InlineData(3, 2, 1)]
        public async void TestEscaleno(int lado1, int lado2, int lado3)
        {
            // Arrange
            string url = $"{base_url}/TipoDeTriangulo?lado1={lado1}&lado2={lado2}&lado3={lado3}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("Escaleno", await response.Content.ReadAsStringAsync());
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 124, 0)]
        [InlineData(0, 0, 74)]
        [InlineData(62, 0, 0)]
        [InlineData(0, 364, 23)]
        [InlineData(75, 0, 657)]
        [InlineData(567, 334, 0)]
        [InlineData(-5, 645, 345)]
        [InlineData(89, -4, 56)]
        [InlineData(523, 537, -67)]
        [InlineData(-496, -734, 58)]
        [InlineData(-329, 72, -546)]
        [InlineData(45, -28, -94)]
        [InlineData(-467, -123, -356)]
        public async void TestError(int lado1, int lado2, int lado3)
        {
            // Arrange
            string url = $"{base_url}/TipoDeTriangulo?lado1={lado1}&lado2={lado2}&lado3={lado3}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.True(response.InternalServerErrorResult);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 2)]
        [InlineData(2, 1, 3)]
        [InlineData(2, 3, 1)]
        public async void TestNoEsUnTriangulo(int lado1, int lado2, lado3)
        {
            // Arrange
            string url = $"{base_url}/TipoDeTriangulo?lado1={lado1}&lado2={lado2}&lado3={lado3}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(“No es un triángulo válido”, await response.Content.ReadAsStringAsync());
        }
    }
}