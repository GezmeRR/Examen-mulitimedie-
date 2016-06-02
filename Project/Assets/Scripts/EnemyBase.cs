using System.Linq;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float fallSpeed;

    private BoxCollider2D col;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Vector2 position = transform.position;
        Vector2 scale = transform.localScale;

        Vector2 center = position + Vector2.Scale(col.offset, scale);
        Vector2 size = Vector2.Scale(col.size, scale);

        Fall(center, size);
    }

    void Fall(Vector2 center, Vector2 size)
    {
        float fallDist = fallSpeed * Time.deltaTime;
        RaycastHit2D[] hit = Physics2D.BoxCastAll(center, size, 0, Vector2.down, fallDist);

        if (hit.Length > 1)
        {
            fallDist = hit.First(h => h.collider.gameObject != gameObject).distance;
        }

        transform.position += Vector3.down * fallDist;
    }
}
