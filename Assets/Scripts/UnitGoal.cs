using System;
using UnityEngine;

namespace AgentsAndEntities
{
    [Serializable]
    public class UnitGoal
    {
        public bool IsComplete { get; set; }
        public Vector3 GoalPosition { get; }
    
        public UnitGoal(Vector3 goalPosition)
        {
            GoalPosition = goalPosition;
            IsComplete = false;
        }
    }
}