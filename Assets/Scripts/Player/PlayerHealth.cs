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
        public static event Action<int, int> OnHealthChanged;

        [SerializeField] private int maxHealth = 5;

        private int currentHealth;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        private void Start()
        {
            InvokeHealthChanged();
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            InvokeHealthChanged();
        }

        private void InvokeHealthChanged()
        {
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
            if (currentHealth <= 0)
            {
                LevelManager.Instance.Lose();
            }
        }
    }
}