using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody playerRB; 
	public float forSpeed;
	private GameObject focalPoint;
	private Renderer playerRend;

    void Start()
    {
		playerRB = GetComponent<Rigidbody>();
		playerRend = GetComponent<Renderer>();
		focalPoint = GameObject.Find("Focal Point");
    }
		

    void Update()
    {
		float verticalInput = Input.GetAxis("Vertical");
		playerRB.AddForce(focalPoint.transform.forward * verticalInput * forSpeed);
		if(verticalInput > 0)
		{
			playerRend.material.color = new Color(1 - verticalInput,1,1 - verticalInput);
		}
		else
		{
			playerRend.material.color = new Color(1 + verticalInput,1,1 + verticalInput);
		}
    }
}
