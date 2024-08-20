using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    private int _isMovingParameter = Animator.StringToHash("isMoving");

    [Header("Movement")]
    [SerializeField] private float _movementSpeed;
    private Vector2 _moveDirection;

    private void Update()
    {
        // Gets the direction of the movement from the keyboard input
        _moveDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // Normalize the vector so we do not move faster when going diagonally
        _moveDirection.Normalize();

        // Animate according to direction
        _animator.SetBool(_isMovingParameter, _moveDirection != Vector2.zero);

        // Flip sprite according to direction
        if (_moveDirection.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_moveDirection.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            // Prevents sprite from returning to default when movement key is released
            _spriteRenderer.flipX = _spriteRenderer.flipX;
        }

        transform.Translate(_moveDirection * _movementSpeed * Time.deltaTime);
    }
}
