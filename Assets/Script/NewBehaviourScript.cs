using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	Vector3 pos, mp, direction;
	public float speed = 3f;

	// Start is called before the first frame update
	void Start()
	{


	}

	// Update is called once per frame
	void FixedUpdate()
	{
		transform.position = FindObjectOfType<Paddle>().transform.position;
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

	}
}
