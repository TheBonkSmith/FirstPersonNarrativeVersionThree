using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class InventoryMenuItemToggle : MonoBehaviour
{
    [Tooltip("Image used for items icon")]
    [SerializeField]
    private Image iconImage;

    public static event Action<InventoryObjects> InventoyryMenuItemSelected;
    private InventoryObjects associatedInventoryObject;

    public InventoryObjects AssociatedInvenotryObject
    {
        get { return associatedInventoryObject; }
        set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;
        }
    }

    public void InventoryMenuItemWasToggled(bool isOn)
    {
        if (isOn)
            InventoyryMenuItemSelected?.Invoke(AssociatedInvenotryObject);

        
    }
    private void Awake()
    {
        Toggle toggle = GetComponent<Toggle>();
        ToggleGroup toggleGroup = GetComponentInParent<ToggleGroup>();
        toggle.group = toggleGroup;
    }

}