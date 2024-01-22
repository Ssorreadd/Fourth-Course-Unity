using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void Exit()
    {
        PlayerPrefs.SetString("Leaders",
            $"{PlayerPrefs.GetString("Nickname")}: {Random.Range(0, 50)} Легко\n{PlayerPrefs.GetString("Leaders")}");
        SceneManager.LoadScene("MenuScene");
    }
}
