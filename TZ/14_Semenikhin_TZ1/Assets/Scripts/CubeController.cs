using System.Collections;
using TMPro;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cpsText;
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private int _plusCount = 10;

    private bool _coroutineIsWork = false;

    public void Buy()
    {
        int cube = PlayerPrefs.GetInt("Cube");

        int cost = int.Parse(_costText.text);


        if (cube >= cost)
        {
            PlayerPrefs.SetInt("Cube", cube - int.Parse(_costText.text));

            _plusCount += int.Parse(_cpsText.text.Remove(0, 4));

            _cpsText.text = $"Cps: {_plusCount}";
            _countText.text = $"Count: {int.Parse(_countText.text.Remove(0, 6)) + 1}";

            _costText.text = (int.Parse(_costText.text) + cost).ToString();

            if (_coroutineIsWork == false)
            {
                StartCoroutine(PlusCube());
                _coroutineIsWork = true;
            }
        }
    }

    private IEnumerator PlusCube()
    {
        while (true)
        {
            GameController.UpdateStatsDelegate(_plusCount);
            yield return new WaitForSeconds(1);
        }
    }
}
