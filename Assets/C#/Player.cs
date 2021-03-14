using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UIManager uiManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckDialogTriggerEnter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckDialogTriggerExit(collision);
    }

    private void CheckDialogTriggerEnter(Collider2D collision)
    {
        VIDE_Assign vide = collision.gameObject.GetComponent<VIDE_Assign>();
        if (vide != null)
        {
            uiManager.EnterDialogTrigger(vide);
        }
    }

    private void CheckDialogTriggerExit(Collider2D collision)
    {
        VIDE_Assign vide = collision.gameObject.GetComponent<VIDE_Assign>();
        if (vide != null)
        {
            uiManager.ExitDialogTrigger();
        }
    }
}
