using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterDamage : MonoBehaviour
    
{
   
    public PlayerHealth health;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private SC_CharacterBase characterScript;
    Scene currentScene = SceneManager.GetActiveScene();
    public string currentLevel;

    private void Start()
    {
        characterScript = FindObjectOfType<SC_CharacterBase>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") ;
        {
        /*    PlayerHealth.TakeDamage(damage);*/
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(characterScript != null)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(characterScript.Attacking == true)
        {
            Destroy(gameObject);

        }
        else if (collision.isTrigger == false)
        {
            SceneManager.LoadScene(0); 
        }
    }
    public void FixedUpdate()
    {
        body.velocity = new Vector2(speed, body.velocity.y);
        
    }
    
}
