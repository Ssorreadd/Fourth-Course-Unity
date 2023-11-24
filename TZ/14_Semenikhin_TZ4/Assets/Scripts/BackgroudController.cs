using UnityEngine;

public class BackgroudController : MonoBehaviour
{
    public float _backgroundSpeed;
    public Renderer _backgroundRenderer;

    void Update()
    {
        _backgroundRenderer.material.mainTextureOffset += new Vector2(0f, _backgroundSpeed * Time.deltaTime);
    }
}
