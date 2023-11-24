using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _clicksText;
    [SerializeField] private TextMeshProUGUI _cubes;

    private Player _player = Player.GetContext();

    void Start()
    {
        
    }

    public void PlusCubeCount(int amount)
    {
        _player.Info.CubeCount += amount;

        _cubes.text = $"Cube: {_player.Info.CubeCount}";
    }
}
