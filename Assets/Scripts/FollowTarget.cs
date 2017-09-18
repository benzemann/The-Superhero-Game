using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(TargetFinder))]
public class FollowTarget : MonoBehaviour {

    TargetFinder tf;

    [SerializeField]
    float maxRotation;
    [SerializeField]
    float speed;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<TargetFinder>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        var target = tf.Target;
	    if(target != null)
        {
            var dir = target.transform.position - transform.position;
            var angleDiff = Vector2.SignedAngle(transform.up, dir);
            if(angleDiff < 0f)
            {
                angleDiff = Mathf.Max(angleDiff, -maxRotation);
            } else
            {
                angleDiff = Mathf.Min(angleDiff, maxRotation);
            }
            rb.MoveRotation((rb.rotation + (angleDiff)));
        }

        rb.velocity = (transform.up * Time.deltaTime * speed);
	}
}
