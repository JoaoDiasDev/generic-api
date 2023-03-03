namespace joaodias_generic.Integrations.LoteriasCaixa.DTO
{
    public class LotoFacilGame
    {
        public int n1 { get; set; }
        public int n2 { get; set; }
        public int n3 { get; set; }
        public int n4 { get; set; }
        public int n5 { get; set; }
        public int n6 { get; set; }
        public int n7 { get; set; }
        public int n8 { get; set; }
        public int n9 { get; set; }
        public int n10 { get; set; }
        public int n11 { get; set; }
        public int n12 { get; set; }
        public int n13 { get; set; }
        public int n14 { get; set; }
        public int n15 { get; set; }
        public List<int> GameNumbers { get; set; }
        public string Name { get; set; }
        public int Matches { get; set; } = 0;

        public LotoFacilGame(int n1, int n2, int n3, int n4, int n5, int n6, int n7, int n8, int n9, int n10, int n11, int n12, int n13, int n14, int n15, List<int> gameNumbers, string gameName)
        {
            this.n1 = n1;
            this.n2 = n2;
            this.n3 = n3;
            this.n4 = n4;
            this.n5 = n5;
            this.n6 = n6;
            this.n7 = n7;
            this.n8 = n8;
            this.n9 = n9;
            this.n10 = n10;
            this.n11 = n11;
            this.n12 = n12;
            this.n13 = n13;
            this.n14 = n14;
            this.n15 = n15;
            this.GameNumbers = gameNumbers;
            this.Name = gameName;
            List<int> numbers = new() { n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15 };
            gameNumbers.AddRange(numbers);
        }
    }
}
