using joaodias_generic.Integrations.LoteriasCaixa.DTO;

namespace joaodias_generic.Integrations.LoteriasCaixa.Services
{
    public static class DefaultLotoFacilGames
    {
        public static readonly LotoFacilGame lotoFacilGame0 = new(01, 02, 05, 07, 09, 10, 13, 14, 16, 17, 18, 21, 22, 24, 25, new List<int>(), "Game0");
        public static readonly LotoFacilGame lotoFacilGame1 = new(01, 02, 04, 06, 07, 08, 10, 11, 12, 18, 19, 20, 21, 23, 25, new List<int>(), "Game1");
        public static readonly LotoFacilGame lotoFacilGame2 = new(03, 04, 05, 06, 07, 09, 10, 11, 12, 13, 16, 18, 20, 21, 25, new List<int>(), "Game2");
        public static readonly LotoFacilGame lotoFacilGame3 = new(01, 02, 05, 06, 07, 08, 11, 13, 14, 17, 18, 19, 20, 24, 25, new List<int>(), "Game3");
        public static readonly LotoFacilGame lotoFacilGame4 = new(01, 03, 04, 05, 08, 09, 11, 13, 14, 15, 16, 19, 21, 24, 25, new List<int>(), "Game4");
        public static readonly LotoFacilGame lotoFacilGame5 = new(02, 07, 08, 10, 12, 13, 14, 15, 17, 18, 21, 22, 23, 24, 25, new List<int>(), "Game5");
        public static readonly LotoFacilGame lotoFacilGame6 = new(02, 04, 05, 06, 07, 11, 12, 13, 18, 19, 20, 21, 23, 24, 25, new List<int>(), "Game6");
        public static readonly LotoFacilGame lotoFacilGame7 = new(01, 02, 04, 05, 06, 08, 11, 12, 14, 16, 17, 18, 21, 22, 23, new List<int>(), "Game7");
        public static readonly LotoFacilGame lotoFacilGame8 = new(02, 03, 04, 07, 09, 10, 12, 14, 15, 19, 20, 21, 22, 23, 25, new List<int>(), "Game8");
        public static readonly LotoFacilGame lotoFacilGame9 = new(03, 04, 09, 10, 12, 15, 16, 18, 19, 20, 21, 22, 23, 24, 25, new List<int>(), "Game9");
        public static readonly LotoFacilGame lotoFacilGame10 = new(02, 03, 05, 06, 07, 08, 09, 10, 11, 12, 15, 16, 17, 18, 24, new List<int>(), "Game10");
        public static readonly LotoFacilGame lotoFacilGame11 = new(02, 05, 06, 07, 08, 10, 12, 13, 14, 15, 17, 19, 20, 21, 23, new List<int>(), "Game11");
        public static readonly LotoFacilGame lotoFacilGame12 = new(02, 05, 06, 07, 09, 10, 11, 12, 13, 14, 15, 17, 21, 24, 25, new List<int>(), "Game12");
        public static readonly LotoFacilGame lotoFacilGame13 = new(02, 04, 05, 07, 08, 09, 11, 13, 14, 15, 17, 19, 21, 23, 25, new List<int>(), "Game13");
        public static readonly LotoFacilGame lotoFacilGame14 = new(03, 05, 06, 08, 10, 11, 12, 13, 14, 15, 16, 17, 22, 24, 25, new List<int>(), "Game14");
        public static readonly LotoFacilGame lotoFacilGame15 = new(02, 06, 07, 09, 10, 12, 13, 14, 15, 17, 18, 21, 23, 24, 25, new List<int>(), "Game15");
        public static readonly LotoFacilGame lotoFacilGame16 = new(01, 03, 04, 07, 10, 11, 12, 13, 14, 15, 17, 18, 19, 23, 25, new List<int>(), "Game16");
        public static readonly LotoFacilGame lotoFacilGame17 = new(01, 03, 05, 06, 07, 08, 09, 13, 15, 16, 18, 19, 20, 22, 25, new List<int>(), "Game17");
        public static readonly LotoFacilGame lotoFacilGame18 = new(01, 02, 03, 05, 07, 09, 11, 13, 14, 16, 17, 18, 19, 22, 23, new List<int>(), "Game18");
        public static readonly LotoFacilGame lotoFacilGame19 = new(01, 02, 03, 04, 07, 08, 09, 10, 12, 15, 17, 20, 22, 23, 24, new List<int>(), "Game19");
        public static readonly LotoFacilGame lotoFacilGame20 = new(02, 03, 05, 07, 08, 10, 13, 15, 16, 17, 18, 19, 22, 24, 25, new List<int>(), "Game20");

        public static string VerifyDefaultLotoFacilGames(List<int> numeros, string concourse)
        {
            int matches = 0;
            List<LotoFacilGame> winnerBets = new();
            var allGames = new List<LotoFacilGame>() {lotoFacilGame0,lotoFacilGame1,lotoFacilGame2,lotoFacilGame3,lotoFacilGame4,
                lotoFacilGame5,lotoFacilGame6,lotoFacilGame7,lotoFacilGame8,lotoFacilGame9, lotoFacilGame10, lotoFacilGame11, lotoFacilGame12,
                lotoFacilGame13, lotoFacilGame14, lotoFacilGame15, lotoFacilGame16, lotoFacilGame17, lotoFacilGame18, lotoFacilGame19, lotoFacilGame20};
            foreach (var game in allGames)
            {
                foreach (var number in game.GameNumbers)
                {
                    if (numeros.Contains(number))
                    {
                        matches++;
                    }
                }
                if (matches >= 11)
                {
                    game.Matches = matches;
                    winnerBets.Add(game);
                }
                matches = 0;
            }
            if (winnerBets.Count <= 0)
            {
                return "No winner Bet! :(";

            }
            var winnersAnnounce = $"You had {winnerBets.Count} winner bets on concourse {concourse}. Congrats!!!\n";
            foreach (var game in winnerBets)
            {
                winnersAnnounce += $"Winner Bet: {game.Name} with {game.Matches} correct numbers\n";
            }
            return winnersAnnounce;

        }
    }
}
