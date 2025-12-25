using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

namespace Controllers
{
    /// <summary>
    /// Manager class for handling playing timeline animations within a level
    /// </summary>
    public class TimelineManager : MonoBehaviour
    {       
        public static TimelineManager Instance { get; private set; }

        [SerializeField] private PlayableDirector playableDirector;

        public static event Action OnPlay;
        public static event Action OnEnd;
        
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
            StartCoroutine(PlayIntroAnimation());
        }
        private IEnumerator PlayIntroAnimation()
        {
            OnPlay?.Invoke();
            playableDirector.Play();
            yield return new WaitForSeconds((float)playableDirector.duration);
            OnEnd?.Invoke();
        }
    }
}