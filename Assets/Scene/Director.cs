using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    MobSpawner mobSpawner;
    public float logoFadeStart = 10.0f;
    public float logoFadeStep = 5.0f;
    public float logoEnableStart = 5.0f;

    public float storyFadeStart = 15.0f;
    public float storyFadeStep = 0.01f;
    public float storyEnableStart = 5.0f;

    bool storyEnabled = false;

    public float killingStart = 30.0f;
	
    public Font storyFont;
    float storyAlpha = 0.0f;
    bool logoFadeDone = false;

    bool skullEnabled = false;
    bool teyeEnabled = false;
    bool temurEnabled = false;

    public float skullStart = 20.0f;
    public float teyeStart = 25.0f;
    public float temurStart = 30.0f;

    public float skullCooldown = 2.0f;
    public float teyeCooldown = 3.0f;
    public float temurCooldown = 1.0f;

    public float skullSpawnInterval = 10.0f;
    public float temurSpawnInterval = 5.0f;
    public float teyeSpawnInterval = 15.0f;

    public float levelUpInterval = 5.0f;
    public int maxLevel = 100;
    float nextLevelUp = 0.0f;
    float nextSpawn = 0.0f;

    public float finalSpawnRelation = 4.0f;
    float divSpawnFactor;

    bool tick = false;
    public int level = 0;
    float now;
    private GUIStyle mystyle;
    private GUIStyle mystyle2;

	// Use this for initialization
	void Start () {
		mystyle = new GUIStyle();
		mystyle.font = storyFont;
		Color c = Color.white;
		c.a = storyAlpha;
		mystyle.normal.textColor = c;
		mystyle.alignment = TextAnchor.MiddleCenter;

		mystyle2 = new GUIStyle();
		mystyle2.font = storyFont;
		mystyle2.normal.textColor = Color.green;
		mystyle2.alignment = TextAnchor.MiddleCenter;



        divSpawnFactor = ((float)maxLevel) * finalSpawnRelation; 
        //divSpawnFactor = finalSpawnRelation; 
        mobSpawner = GameObject.FindGameObjectWithTag("MobSpawner").GetComponent<MobSpawner>();
        audio.Play();
		now = Time.time;
        logoFadeDone = false;
        storyAlpha = 1.0f;
        this.renderer.enabled = false;
        storyEnabled = false;
        skullEnabled = teyeEnabled = temurEnabled = false;
        nextLevelUp = Time.time + levelUpInterval;

	}
	
	// Update is called once per frame
	void Update () {
		if( level > skullStart ) skullEnabled = true;
		if( level > temurStart ) temurEnabled = true;
		if( level > teyeStart ) teyeEnabled = true;

        if (Time.time > killingStart)
        {
			if( level < maxLevel && Time.time > nextLevelUp )
			{
				nextLevelUp = Time.time + levelUpInterval;
				level++;
				Debug.Log("level: " + level);
			}
			else if( level == 10 && !tick )
			{
				GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Weapons>().enableHyper = true;
				tick = true;
			}


			if( Time.time > nextSpawn )
            {
				SpawnSomething();
			}
        }
	}

	void SpawnSomething()
    {
		int sel = Random.Range(0, 3);
        if (sel == 0) SpawnSkull();
		if (sel == 1) SpawnTeye();
        if (sel == 2) SpawnTemur();
    }

	void SpawnTeye()
    {
        int qtt = 1;
		if( level > 8 ) qtt = 2;
		else if( level > 4 ) qtt = 1;

		while( qtt > 0 )
        {
            mobSpawner.SpawnTeye();
            qtt--;
        }

        float cooldown = teyeCooldown * (1.0f - (level / divSpawnFactor));
        nextSpawn = Time.time + cooldown;
        Debug.Log("TEYE! " + cooldown);
    }

	void SpawnSkull()
    {
        int qtt = 1;
		if( level > 8 ) qtt = 3;
		else if( level > 4 ) qtt = 2;
		else if( level > 2 ) qtt = 1;

		while( qtt > 0 )
        {
            mobSpawner.SpawnSkull();
            qtt--;
        }

        float cooldown = skullCooldown * (1.0f - (level / divSpawnFactor));
        nextSpawn = Time.time + cooldown;
        Debug.Log("SKULL! " + cooldown);
    }

	void SpawnTemur()
    {
        int qtt = 1;
		if( level > 8 ) qtt = 8;
		else if( level > 6 ) qtt = 4;
		else if( level > 4 ) qtt = 2;
		else if( level > 2 ) qtt = 1;

		while( qtt > 0 )
        {
            mobSpawner.SpawnTemur();
            qtt--;
        }

        float cooldown = temurCooldown * (1.0f - (level / divSpawnFactor));
        nextSpawn = Time.time + cooldown;
        Debug.Log("TEMUR! " + cooldown);
    }

	void FixedUpdate()
    {
		if( Time.time > logoEnableStart )
        {
            this.renderer.enabled = true;
        }

		if( Time.time > logoFadeStart && this.renderer.material.color.a > 0 )
        {
            Color c = this.renderer.material.color;
            c.a -= logoFadeStep;
            this.renderer.material.color = c;
        }

    }

	void Timeline( float start, float duration, float fadestart, float fadestep, string text )
    {
		if( Time.time > start && Time.time < start + duration )
        {

        }
    }

	void OnGUI()
    {
        storyEnabled = Time.time > storyEnableStart;

		if( Time.time > storyFadeStart && storyAlpha > 0.0f )
        {
            storyAlpha -= storyFadeStep;
        }

		if( storyEnabled )
        {
			GUI.Label(new Rect(0, 0, Screen.width,Screen.height-100), "every night, every dream\ni am tough,\nbut never completed\nuntil the death has come", mystyle);
        }

        GUI.Label(new Rect(Screen.width/2, 0, 2*Screen.width/3, Screen.height/4), "instructions:\narrows/wasd: movement\n1-4/h-l: option enable/disable\nspace: shoot", mystyle2);
    }

	void CenterText(string text)
    {
    }
}
