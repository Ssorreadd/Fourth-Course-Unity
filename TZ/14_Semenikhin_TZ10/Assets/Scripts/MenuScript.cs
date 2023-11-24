using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private TripolyBaseScript _tripolyBase;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Image _background;

    private void Start()
    {
        _tripolyBase.SetRectColors(_buttons, _background, _tripolyBase.tripolies[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
