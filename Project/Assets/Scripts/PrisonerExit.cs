using UnityEngine;
using UnityEngine.SceneManagement;

public class PrisonerExit : MonoBehaviour {

    public int health;
    public int damage;

    public int score;
    public int scorePenalty;
    public AudioClip[] damageClips;

    private AudioSource source;
    private BoxCollider2D col;

    protected Vector2 Center { get { return (Vector2)transform.position + Vector2.Scale(col.offset, transform.localScale); } }
    protected Vector2 Size { get { return Vector2.Scale(col.size, transform.localScale); } }

    // Use this for initialization
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        col = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update () {

        RaycastHit2D hit = Physics2D.BoxCast(Center, Size, 0, Vector2.down, 10);

        if (!hit.collider.GetComponent<PlayerMovement>() && hit.collider.gameObject != gameObject)
        {
            Debug.Log("hit");
            Destroy(hit.transform.gameObject);
            //different foe, different damage
            //health -= other.gameObject.damage;
            //same damage for all
            damage++;
            score -= scorePenalty;

            if (damage >= health)
            {
                SaveFile.newScore = score;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                source.clip = damageClips[Random.Range(0, damageClips.Length)];
                source.Play();
            }
        }
	}
}
