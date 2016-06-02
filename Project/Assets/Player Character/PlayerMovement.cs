using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {



    bool inAir = false;
    //distance from center to ground
    public float groundOffset;

    public int score;
    public int lives;

    bool invincible;
    float invTimer;

    public float fallSpeed;

    public GameObject spawn;

    public GameObject self;

	// Use this for initialization
	void Start () {

        

        //Always start at spawn, no need to move player and spawn in editor
        self.transform.position = spawn.transform.position;

        if(Physics2D.BoxCast(Vector2.zero, new Vector2(0.5f, 1), 0f, Vector2.down, groundOffset) && )
        {



        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
