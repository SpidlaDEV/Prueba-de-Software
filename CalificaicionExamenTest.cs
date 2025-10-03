namespace Prueba_de_Software
{
    public class CalificacionExamenTest
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string base_url = "https://iso-2025.somee.com/test/Test";

        [Theory]
        [InlineData(50)]
        [InlineData(51)]
        [InlineData(52)]
        [InlineData(53)]
        [InlineData(60)]
        [InlineData(61)]
        [InlineData(62)]
        [InlineData(63)]
        [InlineData(64)]
        [InlineData(65)]
        [InlineData(66)]
        [InlineData(67)]
        [InlineData(68)]
        [InlineData(69)]
        [InlineData(70)]
        [InlineData(71)]
        [InlineData(72)]
        [InlineData(73)]
        [InlineData(74)]
        [InlineData(75)]
        [InlineData(76)]
        [InlineData(77)]
        [InlineData(78)]
        [InlineData(79)]
        [InlineData(80)]
        [InlineData(81)]
        [InlineData(82)]
        [InlineData(83)]
        [InlineData(84)]
        [InlineData(85)]
        [InlineData(86)]
        [InlineData(87)]
        [InlineData(88)]
        [InlineData(89)]
        [InlineData(90)]
        [InlineData(91)]
        [InlineData(92)]
        [InlineData(93)]
        [InlineData(94)]
        [InlineData(95)]
        [InlineData(96)]
        [InlineData(97)]
        [InlineData(98)]
        [InlineData(99)]
        [InlineData(100)]

        public async void Calificacion(int nota)
        {
            // Arrac
            string url = $"{base_url}/CalificacionExamen?nota={nota}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.True(response.IsSuccessStatusCode);
           
            string resultado = await response.Content.ReadAsStringAsync();

            if(nota>89)
                Assert.Equal("Sobresaliente",resultado);
            else if(nota > 59 && nota < 90)
                Assert.Equal("Aprobado", resultado);
            else
                Assert.Equal("Reprobado", resultado);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-23)]
        [InlineData(-67)]
        [InlineData(101)]
        [InlineData(1002)]
        [InlineData(1203)]

        public async void CalificacionIsNegative(int nota)
        {
            // Arrac
            string url = $"{base_url}/CalificacionExamen?nota={nota}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);



        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("a")]

        public async void CalificacionIsNull(string nota)
        {
            // Arrac
            string url = $"{base_url}/CalificacionExamen?nota={nota}";

            // Act
            var response = await httpClient.GetAsync(url);

            // Assest
            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
           



        }
    }
}