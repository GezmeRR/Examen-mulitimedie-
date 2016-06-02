using System.Linq;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float fallSpeed;
    public float speed;
    public bool direction;

    private BoxCollider2D col;
    private bool grounded;

    private Vector2 Center { get { return (Vector2)transform.position + Vector2.Scale(col.offset, transform.localScale); } }
    private Vector2 Size { get { return Vector2.Scale(col.size, transform.localScale); } }

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Fall();
        Move();
    }

    void Fall()
    {
        float fallDist = fallSpeed * Time.deltaTime;
        
        RaycastHit2D[] hit = Physics2D.BoxCastAll(Center, Size, 0, Vector2.down, fallDist)
            .Where(h => h.collider.gameObject != gameObject && h.normal == Vector2.up)
            .ToArray();

        grounded = false;

        if (hit.Length > 0)
        {
            fallDist = hit[0].distance;
            grounded = true;
        }

        transform.position += fallDist * Vector3.down;
    }

    void Move()
    {
        float moveDist = speed * Time.deltaTime;
        Vector3 moveDir = direction ? Vector3.left : Vector3.right;

        RaycastHit2D[] hit = Physics2D.BoxCastAll(Center, Size, 0, moveDir, moveDist)
            .Where(h => h.collider.gameObject != gameObject && h.normal == -(Vector2)moveDir)
            .ToArray();

        if (hit.Length > 0)
        {
            moveDist = hit[0].distance;
            direction = !direction;
        }

        transform.position += moveDist * moveDir;
    }
}
