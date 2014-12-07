using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Texture heart;

	[System.Serializable]
	public struct Health {
		public int current;
		public int total;
	};
	public Health health;
    public float painTime = 1;
    float lastPain = 0;
    public GameObject graphics;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Color c = graphics.renderer.material.color;
        if (lastPain + painTime > Time.time) c.a = 0.3f;
        else c.a = 1.0f;
        graphics.renderer.material.color = c;

	}

    void OnTriggerStay2D(Collider2D other)
    {
		if( lastPain + painTime < Time.time && other.gameObject.layer == LayerMask.NameToLayer("Enemy") )
        {
            lastPain = Time.time;
            health.current--;
        }
		else if( other.gameObject.layer == LayerMask.NameToLayer("Powerup") )
        {
            Powerup pwup = other.gameObject.GetComponent<Powerup>();
			switch( pwup.type )
            {
				case Powerup.Type.HEALTH:
					if( health.current + 1 <= health.total )
                    {
						health.current++;
						Destroy(other.gameObject);
                    }
					break;
            }
        }
		else if( other.gameObject.layer == LayerMask.NameToLayer("EnemyBullet") )
        {
            if (Time.time > lastPain + painTime)
            {
                Destroy(other.gameObject);
                lastPain = Time.time;
                health.current--;
            }
        }
    }

	void OnGUI()
    {
        for (int i = 0; i < health.current; i++ )
            GUI.DrawTexture(new Rect((heart.width + 2) * i + 10, 10, heart.width, heart.height), heart);
    }

}
