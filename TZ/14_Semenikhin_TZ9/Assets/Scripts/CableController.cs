using System.Collections;
using UnityEngine;

public class CableController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(RotateCable());
    }

    private IEnumerator RotateCable() 
    { 

        while (true)
        {
            do
            {
                transform.Rotate(new Vector3(0, 0, 0.25f));
                yield return new WaitForSeconds(0.01f);

            } while (Mathf.Round(transform.eulerAngles.z) != 19);

            yield return new WaitForSeconds(0.1f);

            do
            {
                transform.Rotate(new Vector3(0, 0, -0.25f));
                yield return new WaitForSeconds(0.01f);

            } while (Mathf.Round(transform.eulerAngles.z) != 340);

            yield return new WaitForSeconds(0.1f);

        }
    } 
}
