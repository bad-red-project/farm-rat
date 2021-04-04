using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UIManager uiManager;

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        CheckDialogTriggerEnter(collider);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        CheckDialogTriggerExit(collider);
    }

    private void CheckDialogTriggerEnter(Collider2D collider)
    {
        VIDE_Assign vide = collider.gameObject.GetComponent<VIDE_Assign>();
        if (vide != null)
        {
            uiManager.EnterDialogTrigger(vide);
        }
    }

    private void CheckDialogTriggerExit(Collider2D collider)
    {
        VIDE_Assign vide = collider.gameObject.GetComponent<VIDE_Assign>();
        if (vide != null)
        {
            uiManager.ExitDialogTrigger();
        }
    }
}
