using UnityEngine;
using System.Collections;

public class LinearMover : MonoBehaviour {

    public enum Type { X, Y };
    public Type type;
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 vel = this.rigidbody2D.velocity;
        switch (type)
        {
            case Type.X: vel.x = speed; break;
            case Type.Y: vel.y = speed; break;
        }
        this.rigidbody2D.velocity = vel;	
	}
}
