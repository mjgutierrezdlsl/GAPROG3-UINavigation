using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIGAME
{
    public abstract class Character : MonoBehaviour
    {

        public Health Health { get; private set; }
        public virtual void TakeDamage(float damageAmount)
        {
            Health.ReduceHealth(damageAmount);

            if (Health.IsDepleted)
            {
                Destroy(gameObject);
            }
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

    }
}
