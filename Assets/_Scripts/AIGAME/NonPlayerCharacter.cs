using System;
using UnityEngine;

namespace AIGAME
{
    public class NonPlayerCharacter : Character
    {
        [SerializeField] float waypointThreshold;
        [SerializeField] Transform[] waypoints;
        private int _wayPointIndex;
        private Vector3 _currentWaypoint;

        protected override Vector2 GetMovementDirection()
        {
            _currentWaypoint = waypoints[_wayPointIndex].position;
            Vector2 moveDirection = _currentWaypoint - transform.position;
            return moveDirection.normalized;
        }
        protected override void Move(Vector2 direction)
        {
            transform.position = Vector2.MoveTowards(transform.position, _currentWaypoint, _movementSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, _currentWaypoint) < waypointThreshold)
            {
                _wayPointIndex++;

                // Loops the waypoints
                if (_wayPointIndex >= waypoints.Length)
                {
                    _wayPointIndex = 0;
                }
            }
        }
    }
}
