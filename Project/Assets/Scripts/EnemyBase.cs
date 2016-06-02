using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Animator))]
public class EnemyBase : MonoBehaviour
{
    public float fallSpeed;
    public float speed;
    public bool direction;
    public AnimationParameters animationParameters = new AnimationParameters { direction = "Direction", grounded = "Grounded" };

    private BoxCollider2D col;
    private Animator animator;
    protected bool Grounded { get; private set; }

    protected Vector2 Center { get { return (Vector2)transform.position + Vector2.Scale(col.offset, transform.localScale); } }
    protected Vector2 Size { get { return Vector2.Scale(col.size, transform.localScale); } }

    [Serializable]
    public struct AnimationParameters
    {
        public string direction;
        public string grounded;
    }

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Fall();
        Move();

        animator.SetBool(animationParameters.direction, direction);
        animator.SetBool(animationParameters.grounded, Grounded);
    }

    void Fall()
    {
        float fallDist = fallSpeed * Time.deltaTime;
        
        RaycastHit2D[] hit = Physics2D.BoxCastAll(Center, Size, 0, Vector2.down, fallDist)
            .Where(h => h.collider.gameObject != gameObject && h.normal == Vector2.up
                && !Physics2D.GetIgnoreLayerCollision(gameObject.layer, h.collider.gameObject.layer))
            .ToArray();

        Grounded = false;

        if (hit.Length > 0)
        {
            fallDist = hit[0].distance;
            Grounded = true;
        }

        transform.position += fallDist * Vector3.down;
    }

    protected virtual void Move()
    {
        float moveDist = speed * Time.deltaTime;
        Vector3 moveDir = direction ? Vector3.left : Vector3.right;

        RaycastHit2D[] hit = Physics2D.BoxCastAll(Center, Size, 0, moveDir, moveDist)
            .Where(h => h.collider.gameObject != gameObject && h.normal == -(Vector2)moveDir
                && !Physics2D.GetIgnoreLayerCollision(gameObject.layer, h.collider.gameObject.layer))
            .ToArray();

        if (hit.Length > 0)
        {
            moveDist = hit[0].distance;
            direction = !direction;
        }

        transform.position += moveDist * moveDir;
    }
}
