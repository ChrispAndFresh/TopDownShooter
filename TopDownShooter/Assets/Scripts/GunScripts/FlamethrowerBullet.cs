using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerBullet : MonoBehaviour
{
    public float bulletTime;
    public float destructionDelay;

    private void Awake()
    {

        StartCoroutine(DestroyBulletAfter(bulletTime + Random.Range(-destructionDelay, destructionDelay)));
    }


    public IEnumerator DestroyBulletAfter(float seconds)
    {
        //Wait x amount of seconds and then destroy flamethrower bullet
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
