using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public int damage = 3;
    public bool isAttack = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && !isAttack)
        {
            isAttack = true;
            collision.gameObject.GetComponent<Enemy>().OnDamage(damage);
            isAttack = false;
        }
    }
}
