using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private PlayerGrounded _playerGrounded;
        [SerializeField] private SpriteRenderer _playerBody;
        [SerializeField] private Transform _playerHead;
        private Animator _animator;
        private Rigidbody2D _rb2D;
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Fall = Animator.StringToHash("Fall");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rb2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (Mathf.Abs(_rb2D.velocity.x) > 0.1f)
            {
                _playerBody.flipX = _rb2D.velocity.x < 0;
                var position = _playerHead.localPosition;
                position.x = _rb2D.velocity.x > 0 ? Mathf.Abs(position.x) : -Mathf.Abs(position.x);
                _playerHead.position = position;
            }
            
            if (_playerGrounded.IsGrounded())
            {
                _animator.SetTrigger(Mathf.Abs(_rb2D.velocity.x) > 0.1 ? Run : Idle);
            }
            else
            {
                _animator.SetTrigger(_rb2D.velocity.y > 0 ? Jump : Fall);
            }
        }
    }
}