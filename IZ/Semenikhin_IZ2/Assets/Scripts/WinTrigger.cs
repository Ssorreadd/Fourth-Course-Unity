using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("win");
        if (collision.gameObject.name == "Player")
            _winText.gameObject.SetActive(true);
    }
}
