using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(TargetFinder))]
public class ChaseTarget : MonoBehaviour {

    TargetFinder tf;

    [SerializeField]
    float distanceToTarget;
    [SerializeField]
    float speed;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float slowDownModifier;
    [SerializeField]
    float otherEnemiesAvoidance;
    [SerializeField]
    float alliesAvoidance;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<TargetFinder>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        var target = tf.Target;
        var force = new Vector3();
        if(target != null)
        {
            // Check if target is too far away
            var disToTarget = Vector2.Distance(this.transform.position, target.transform.position);
            if(disToTarget > distanceToTarget)
            {
                // Calculate vector towards target
                force = target.transform.position - this.transform.position;
                
            } else if(rb.velocity.magnitude > 0f)
            {
                // Slow down
                rb.velocity = rb.velocity * slowDownModifier;
                if(rb.velocity.magnitude < 0.05f)
                {
                    rb.velocity = Vector2.zero;
                }
            }
        }
        // Calculate local avoidance of other enemies
        var enemies = ObjectManager.Instance.AllEnemies;
        for (int i = 0; i < enemies.Length; i++)
        {
            var dis = Vector2.Distance(this.transform.position, enemies[i].transform.position);
            if (enemies[i] != this.gameObject && dis < otherEnemiesAvoidance)
            {
                force += (this.transform.position - enemies[i].transform.position).normalized;
            }
        }
        // Calculate avoidance to all allies
        var allies = ObjectManager.Instance.AllAllies;
        for (int i = 0; i < allies.Length; i++)
        {
            var dis = Vector2.Distance(this.transform.position, allies[i].transform.position);
            if (allies[i] != this.gameObject && dis < alliesAvoidance)
            {
                force += (this.transform.position - allies[i].transform.position).normalized;
            }
        }
        rb.AddForce((force.normalized * speed) * Time.deltaTime);
        // Limit velocity to max speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
