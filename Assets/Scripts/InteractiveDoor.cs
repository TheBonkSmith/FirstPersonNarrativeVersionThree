using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractiveDoor : InteractiveObject
{
    //making a key locks the door
    [SerializeField]
    private InventoryObjects key;

    [SerializeField]
    private InventoryObjects key1;

    [SerializeField]
    private InventoryObjects key2;

    [SerializeField]
    private InventoryObjects key3;

    private bool isLocked;

    [Tooltip("text that displays when door is locked")]
    [SerializeField]
    private string lockedDisplayText = "Locked";

    [SerializeField]
    private AudioClip lockedAudioClip;


    [SerializeField]
    private AudioClip openAudioClip;

    private bool HasKey => PlayerInventory.InvetoryObjectsGroup.Contains(key) && PlayerInventory.InvetoryObjectsGroup.Contains(key1) && PlayerInventory.InvetoryObjectsGroup.Contains(key2) && PlayerInventory.InvetoryObjectsGroup.Contains(key3);
    public override string DisplayText
    {
        get
        {
            string toReturn;
            if (isLocked)
            {
                toReturn = HasKey ? $"USE THE BEANS!!" : lockedDisplayText;
            }
            else
            {
                toReturn = base.DisplayText;
            }

            return toReturn;
        }
    }
    private bool isOpen = false;
    private Animator animator;

    public InteractiveDoor()
    {
        displayText = nameof(InteractiveDoor);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        InitializedIsLocked();
    }

    private void InitializedIsLocked()
    {
        if (key != null)
            isLocked = true;
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if(isLocked && !HasKey)
            {
                audioSource.clip = lockedAudioClip;
            }
            else
            {
                audioSource.clip = openAudioClip;
                animator.SetTrigger("open sesame");
                displayText = string.Empty;
                isLocked = false;
            }
            base.InteractWith();
        }

    }
}
