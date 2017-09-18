using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    [SerializeField]
    float damage;
    [SerializeField]
    float radius;

	// Use this for initialization
	void Start () {
        StartCoroutine(Animate());
    }

    void Explode()
    {
        var collidersInside = Physics2D.OverlapCircleAll(this.transform.position, radius);
        for (int i = 0; i < collidersInside.Length; i++)
        {
            var healthComponent = collidersInside[i].GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.Damage(damage);
            }
        }
        Destroy(this.gameObject);
    }

    IEnumerator Animate()
    {
        yield return new WaitForSeconds(0.1f);
        Explode();
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
