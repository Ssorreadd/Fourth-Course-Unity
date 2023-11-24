using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private bool _canDrag = true;

    private void OnMouseDown()
    {
        if (_canDrag)
        {
            transform.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    private void OnMouseUp()
    {
        if (_canDrag)
        {
            _canDrag = false;
            transform.GetComponent<Rigidbody2D>().isKinematic = false;

            GameManager.SpawnBlockDelegate();
        }
    }

    private void OnMouseDrag()
    {
        if (_canDrag)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var blockPose = transform.position;

            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }
}
