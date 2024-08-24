using UnityEngine;

namespace AIGAME
{
    public abstract class Character : MonoBehaviour
    {
        [field: SerializeField] public Health Health { get; protected set; }
        public virtual void Initialize(float maxHealth = 100f)
        {
            Health = new(maxHealth);
        }
        public virtual void TakeDamage(float damageAmount)
        {
            Health.ReduceHealth(damageAmount);

            if (Health.IsDepleted)
            {
                Destroy(gameObject);
            }

            print($"{name} Health: {Health.CurrentHealth}/{Health.MaxHealth}");
        }

        [Header("Animation")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Animator _animator;
        private int _isMovingParameter = Animator.StringToHash("isMoving");

        protected void AnimateMovement(Vector2 direction)
        {

            // Animate according to direction
            _animator.SetBool(_isMovingParameter, direction != Vector2.zero);

            // Flip sprite according to direction
            if (direction.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else if (direction.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                // Prevents sprite from returning to default when movement key is released
                _spriteRenderer.flipX = _spriteRenderer.flipX;
            }
        }

        [Header("Movement")]
        [SerializeField] protected float _movementSpeed;
        protected abstract Vector2 GetMovementDirection();

        protected virtual void Move(Vector2 direction)
        {
            transform.Translate(direction * _movementSpeed * Time.deltaTime);
        }

        protected virtual void Update()
        {
            Move(GetMovementDirection());
            AnimateMovement(GetMovementDirection());
        }

        [Header("Selection")]
        [SerializeField] protected SpriteRenderer _selectionIndicator;
        public void ShowSelectIndicator()
        {
            _selectionIndicator.gameObject.SetActive(true);
        }

        public void HideSelectIndicator()
        {
            _selectionIndicator.gameObject.SetActive(false);
        }

        public abstract void Select();
    }
}
