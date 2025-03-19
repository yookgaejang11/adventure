using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningAxe : MonoBehaviour
{
    public GameObject Player;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Player.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
