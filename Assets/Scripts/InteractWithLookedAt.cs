using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithLookedAt : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    void Update()
    {
        if(Input.GetButtonDown("Interact") && lookedAtInteractive != null)
        {
            Debug.Log("YUHHHHHHH");
            lookedAtInteractive.InteractWith();
        }
    }


    /// <summary>
    /// EventHhandler for DetectLookedAtInteractive.LookedAtInteractiveChanged
    /// </summary>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
    }

    #region Event subscription / unsubscription
    private void OnEnable()
    {
        DetectInteraction.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }
    private void OnDisable()
    {
        DetectInteraction.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion
}
