using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [Range(0.3f, 1.0f)]
    private float fireRate = 0.3f;
    [Range(1,10)]
    private int damage = 1;

    private float timer;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    [SerializeField]
    private AudioSource gunFireSource;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        muzzleParticle.Play();
        gunFireSource.Play();

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);

        Debug.DrawRay(ray.origin, ray.direction * 25, Color.red, 2.0f);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 25))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
                health.TakeDamage(damage);
        }
    }
}
