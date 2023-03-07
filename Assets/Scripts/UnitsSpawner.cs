using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AgentsAndEntities
{
    [Serializable]
    public class UnitsSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject unitPrefabToSpawn;
        
        [Range(0, 100)]
        [SerializeField] private float spawnXOffset;
        
        [Range(0, 100)]
        [SerializeField] private float spawnZOffset;
        [SerializeField] private Transform spawnPoint;
        
        [SerializeField] private Transform UnitsParent;

        public void Spawn1Unit() => SpawnUnits(1);

        public void Spawn10Units() => SpawnUnits(10);

        public void Spawn100Units() => SpawnUnits(100);

        public void ClearUnits()
        {
            foreach (Transform child in UnitsParent) 
                Destroy(child.gameObject);
        }

        private void SpawnUnits(int unitsCount)
        {
            for (int i = 0; i < unitsCount; i++)
            {
                var unit = Instantiate(unitPrefabToSpawn, spawnPoint.position + new Vector3(Random.Range(-spawnXOffset, spawnXOffset), 0, Random.Range(-spawnZOffset, spawnZOffset)), Quaternion.identity, UnitsParent);
                unit.name = $"Unit {i}";
            }
        }
    }
}