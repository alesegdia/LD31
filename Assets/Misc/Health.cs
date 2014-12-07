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
        Debug.Log(current);
		if( current < 0 )
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().points += pointsOnDying;
            Destroy(this.transform.parent.gameObject);
        }
	}

	void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ONTRIGGER!");
		if( other.gameObject.layer == LayerMask.NameToLayer("PlayerBullet") )
        {
			Debug.Log("YEAH!!");
            current--;
            Destroy(other.gameObject);
        }
    }
}
