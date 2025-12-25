using Models.ScriptableObjects;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Script to help populate level buttons within the level selector
    /// </summary>
    public class LevelSelector : MonoBehaviour
    {
        private const string LEVELS_RESOURCES_PATH = "LevelData";
        
        [SerializeField] private RectTransform levelButtonsLayoutParent;
        [SerializeField] private LevelSelectButton levelButtonPrefab;

        private void Start()
        {
            GenerateLevelButtons();
        }
        private void GenerateLevelButtons()
        {
            SceneSelectionData[] allLevels = Resources.LoadAll<SceneSelectionData>(LEVELS_RESOURCES_PATH);
            foreach (SceneSelectionData levelData in allLevels)
            {
                LevelSelectButton levelButton = Instantiate(levelButtonPrefab, levelButtonsLayoutParent);
                levelButton.SetSceneData(levelData);
            }
        }
    }
}