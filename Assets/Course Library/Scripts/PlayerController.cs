using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Animator anim;
	private Rigidbody playerRB; 
	public float forSpeed;
	private GameObject focalPoint;
	private Renderer playerRend;
	public bool hasPowerUp = false;
	private float powerUpKick = 10.0f;
	public GameObject powerUpRing;

    void Start()
    {
		anim = GetComponent<Animator>();
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
		powerUpRing.transform.position = transform.position;
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("PowerUp"))
		{
			hasPowerUp = true;
			anim.SetBool("HasPowerUp", true);
			powerUpRing.SetActive(true);
			Destroy(other.gameObject);
			StartCoroutine(PowerUpCountdown());
		}
	}

	private IEnumerator PowerUpCountdown()
	{
		yield return new WaitForSeconds(5.0f);
		hasPowerUp = false;
		anim.SetBool("HasPowerUp", false);
		powerUpRing.SetActive(false);
	}

	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Player collided with " + collision.gameObject + " with powerUp set to " + hasPowerUp);
		if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
		{
			Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
			Vector3 dir = collision.gameObject.transform.position - transform.position;
			enemyRB.AddForce(dir * powerUpKick, ForceMode.Impulse);
		}
	}
}
