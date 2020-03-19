using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _currentHealth;
        [SerializeField] private int _maxHealth;
        private PlayerManager _playerManager;

        private void Awake()
        {
            _playerManager = GetComponentInParent<PlayerManager>();
        }

        public int GetCurrentHealth()
        {
            return _currentHealth;
        }

        public int GetMaxHealth()
        {
            return _maxHealth;
        }
        public void ChangeHealth(int amount)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            print("Dead!");
            gameObject.SetActive(false);
            _playerManager.CheckGameOver();
        }
    }
}