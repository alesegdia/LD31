using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int maxHealth = 10;
    int current;
    public int pointsOnDying = 0;

	// Use this for initialization
	void Start () {
        current = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if( current < 0 )
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentScore += pointsOnDying;
            Destroy(this.transform.parent.gameObject);
        }
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		if( other.gameObject.layer == LayerMask.NameToLayer("PlayerBullet") )
        {
            current -= other.gameObject.GetComponent<Bullet>().damage;
            Destroy(other.gameObject);
        }
    }
}
