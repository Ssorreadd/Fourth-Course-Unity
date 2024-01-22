using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform _rotatable;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private float _rotateSpeed = 5;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rotatable.Rotate(new Vector3(0, 0, (_rotatable.position.z + _rotateSpeed) * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rotatable.Rotate(new Vector3(0, 0, (_rotatable.position.z - _rotateSpeed) * Time.deltaTime));
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Shop()
    {
        PlayerPrefs.SetString("PrevScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Shop");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Continue()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
