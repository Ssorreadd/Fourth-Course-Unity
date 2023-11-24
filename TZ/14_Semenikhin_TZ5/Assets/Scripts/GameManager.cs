using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nicknameLabel;
    [SerializeField] private Transform _spawnContainer;
    [SerializeField] private GameObject[] _blockPrefabs;

    public delegate void Method();

    public static Method SpawnBlockDelegate;

    private void Start()
    {
        _nicknameLabel.text = $"Nickname: {PlayerPrefs.GetString("Nickname")}";
        SpawnBlockDelegate = SpawnBlock;

        SpawnBlock();
    }

    private void Update()
    {
        
    }

    private void SpawnBlock()
    {
        var spawnPrefab = _blockPrefabs[Random.Range(0, _blockPrefabs.Length)];

        var block = Instantiate(spawnPrefab, _spawnContainer);
    }
}
