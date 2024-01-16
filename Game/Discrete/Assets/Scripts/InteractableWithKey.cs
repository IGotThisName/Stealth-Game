using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWithKey : MonoBehaviour
{
    [Header("Events")]
    public GameEvent uniqueInteractionName;
    public InventorySystem inventorySystem;
    public InventoryItem requiredItem;
    private List<InventoryItem> inventoryItems;
    
    // Start is called before the first frame update
    void Start()
    {
        inventoryItems = inventorySystem.Items;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerEvent()
    {
        if (inventoryItems.Contains(requiredItem))
        {
            uniqueInteractionName.Raise(this, null);
        }
    }
}