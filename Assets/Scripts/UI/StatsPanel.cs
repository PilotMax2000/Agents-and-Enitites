using TMPro;
using UnityEngine;

namespace AgentsAndEntities.UI
{
    public class StatsPanel : MonoBehaviour
    {
        [SerializeField] private UnitsSpawner unitsSpawner;
        [SerializeField] private TextMeshProUGUI unitsCountText;

        private void Start() => 
            unitsSpawner.OnUnitsCountChanged += UpdateUnitsCountText;

        private void OnDisable() => 
            unitsSpawner.OnUnitsCountChanged -= UpdateUnitsCountText;

        private void UpdateUnitsCountText() =>
            unitsCountText.text = unitsSpawner.GetUnitsCount().ToString();
    }
}