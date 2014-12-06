using UnityEngine;
using System.Collections;

public class PlayerAnimatorController : MonoBehaviour {

    public Animator controlledAnimator;
    public Rigidbody2D controlledRigidbody;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        controlledAnimator.SetFloat("Vertical Speed", controlledRigidbody.velocity.y);
	}
}
