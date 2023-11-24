using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TripolyBase", menuName = "TripolyBase")]
public class TripolyBaseScript : ScriptableObject
{
    public List<TripolyType> tripolies;
    
    public void SetRectColors(Button[] buttons, Image background, TripolyType tripoly)
    {
        foreach (var button in buttons)
        {
            switch (button.tag)
            {
                case "TopTripoly":
                    button.image.color = tripoly.topColor;
                    break;
                case "LeftTripoly":
                    button.image.color = tripoly.leftColor;
                    break;
                case "RightTripoly":
                    button.image.color = tripoly.rightColor;
                    break;
            }
        }

        background.color = tripoly.backgroundColor;
    }
}
