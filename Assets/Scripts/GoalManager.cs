using Pathfinding;
using UnityEngine;

namespace AgentsAndEntities
{
    public class GoalManager : MonoBehaviour
    {
        [Range(0, 100)] 
        [SerializeField] private float goalXRange;
    
        [Range(0, 100)]
        [SerializeField] private float goalZRange;
        public UnitGoal GetNewGoal(Transform startTransform)
        {
            return new UnitGoal(FindValidTargetPosition(startTransform));
        }
        
        private Vector3 FindValidTargetPosition(Transform startPosition)
        {
            GraphNode startNode = AstarPath.active.GetNearest(startPosition.position, NNConstraint.Default).node;

            do
            {
                Vector3 randomPosition = new Vector3(Random.Range(-goalXRange, goalXRange), 0,
                    Random.Range(-goalZRange, goalZRange));

                // Check if the target position is reachable
                NNInfo nearestNodeInfo = AstarPath.active.GetNearest(randomPosition, NNConstraint.Default);
                if (nearestNodeInfo.node != null)
                {
                    GraphNode nearestNode = nearestNodeInfo.node;
                    if (PathUtilities.IsPathPossible(startNode, nearestNode))
                    {
                        return randomPosition;
                    }
                }
            } while (true);
        }
    }
}