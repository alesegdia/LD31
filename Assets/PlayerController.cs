using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject controlled;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKey(KeyCode.Space) )
        {
            controlled.rigidbody2D.AddForce(new Vector2(0, 20));
        }

        CapVelocity(5);
	}

	void CapVelocity( float max )
    {
		Vector2 vel = controlled.rigidbody2D.velocity;
		if( vel.y > max )
        {
            Debug.Log("FUCK!");
            vel.y = max;
        }
        controlled.rigidbody2D.velocity = vel;
    }
}
