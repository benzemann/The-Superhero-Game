using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetFinder))]
public class RotateTowardsTarget : MonoBehaviour {

    TargetFinder tf;

    [SerializeField]
    float maxRotation;
    [SerializeField]
    float rotationSpeed;

    // Use this for initialization
    void Start () {
        tf = GetComponent<TargetFinder>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        var target = tf.Target;
        if (target != null)
        {
            var dir = target.transform.position - transform.position;
            var angleDiff = Vector2.SignedAngle(transform.up, dir);
            if (angleDiff < 0f)
            {
                angleDiff = Mathf.Max(angleDiff, -maxRotation);
            }
            else
            {
                angleDiff = Mathf.Min(angleDiff, maxRotation);
            }
            this.transform.Rotate(Vector3.forward,((angleDiff)) * rotationSpeed * Time.deltaTime);
        }
    }
}
