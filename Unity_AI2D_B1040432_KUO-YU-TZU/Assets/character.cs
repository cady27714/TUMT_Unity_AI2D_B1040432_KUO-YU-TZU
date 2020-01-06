using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    public int speed = 50;
    public float jump = 2.5f;
    public string charactername = "QQ";
    public bool pass = false;
    public bool isGround;
    public UnityEvent onEat;
    [Header("血量"), Range(0, 200)]
    public float hp = 60;

    public Image hpBar;
    [Header("結束畫面")]
    public GameObject final;

    private float hpMax;

    private Rigidbody2D r2d;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        //tra = GetComponent<Transform>();

        hpMax = hp;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) { TurnRight(); }
        if (Input.GetKeyDown(KeyCode.A)) { TurnLift(); }
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "金幣")
        {
            Destroy(collision.gameObject);
            onEat.Invoke();           
        }
    }

    private void Walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }

    private void Jump()
    {

        r2d.AddForce(new Vector2(0, jump * Input.GetAxis("Jump")));
    }

    private void TurnRight()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void TurnLift()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void Damage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / hpMax;

        if (hp <= 0) final.SetActive(true);
    }

    public void win()
    {
        final.SetActive(true);
    }
}
