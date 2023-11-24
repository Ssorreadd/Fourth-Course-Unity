using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeedBuffer = 2;
    [SerializeField] private GameObject _moonBulletPrefab;
    [SerializeField] private GameObject _earthBulletPrefab;
    [SerializeField] private Transform _moonGun;
    [SerializeField] private Transform[] _earthGuns;

    private void Start()
    {
        StartCoroutine(MoonShoot());
        StartCoroutine(EarthShoot());
    }

    private void FixedUpdate()
    {
        var rotateZ = Input.GetAxis("Horizontal");

        transform.Rotate(new Vector3(0, 0, -rotateZ * _rotateSpeedBuffer));
    }


    private IEnumerator MoonShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.7f);

            GameObject moonBullet = Instantiate(_moonBulletPrefab, _moonGun.position, Quaternion.identity, transform);

            moonBullet.GetComponent<Rigidbody2D>().velocity = -transform.right * 2.5f;
            moonBullet.transform.parent = null;
        }
    }

    private IEnumerator EarthShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);

            foreach (var gun in _earthGuns)
            {
                GameObject earthBullet = Instantiate(_earthBulletPrefab, gun.position, Quaternion.identity, transform);

                earthBullet.GetComponent<Rigidbody2D>().velocity = -transform.right * 10.2f;
                earthBullet.transform.parent = null;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerPrefs.SetString("Leaders",
                $"{PlayerPrefs.GetString("Nickname")}: 0 оч.\n{PlayerPrefs.GetString("Leaders")}");

            SceneManager.LoadScene("MenuScene");
        }
    }
}
