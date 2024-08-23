using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 10;
    
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.layer == 6)
        {
           Damageable dam = collider2D.gameObject.GetComponent<Damageable>();
           dam.Hit(attackDamage);
           Debug.Log(collider2D.name + " hit for " + attackDamage);  
        } 
    }
}
