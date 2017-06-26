using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Vector3 MoveBy;
	public float moveSpeed;
	Vector3 pointA;
	Vector3 pointB;

	Vector3 target;
	Vector3 myPos;

	bool going_to_a = false;

	public float delayTime;
	private float waitTime;

	void Start()
	{
		pointA = transform.position;
		pointB = pointA + MoveBy;
	}

	void Update()
	{
		waitTime -= Time.deltaTime;
		if(waitTime > 0)
			return;

		if (going_to_a)
			target = pointA;
		else
			target = pointB;
		
		myPos = transform.position;
		Vector3 direction = target - myPos;
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
		if (isArrived(transform.position, target))
		{
			going_to_a = !going_to_a;
			waitTime = delayTime;
		}
		transform.Translate(direction.normalized * Time.deltaTime * moveSpeed);

	}

	bool isArrived(Vector3 pos, Vector3 target)
	{
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance(pos, target) < 0.02f;
	}
}
