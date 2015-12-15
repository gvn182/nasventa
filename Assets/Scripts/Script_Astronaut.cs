using UnityEngine;
using System.Collections;

public class Script_Astronaut : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.rigidbody2D.AddForceAtPosition(new Vector2(0.5f, 0.5f), new Vector2(1,1));
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
