using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScriptvoorDamageObject : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        m_Rigidbody.rotation += 1.5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = startPosition;
    }
}
