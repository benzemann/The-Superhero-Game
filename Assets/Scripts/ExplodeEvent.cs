using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEvent : Triggable {
    [SerializeField]
    GameObject explosionPrefab;
    [SerializeField]
    bool destroyThisGameobject;

    public override void Trigger()
    {
        if(explosionPrefab != null)
        {
            var explosion = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity) as GameObject;
        }
        if (destroyThisGameobject)
        {
            Destroy(this.gameObject);
        }
    }

    public override void Trigger(GameObject go)
    {
        // Does not use input gameobject
        Trigger();
    }

}
