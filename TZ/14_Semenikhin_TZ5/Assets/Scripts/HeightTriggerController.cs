using UnityEngine;
using TMPro;
using System.Collections;

public class HeightTriggerController : MonoBehaviour
{
    [SerializeField] private float _heightValue; 

    [SerializeField] private TextMeshProUGUI _heightText;

    private float _maxScore;

    private void Update()
    {
        _maxScore = float.Parse(_heightText.text);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Block"))
        {
            if (!collision.transform.GetComponent<Rigidbody2D>().isKinematic && _heightValue > _maxScore)
            {
                _heightText.text = _heightValue.ToString();
                _maxScore = _heightValue;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Block"))
        {
            if (!collision.transform.GetComponent<Rigidbody2D>().isKinematic)
            {
                _heightText.text = (float.Parse(_heightText.text) - _heightValue).ToString();
            }
        }
    }
}
