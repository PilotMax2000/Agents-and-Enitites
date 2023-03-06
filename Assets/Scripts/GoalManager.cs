using UnityEngine;

namespace AgentsAndEntities
{
    public class GoalManager : MonoBehaviour
    {
        [Range(0, 100)] 
        [SerializeField] private float goalXRange;
    
        [Range(0, 100)]
        [SerializeField] private float goalYRange;
        public UnitGoal GetNewGoal()
        {
            return new UnitGoal(new Vector3(Random.Range(-goalXRange, goalXRange), Random.Range(-goalYRange, goalYRange), 0));
        }
    }
}