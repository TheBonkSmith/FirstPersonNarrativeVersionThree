using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushableCrate : InteractiveObject
{
    private bool isPushed = false;
    private Animator animator;
    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }
    public override void InteractWith()
    {
        if (!isPushed)
        {
            animator.SetTrigger("push sesame");
            displayText = "";
        }
    }

}
