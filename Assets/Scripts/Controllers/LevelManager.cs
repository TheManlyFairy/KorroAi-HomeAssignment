using System;
using Interactables;
using Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using Key = Interactables.Key;

namespace Controllers
{
    /// <summary>
    /// Manager for handling gameplay logic within a level.
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }
        
        public event Action OnInitializationComplete;
        public event Action<int> OnCoinCollected;
        public event Action<int> OnKeyCollected;
        public event Action OnAllKeysCollected;

        public bool Initialized { get; private set; }
        public LevelData LevelData{ get; private set; }
        
        private int coinsCollected;
        private int keysCollected;

        #region Startup

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        void Start()
        {
            TallyAllCoinsAndKeysInLevel();
            Initialized = true;
            OnInitializationComplete?.Invoke();
        }
        private void TallyAllCoinsAndKeysInLevel()
        {
            int totalCoinsCount = FindObjectsByType<Coin>(FindObjectsSortMode.None).Length;
            int totalKeysCount = FindObjectsByType<Key>(FindObjectsSortMode.None).Length;
            LevelData = new LevelData(totalCoinsCount, totalKeysCount);
        }

        #endregion

        #region Collectible Interactions

        public void AddCoin()
        {
            coinsCollected++;
            OnCoinCollected?.Invoke(coinsCollected);
        }

        public void AddKey()
        {
            keysCollected++;
            OnKeyCollected?.Invoke(keysCollected);
            if (keysCollected == LevelData.TotalKeys)
            {
                OnAllKeysCollected?.Invoke();
            }
        }

        #endregion

        public void Victory()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void Lose()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}