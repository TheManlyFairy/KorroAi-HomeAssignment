using UnityEngine;

namespace Models.ScriptableObjects
{
    /// <summary>
    /// Scriptable object containing data for selecting which scene to play from the level selector.
    /// </summary>
    [CreateAssetMenu(fileName = "SceneSelectionData", menuName = "KorroAI/Scene Selection Data")]
    public class SceneSelectionData : ScriptableObject
    {
        [SerializeField] private string scene;
        [SerializeField] private string sceneDisplayName;

        /// <summary>
        /// The actual scene name within unity's build settings.
        /// </summary>
        public string Scene => scene;
        
        /// <summary>
        /// The scene name to display in the level selection.
        /// </summary>
        public string SceneDisplayName => sceneDisplayName;
    }
}