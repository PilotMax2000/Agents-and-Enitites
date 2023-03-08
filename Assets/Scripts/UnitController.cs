using System;
using Pathfinding;
using UnityEngine;

namespace AgentsAndEntities
{
    public class UnitController : MonoBehaviour
    {
        [SerializeField] private GoalManager goalManager;
        [SerializeField] private MovementController movementController;
    
        private Seeker _seeker;
        private Vector3 _verifiedNewGoalPosition;

        private void Awake()
        {
            _seeker = GetComponent<Seeker>();
        }

        private void Start() => 
            SetNewGoal();

        private void SetNewGoal()
        {
            _verifiedNewGoalPosition = goalManager.GetNewGoalVerifiedPosition(transform);
            _seeker.StartPath(transform.position, _verifiedNewGoalPosition, OnPathCompleteCreateNewGoal);
        }
        
        private void OnPathCompleteCreateNewGoal(Path p)
        {
            if (p.error)
                return;

            movementController.SetNewGoal(new UnitGoal(_verifiedNewGoalPosition, p), onGoalReached: SetNewGoal);
        }
    }
}