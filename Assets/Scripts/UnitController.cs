using UnityEngine;

namespace AgentsAndEntities
{
    public class UnitController : MonoBehaviour
    {
        [SerializeField] private GoalManager goalManager;
        [SerializeField] private MovementController movementController;
    
        private UnitGoal _currentGoal;

        private void Start() => 
            SetNewGoal();

        private void SetNewGoal()
        {
            _currentGoal = goalManager.GetNewGoal(transform);
            movementController.SetNewGoal(_currentGoal, onGoalReached: SetNewGoal);
        }
    }
}