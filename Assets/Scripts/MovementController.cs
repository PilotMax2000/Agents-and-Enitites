using System;
using DG.Tweening;
using UnityEngine;

namespace AgentsAndEntities
{
    public class MovementController: MonoBehaviour
    {
        private UnitGoal _unitGoal;

        public void SetNewGoal(UnitGoal unitGoal, Action onGoalReached)
        {
            _unitGoal = unitGoal;
            StartMovementTowardsGoal(onGoalReached);
        }

        private void StartMovementTowardsGoal(Action onGoalReached)
        {
            transform.DOMove(_unitGoal.GoalPosition, 1f).OnComplete(() =>
            {
                _unitGoal.IsComplete = true;
                onGoalReached();
            });
        }
    }
}