using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image itemIcon;
    public Button removeBtn;
    public Button useBtn;
    public TMP_Text useTxt;
    public void AddItem(Item i)
    {
        item = i;
        itemIcon.sprite = i.icon;
        itemIcon.enabled = true;
        removeBtn.interactable = true;
        if (item.isConsumable)
        {
            useTxt.text = "USE";
            useBtn.interactable = true;
        }
    }
    public void ClearSlot()
    {
        item = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        removeBtn.interactable = false;
        useBtn.interactable = false;
        useTxt.text = "";
    }
    public void OnRemoveButton()
    {
        Inventory.Instance.RemoveItem(item);
    }
    public void OnUseButton()
    {
        if (item != null)
        {
            item.Use();
            ClearSlot();
        }
    }
}
