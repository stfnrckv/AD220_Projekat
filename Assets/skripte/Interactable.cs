using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 5f;

    bool isFocus = false;
    Transform player;
    Transform interactionLocation;

    int i = 0;
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }
    public void OnFocused(Transform p)
    {
        i = 0;
        isFocus = true;
        player = p;
    }
    public void OnUnFocused()
    {
        i = 0;
        isFocus = false;
        player = null;
    }
    void Start()
    {
        if (interactionLocation == null)
        {
            interactionLocation = transform;
        }
    }
    void Update()
    {
        if (isFocus)
        {
            float dis = Vector3.Distance(player.position, transform.position);
            if (dis <= radius && i == 0)
            {
                Interact();
                i++;
            }
        }
    }
}
