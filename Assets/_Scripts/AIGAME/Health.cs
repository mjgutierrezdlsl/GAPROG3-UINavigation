using System;
using UnityEngine;

namespace AIGAME
{
    [Serializable]
    public class Health
    {
        public bool IsDepleted { get; private set; }

        [field: SerializeField] public float MaxHealth { get; private set; }

        private float _currentHealth;
        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                _currentHealth = Mathf.Clamp(_currentHealth, 0f, MaxHealth);
                IsDepleted = _currentHealth == 0;
            }
        }

        public void GainHealth(float amount)
        {
            CurrentHealth += amount;
        }

        public void ReduceHealth(float amount)
        {
            CurrentHealth -= amount;
        }

        public Health(float maxAmount = 100f)
        {
            MaxHealth = maxAmount;
            CurrentHealth = MaxHealth;
        }
    }
}
