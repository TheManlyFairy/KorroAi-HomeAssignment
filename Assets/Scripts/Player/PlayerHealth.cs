using System;
using Controllers;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// Component for handling the player's health.
    /// </summary>
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 5;
        
        private int currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                LevelManager.Instance.Lose();
            }
        }
    }
}