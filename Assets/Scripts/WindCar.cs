using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCar : MonoBehaviour
{
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = Random.Range(300f,350f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,rotateSpeed) * Time.deltaTime);
    }
}
