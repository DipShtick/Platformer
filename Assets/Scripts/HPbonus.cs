using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbonus : MonoBehaviour
{
    float bonus;
    void Awake()
    {
        bonus = 25f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<HealthManager>().AddHP(bonus);
        }

        Destroy(gameObject);
    }
}
