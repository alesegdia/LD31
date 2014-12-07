using UnityEngine;
using System.Collections;

public class DestructionTimer : MonoBehaviour {

    public float timeToDestruction = 5.0f;
    float destructionTime = 5.0f;

	// Use this for initialization
	void Start () {
        destructionTime = Time.time + timeToDestruction;
	}
	
	// Update is called once per frame
	void Update () {
		if( Time.time > destructionTime )
        {
            Destroy(this.gameObject);
        }
	}
}
