namespace joaodias_generic.Integrations.LoteriasCaixa.Services
{
    public static class GenerateRandomLotoFacilGame
    {
        private static List<int> Numeros { get; set; } = new List<int>();
        public static List<int> LotoFacilGame()
        {
            Random random = new Random();
            Numeros = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                int numero = random.Next(1, 26);
                while (Numeros.Contains(numero))
                {
                    numero = random.Next(1, 26);
                }
                Numeros.Add(numero);
            }
            Numeros.Sort();
            return Numeros;
        }
    }
}
