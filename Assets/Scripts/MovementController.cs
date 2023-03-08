using System;
using DG.Tweening;
using UnityEngine;

namespace AgentsAndEntities
{
    public class MovementController: MonoBehaviour
    {
        [Range(0, 10f)]
        [SerializeField] private float tweenMovementTime = 1f;
        private UnitGoal _unitGoal;

        public void SetNewGoal(UnitGoal unitGoal, Action onGoalReached)
        {
            _unitGoal = unitGoal;
            StartMovementTowardsGoal(onGoalReached);
        }

        private void OnDestroy()
        {
            StopMovement();
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
            
            Debug.DrawLine(transform.position, _unitGoal.GoalPosition, Color.green, 3);
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_unitGoal.GoalPosition + new Vector3(0, 0.75f, 0), .75f);
        }
    }
}