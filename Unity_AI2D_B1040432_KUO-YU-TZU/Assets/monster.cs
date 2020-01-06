using UnityEngine;
using UnityEngine.Tilemaps;

public class monster : MonoBehaviour
{
    [Header("速度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("傷害"), Range(0, 100)]
    public float damage = 20;
    [Header("檢查地板")]
    public Transform checkPoint;

    private Rigidbody2D r2d;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(checkPoint.position, -checkPoint.up * 2);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "QQ")
        {
            Track(collision.transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "QQ")
        {
            collision.gameObject.GetComponent<character>().Damage(damage);
        }
    }

    private void Move()
    {
        //r2d.AddForce(new Vector2(-speed, 0));
        
        RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, -checkPoint.up, 1.5f,1<<8);

        if (hit==false )
        {
            Debug.Log("ggg");
            transform.eulerAngles += new Vector3(0, 180, 0);
        } else {
            r2d.AddForce(transform.right * speed);
            Debug.Log("hhhh");
        }
    }

    private void Track(Vector3 target)
    {
        if (target.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
