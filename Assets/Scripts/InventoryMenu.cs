using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuItemTogglePrefab;

    [SerializeField]
    [Tooltip("content of the scroll view for the list of inventory items")]
    private Transform inventoryListContentArea;

    [SerializeField]
    private Text itemLabelText;

    [SerializeField]
    private Text descriptionAreaText;

    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private FirstPersonController firstPersonController;
    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("There is currently no Inventory Menu instance, apply script to game object");
            return instance;
        }
        private set { instance = value; }
    }

    private bool isVisible => canvasGroup.alpha > 0;

    public void ExitmenuButtonClicked()
    {
        HideMenu();
    }

    public void AddItemToMenu(InventoryObjects inventoryObjectToAdd)
    {
        GameObject clone = Instantiate(inventoryMenuItemTogglePrefab, inventoryListContentArea);
        InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
        toggle.AssociatedInvenotryObject = inventoryObjectToAdd; 

    }

    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        firstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        firstPersonController.enabled = true;
    }

    private void OnInventoryMenuItemSelected(InventoryObjects inventoryObjectThatWasSelected)
    {
        itemLabelText.text = inventoryObjectThatWasSelected.ObjectName;
        descriptionAreaText.text = inventoryObjectThatWasSelected.Description;
    }

    private void OnEnable()
    {
        InventoryMenuItemToggle.InventoyryMenuItemSelected += OnInventoryMenuItemSelected;
    }

    private void OnDisable()
    {
        InventoryMenuItemToggle.InventoyryMenuItemSelected -= OnInventoryMenuItemSelected;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Inventory Menu"))
            if (isVisible)
                HideMenu();
            else
                ShowMenu();
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("There is already an instance of this inventory menu.");
        canvasGroup = GetComponent<CanvasGroup>();
        firstPersonController = FindObjectOfType<FirstPersonController>();
    }

    private void Start()
    {
        HideMenu();
    }
}
