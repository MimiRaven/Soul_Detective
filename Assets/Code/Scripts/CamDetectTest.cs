using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDetectTest : MonoBehaviour
{
	public float viewRadius;
	[Range(0, 360)]
	public float viewAngle;
	//public int speed = 5;

	public LayerMask targetMask;
	public LayerMask obstacleMask;

	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();

	void Start()
	{
		StartCoroutine("FindTargetsWithDelay", .2f);
	}


	IEnumerator FindTargetsWithDelay(float delay)
	{
		while (true)
		{
			yield return new WaitForSeconds(delay);
			FindVisibleTargets();
		}
	}

	void FindVisibleTargets()
	{
		visibleTargets.Clear();
		Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

		for (int i = 0; i < targetsInViewRadius.Length; i++)
		{
			Transform target = targetsInViewRadius[i].transform;
			Vector3 dirToTarget = (target.position - transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(dirToTarget);
			if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
			{
				float dstToTarget = Vector3.Distance(transform.position, target.position);
				if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
				{

					//Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);
					//var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
					//transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
					visibleTargets.Add(target);
					transform.LookAt(target);
				}
			}
		}
	}


	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
	{
		if (!angleIsGlobal)
		{
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}
}
