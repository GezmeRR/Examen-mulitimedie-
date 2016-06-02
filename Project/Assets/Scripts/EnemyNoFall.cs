using System.Linq;
using UnityEngine;

public class EnemyNoFall : EnemyBase
{
    protected override void Move()
    {
        if (Grounded)
        {
            Vector3 moveDir = direction ? Vector3.left : Vector3.right;

            RaycastHit2D[] hit = Physics2D.BoxCastAll(Center + Vector2.Scale(Size, new Vector2(moveDir.x * 0.45F, -0.45F)), Size*0.1F, 0, Vector2.down, Size.y * 0.5F + 0.1F)
                .Where(h => CanCollide(h.collider))
                .ToArray();

            if (hit.Length == 0)
            {
                direction = !direction;
                return;
            }
        }

        base.Move();
    }
}
