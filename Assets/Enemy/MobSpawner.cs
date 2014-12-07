using UnityEngine;
using System.Collections;

public class MobSpawner : MonoBehaviour {

    public Rect teyeSpawnArea;
    public GameObject teyeProjectile;
    public GameObject skull;
    public GameObject teye;
    GameObject player;
    bool click = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (!click)
        {
            SpawnTeye();
            click = true;
        }
	}

	void SpawnSkull()
    {
        GameObject go = Instantiate(skull, this.transform.position, Quaternion.identity) as GameObject;
        Skull skullgo = go.GetComponent<Skull>();
        skullgo.player = player;
        skullgo.GetComponent<SinusMover>().angleOffset = Random.RandomRange(0, Mathf.PI * 2);
    }

	void SpawnTeye()
    {
		float x = Random.RandomRange(teyeSpawnArea.x, teyeSpawnArea.x + teyeSpawnArea.width);
		float y = Random.RandomRange(teyeSpawnArea.y, teyeSpawnArea.y + teyeSpawnArea.height);
		GameObject go = Instantiate(teye, new Vector3(x,y), Quaternion.identity) as GameObject;
        EnemyTeye eteye = go.GetComponent<EnemyTeye>();
        eteye.projectile = teyeProjectile;
        eteye.projectile.GetComponent<FixedTargetMover>().targetTag = "Player";
        foreach( SinusMover sm in go.GetComponents<SinusMover>() )
        {
            sm.angleOffset = Random.RandomRange(0, 2 * Mathf.PI);
        }
    }
}
