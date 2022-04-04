using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(PlayerMover))]
public class PlayerController : MonoBehaviour
{
    public Interactable currentFocus;// = new Interactable();
    public GameObject inventoryPanel;
    bool invShow = false;
    public TMP_Text instructionTxt;

    public LayerMask moveMask;
    Camera cam;
    PlayerMover mover;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        mover = GetComponent<PlayerMover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 50f, moveMask))
            {
                ClearFocus();
                mover.MoveToPoint(hitInfo.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 200f))
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);

                }
            }
        }

        if (Input.GetKeyDown("i"))
        {
            instructionTxt.text = "";
            invShow = !invShow;
            inventoryPanel.SetActive(invShow);
        }
    }
    void SetFocus(Interactable newFocus)
    {
        if (newFocus != currentFocus)
        {
            if (currentFocus != null)
            {
                currentFocus.OnUnFocused();
            }
            currentFocus = newFocus;
            mover.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }
    void ClearFocus()
    {
        if (currentFocus != null)
        {
            currentFocus.OnUnFocused();
        }
        currentFocus = null;
        mover.ClearTarget();
    }
}
