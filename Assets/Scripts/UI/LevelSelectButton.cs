using Models.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Component for handling a level selection button;
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class LevelSelectButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text levelNameText;
        
        /// <summary>
        /// Sets the <see cref="SceneSelectionData"/> with this button.
        /// </summary>
        /// <param name="data">Scene selection data to use if this button is pressed.</param>
        public void SetSceneData(SceneSelectionData data)
        {
            levelNameText.text = data.SceneDisplayName;
            
            Button button = GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => LoadLevel(data.Scene));
        }

        private void LoadLevel(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}