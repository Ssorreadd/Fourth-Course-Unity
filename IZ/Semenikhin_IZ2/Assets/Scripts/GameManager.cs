using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _keysPanel;
    [SerializeField] private TextMeshProUGUI _winText;

    private bool[] _haveKeys = { false, false, false };

    internal void ShowKey(GameObject key)
    {
        _keysPanel.Find(key.gameObject.name).gameObject.SetActive(true);

        key.gameObject.SetActive(false);

        switch (key.gameObject.name)
        {
            case "RedKey":
                _haveKeys[0] = true;
                break;
            case "GreenKey":
                _haveKeys[1] = true;
                break;
            case "BlueKey":
                _haveKeys[2] = true;
                break;
        }
    }

    internal void OpenDoor(GameObject door)
    {
        switch (door.gameObject.name)
        {
            case "RedDoor":
                if (_haveKeys[0])
                    door.gameObject.SetActive(false);
                break;
            case "GreenDoor":
                if (_haveKeys[1])
                    door.gameObject.SetActive(false);
                break;
            case "BlueDoor":
                if (_haveKeys[2])
                    door.gameObject.SetActive(false);
                break;
        }
    }

    internal void WinEvent()
    {
        _winText.gameObject.SetActive(true);
    }
}
