using UnityEngine;
using System.Collections;

public class DestructionLessThan : MonoBehaviour {

    public float howMuch = -10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( this.transform.position.x < howMuch )
        {
            Destroy(this);
        }
	}
}
