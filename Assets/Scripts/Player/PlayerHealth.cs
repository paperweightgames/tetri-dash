using Player.Tracker;
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
        private Transform _respawnPoint;
        private Rigidbody2D _rb;
        private float _timeSinceHurt;
        private PlayerManager _playerManager;
        private ScreenShake _screenShake;
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerManager = GetComponentInParent<PlayerManager>();
            _screenShake = FindObjectOfType<ScreenShake>();
            _playerMovement = GetComponent<PlayerMovement>();
            _rb = GetComponent<Rigidbody2D>();
            _respawnPoint = FindObjectOfType<HighestPoint>().transform;
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
            
            var newPosition = _respawnPoint.position;
            newPosition.z = 0;
            transform.position = newPosition;
            // Reset y velocity.
            _rb.velocity = Vector2.right * _rb.velocity.x;
            // Reset the player's jump count.
            _playerMovement.ResetJumps();
        }

        private void Die()
        {
            gameObject.SetActive(false);
            _playerManager.CheckGameOver();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if player is stuck in a tetriminoe.
            if (other.CompareTag("Tetriminoe Fall"))
            {
                Hurt(1);
            }
        }
    }
}