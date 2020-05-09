using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInteraction : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interaction")]
    [SerializeField]
    private Transform rayCastOrigin;

    [Tooltip("Search range for interaction")]
    [SerializeField]
    private float maxRange = 5.0f;

    public RaycastHit hitInfo;

    ///Summary
    /// Event raised when player looks at a different IInteractive
    ///Summary
    public static event Action<IInteractive> LookedAtInteractiveChanged;
    
    public IInteractive LookedAtInteractive
    {
        get { return lookedAtInteractive; }
        private set 
        {
            bool isInteractiveChanged = value != lookedAtInteractive;
            if (isInteractiveChanged)
            {
                lookedAtInteractive = value;
                LookedAtInteractiveChanged?.Invoke(lookedAtInteractive);
            }
        }
    }

    private IInteractive lookedAtInteractive;

    private void FixedUpdate()
    {
        LookedAtInteractive = GetLookedAtInteractive();
    }

    /// <summary>
    /// Raycasts forward from the camera to look to IInteractives
    /// </summary>
    /// <returns>The first Interactive Detected, or null</returns>
    private IInteractive GetLookedAtInteractive()
    {
        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.forward * maxRange, Color.red);
      //  RaycastHit hitInfo;
        bool objectWasDetected = Physics.Raycast(rayCastOrigin.position, rayCastOrigin.forward, out hitInfo, maxRange);

        IInteractive interactive = null;

        LookedAtInteractive = interactive;

        if (objectWasDetected)
        {
            //Debug.Log($"Player is looking at: { hitInfo.collider.gameObject.name}");
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        return interactive;
    }
}
