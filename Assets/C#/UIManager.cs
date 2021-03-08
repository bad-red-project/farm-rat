using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using VIDE_Data;

public class UIManager : MonoBehaviour
{
    public GameObject replicaContainer;
    public GameObject actionsContainer;
    public GameObject joystic;
    public TextMeshProUGUI npcReplica;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI[] textChoices;

    private int LEFT_BUTTON_KEY = 0;
    private string CLICKABLE_LAYER_KEY = "Clickable";
    private string ACTION_TAG = "DialogAction";

    private void Start()
    {
        HideReplicaContainer();
        HideActionsContainer();
    }

    private void Update()
    {
        UpdateDialogState();
    }

    private void OnDisable()
    {
        if (replicaContainer != null)
        {
            End(null);
        }
    }

    private void UpdateDialogState()
    {
        if (!getIsLeftMouseClick() || getIsDialogActionCkicked() || actionsContainer.activeSelf)
            return;

        if (VD.isActive)
        {
            VD.Next();
            return;
        }

        VIDE_Assign vide = getTargetVide();
        if (vide != null)
        {
            StartDialog(vide);
        }
    }

    private void StartDialog(VIDE_Assign videAssign)
    {
        HideJoystick();
        ShowReplicaContainer();
        VD.OnNodeChange += UpdateDialogUI;
        VD.OnEnd += End;
        VD.BeginDialogue(videAssign);
    }

    private void UpdateDialogUI(VD.NodeData dialogData)
    {
        if (dialogData.isPlayer)
        {
            ShowActionsContainer();
            RenderDialogActions(dialogData.comments);

        }
        else
        {
            HideActionsContainer();
            npcReplica.text = dialogData.comments[dialogData.commentIndex];
            npcName.text = dialogData.tag;
        }
    }

    private void RenderDialogActions(string[] comments)
    {
        for (int index = 0; index < textChoices.Length; index++)
        {
            bool hasReplica = index < comments.Length & !string.IsNullOrWhiteSpace(comments[index]);
            if (hasReplica)
            {
                textChoices[index].transform.parent.gameObject.SetActive(true);
                textChoices[index].text = comments[index];
            }
            else
            {
                textChoices[index].transform.parent.gameObject.SetActive(false);
            }
        }
    }

    private void End(VD.NodeData data)
    {
        ShowJoystick();
        HideReplicaContainer();
        HideActionsContainer();
        VD.OnNodeChange -= UpdateDialogUI;
        VD.OnEnd -= End;
        VD.EndDialogue();
    }

    public void SetPlayerChoice(int choiceIndex)
    {
        VD.nodeData.commentIndex = choiceIndex;
        if (getIsLeftMouseClick())
        {
            VD.Next();
        }
    }

    private void HideReplicaContainer()
    {
        replicaContainer.SetActive(false);
    }

    private void ShowReplicaContainer()
    {
        replicaContainer.SetActive(true);
    }

    private void HideActionsContainer()
    {
        actionsContainer.SetActive(false);
    }

    private void ShowActionsContainer()
    {
        actionsContainer.SetActive(true);
    }

    private void HideJoystick()
    {
        joystic.SetActive(false);
    }

    private void ShowJoystick()
    {
        joystic.SetActive(true);
    }

    private bool getIsLeftMouseClick()
    {
        return Input.GetMouseButtonUp(LEFT_BUTTON_KEY);
    }

    private bool getIsDialogActionCkicked()
    {
        if (!getIsLeftMouseClick())
            return false;

        if (EventSystem.current.IsPointerOverGameObject())
        {
            GameObject UIObject = EventSystem.current.currentSelectedGameObject;
            return UIObject != null && UIObject.CompareTag(ACTION_TAG);
        }

        return false;
    }

    private VIDE_Assign getTargetVide()
    {
        if (!getIsLeftMouseClick())
            return null;

        int clickableLayer = LayerMask.GetMask(CLICKABLE_LAYER_KEY);
        Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(clickedPosition, Vector2.zero, Mathf.Infinity, clickableLayer);
        if (hit.collider == null)
            return null;

        return hit.transform.gameObject.GetComponent<VIDE_Assign>();
    }
}
