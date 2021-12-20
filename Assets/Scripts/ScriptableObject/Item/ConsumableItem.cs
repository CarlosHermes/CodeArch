using UnityEngine;


[CreateAssetMenu(fileName = "New Consumable Item", menuName = "ScriptableObjects/Items/Consumable Item", order = 1)]
public class ConsumableItem : ScriptableItem
{
    [SerializeField] private AudioClip _lootSound;
}
