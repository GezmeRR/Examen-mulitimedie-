using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour {



    
    //distance from center to ground
    public float groundOffset;
    public bool grounded = false;


    public int score;
    public int lives;

    bool invincible;
    float invTimer;


    public float jumpMax;
    public float jumping;
    public float jumpVelocity;
    //public float fallAcceleration;
    public float fallSpeed;
    public float moveSpeed;


    public GameObject spawn;

    public GameObject self;
    public Rigidbody2D rbSelf;

    public float ySpeed;
    private BoxCollider2D col;

    protected Vector2 Center { get { return (Vector2)transform.position + Vector2.Scale(col.offset, transform.localScale); } }
    protected Vector2 Size { get { return Vector2.Scale(col.size, transform.localScale); } }

    // Use this for initialization
    void Start () {

        col = self.GetComponent<BoxCollider2D>();
        rbSelf = GetComponent<Rigidbody2D>();

        //Always start at spawn, no need to move player and spawn in editor
        transform.position = spawn.transform.position;



        RaycastHit2D[] hit = Physics2D.BoxCastAll(Center, Size, 0, Vector2.down, groundOffset)
            .Where(h => h.collider.gameObject != self && h.normal == Vector2.up)
            .ToArray();

        grounded = false;

        if (hit.Length > 0)
        {
            grounded = true;

            jumping = jumpMax;
        }

    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit2D[] hit = Physics2D.BoxCastAll(Center, Size, 0, Vector2.down, groundOffset)
        .Where(h => h.collider.gameObject != self && h.normal == Vector2.up)
        .ToArray();

        grounded = false;

        if (hit.Length > 0)
        {
            grounded = true;
        }


        Vector2 position = self.transform.position;
        position.x += Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W) && jumping < jumpMax)
        {
            position.y += jumpVelocity * Time.deltaTime;
            jumping += jumpVelocity * Time.deltaTime;
            Debug.Log("jump");
            
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            jumping = jumpMax;
        }


        if (grounded)
        {
            jumping = 0;
        }
        else if (!grounded && Input.GetKey(KeyCode.W) == false || jumping >= jumpMax)
        {
            position.y -= jumpVelocity * Time.deltaTime;
        }


        

        

        /*
                if (grounded)
                {
                    if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Space))
                    {

                        (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && jumpModifier < 1)
                        {
                            jumpModifier = Mathf.Lerp(0.5f, 1, 0.5f);
                        }
                        ySpeed = jumpVelocity * jumpModifier;
                        grounded = false;
                    }
                }
                else
                {

                    if (ySpeed - fallAcceleration * Time.deltaTime < -fallSpeedMax)
                    {
                        float timeToMax = (Mathf.Pow(fallSpeedMax, 2) - Mathf.Pow(ySpeed, 2)) / fallAcceleration * 0.5f;
                        position.y += 0.5f * fallAcceleration * Mathf.Pow(timeToMax, 2) + ySpeed * timeToMax;
                        position.y -= fallSpeedMax * (Time.deltaTime - timeToMax);
                        ySpeed = -fallSpeedMax;
                    }
                    else
                    {
                        position.y += 0.5f * fallAcceleration * Mathf.Pow(Time.deltaTime, 2) + ySpeed * Time.deltaTime;
                        ySpeed -= fallAcceleration * Time.deltaTime;
                    }

                    RaycastHit2D[] hit = Physics2D.BoxCastAll(Center, Size, 0, Vector2.down, groundOffset)
                    .Where(h => h.collider.gameObject != self && h.normal == Vector2.up)
                    .ToArray();

                    grounded = false;

                    if (hit.Length > 0)
                    {
                        grounded = true;
                    }
                }
                */
        rbSelf.MovePosition(position);
                
    }
}
