using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    const float MaxHP = 100f;
    public float HP;
    void Awake()
    {
        HP = MaxHP;
        _anim = GetComponent<Animator>();
    }

    Animator _anim;
    void Die()
    {
        _anim.SetBool("Dead", true);
        GetComponent<CharacterController2D>().enabled = false;
    }

    public Slider sld;
    public void TakeDamage(float amount)
    {
        HP -= amount;

        if(HP <= 0)
        {
            HP = 0;
            Die();
        }
        
        sld.value = HP / MaxHP;
    }

    public void AddHP(float amount)
    {
        if(HP != MaxHP)
        {
            HP += amount;
        }
    }
}
