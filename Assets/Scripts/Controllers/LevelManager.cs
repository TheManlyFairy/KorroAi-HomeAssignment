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
        /// <summary>
        /// The singleton instance of this manager.
        /// </summary>
        public static LevelManager Instance { get; private set; }
        
        /// <summary>
        /// Subscribe to this event when you want to know that the level has finished initialization.
        /// </summary>
        public event Action OnInitializationComplete;
        
        /// <summary>
        /// Subscribe to this event to know when a coin has been collected.
        /// </summary>
        public event Action<int> OnCoinCollected;
        
        /// <summary>
        /// Subscribe to this event to know when a key has been collected.
        /// </summary>
        public event Action<int> OnKeyCollected;
        
        /// <summary>
        /// Subscribe to this event to know when all keys in this level have been collected.
        /// </summary>
        public event Action OnAllKeysCollected;

        /// <summary>
        /// Bool value that indicates whether initialization has been complete or not.
        /// </summary>
        public bool Initialized { get; private set; }
        
        /// <summary>
        /// Data regarding the current level.
        /// </summary>
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

        private void Start()
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

        /// <summary>
        /// Notifies the manager that a coin has been collected.
        /// </summary>
        public void AddCoin()
        {
            coinsCollected++;
            OnCoinCollected?.Invoke(coinsCollected);
        }

        /// <summary>
        /// Notifies the manager that a key has been collected.
        /// </summary>
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

        /// <summary>
        /// Notifies the manager that the victory trigger has been hit.
        /// </summary>
        public void Victory()
        {
            SceneManager.LoadScene("MainMenu");
        }

        /// <summary>
        /// Notifies the manager that the player has lost the game.
        /// </summary>
        public void Lose()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}