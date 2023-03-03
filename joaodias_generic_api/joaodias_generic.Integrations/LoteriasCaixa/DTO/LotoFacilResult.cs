namespace joaodias_generic.Integrations.LoteriasCaixa.DTO
{
    public class LotoFacilResult
    {
        public string Concurso { get; set; }
        public DateTime DataSorteio { get; set; }
        public List<int> Numeros { get; set; }
        public List<int> dezenas { get; set; }
        public int NumeroGanhadores15 { get; set; }
        public int NumeroGanhadores14 { get; set; }
        public int NumeroGanhadores13 { get; set; }
        public int NumeroGanhadores12 { get; set; }
        public int NumeroGanhadores11 { get; set; }
        public decimal ValorRateio15 { get; set; }
        public decimal ValorRateio14 { get; set; }
        public decimal ValorRateio13 { get; set; }
        public decimal ValorRateio12 { get; set; }
        public decimal ValorRateio11 { get; set; }
        public decimal ValorAcumulado { get; set; }
        public decimal ValorEstimadoProximoConcurso { get; set; }
    }
}
