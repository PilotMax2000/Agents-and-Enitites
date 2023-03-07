using UnityEngine;

namespace AgentsAndEntities.Input
{
    public class KeyboardInput : MonoBehaviour
    {
        [SerializeField] private UnitsSpawner unitsSpawner;
        
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
            {
                unitsSpawner.Spawn1Unit();
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                unitsSpawner.Spawn10Units();
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                unitsSpawner.Spawn100Units();
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.R))
            {
                unitsSpawner.ClearUnits();
            }
        }
    }
}