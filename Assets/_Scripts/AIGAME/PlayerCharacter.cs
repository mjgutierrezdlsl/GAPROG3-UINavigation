using System;
using UnityEngine;

namespace AIGAME
{
    public class PlayerCharacter : Character
    {
        public override void Initialize(float maxHealth = 100)
        {
            Health = new Health(maxHealth / 2, maxHealth);
        }

        public override void Select()
        {
            TakeDamage(10);
        }

        protected override Vector2 GetMovementDirection()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }

    }
}
