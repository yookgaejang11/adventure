using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{

    bool isAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
        if(isAttack)
        {
            isAttack = false;
            GameObject.Find("Player").GetComponent<Player>().SetHp(3);
        }
        yield return new WaitForSeconds(0.1f);
        isAttack = true;
    }
}
