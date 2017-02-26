using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Vector2 speed;
    public Vector2 maxSpeed;
    Animator animator;
    public GameObject controlledGameobject;
    public GameObject graphicGameobject;

	// Use this for initialization
	void Start () {
        animator = graphicGameobject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// handle horizontal and vertical input forces
        float hor, ver;
        hor = ver = 0;
		if( Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) )  ver = 1;
		if( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ) hor = -1;
		if( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ) hor = 1;
        controlledGameobject.GetComponent<Rigidbody2D>().AddForce(new Vector2(hor * speed.y, ver * speed.y));

		// cap
		Vector2 vel = controlledGameobject.GetComponent<Rigidbody2D>().velocity;
        if (vel.y > maxSpeed.y)
        {
            vel.y = maxSpeed.y;
        }
		if (Mathf.Abs(vel.x) > maxSpeed.x) vel.x = maxSpeed.x * Mathf.Sign(vel.x);
        controlledGameobject.GetComponent<Rigidbody2D>().velocity = vel;
        animator.SetFloat("Vertical Speed", controlledGameobject.GetComponent<Rigidbody2D>().velocity.y);

	}
}
