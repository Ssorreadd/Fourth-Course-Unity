using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _budgetText;
    [SerializeField] private RectTransform _prefab;
    [SerializeField] private Transform _picturesPanel;
    [SerializeField] private GalleryBase _galleryBase;

    private float _playerBudget = 0f;

    void Start()
    {
        FillList();
    }

    private void FillList()
    {
        foreach (var picture in _galleryBase.pictures)
        {
            RectTransform item = Instantiate(_prefab, _picturesPanel);

            (item.Find("NameText").GetComponent<Text>()).text = picture.name;
            (item.Find("AuthorText").GetComponent<Text>()).text = picture.author;
            (item.Find("DescriptionText").GetComponent<Text>()).text = picture.description;
            (item.Find("CostText").GetComponent<Text>()).text = picture.cost.ToString() + "$";

            var itemButton = item.GetComponent<Button>();
            itemButton.onClick.AddListener(() => Buy(itemButton));
        }
    }

    private void Buy(Button button)
    {
        var pictureCost = float.Parse(button.transform.Find("CostText").GetComponent<Text>().text.Replace('$', ' ').Trim());

        _playerBudget += pictureCost - (pictureCost * 0.13f);

        _budgetText.text = $"Ваш баланс: " +
            $"{_playerBudget}$";

        button.gameObject.SetActive(false);
    }
}
