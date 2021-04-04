using UnityEngine;

public class Player : MonoBehaviour
{
    public UIManager uiManager;
    public string startPointName;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        CheckDialogTriggerEnter(collider);
        CheckSceneLoaderTriggerEnter(collider);
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

    private void CheckSceneLoaderTriggerEnter(Collider2D collider)
    {
        LoadNewScene sceneLoader = collider.gameObject.GetComponent<LoadNewScene>();
        if (sceneLoader != null)
        {
            startPointName = sceneLoader.newLevelStartPointName;
        }
    }
}
