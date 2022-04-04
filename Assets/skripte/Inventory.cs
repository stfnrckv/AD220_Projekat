using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one Inventory instance found!");
            return;
        }
        Instance = this;
    }
    #endregion

    public delegate void InventoryUpdated();
    public InventoryUpdated InventoryUpdatedCallback;

    public List<Item> items = new List<Item>();
    public int maxCapacity = 20;
    public bool AddItem(Item item)
    {
        if (!item.isDefaultItem && items.Count < maxCapacity)
        {
            items.Add(item);
            if (InventoryUpdatedCallback != null)
            {
                InventoryUpdatedCallback.Invoke();
            }
            return true;
        }
        Debug.Log("Inventory full!!!");
        return false;
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        if (InventoryUpdatedCallback != null)
        {
            InventoryUpdatedCallback.Invoke();
        }
    }
}
