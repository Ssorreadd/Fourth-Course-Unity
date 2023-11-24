using UnityEngine;

public class CoupleController : MonoBehaviour
{
    private void OnMouseUp()
    {
        if (Time.timeScale != 0)
            GameController.SetCoupleDelegate(gameObject);
    }
}
