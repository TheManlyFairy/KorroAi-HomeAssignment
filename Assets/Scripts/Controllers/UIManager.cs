using Models;
using Player;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class UIManager : MonoBehaviour
    {
        private const string HEALTH_STRING_FORMAT = "Health: {0}/{1}";
        private const string COINS_STRING_FORMAT = "Coins: {0}/{1}";
        private const string KEYS_STRING_FORMAT = "Keys: {0}/{1}";

        [SerializeField] private TMP_Text playerHealthText;
        [SerializeField] private TMP_Text coinsCollectedText;
        [SerializeField] private TMP_Text keysCollectedText;

        /// <summary>
        /// Simplified reference to level manager's level data.
        /// </summary>
        private LevelData LevelData => LevelManager.Instance?.LevelData;

        private void Awake()
        {
            PlayerHealth.OnHealthChanged += UpdateHealth;
        }


        private void Start()
        {
            if (LevelData != null)
            {
                SubscribeToUpdates();
            }
            else
            {
                LevelManager.Instance.OnInitializationComplete += SubscribeToUpdates;
            }
        }

        private void OnDestroy()
        {
            PlayerHealth.OnHealthChanged -= UpdateHealth;
        }

        private void SubscribeToUpdates()
        {
            LevelManager.Instance.OnInitializationComplete -= SubscribeToUpdates;
            LevelManager.Instance.OnCoinCollected += UpdateCoins;
            LevelManager.Instance.OnKeyCollected += UpdateKeys;
            UpdateCoins(0);
            UpdateKeys(0);
        }

        private void UpdateHealth(int currentHealth, int maxHealth)
        {
            playerHealthText.text = string.Format(HEALTH_STRING_FORMAT, currentHealth, maxHealth);
        }

        private void UpdateCoins(int currentCoins)
        {
            coinsCollectedText.text = string.Format(COINS_STRING_FORMAT, currentCoins, LevelData.TotalCoins);
        }

        private void UpdateKeys(int currentKeys)
        {
            keysCollectedText.text = string.Format(KEYS_STRING_FORMAT, currentKeys,  LevelData.TotalKeys);
        }
    }
}