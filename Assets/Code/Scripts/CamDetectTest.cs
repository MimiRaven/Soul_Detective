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

	public bool EnemyInRange;

	public AudioSource audioSource;
	public AudioClip bossMusic;

	void Start()
	{
        //StartCoroutine("FindTargetsWithDelay", .2f);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bossMusic;
        audioSource.Stop();
    }
	void Update()
	{
		FindVisibleTargets();
		//EnemyInRange = false;
	}



	void FindVisibleTargets()
	{
		visibleTargets.Clear();
		Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
		EnemyInRange = false;

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


					visibleTargets.Add(target);

					EnemyInRange = true;
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
