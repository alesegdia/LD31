using UnityEngine;
using System.Collections;

public class FixedTargetMover : MonoBehaviour {

    public string targetTag;
    GameObject target;
    public float speed = 10.0f;
    Vector2 fixed_velocity = new Vector2();
    bool first = true;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag(targetTag);
	}
	
	// Update is called once per frame
	void Update () {
		if( first )
        {
            first = false;
            fixed_velocity = (target.transform.position - this.transform.position).normalized * speed;
        }
        this.GetComponent<Rigidbody2D>().velocity = fixed_velocity;
	
	}
}
