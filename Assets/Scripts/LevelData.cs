namespace Models
{
    /// <summary>
    /// POCO for tracking level data.
    /// </summary>
    public class LevelData
    {
        public LevelData(int coinsCount, int keysCount)
        {
            TotalCoins = coinsCount;
            TotalKeys = keysCount;
        }

        public int TotalCoins { get; private set; }
        public int TotalKeys { get; private set; }
    }
}