using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {

    GameObject fireball;
    GameObject snowball;
    GameObject venoball;
    public GameObject fireproj;
    public GameObject snowproj;
    public GameObject venoproj;
    string selected = "fireball";
    float nextShot;
    float cooldown = 0.2f;

	// Use this for initialization
	void Start () {
        fireball = transform.Find("WpFireball").gameObject;
        snowball = transform.Find("WpSnowball").gameObject;
        venoball = transform.Find("WpVenoball").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.Alpha1) )
        {
            fireball.SetActive(true);
            snowball.SetActive(false);
            venoball.SetActive(false);
            selected = "fireball";
        }
		if( Input.GetKeyDown(KeyCode.Alpha2) )
        {
            fireball.SetActive(false);
            snowball.SetActive(true);
            venoball.SetActive(false);
            selected = "snowball";
        }
		if( Input.GetKeyDown(KeyCode.Alpha3) )
        {
            fireball.SetActive(false);
            snowball.SetActive(false);
            venoball.SetActive(true);
            selected = "venoball";
        }

        if (Time.time > nextShot && Input.GetKey(KeyCode.Space))
        {
            nextShot = Time.time + cooldown;
            Shot();
        }
	}

	void Shot()
    {
		GameObject proj;
        if( selected == "fireball" ) proj = fireproj;
        else if( selected == "snowball" ) proj = snowproj;
        else proj = venoproj;
		GameObject go = Instantiate(proj, this.transform.position, Quaternion.identity) as GameObject;
        DestructionTimer dt = go.AddComponent<DestructionTimer>();
        dt.timeToDestruction = 4.0f;
    }
}
