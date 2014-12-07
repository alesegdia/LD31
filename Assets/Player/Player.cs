using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Texture heart;
    public Texture noheart;
    public Font pointsFont;

    static int hiscore = 0;

	[System.Serializable]
	public struct Health {
		public int current;
		public int total;
	};
	public Health health;
    public float painTime = 1;
    float lastPain = 0;
    public GameObject graphics;
    public int currentScore = 0;

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
        if (health.current <= 0)
        {
            if (currentScore > hiscore) hiscore = currentScore;
            Application.LoadLevel(Application.loadedLevel);
        }
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
                        currentScore += 5;
                    }
					else
					{
                        currentScore += 10;
					}
					
					Destroy(other.gameObject);
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
        int i;
        for ( i = 0; i < health.current; i++ )
            GUI.DrawTexture(new Rect((heart.width + 2) * i + 10, 10, heart.width, heart.height), heart);

        for (; i < health.total; i++ )
        {
            GUI.DrawTexture(new Rect((noheart.width + 2) * i + 10, 10, noheart.width, noheart.height), noheart);
        }

        GUIStyle mystyle = new GUIStyle();
        mystyle.font = pointsFont;
        mystyle.normal.textColor = Color.white;
		GUI.Label(new Rect(10, 30, 200, 200), "SCORE " + currentScore.ToString(), mystyle);
		GUI.Label(new Rect(10, 50, 200, 200), "HI-SCORE " + hiscore.ToString(), mystyle);
    }

}
