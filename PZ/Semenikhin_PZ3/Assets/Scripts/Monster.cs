using System.Collections;
using UnityEngine;

[SelectionBase]
public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;

    private bool _hasDie;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
            StartCoroutine(Die());
    }

    private bool ShouldDieFromCollision(Collision2D collision)
    {
        if (_hasDie)
            return false;

        Bird bird = collision.gameObject.GetComponent<Bird>();

        if (bird != null)
            return true;

        if (collision.contacts[0].normal.y < 0.5)
            return true;

        return false;

    }

    private IEnumerator Die()
    {
        _hasDie = true;

        GetComponent<SpriteRenderer>().sprite = _deadSprite;

        _particleSystem.Play();

        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);
    }
}
