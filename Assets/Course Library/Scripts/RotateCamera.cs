using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
	public float rotSpeed;

    void Start()
    {
        
    }

    
    void Update()
    {
		float horizontalInput = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.up, horizontalInput * rotSpeed);
    }
}
