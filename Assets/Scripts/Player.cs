using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float airTime = 0;
    public int airLevel = 1;
    public GameObject weapon;
    public GameObject light_obj;
    public GameObject flashLight;
    public bool onWeapon = true;
    public bool isAttack = false;
    public bool isDie = false;
    public int Money;
    public int currentHp = 0;
    public int maxHp = 0;
    public int maxAir = 100;
    public float currentAir = 0;
    public Inventory inventory;
    Animator animator;
    public float speed = 5;
    public float rotateSpeed = 5;
    CharacterController controller;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        currentAir = maxAir;
        currentHp = maxHp;
    }
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        
        StartCoroutine(Attack());
        if(Input.GetKeyDown(KeyCode.Q) && onWeapon)
        {
            light_obj.SetActive(true);
            flashLight.SetActive(true);
            weapon.SetActive(false);
            onWeapon = false;
        }
        else if(Input.GetKeyDown(KeyCode.Q) && !onWeapon)
        {
            light_obj.SetActive(false );
            flashLight.SetActive(false);
            weapon.SetActive(true);
            onWeapon = true;
        }

        AirDown();
        
    }
    
    void AirDown()
    {
        airTime += Time.deltaTime;
        if(airTime >= 1)
        {
            airTime = 0;
            currentAir -= airLevel;
        }
    }

    void Move()
    {
        float x_pos = Input.GetAxisRaw("Horizontal");
        float z_pos = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x_pos, 0,z_pos).normalized;

        controller.Move(dir * speed * Time.deltaTime);

         if( dir != Vector3.zero )
        {
            animator.SetBool("isWalk", true);
            Quaternion rot = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotateSpeed * Time.deltaTime);
            transform.rotation = rot;
        }
        else
        {
            animator.SetBool("isWalk",false);
        }

        
    }

    IEnumerator Attack()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetTrigger("isAttack");
            isAttack = true;
            yield return new WaitForSeconds(0.7f);
            isAttack = false;
        } 
    }

    public void SetHp(int damage)
    {
        if(isDie) { return; }
        currentHp -= damage;
        if(currentHp <= 0 )
        {
            currentHp = 0;
            isDie = true;
            animator.SetBool("isDie",true);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.gameObject.CompareTag("Gate_In"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            inventory.SetItem(other.gameObject.GetComponent<Item>().InventoryImg);
            
        }
    }

    public void Hp()
    {
        if(currentHp + 5 > maxHp)
        {
            currentHp = maxHp;
        }
        else
        {
            currentHp += 5;
        }
    }

    public void Air()
    {
        if (currentAir + 5 > maxAir)
        {
            currentAir = maxAir;
        }
        else
        {
            currentAir += 5;
        }
    }

    public void ItemDirection()
    {

    }

    public void Small_Speed()
    {
        Debug.Log("속도 증가");
    }

    public void Speed()
    {

    }

    public void Invisible()
    {

    }
}
