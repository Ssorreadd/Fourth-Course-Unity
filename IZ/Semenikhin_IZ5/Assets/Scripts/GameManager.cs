using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _neededColorText;
    [SerializeField] TextMeshProUGUI _scoreCountText;
    [SerializeField] Transform[] _cubesRow;

    private Color[] _colors = {Color.red, Color.green, Color.blue};

    private Color _selectedColor;

    void Start()
    {
        StartGame();
    }

    private void StartGame ()
    {
        foreach (var row in _cubesRow)
        {
            foreach (var cube in row.transform.GetComponentsInChildren<SpriteRenderer>())
            {
                cube.color = _colors[Random.Range(0, _colors.Length)];
            }
        }

        _selectedColor = _colors[Random.Range(0, _colors.Length)];
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
