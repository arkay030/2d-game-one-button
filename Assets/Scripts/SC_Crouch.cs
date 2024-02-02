using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Crouch : SC_CharacterBase
{
    [SerializeField] private bool crouched = false;
    [SerializeField] private float crouchSpeed;
    protected override void Start()
    {
        base.Start();
        runSpeedBase = 2.6f;
        movementX = 1;
    }
    protected override void Update()
    {
        base.Update();
        if (Input.anyKeyDown && !crouched)
        {
            crouched = true;
        }
        if (crouched)
        {
            if (runSpeed > crouchSpeed)
            {
                runSpeed--;
            }
            else
            {
                runSpeed = runSpeedBase;
                crouched = false;
            }
        }
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}