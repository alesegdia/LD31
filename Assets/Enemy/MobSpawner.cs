using UnityEngine;
using System.Collections;

public class MobSpawner : MonoBehaviour {

    public Rect teyeSpawnArea;
    public GameObject teyeProjectile;
    public GameObject skull;
    public GameObject teye;
    public GameObject temur;
    GameObject player;
    bool click = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (!click)
        {
            SpawnTeye();
            click = true;
        }
		*/
	}

	public void SpawnSkull()
    {
        GameObject go = Instantiate(skull, this.transform.position, Quaternion.identity) as GameObject;
        Skull skullgo = go.GetComponent<Skull>();
        skullgo.player = player;
        skullgo.GetComponent<SinusMover>().angleOffset = Random.RandomRange(0, Mathf.PI * 2);
    }

	public void SpawnTeye()
    {
		//float x = teyeSpawnArea.x + teyeSpawnArea.width;//Random.RandomRange(teyeSpawnArea.x, teyeSpawnArea.x + teyeSpawnArea.width);
        //float y = teyeSpawnArea.y;//Random.RandomRange(teyeSpawnArea.y, teyeSpawnArea.y + teyeSpawnArea.height);
		float x = Random.RandomRange(teyeSpawnArea.x, teyeSpawnArea.x + teyeSpawnArea.width);
        float y = Random.RandomRange(teyeSpawnArea.y, teyeSpawnArea.y + teyeSpawnArea.height);
        Debug.Log("x: " + x + ", y: " + y);
		GameObject go = Instantiate(teye, new Vector3(0,0), Quaternion.identity) as GameObject;
        EnemyTeye eteye = go.GetComponent<EnemyTeye>();
        eteye.projectile = teyeProjectile;
        eteye.projectile.GetComponent<FixedTargetMover>().targetTag = "Player";
        foreach( SinusMover sm in go.GetComponents<SinusMover>() )
        {
            sm.angleOffset = Random.RandomRange(0, 2 * Mathf.PI);
            if( sm.type == SinusMover.Type.X ) sm.offset = x;
            if( sm.type == SinusMover.Type.Y ) sm.offset = y;
        }
    }

	public void SpawnTemur()
    {
        Vector2 pos = this.transform.position;
        pos.y += Random.Range(-5, 5);
        GameObject go = Instantiate(temur, pos, Quaternion.identity) as GameObject;
        TargetForceFinderMover ftm = go.GetComponent<TargetForceFinderMover>();
        ftm.target = GameObject.FindGameObjectWithTag("Player");
    }
}
