using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDrag()
    {
        // Получаем текущую позицию мыши в мировых координатах
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // Ограничиваем позицию платформы по оси X в пределах камеры
        float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + transform.localScale.x / 2f;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - transform.localScale.x / 2f;
        mousePos.x = Mathf.Clamp(mousePos.x, minX, maxX);

        // Устанавливаем новую позицию платформы
        transform.position = new Vector3(mousePos.x, transform.position.y, transform.position.z);
    }
}
