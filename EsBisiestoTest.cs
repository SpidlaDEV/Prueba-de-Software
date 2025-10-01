namespace Prueba_de_Software
{
    public class EsBisiesto
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string base_url = "https://iso-2025.somee.com/test/Test";

        [Theory]
        [InlineData(1980)]
        [InlineData(2004)]
        [InlineData(1992)]
        [InlineData(1968)]
        [InlineData(2016)]
        [InlineData(2020)]
        [InlineData(1952)]
        [InlineData(2040)]
        [InlineData(1904)]
        [InlineData(1988)]
        public async void TestEsBisiesto(int anio)
        {
            // Arrange
            string url = $"{base_url}/EsBisiesto?anio={anio}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("true", await response.Content.ReadAsStringAsync());
        }

        [Theory]
        [InlineData(1955)]
        [InlineData(2017)]
        [InlineData(2001)]
        [InlineData(2023)]
        [InlineData(1983)]
        [InlineData(1979)]
        [InlineData(2027)]
        [InlineData(2022)]
        [InlineData(2011)]
        [InlineData(2009)]
        public async void TestNoEsBisiesto(int anio)
        {
            // Arrange
            string url = $"{base_url}/EsBisiesto?anio={anio}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("false", await response.Content.ReadAsStringAsync());
        }

        [Theory]
        [InlineData(-3)]
        public async void TestInternalServerError(int anio)
        {
            // Arrange
            string url = $"{base_url}/EsBisiesto?anio={anio}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.Equal("InternalServerError", response.StatusCode.ToString());
        }
    }
}