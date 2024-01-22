using UnityEngine;
using UnityEngine.SceneManagement;

public class FinisihController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 1000);
            PlayerPrefs.SetInt("lastOpenLevel", 2);

            SceneManager.LoadScene("Menu");
        }
    }
}
