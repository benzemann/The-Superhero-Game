using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControls : MonoBehaviour {

    Rigidbody2D rb;

    [SerializeField]
    float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        /* MOUSE CONTROLS
        // Calculate the direction to the mouse in worldcoords
        var mousePos = Input.mousePosition;
        var mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
        var dir = new Vector2(mousePosWorld.x, mousePosWorld.y) - 
            new Vector2(this.transform.position.x, this.transform.position.y);
            if(dir.magnitude > 1f)
        {
            // Move player and rotate towards mouse
            rb.velocity = dir * Time.deltaTime * 100f;
            transform.up = new Vector3(mousePosWorld.x, mousePosWorld.y, 0f) 
                - new Vector3(transform.position.x, transform.position.y, 0f);
        } else
        {
            // Reset rotation and stop moving
            rb.velocity = Vector2.zero;
            transform.rotation = Quaternion.identity;
        }
        */
        var dir = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
        rb.velocity = (dir * speed * Time.deltaTime);
        transform.up = (new Vector3(transform.position.x, transform.position.y, 0f) + 
            new Vector3(dir.normalized.x, dir.normalized.y, 0f)) - 
            new Vector3(transform.position.x, transform.position.y, 0f);
        // Move the camera with the player
        Camera.main.transform.position = 
            new Vector3( 
                transform.position.x, 
                transform.position.y, 
                Camera.main.transform.position.z
                );

    }
}
