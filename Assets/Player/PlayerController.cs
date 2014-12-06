using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Vector2 speed;
    public Vector2 maxSpeed;
    Animator animator;
    public GameObject controlledGameobject;
    public GameObject graphicGameobject;
    public Texture heart;

	[System.Serializable]
	public struct Health {
		public int current;
		public int total;
	};
	public Health health;

	// Use this for initialization
	void Start () {
        animator = graphicGameobject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// handle horizontal and vertical input forces
        float hor, ver;
        hor = ver = 0;
		if( Input.GetKey(KeyCode.Space) )  ver = 1;
		if( Input.GetKey(KeyCode.A) ) hor = -1;
		if( Input.GetKey(KeyCode.D) ) hor = 1;
        controlledGameobject.rigidbody2D.AddForce(new Vector2(hor * speed.y, ver * speed.y));

		// cap
		Vector2 vel = controlledGameobject.rigidbody2D.velocity;
        if (vel.y > maxSpeed.y)
        {
            Debug.Log(vel.y);
            vel.y = maxSpeed.y;
        }
		if (Mathf.Abs(vel.x) > maxSpeed.x) vel.x = maxSpeed.x * Mathf.Sign(vel.x);
        controlledGameobject.rigidbody2D.velocity = vel;
        animator.SetFloat("Vertical Speed", controlledGameobject.rigidbody2D.velocity.y);

	}

	void OnGUI()
    {
        for (int i = 0; i < health.current; i++ )
            GUI.DrawTexture(new Rect((heart.width + 2) * i, 0, heart.width, heart.height), heart);
    }
}
