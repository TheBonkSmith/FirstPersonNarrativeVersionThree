using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObjects : InteractiveObject
{
    //whatcha see in the menu
    [SerializeField]
    private string objectName = nameof(InventoryObjects);

    [Tooltip("Text displays on selected")]
    [TextArea(3, 8)]
    [SerializeField]
    private string description;

    [Tooltip("icon of item")]
    [SerializeField]
    private Sprite icon;


    public Sprite Icon => icon;
    public string ObjectName => objectName;
    public string Description => description;


    private new Renderer renderer;
    private new Collider collider;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }
    public InventoryObjects()
    {
        displayText = $"Take {objectName}";
    }


    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InvetoryObjectsGroup.Add(this);
        renderer.enabled = false;
        collider.enabled = false;
        InventoryMenu.Instance.AddItemToMenu(this);
        
    }
}
