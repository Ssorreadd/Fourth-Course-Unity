using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject[] _tripoliesPrefs;
    [SerializeField] private TripolyBaseScript _tripolyBase;

    private void Start()
    {
        for (int i = 0; i < _tripoliesPrefs.Length; i++)
        {
            var tripoly = _tripoliesPrefs[i];

            _tripolyBase.SetRectColors(tripoly.GetComponentsInChildren<Button>(),
                tripoly.GetComponent<Image>(),
                _tripolyBase.tripolies[i]);

        }
    }
}
