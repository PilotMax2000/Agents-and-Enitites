using System;
using Pathfinding;
using UnityEngine;

namespace AgentsAndEntities
{
    [Serializable]
    public class UnitGoal
    {
        public bool IsComplete { get; set; }
        public Vector3 GoalPosition { get; }
        public Path Path { get; }

        public UnitGoal(Vector3 goalPosition, Path path)
        {
            GoalPosition = goalPosition;
            Path = path;
            IsComplete = false;
        }
    }
}