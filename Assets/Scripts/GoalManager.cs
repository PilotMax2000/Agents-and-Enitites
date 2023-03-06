using UnityEngine;

namespace AgentsAndEntities
{
    public class GoalManager : MonoBehaviour
    {
        [Range(0, 100)] 
        [SerializeField] private float goalXRange;
    
        [Range(0, 100)]
        [SerializeField] private float goalZRange;
        public UnitGoal GetNewGoal()
        {
            return new UnitGoal(new Vector3(Random.Range(-goalXRange, goalXRange), 0, Random.Range(-goalZRange, goalZRange)));
        }
    }
}