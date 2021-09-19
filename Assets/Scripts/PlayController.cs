using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
	public Animator animator;
	SMRMotionTrailCreator trailCreator;

	private void Start()
	{
		trailCreator = GetComponent<SMRMotionTrailCreator>();
		trailCreator.Setup(transform.GetComponentInChildren<SkinnedMeshRenderer>(), 8, 0.5f);
	}

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
			trailCreator.Create(true);
		}
		else if (Input.GetKeyDown("2"))
		{
			trailCreator.Create(false);


		}
		
	}
}
