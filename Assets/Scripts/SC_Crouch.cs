using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Crouch : SC_CharacterBase
{
    [SerializeField] private bool crouched = false;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private CapsuleCollider2D standardCollider;
    [SerializeField] private CapsuleCollider2D crouchCollider;
    protected override void Start()
    {
        base.Start();
        movementX = 1;
    }
    protected override void Update()
    {
        base.Update();
        if (Input.anyKeyDown && !crouched)
        {
            crouched = true;
            standardCollider.enabled = false;
            crouchCollider.enabled = true;
        }
        if (crouched)
        {
            if (runSpeed > crouchSpeed)
            {
                playerState = PlayerState.crouchWalking;
                runSpeed -= Time.deltaTime;
            }
            else
            {
                playerState = PlayerState.walking;
                runSpeed = runSpeedBase;
                crouched = false;
                crouchCollider.enabled = false;
                standardCollider.enabled = true;
            }
        }
    }
}