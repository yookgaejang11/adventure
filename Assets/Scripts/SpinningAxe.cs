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
        rotateSpeed = Random.Range(1, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Player.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
