using UnityEngine;
using System.Collections;

public class SpeedCutter : MonoBehaviour {

    public float max_speed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 vel = this.rigidbody2D.velocity;

        if (Mathf.Abs(vel.x) > max_speed) vel.x = max_speed * Mathf.Sign(vel.x);
        if (Mathf.Abs(vel.y) > max_speed) vel.y = max_speed * Mathf.Sign(vel.y);

        this.rigidbody2D.velocity = vel;
	}
}
