using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseBlockController : MonoBehaviour
{
    private Rigidbody2D _houseBlockBody;

    private bool _isGrounded = false;

    private void Start()
    {
        _houseBlockBody = GetComponent<Rigidbody2D>();
        _houseBlockBody.isKinematic = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _houseBlockBody.isKinematic = false;
            transform.parent = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.name.Contains("StartHouseBlock") == false && collision.gameObject.CompareTag("Floor"))
        {
            SceneManager.LoadScene("GameScene");
        }
        else if (_isGrounded == false && (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("HouseBlock")))
        {
            StartCoroutine(SpawnerController.SpawnNewHouseBlockDelegate());

            _isGrounded = true;
        }
    }
}
