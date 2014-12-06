using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Texture heart;

	[System.Serializable]
	public struct Health {
		public int current;
		public int total;
	};
	public Health health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTrigger2DStay(Collider2D other)
    {
        Debug.Log("HEY!!");
    }

	void OnCollision2DEnter(Collider2D other)
    {
        Debug.Log("HEY!!");
    }

	void OnGUI()
    {
        for (int i = 0; i < health.current; i++ )
            GUI.DrawTexture(new Rect((heart.width + 2) * i, 0, heart.width, heart.height), heart);
    }

}
