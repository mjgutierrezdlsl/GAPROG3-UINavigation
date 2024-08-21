using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] PlayerController[] _players;
    private int _lastSelected;
    private bool _isSelecting;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isSelecting = !_isSelecting;

            // Only ran when selection is toggled off
            if (!_isSelecting)
            {
                for (int i = 0; i < _players.Length; i++)
                {
                    var player = _players[i];
                    player.HideSelectIndicator();
                    if (i == _lastSelected)
                    {
                        player.GetSelected();
                    }
                }
            }
        }

        if (_isSelecting)
        {
            // Highlight the last selected player before exiting selection mode
            SelectPlayer(_lastSelected);

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectPlayer(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectPlayer(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectPlayer(2);
            }
        }
    }

    private void SelectPlayer(int index)
    {
        _lastSelected = index;

        for (int i = 0; i < _players.Length; i++)
        {
            var player = _players[i];
            if (i != index)
            {
                player.HideSelectIndicator();
            }
            else
            {
                player.ShowSelectIndicator();
            }
        }
    }
}
