using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance;
    public float ileriHiz = 2f; 

    public Rigidbody2D rb;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Swipe();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(ileriHiz, rb.velocity.y);
    }

    private void Swipe()
    {
        if (gameObject.transform.position.y < 3)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3,0);
        }
        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, - 3,0);
        }
    }
}