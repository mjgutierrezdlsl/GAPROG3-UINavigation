using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAPROG3.Assets._Scripts.GAPROG3
{
    public class CreatureController : MonoBehaviour
    {
        [Header("Interaction")]
        [SerializeField] private SpriteRenderer _indicator;
        public bool IsSelected { get; private set; }

        [Header("Animation")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Animator _animator;
        private int _isMovingParameter = Animator.StringToHash("isMoving");

        [Header("Movement")]
        [SerializeField] private float _movementSpeed;
        private Vector2 _moveDirection;
        private Vector2 _screenBounds;
        private float _objectWidth, _objectHeight;

        public Sprite Sprite => _spriteRenderer.sprite;

        [field: SerializeField] public float MaxLikeness { get; private set; } = 100;
        public float Likeness { get; private set; }


        private void Start()
        {
            _screenBounds = Camera.main.ScreenToWorldPoint(new(Screen.width, Screen.height, Camera.main.transform.position.z));
            _objectWidth = _spriteRenderer.bounds.size.x / 2;
            _objectHeight = _spriteRenderer.bounds.size.y / 2;
        }

        private void Update()
        {

            // We only move if this is the creature selected
            if (!IsSelected) { return; }

            // Gets the direction of the movement from the keyboard input
            _moveDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            // Normalize the vector so we do not move faster when going diagonally
            _moveDirection.Normalize();
            {
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
        private void LateUpdate()
        {
            // Prevents the player from moving the character off-camera
            var viewPosition = transform.position;
            viewPosition.x = Mathf.Clamp(viewPosition.x, _screenBounds.x * -1 + _objectWidth, _screenBounds.x - _objectWidth);
            viewPosition.y = Mathf.Clamp(viewPosition.y, _screenBounds.y * -1 + _objectHeight, _screenBounds.y - _objectHeight);
            transform.position = viewPosition;
        }

        public void ShowSelectIndicator()
        {
            _indicator.gameObject.SetActive(true);
        }
        public void HideSelectIndicator()
        {
            _indicator.gameObject.SetActive(false);
        }
        public void SelectCreature()
        {
            print($"{name} has been selected");
            IsSelected = true;
            Likeness += 10;
            Likeness = Mathf.Clamp(Likeness, 0f, MaxLikeness);
            print($"{Likeness}/100");
        }
        public void DeselectCreature()
        {
            IsSelected = false;
        }
    }
}