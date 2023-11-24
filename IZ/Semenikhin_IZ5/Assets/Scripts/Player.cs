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
        // �������� ������� ������� ���� � ������� �����������
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // ������������ ������� ��������� �� ��� X � �������� ������
        float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + transform.localScale.x / 2f;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - transform.localScale.x / 2f;
        mousePos.x = Mathf.Clamp(mousePos.x, minX, maxX);

        // ������������� ����� ������� ���������
        transform.position = new Vector3(mousePos.x, transform.position.y, transform.position.z);
    }
}
