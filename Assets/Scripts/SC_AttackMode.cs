using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AttackMode : SC_CharacterBase
{
    [SerializeField] private BoxCollider2D attackHitTrigger;

    protected override void Start()
    {
        base.Start();
        runSpeedBase = 2.6f;
        movementX = 1;
    }

    protected override void Update()
    {
        base.Update();

        if (Input.anyKeyDown && canAttack)
        {
            Attack();
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
