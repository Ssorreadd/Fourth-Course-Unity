using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] Text countText;
    
    [SerializeField] Text winText;

    private Rigidbody2D rigidbody;

    private int count = 0;

    void Start()
    {
        SetCountText();

        winText.text = null;

        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");    
        float moveVertical = Input.GetAxis("Vertical");

        rigidbody.AddForce(new Vector2(moveHorizontal, moveVertical) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = $"Count: {count}";

        if (count == 8)
        {
            winText.text = "YOU WIN!";
        }
    }
}
 