using UnityEngine;
using System.Collections;

public class PrisonerExit : MonoBehaviour {

    public GameObject player;
    private GameObject self;
    private GameObject other;

    public int health;
    public int damage;

    public int score;
    public int scorePenalty;

    private BoxCollider2D col;

    protected Vector2 Center { get { return (Vector2)transform.position + Vector2.Scale(col.offset, transform.localScale); } }
    protected Vector2 Size { get { return Vector2.Scale(col.size, transform.localScale); } }

    // Use this for initialization
    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update () {

        RaycastHit2D hit = Physics2D.BoxCast(Center, Size, 0, Vector2.down, 10);

        if (!hit.collider.GetComponent<PlayerMovement>() && hit.collider.gameObject != gameObject)
        {
            Debug.Log("hit");
            other = hit.transform.gameObject;
            Destroy(other.gameObject);
            //different foe, different damage
            //health -= other.gameObject.damage;
            //same damage for all
            health --;


            score -= scorePenalty;
        }
	}
}
