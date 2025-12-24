using Models;
using Models.ScriptableObjects;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Script to help populate level buttons within the level selector
    /// </summary>
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] private RectTransform levelButtonsLayoutParent;
        [SerializeField] private LevelSelectButton levelButtonPrefab;
        [SerializeField] private SceneSelectionData[] levels;

        private void Start()
        {
            GenerateLevelButtons();
        }
        private void GenerateLevelButtons()
        {
            foreach (SceneSelectionData levelData in levels)
            {
                LevelSelectButton levelButton = Instantiate(levelButtonPrefab, levelButtonsLayoutParent);
                levelButton.SetSceneData(levelData);
            }
        }
    }
}