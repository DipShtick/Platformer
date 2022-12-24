using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LethalScript : MonoBehaviour
{
    // Start is called before the first frame update
    float damage;
    bool push;
    public float force = 300f;

    void Awake()
    {
        damage = 25f;
        push = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<HealthManager>().TakeDamage(damage);

            if(push)
            {
                Vector2 _pushDir = col.transform.position - transform.position;
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(_pushDir.normalized * force);    
            }
        }
    }

}
