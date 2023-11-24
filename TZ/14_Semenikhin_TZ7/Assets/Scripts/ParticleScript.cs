using System.Collections;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Dead());
    }

    private IEnumerator Dead()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
