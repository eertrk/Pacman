using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance;
    public float ileriHiz = 2f; 

    public Rigidbody2D rb;

    public bool isFinished;

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

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.deltaPosition.y > 15.0f)
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
            /*else
            {
                if (gameObject.transform.position.y > 3)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 3,0);
                }
                else
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, + 3,0);
                }
            }*/
        }
    }

    private void FixedUpdate()
    {
        if (!isFinished)
        {
            rb.velocity = new Vector2(ileriHiz, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
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
