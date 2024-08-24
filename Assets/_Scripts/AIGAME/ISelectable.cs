using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIGAME
{
    public interface ISelectable
    {
        SpriteRenderer SelectionIndicator { get; set; }
        public void ShowSelectIndicator();
        public void HideSelectIndicator();
        public abstract void Select();
    }
}
