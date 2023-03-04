using joaodias_generic.Integrations.LoteriasCaixa.DTO;

namespace joaodias_generic.Integrations.LoteriasCaixa.Services
{
    public static class DefaultLotoFacilGames
    {
        public static readonly LotoFacilGame lotoFacilGame0 = new(01, 02, 05, 07, 09, 10, 13, 14, 16, 17, 18, 21, 22, 24, 25, new List<int>(), "Game0");
        public static readonly LotoFacilGame lotoFacilGame1 = new(01, 02, 04, 06, 07, 10, 11, 12, 14, 18, 19, 20, 21, 23, 25, new List<int>(), "Game1");
        public static readonly LotoFacilGame lotoFacilGame2 = new(01, 02, 03, 06, 07, 09, 10, 12, 13, 16, 17, 18, 20, 24, 25, new List<int>(), "Game2");
        public static readonly LotoFacilGame lotoFacilGame3 = new(01, 02, 04, 05, 06, 10, 12, 16, 19, 20, 21, 22, 23, 24, 25, new List<int>(), "Game3");
        public static readonly LotoFacilGame lotoFacilGame4 = new(01, 04, 05, 07, 08, 09, 11, 12, 14, 18, 20, 21, 22, 24, 25, new List<int>(), "Game4");
        public static readonly LotoFacilGame lotoFacilGame5 = new(01, 03, 05, 06, 07, 08, 11, 12, 14, 15, 16, 17, 21, 23, 25, new List<int>(), "Game5");
        public static readonly LotoFacilGame lotoFacilGame6 = new(01, 05, 09, 11, 12, 13, 14, 17, 18, 19, 21, 22, 23, 24, 25, new List<int>(), "Game6");
        public static readonly LotoFacilGame lotoFacilGame7 = new(01, 05, 08, 10, 11, 12, 13, 15, 17, 18, 21, 22, 23, 24, 25, new List<int>(), "Game7");
        public static readonly LotoFacilGame lotoFacilGame8 = new(01, 02, 04, 05, 10, 11, 12, 15, 17, 19, 20, 21, 23, 24, 25, new List<int>(), "Game8");
        public static readonly LotoFacilGame lotoFacilGame9 = new(01, 03, 04, 06, 09, 10, 12, 15, 16, 17, 18, 20, 22, 24, 25, new List<int>(), "Game9");

        public static string VerifyDefaultLotoFacilGames(List<int> numeros, string concourse)
        {
            int matches = 0;
            List<LotoFacilGame> winnerBets = new();
            var allGames = new List<LotoFacilGame>() {lotoFacilGame0,lotoFacilGame1,lotoFacilGame2,lotoFacilGame3,lotoFacilGame4,
                lotoFacilGame5,lotoFacilGame6,lotoFacilGame7,lotoFacilGame8,lotoFacilGame9};
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
