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
    bool isShowing = true;
    float whenIsShown = 0;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        whenIsShown = Time.time + 5;
	}
	
	// Update is called once per frame
	void Update () {

		if( Time.time < whenIsShown )
        {
            Color c = GetComponent<Renderer>().material.color;
            c.a = Mathf.Lerp(1, 0, (whenIsShown - Time.time) / 5);
            GetComponent<Renderer>().material.color = c;
        }

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
		GameObject go = Instantiate(projectile, this.transform.position, Quaternion.identity) as GameObject;
        DestructionTimer dt = go.AddComponent<DestructionTimer>();
        dt.timeToDestruction = 4.0f;
    }
}
