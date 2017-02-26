using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

    public enum Type
    {
        HEALTH, SPEED
    }

    public Type type;
    public float quantity;
    public float velocity = -2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newvel = this.GetComponent<Rigidbody2D>().velocity;
		newvel.x = velocity;
        this.GetComponent<Rigidbody2D>().velocity = newvel;
	}
}
