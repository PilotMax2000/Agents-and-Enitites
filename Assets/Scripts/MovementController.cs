using System;
using DG.Tweening;
using Pathfinding;
using UnityEngine;

namespace AgentsAndEntities
{
    public class MovementController: MonoBehaviour
    {
        [Range(0, 5f)]
        [SerializeField] private float tweenMovementTime = 1f;
        
        [Range(0, 1f)]
        [SerializeField] private float minDistanceToPointForChangingToNext = 0.1f;

        private UnitGoal _unitGoal;
        private int _currentWaypointIndex;
        private Action _onGoalReached;

        public void SetNewGoal(UnitGoal unitGoal, Action onGoalReached)
        {
            _onGoalReached = onGoalReached;
            _unitGoal = unitGoal;
            _currentWaypointIndex = 0;
            MakeStepTowardsGoal();
        }

        private void OnDestroy()
        {
            StopMovement();
        }
        
        private void MakeStepTowardsGoal()
        {
            if (_unitGoal == null)
                return;
            
            if (_unitGoal.IsComplete || _unitGoal.Path == null) 
                return;

            if (_currentWaypointIndex >= _unitGoal.Path.vectorPath.Count)
            {
                // Reached the end of the path
                _unitGoal.IsComplete = true;
                _onGoalReached.Invoke();
                return;
            }

            // Move towards the current waypoint
            Vector3 waypoint = _unitGoal.Path.vectorPath[_currentWaypointIndex];
            transform.DOMove(waypoint, tweenMovementTime);
        }

        private void Update()
        {
            if (_unitGoal == null)
                return;
            
            if (_unitGoal.IsComplete || _unitGoal.Path == null) 
                return;
            
            // Check if reached the current waypoint
            float distanceToWaypoint = Vector3.Distance(transform.position, _unitGoal.Path.vectorPath[_currentWaypointIndex]);
            transform.LookAt(_unitGoal.Path.vectorPath[_currentWaypointIndex]);
            
            if (distanceToWaypoint < minDistanceToPointForChangingToNext)
            {
                OnStepTowardsGoalComplete();
            }
            
        }

        private void OnStepTowardsGoalComplete()
        {
            _currentWaypointIndex++;
            MakeStepTowardsGoal();
        }

        private void StopMovement()
        {
            //Stop Tweening
            transform.DOKill();
        }

        private void StartMovementTowardsGoal(Action onGoalReached)
        {
            transform.DOMove(_unitGoal.GoalPosition, tweenMovementTime).OnComplete(() =>
            {
                _unitGoal.IsComplete = true;
                onGoalReached();
            });
        }

        private void OnDrawGizmosSelected()
        {
            if(_unitGoal == null) 
                return;
            
            //Debug.DrawLine(transform.position, _unitGoal.GoalPosition, Color.green, 3);
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_unitGoal.GoalPosition + new Vector3(0, 0.75f, 0), 2f);
        }
    }
}