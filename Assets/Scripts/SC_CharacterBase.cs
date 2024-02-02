using Unity.VisualScripting;
using UnityEngine;

public enum PlayerState
{
    idle = 0,
    walking,
    running,
    jumping,
    attacking,
    crouchWalking,
    dead
}

public class SC_CharacterBase : MonoBehaviour
{
    [SerializeField] protected float runSpeedBase;    //standaard loopsnelheid (als je gewoon staat)
    [SerializeField] protected float runSpeed; // Running speed.
    [SerializeField] protected float jumpForce = 2.6f; // Jump height.

    //[SerializeField] protected SpriteRenderer spriteRenderer;

    protected Rigidbody2D body;

    protected PlayerState playerState;
    [SerializeField] protected Animator animator; // Variable for the Animator component

    protected bool canLand = false;     //voor als die geland is
    protected bool isGrounded; // Variable that will check if character is on the ground.
    [SerializeField] protected GameObject groundCheckPoint; // The object through which the isGrounded check is performed.

    [SerializeField] private float groundCheckRadius; // isGrounded check radius.
    [SerializeField] private LayerMask groundLayer; // Layer wich the character can jump on.

    [SerializeField] protected float jumpCooldownBase = 0.2f;
    [SerializeField] protected float jumpCooldown;

    protected float movementX;
    protected float runSpeedDirection;

    [SerializeField] private CapsuleCollider2D standingHitbox;


    [SerializeField] protected float attackCooldownBase;
    [SerializeField] protected float attackCooldown;
    protected bool canAttack = true;

    protected bool attacking = false;
    public bool Attacking   //zodat andere scripts bij de variabele kunnen die hier in staat
    {
        get { return attacking; }
        set { attacking = value; }
    }

    protected virtual void Start()
    {
        body = GetComponent<Rigidbody2D>(); // Setting the RigidBody2D component.

        attackCooldown = attackCooldownBase;
        jumpCooldown = jumpCooldownBase;    //een "Base" van iets is de standaard waarde; zodat deze later weer opgehaald kan worden
        runSpeed = runSpeedBase;
        playerState = PlayerState.walking;
    }

    protected virtual void Update()
    {
        if (Time.timeScale == 0)        //dat je niet op konppen kan klikken als het spel op pauze staat
        {
            return;
        }

        if (canAttack == false && attackCooldown >= 0)              //attack Cooldown timer
        {
            attackCooldown -= Time.deltaTime;
            // Debug.Log(canJump);
        }
        else if (canAttack == false)
        {
            canAttack = true;
            attackCooldown = attackCooldownBase;
            print("Can attack again");
        }
    }

    protected virtual void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.transform.position, groundCheckRadius, groundLayer); // Checking if character is on the ground.

        if (isGrounded && attacking == false) { playerState = PlayerState.walking; }

        if (movementX != 0) //zodat er niet keer 0 wordt gedaan
        {
            runSpeedDirection = movementX * runSpeed;
            body.velocity = new Vector2(runSpeedDirection, body.velocity.y);
        }

        if (movementX == 1)     //tijdelijk om te draaien; gaat later via animation waarschijnlijk
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z); // Rotating the character object to the right.
        }
        else if (movementX == -1)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z); // Rotating the character object to the left.
        }

        animator.SetInteger("PlayerState", (int)playerState);
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "hitObject")
        {

        }

    }


    protected virtual void Jump()
    {      // Jumps.
        print("Jumping");
        body.velocity = new Vector2(0, jumpForce); // Jump physics.
        //playerState = PlayerState.jumping;
        canLand = true;
        playerState = PlayerState.jumping;
    }


    protected virtual void Attack()
    {
        playerState = PlayerState.attacking;
        runSpeed = 0;
        canAttack = false;
        attacking = true;
        Invoke("StopAttack", 0.2f);
    }

    protected virtual void StopAttack()     //stopt met de attack
    {
        runSpeed = runSpeedBase;
        attacking = false;
        playerState = PlayerState.walking;
    }
}
