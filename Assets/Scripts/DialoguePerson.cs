using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DialoguePerson : MonoBehaviour, IInteractive
{
    //Array of strings for dialogue to go through?

    [SerializeField]
    protected string displayText = nameof(InteractiveObject);

    [TextArea(3, 6)]
    [SerializeField]
    private string NpcWords;

    public FirstPersonController firstPersonController;
    public GameObject DialogueCanvas;
    public Text npcDialogueText;

    public virtual string DisplayText => displayText;

    protected AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

   

    public virtual void InteractWith()
    {
        npcDialogueText.text = NpcWords;
        ShowMenu();
    }

    public void ExitMenuButtonClicked()
    {
        HideMenu();
    }

    private void ShowMenu()
    {
        DialogueCanvas.gameObject.SetActive(true);
        firstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Inventory Menu"))
            HideMenu();
    }
    private void HideMenu()
    {
        DialogueCanvas.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        firstPersonController.enabled = true;
    }
}