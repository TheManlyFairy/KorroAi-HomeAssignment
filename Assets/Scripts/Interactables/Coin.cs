using Controllers;

namespace Interactables
{
    /// <summary>
    /// Class for handling Coin collectible behavior.
    /// </summary>
    public class Coin : CollectibleBase
    {
        public override void Collect()
        {
            LevelManager.Instance.AddCoin();
        }
    }
}