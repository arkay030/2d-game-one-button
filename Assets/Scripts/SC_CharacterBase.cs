using UnityEngine;

public enum PlayerState
{
    idle = 0,
    walking,
    running,
    jumping,
    idleCrouch,
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

    protected bool canLand = false;     //voor als die geland is
    protected bool isGrounded; // Variable that will check if character is on the ground.
    [SerializeField] protected GameObject groundCheckPoint; // The object through which the isGrounded check is performed.

    [SerializeField] private float groundCheckRadius; // isGrounded check radius.
    [SerializeField] private LayerMask groundLayer; // Layer wich the character can jump on.

    [SerializeField] protected float jumpCoolDownBase = 0.2f;
    [SerializeField] protected float jumpCoolDown;

    protected float movementX;
    protected float runSpeedDirection;

    [SerializeField] private CapsuleCollider2D standingHitbox;

    protected virtual void Start()
    {
        body = GetComponent<Rigidbody2D>(); // Setting the RigidBody2D component.

        jumpCoolDown = jumpCoolDownBase;    //een "Base" van iets is de standaard waarde; zodat deze later weer opgehaald kan worden
        runSpeed = runSpeedBase;
    }

    protected virtual void Update()
    {
        if (Time.timeScale == 0)        //dat je niet op konppen kan klikken als het spel op pauze staat
        {
            return;
        }


    }

    protected virtual void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.transform.position, groundCheckRadius, groundLayer); // Checking if character is on the ground.

        if (movementX != 0) //zodat er niet keer 0 wordt gedaan
        {
            runSpeedDirection = movementX * runSpeed;
            body.velocity = new Vector2(runSpeedDirection, body.velocity.y);
        }

        if (movementX == 1)     //tijdelijk om te draaien; gaat later via animation waarschijnlijk
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z); // Rotating the character object to the right.
        }
        else if (movementX == -1)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z); // Rotating the character object to the left.
        }
    }


    protected virtual void Jump()
    {      // Jumps.
        print("Jumping");
        body.velocity = new Vector2(0, jumpForce); // Jump physics.
        //playerState = PlayerState.jumping;
        canLand = true;
    }
}
