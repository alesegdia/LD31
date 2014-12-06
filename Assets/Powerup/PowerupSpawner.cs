using UnityEngine;
using System.Collections;

public class PowerupSpawner : MonoBehaviour {

    public float minSpawnTime = 2.0f;
    public float maxSpawnTime = 5.0f;
    public float maxYoffset = 7.0f;
    private float lastSpawn = 0.0f;
    private float nextSpawnDelta = 0.0f;

    public GameObject[] powerups;

	// Use this for initialization
	void Start () {
        lastSpawn = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if( lastSpawn + nextSpawnDelta < Time.time )
        {
			// new spawn!!
            nextSpawnDelta = Random.RandomRange(minSpawnTime, maxSpawnTime);
            lastSpawn = Time.time;
			int selected = Random.Range(0, powerups.Length-1);
            Vector2 pos = this.transform.position;
            pos.y += Random.RandomRange(0.0f, maxYoffset);
			Instantiate(powerups[selected], pos, Quaternion.identity);
        }
	}
}
