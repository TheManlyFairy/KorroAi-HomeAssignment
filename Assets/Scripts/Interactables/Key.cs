using Controllers;
using UnityEngine;

namespace Interactables
{
    /// <summary>
    /// Class for handling Key collectible behavior.
    /// </summary>
    public class Key : CollectibleBase
    {
        public override void Collect()
        {
            LevelManager.Instance.AddKey();
        }
    }
}