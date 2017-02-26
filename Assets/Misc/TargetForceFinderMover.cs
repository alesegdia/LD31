using UnityEngine;
using System.Collections;

public class TargetForceFinderMover : MonoBehaviour {

    public GameObject target;
    public float force = 1.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody2D>().AddForce((- this.transform.position + target.transform.position).normalized * force);


	}
}
