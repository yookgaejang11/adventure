using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Animator animator;
    public float speed = 5;
    public float rotateSpeed = 5;
    CharacterController controller;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.gameObject.CompareTag("Gate_In"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}
