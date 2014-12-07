using UnityEngine;
using System.Collections;

public class Skull : MonoBehaviour {

    public GameObject player;
    public float attraction = 1.0f;
    public float alpha = 0.5f;
    public bool randomize = false;

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 player_pos = new Vector2( player.transform.position.x, player.transform.position.y );
        Vector2 skull_velocity = this.rigidbody2D.velocity;

        Vector2 new_velocity = Vector2.Lerp(player_pos.normalized, skull_velocity.normalized, alpha) * attraction;
		this.rigidbody2D.velocity = - this.transform.position + player.transform.position;

        transform.Find("Physic").rigidbody2D.MovePosition(this.transform.position);
	}

}
