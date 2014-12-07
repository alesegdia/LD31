using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyTeye : MonoBehaviour {

    GameObject player;
    public GameObject projectile;
    public int shotsPerTrigger = 3;
    public float timeBetweenShots = 0.5f;
    public float timeBetweenTriggers = 3.0f;
    private float nextTrigger;
    private List<float> shotQueue = new List<float>();

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		// trigger or not to trigger?
        if (nextTrigger < Time.time)
        {
            Trigger();
            nextTrigger = Time.time + timeBetweenTriggers;
        }

		// dispatch ready shots
		int removed_shot = -1;
		for( int i = 0; i < shotQueue.Count; i++ )
        {
			if( shotQueue[i] < Time.time )
            {
                Shot();
				removed_shot = i;
				break;
            }
		}
		if( removed_shot != -1 ) shotQueue.RemoveAt(removed_shot);
	}

	void Trigger()
    {
		for( int i = 0; i < shotsPerTrigger; i++ )
        {
            shotQueue.Add(Time.time + timeBetweenShots * i);
        }
    }

	void Shot()
    {
		Instantiate(projectile, this.transform.position, Quaternion.identity);
    }
}
