using UnityEngine;

namespace Player.Input
{
    public class InputController : MonoBehaviour
    {
        protected Vector2 PlayerInput;
        private PlayerMovement _playerMovement;
        public virtual string GetName()
        {
            return "Player Name";
        }
        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        protected virtual void Update()
        {
            _playerMovement.SetPlayerInput(PlayerInput);
        }
    }
}