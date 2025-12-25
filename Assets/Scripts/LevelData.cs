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

        /// <summary>
        /// The total coins to collect in the current level.
        /// </summary>
        public int TotalCoins { get; private set; }
        
        /// <summary>
        /// The total keys to collect in the current level.
        /// </summary>
        public int TotalKeys { get; private set; }
    }
}