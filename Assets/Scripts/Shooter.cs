using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TargetFinder))]
public class Shooter : MonoBehaviour {

    TargetFinder tf;

    [SerializeField]
    float distanceToTarget;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float delay;

    float timeAtLastShot;
	// Use this for initialization
	void Start () {
        tf = GetComponent<TargetFinder>();
	}
	
	// Update is called once per frame
	void Update () {
        var target = tf.Target;
        if (target == null)
            return;
        if (Time.time - timeAtLastShot < delay)
            return;
        if (Vector2.Distance(this.transform.position, target.transform.position) > distanceToTarget)
            return;
        var vecToTarget = target.transform.position - this.transform.position;
        var hit = Physics2D.Raycast(this.transform.position + (vecToTarget.normalized * 4f), vecToTarget);
        if(hit.transform != null && hit.transform.gameObject == target)
        {
            var bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation) as GameObject;
            timeAtLastShot = Time.time;
        }
	}
}
