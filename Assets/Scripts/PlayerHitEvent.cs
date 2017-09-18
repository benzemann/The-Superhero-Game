using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitEvent : Triggable
{
    
    public override void Trigger()
    {
        Debug.LogWarning("This event needs to be called with the gameobject parameter");
    }

    public override void Trigger(GameObject go)
    {
        // Get the parent who should be the player object
        var player = transform.parent.gameObject;
        // Check if player is moving
        if (player != null && 
            player.GetComponent<Rigidbody2D>().velocity.magnitude > 0f &&
            go != null &&
            go.layer == LayerMask.NameToLayer("Enemies"))
        {
            // Perform attack event here
            go.GetComponent<Health>().Damage(100f);
        }
    }
}
