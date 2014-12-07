using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {

    GameObject fireball;
    GameObject snowball;
    GameObject venoball;
    public GameObject fireproj;
    public GameObject snowproj;
    public GameObject venoproj;
    public float FireCooldown = 0.2f;
    public float SnowCooldown = 0.5f;
    public float VenoCooldown = 0.05f;
    float fireNextShot = 0.0f;
    float snowNextShot = 0.0f;
    float venoNextShot = 0.0f;
    string selected = "fireball";
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

        if ( Input.GetKey(KeyCode.Space))
        {
            TryShootFire();
            TryShootSnow();
            TryShootVeno();
        }
	}

	void TryShootFire()
    {
		if( IsEnabledOption("fireball") && Time.time > fireNextShot )
        {
            fireNextShot = Time.time + FireCooldown;
            InstanceBullet(fireproj, fireball.transform.position);
        }
    }

	void TryShootSnow()
    {
		if( IsEnabledOption("snowball") && Time.time > snowNextShot )
        {
            snowNextShot = Time.time + SnowCooldown;
            InstanceBullet(snowproj, snowball.transform.position);
        }
    }
	void TryShootVeno()
    {
		if( IsEnabledOption("venoball") && Time.time > venoNextShot )
        {
            venoNextShot = Time.time + VenoCooldown;
            InstanceBullet(venoproj, venoball.transform.position);
        }
    }


	void Shot()
    {
		GameObject proj;
        Vector2 from;
		/*
        if (IsEnabledOption("fireball"))
        {
            fireballNextShot = Time.time + cooldown;
        }
        if (IsEnabledOption("snowball"))
        {
            InstanceBullet(snowproj, snowball.transform.position);
        }
        if( IsEnabledOption("venoball") )
        {
            InstanceBullet(venoproj, venoball.transform.position);
        }
         */
    }

	void InstanceBullet(GameObject proj, Vector2 from )
    {
		GameObject go = Instantiate(proj, from, Quaternion.identity) as GameObject;
        DestructionTimer dt = go.AddComponent<DestructionTimer>();
        dt.timeToDestruction = 4.0f;
    }
}
