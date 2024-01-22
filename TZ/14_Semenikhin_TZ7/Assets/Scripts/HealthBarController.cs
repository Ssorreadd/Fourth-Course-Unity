using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Image _healthBar; // ������ �� UI-������� ������� ��������

    public void SetHealth(float percentage)
    {
        percentage = Mathf.Clamp01(percentage);

        _healthBar.rectTransform.sizeDelta = new Vector2(_healthBar.rectTransform.sizeDelta.x, percentage * _healthBar.rectTransform.sizeDelta.y);
    }
}
