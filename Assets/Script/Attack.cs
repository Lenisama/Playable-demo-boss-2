using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Collider2D attackCollider;
    public int attackDamage = 10;
    public Damageable damageable;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6 && damageable != null)
        {
           damageable.Hit(attackDamage);
           Debug.Log(collision.name + " hit for " + attackDamage);  
        }
    }
}
