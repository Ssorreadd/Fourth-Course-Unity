using System.Collections;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    private void Start()
    {
        if (transform.position.x > 0)
        {
            StartCoroutine(GoLeft());
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

            StartCoroutine(GoRight());
        }
    }

    private IEnumerator GoRight()
    {
        while (true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2.5f, 0);
            yield return new WaitForSeconds(0.0001f);
        }
    }

    private IEnumerator GoLeft()
    {
        while (true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = -new Vector2(2.5f, 0);
            yield return new WaitForSeconds(0.0001f);
        }
    }

    private void OnMouseUp()
    {
        switch (gameObject.tag)
        {
            case "Duck":
                GameController.SetScoreCountDelegate(1);
                break;
            case "RedDuck":
                GameController.SetScoreCountDelegate(-1);
                break;
            case "Egg":
                GameController.GameOverDelegate();
                break;
        }

        Destroy(gameObject);
    }
}
