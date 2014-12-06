using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {

    GameObject fireball;
    GameObject snowball;
    GameObject venoball;

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
        }
		if( Input.GetKeyDown(KeyCode.Alpha2) )
        {
            fireball.SetActive(false);
            snowball.SetActive(true);
            venoball.SetActive(false);
        }
		if( Input.GetKeyDown(KeyCode.Alpha3) )
        {
            fireball.SetActive(false);
            snowball.SetActive(false);
            venoball.SetActive(true);
        }
	}
}
