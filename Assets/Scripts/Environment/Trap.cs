using UnityEngine;

namespace Interactables
{
    /// <summary>
    /// Script for managing trap objects.
    /// </summary>
    public class Trap : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        
        public int Damage => damage;
    }
}