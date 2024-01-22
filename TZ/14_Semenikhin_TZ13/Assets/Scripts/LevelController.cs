using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Vector2 _startPlayerPosition;
    [SerializeField] private Transform _player;

    public void OnEnable()
    {
        _player.position = _startPlayerPosition;
        _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
