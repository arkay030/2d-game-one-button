using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_JumpMode : SC_CharacterBase
{
    private bool canJump = true;

    protected override void Start()
    {
        base.Start();
        movementX = 1;
        attacking = false;
    }

    protected override void Update()
    {
        base.Update();

        if (Input.anyKeyDown && isGrounded && canJump)
        {
            canJump = false;
            Jump();
        }

        if (canJump == false && jumpCooldown >= 0)              //jump Cooldown timer
        {
            jumpCooldown -= Time.deltaTime;
            // Debug.Log(canJump);
        }
        else if (canJump == false)
        {
            canJump = true;
            jumpCooldown = jumpCooldownBase;
            print("Can attack again");
        }

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        print(isGrounded);
    }
}
