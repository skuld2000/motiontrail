using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
	public Animator animator;

	private void Update()
	{
		bool isRun = false;

		if (Input.GetKey("left"))
		{
			transform.position = new Vector3(transform.position.x + 5.0f * Time.deltaTime, transform.position.y, transform.position.z);
			isRun = true;
		}
		else if (Input.GetKey("right"))
		{
			transform.position = new Vector3(transform.position.x - 5.0f * Time.deltaTime, transform.position.y, transform.position.z);
			isRun = true;
		}

		if (Input.GetKey("up"))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5.0f * Time.deltaTime);
			isRun = true;
		}
		else if (Input.GetKey("down"))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5.0f * Time.deltaTime);
			isRun = true;
		}

		animator.SetBool("isRun", isRun);

		if (Input.GetKeyDown("1"))
		{
		}
		else if (Input.GetKeyDown("2"))
		{
		}
		
	}
}
