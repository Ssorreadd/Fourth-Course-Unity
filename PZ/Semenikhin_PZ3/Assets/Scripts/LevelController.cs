using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private string _nextLevelName;

    private Monster[] _monsters;

    private void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();
    }

    void Update()
    {
        if (IsAllMonstersDead())
            GoNextLevel();
    }

    private void GoNextLevel()
    {
        Debug.Log($"Go to level {_nextLevelName}");

        SceneManager.LoadScene(_nextLevelName);
    }

    private bool IsAllMonstersDead()
    {
        foreach (Monster monster in _monsters)
        {
            if (monster.gameObject.activeSelf)
                return false;
        }

        return true;
    }
}
