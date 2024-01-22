using TMPro;
using UnityEngine;

public class RocketController: MonoBehaviour
{
    private Vector3 _startPos;

    private TextMeshProUGUI _score;


    private void Start()
    {
        _startPos = transform.position;   
        _score = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        transform.position += new Vector3(0, 5f, 0) * Time.deltaTime;
       
        if (Vector3.Distance(_startPos, transform.position) > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.transform.tag.ToLower())
        {
            case "enemy":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                _score.text = (int.Parse(_score.text) + 100).ToString();
                break;
        }

        Destroy(gameObject);
    }
}
