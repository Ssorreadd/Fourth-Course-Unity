using System.Linq;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private GameObject _playerPlanform;
    [SerializeField] private Color[] _colors;

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            var playerRenderer = _playerPlanform.GetComponent<SpriteRenderer>();
            playerRenderer.color = _colors.Where(x => x != playerRenderer.color).First();
        }
    }
}
