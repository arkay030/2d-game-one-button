using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
    
{
    public int damage;
    public PlayerHealth health;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float speed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") ;
        {
        /*    PlayerHealth.TakeDamage(damage);*/
        }
    }
    public void FixedUpdate()
    {
        body.velocity = new Vector2(speed, body.velocity.y);
    }
}
