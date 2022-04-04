using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionItem : Interactable
{
    public Item item;
    public bool State = false;
    public override void Interact()
    {
        Action();
    }
    void Action()
    {
        Debug.Log("Using " + item.name + ": " + State);
        State = !State;
    }
}
