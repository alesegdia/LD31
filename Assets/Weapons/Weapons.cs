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

	void SetOption(string option, bool enabled = true)
    {
        if (option == "fireball") fireball.GetComponent<SpriteRenderer>().enabled = enabled;
        else if (option == "snowball") snowball.GetComponent<SpriteRenderer>().enabled = enabled;
        else venoball.GetComponent<SpriteRenderer>().enabled = enabled;
    }

	void SetAllOptions( bool enable_fire, bool enable_snow, bool enable_veno)
    {
        SetOption("fireball", enable_fire);
        SetOption("snowball", enable_snow);
        SetOption("venoball", enable_veno);
    }

	void SetOnlyFireball() { SetAllOptions(true, false, false); }
	void SetOnlySnowball() { SetAllOptions(false, true, false); }
	void SetOnlyVenoball() { SetAllOptions(false, false, true); }

	// Use this for initialization
	void Start () {
        fireball = transform.Find("WpFireball").gameObject;
        snowball = transform.Find("WpSnowball").gameObject;
        venoball = transform.Find("WpVenoball").gameObject;

		selected = "fireball";
		fireball.GetComponent<SpriteRenderer>().enabled = true;
		snowball.GetComponent<SpriteRenderer>().enabled = false;
		venoball.GetComponent<SpriteRenderer>().enabled = false;
		selected = "fireball";

	}

	bool IsEnabledOption (string option)
    {
        if (option == "fireball") return fireball.GetComponent<SpriteRenderer>().enabled;
        if (option == "snowball") return snowball.GetComponent<SpriteRenderer>().enabled;
        if (option == "venoball") return venoball.GetComponent<SpriteRenderer>().enabled;
        return false;
    }
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.Alpha1) )
        {
            SetOnlyFireball();
        }
		if( Input.GetKeyDown(KeyCode.Alpha2) )
        {
            SetOnlySnowball();
        }
		if( Input.GetKeyDown(KeyCode.Alpha3) )
        {
			SetOnlyVenoball();
        }
		if( Input.GetKeyDown(KeyCode.Alpha4) )
        {
			SetAllOptions( true, true, true );
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
        Vector2 from;
        if (IsEnabledOption("fireball"))
        {
            InstanceBullet(fireproj, fireball.transform.position);
        }
        if (IsEnabledOption("snowball"))
        {
            InstanceBullet(snowproj, snowball.transform.position);
        }
        if( IsEnabledOption("venoball") )
        {
            InstanceBullet(venoproj, venoball.transform.position);
        }
    }

	void InstanceBullet(GameObject proj, Vector2 from )
    {
		GameObject go = Instantiate(proj, from, Quaternion.identity) as GameObject;
        DestructionTimer dt = go.AddComponent<DestructionTimer>();
        dt.timeToDestruction = 4.0f;
    }
}
