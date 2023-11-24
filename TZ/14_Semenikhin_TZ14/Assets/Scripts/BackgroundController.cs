using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Renderer _render;

    void Update()
    {
        _render.material.mainTextureOffset += new Vector2(_speed * Time.deltaTime, 0f);
    }
}
