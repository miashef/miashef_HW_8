using System;
using UnityEngine;

namespace BHSCamp
{
    [RequireComponent(typeof(AudioSource))]
    public class CharacterSound : MonoBehaviour
    {
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private AudioClip _attackSound;
        [SerializeField] private AudioClip _hurtSound;
        [SerializeField] private AudioClip _runSound;

        [SerializeField] private AudioSource _stepAudioSource;
        private AudioSource _audioSource;
        private Ground _ground;
        private float _inputX;
        private bool _isRunning;

        private void Awake()
        {
            _ground = GetComponent<Ground>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            //just started running
            if (false == _isRunning && _ground.OnGround && 0 != _inputX)
            {
                _isRunning = true;
                _audioSource.clip = _runSound;
                _audioSource.Play(0);
            }
            //finish running or jump
            if (_isRunning && (false == _ground.OnGround || 0 == _inputX))
            {
                _isRunning = false;
                _audioSource.Stop();
            }
        }

        public void PlayJumpSound()
        {
            if (_jumpSound != null)
                _audioSource.PlayOneShot(_jumpSound);
        }

        public void PlayAttackSound()
        {
            if (_attackSound != null)
                _audioSource.PlayOneShot(_attackSound);
        }

        public void PlayHurtSound()
        {
            if (_hurtSound != null)
                _audioSource.PlayOneShot(_hurtSound);
        }

        public void SetInputX(float inputX)
        {
            _inputX = inputX;
        }
    }
}