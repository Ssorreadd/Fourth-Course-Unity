using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cpsText;
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private TextMeshProUGUI _costText;

    [SerializeField] private Button _cudeButton;

    [SerializeField] private int _startCost;
    [SerializeField] private int _increaseCost;
    [SerializeField] private int _buffPerSecond;

    private void Start()
    {
        _cudeButton.onClick.AddListener(() => Buy());
    }

    private void Buy()
    {
        if (true)
        {

        }
    }

    private IEnumerator Buff()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            //manager void
        }
    }
}
