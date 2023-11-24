using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelecterController : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    private void OnEnable()
    {
        string openLevels = PlayerPrefs.GetString("OpenLevels");

        for (int i = 2; i <= _buttons.Length; i++)
        {
            _buttons[i - 1].interactable = openLevels.Contains(i.ToString());
        }
    }
}
