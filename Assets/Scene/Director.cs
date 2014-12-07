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

    int level = 1;
    float now;

	// Use this for initialization
	void Start () {
        mobSpawner = GameObject.FindGameObjectWithTag("MobSpawner").GetComponent<MobSpawner>();
        audio.Play();
		now = Time.time;
        logoFadeDone = false;
        storyAlpha = 1.0f;
        this.renderer.enabled = false;
        storyEnabled = false;
        skullEnabled = teyeEnabled = temurEnabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if( level < maxLevel && Time.time > nextLevelUp )
        {
            nextLevelUp += levelUpInterval;
        }

		if( level > skullStart ) skullEnabled = true;
		if( level > temurStart ) temurEnabled = true;
		if( level > teyeStart ) teyeEnabled = true;

        if (Time.time > killingStart)
        {
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
        Debug.Log("TEYE!");
        mobSpawner.SpawnTeye();
        nextSpawn = Time.time + teyeCooldown * (1 - (level / 200));
    }

	void SpawnSkull()
    {
        Debug.Log("SKULL!");
        mobSpawner.SpawnSkull();
        nextSpawn = Time.time + skullCooldown * (1 - (level / 200));
    }

	void SpawnTemur()
    {
        Debug.Log("TEMUR!");
        mobSpawner.SpawnTemur();
        nextSpawn = Time.time + temurCooldown * (1 - (level / 200));
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
			GUIStyle mystyle = new GUIStyle();
			mystyle.font = storyFont;
			Color c = Color.white;
            c.a = storyAlpha;
			mystyle.normal.textColor = c;
			mystyle.alignment = TextAnchor.MiddleCenter;
			GUI.Label(new Rect(0, 0, Screen.width,Screen.height-100), "every night, every dream\ni am tough,\nbut never completed\nuntil the death has come", mystyle);
        }
    }

	void CenterText(string text)
    {
    }
}
