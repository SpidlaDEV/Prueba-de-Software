namespace Prueba_de_Software
{
    public class HelloWorlTest
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string base_url = "https://iso-2025.somee.com/test/Test";

        [Fact]
        public async void Test1()
        {
            // Arrange
            string url = $"{base_url}/Hello";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("Hola Mundo!!!", await response.Content.ReadAsStringAsync());
        }
    }
}