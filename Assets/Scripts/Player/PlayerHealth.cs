﻿using System;
using UnityEngine;
using Utility;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _currentHealth;
        [SerializeField] private int _maxHealth;
        [SerializeField] private float _invincibilityTime;
        [SerializeField] private ParticleSystem _hurtParticles;
        private float _timeSinceHurt;
        private PlayerManager _playerManager;
        private ScreenShake _screenShake;

        private void Awake()
        {
            _playerManager = GetComponentInParent<PlayerManager>();
            _screenShake = FindObjectOfType<ScreenShake>();
        }

        public int GetCurrentHealth()
        {
            return _currentHealth;
        }

        public int GetMaxHealth()
        {
            return _maxHealth;
        }

        private void Update()
        {
            _timeSinceHurt += Time.deltaTime;
        }

        private void ChangeHealth(int amount)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        public void Heal(int amount)
        {
            ChangeHealth(amount);
        }

        public void Hurt(int amount)
        {
            // Only hurt once invincibility runs out.
            if (_timeSinceHurt <= _invincibilityTime)
                return;
            _timeSinceHurt = 0;
            _hurtParticles.Play();
            _screenShake.SetDuration(1);
            ChangeHealth(-amount);
        }

        private void Die()
        {
            gameObject.SetActive(false);
            _playerManager.CheckGameOver();
        }
    }
}