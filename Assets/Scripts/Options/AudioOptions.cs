using UnityEngine;
using UnityEngine.UI;

namespace BHSCamp
{
    public struct SoundSettings 
    {
        public float Master;
        public float SFX;
        public float Music;
    }

    public class AudioOptions : MonoBehaviour
    {
        [SerializeField] private Slider _masterVolume;
        [SerializeField] private Slider _musicVolume;
        [SerializeField] private Slider _sfxVolume;
        private SoundSettings _currentSetings;

        private void Start()
        {
            _currentSetings = SaveLoadSystem.LoadSound();
            _masterVolume.value = _currentSetings.Master;
            _musicVolume.value = _currentSetings.Music;
            _sfxVolume.value = _currentSetings.SFX;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
                SaveLoadSystem.SaveSound(_currentSetings);
        }

        public void SetMasterVolume(System.Single value)
        {
            _currentSetings.Master = value;
        }

        public void SetMusicVolume(System.Single value)
        {
            _currentSetings.Music = value;
        }

        public void SetSFSXVolume(System.Single value)
        {
            _currentSetings.SFX = value;
        }
    }
}
