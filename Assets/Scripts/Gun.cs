using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] public float damage = 50f;
    [SerializeField] public float range = 100f;
    [SerializeField] public float fireRate = 1f;
    [SerializeField] public ParticleSystem muzzleFlash;
    [SerializeField] public GameObject impactFlash;
    [SerializeField] private Camera fpsCamera;
    [SerializeField] private Player owner;

    private float nextTimeToFire = 0f;
    private bool canShoot = false;

    public void Shoot() 
    {
        if(owner.IsDead) return;

        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Zombie target = hit.transform.GetComponent<Zombie>();
            if (target != null)
            {
                target.ReceiveDamage(damage);
            }
        }

        canShoot = false;
        GameObject impactEffect = Instantiate(impactFlash, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactEffect, 2f);
    }

    private void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            canShoot = true;
        }
    }
}