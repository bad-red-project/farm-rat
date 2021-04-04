using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using VIDE_Data;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject replicaContainer;
    public GameObject actionsContainer;
    public GameObject joystick;
    public GameObject dialogAction;
    public TextMeshProUGUI npcReplica;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI[] textChoices;

    private string interactedNpcName;
    private string targetNpcName;

    private int LEFT_BUTTON_KEY = 0;
    private string CLICKABLE_LAYER_KEY = "Clickable";
    private string ACTION_TAG = "DialogAction";

    private void Start()
    {
        HideReplicaContainer();
        HideActionsContainer();

        DontDestroyOnLoad(transform.gameObject);
    }

    private void Update()
    {
        UpdateDialogState();
    }

    private void OnDisable()
    {
        if (replicaContainer != null)
        {
            EndDialog(null);
        }
    }

    private void UpdateDialogState()
    {
        bool isPlayerActionStage = getIsDialogActionCkicked() || actionsContainer.activeSelf;
        if (!getIsLeftMouseClick() || isPlayerActionStage)
            return;

        if (VD.isActive)
        {
            VD.Next();
            return;
        }

        VIDE_Assign vide = getTargetVide();
        if (vide == null)
            return;

        if (!GetIsPlayerInRange())
        {
            GoToDialogTriggerZone();
            return;
        }

        StartDialog(vide);
    }

    private void StartDialog(VIDE_Assign videAssign)
    {
        HideJoystick();
        HideDialogAction();
        ShowReplicaContainer();
        VD.OnNodeChange += UpdateDialogUI;
        VD.OnEnd += EndDialog;
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

    private void EndDialog(VD.NodeData data)
    {
        ShowJoystick();
        ShowDialogAction();
        HideReplicaContainer();
        HideActionsContainer();
        VD.OnNodeChange -= UpdateDialogUI;
        VD.OnEnd -= EndDialog;
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
        joystick.GetComponent<FixedJoystick>().SetInitialCoordinates();
        joystick.SetActive(false);
    }

    private void ShowJoystick()
    {
        joystick.SetActive(true);
    }

    private void HideDialogAction()
    {
        dialogAction.SetActive(false);
    }

    private void ShowDialogAction()
    {
        dialogAction.SetActive(true);
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

        RaycastHit2D hit = GetWorldPointerHit();
        if (hit.collider == null)
            return null;

        return hit.transform.gameObject.GetComponent<VIDE_Assign>();
    }

    private string GetTargetName()
    {
        if (!getIsLeftMouseClick())
            return "";

        RaycastHit2D hit = GetWorldPointerHit();
        if (hit.collider == null)
            return "";

        return hit.transform.gameObject.name;
    }

    private bool GetIsPlayerInRange()
    {
        string targetName = GetTargetName();
        return targetName == interactedNpcName;
    }

    private void GoToDialogTriggerZone()
    {
        targetNpcName = GetTargetName();

        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player.GetComponent<MovementControl>().MoveTo(target);
    }

    private RaycastHit2D GetWorldPointerHit()
    {
        int clickableLayer = LayerMask.GetMask(CLICKABLE_LAYER_KEY);
        Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        return Physics2D.Raycast(clickedPosition, Vector2.zero, Mathf.Infinity, clickableLayer);
    }

    public void EnterDialogTrigger(VIDE_Assign vide)
    {
        ShowDialogAction();
        dialogAction.GetComponent<MultiImageButton>().onClick.AddListener(delegate { StartDialog(vide); });
        interactedNpcName = vide.gameObject.name;

        bool isMovementTarger = interactedNpcName == targetNpcName;
        bool isAutoMove = player.GetComponent<MovementControl>().isAutoMove;
        if (isMovementTarger && isAutoMove)
        {
            StopMovementToDialog();
            StartDialog(vide);
        }
    }

    public void ExitDialogTrigger()
    {
        HideDialogAction();
        dialogAction.GetComponent<MultiImageButton>().onClick.RemoveAllListeners();
        interactedNpcName = "";
    }

    public void StopMovementToDialog()
    {
        targetNpcName = "";
    }
}
