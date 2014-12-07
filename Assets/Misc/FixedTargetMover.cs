using UnityEngine;
using System.Collections;

public class FixedTargetMover : MonoBehaviour {

    public GameObject target;
    public float speed = 10.0f;
    Vector2 fixed_velocity = new Vector2();
    bool first = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if( first )
        {
            first = false;
            fixed_velocity = (target.transform.position - this.transform.position).normalized * speed;
        }
        Debug.Log(fixed_velocity);
        this.rigidbody2D.velocity = fixed_velocity;
	
	}
}
