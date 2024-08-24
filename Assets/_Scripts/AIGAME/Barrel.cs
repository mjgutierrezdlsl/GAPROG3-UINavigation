using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIGAME
{
    public class Barrel : MonoBehaviour, IDamagable, ISelectable
    {
        [SerializeField] Health _health;
        public Health Health
        {
            get => _health;
            set => _health = value;
        }
        public SpriteRenderer SelectionIndicator { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private void Start()
        {
            Health = new(100f);
        }


        public void TakeDamage(float amount)
        {
            Health.ReduceHealth(amount);
            if (Health.IsDepleted)
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                TakeDamage(Health.MaxHealth);
            }
        }

        public void ShowSelectIndicator()
        {
            throw new System.NotImplementedException();
        }

        public void HideSelectIndicator()
        {
            throw new System.NotImplementedException();
        }

        public void Select()
        {
            throw new System.NotImplementedException();
        }
    }
}
