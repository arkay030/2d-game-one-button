using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_JumpMode : SC_CharacterBase
{
    private bool canJump = true;

    protected override void Start()
    {
        base.Start();
        runSpeedBase = 2.6f;
        movementX = 1;
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            canJump = false;
            Jump();
        }

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        print(isGrounded);
    }
}
