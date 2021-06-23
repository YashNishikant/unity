using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunEquip : MonoBehaviour
{
    public GameObject player;
    public Camera maincamera;
    float delay;
    RaycastHit hitGun;
    public float animationDelay = 0;
    public ParticleSystem muzzleFlash;
    public ParticleSystem bulletTrail;
    public GameObject impactEffect;
    Animator gunAnimator;
    bool canShoot;
    void Start()
    {
        gunAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        delay++;
        if(delay == 10) {
            canShoot = true;
            delay = 0;
        }
        if (canShoot) {
            shooting();
        }
    }

    void shooting()
    {

        if (Input.GetMouseButtonDown(0) && !FindObjectOfType<UI>().quitmenu)
        {
            muzzleFlash.Play();
            bulletTrail.Play();
            gunAnimator.SetTrigger("Shoot");

            if (Physics.Raycast(maincamera.transform.position, maincamera.transform.TransformDirection(Vector3.forward), out hitGun, 200)) {
                GameObject impact = Instantiate(impactEffect, hitGun.point, Quaternion.LookRotation(hitGun.normal)) as GameObject;
                Destroy(impact, 0.1f);
            }

            for (int i = 0; i < FindObjectOfType<WorldGen>().zombieArray.Count; i++) {

                if (Physics.Raycast(maincamera.transform.position, maincamera.transform.TransformDirection(Vector3.forward), out hitGun, 200) && hitGun.collider.gameObject == FindObjectOfType<WorldGen>().zombieArray[i] && (!FindObjectOfType<WorldGen>().zombieArray[i].GetComponent<EnemyScript>().dead)) {
                    hitGun.rigidbody.AddForce(player.transform.forward * 500);
                    FindObjectOfType<UI>().score++;
                    FindObjectOfType<WorldGen>().zombieArray[i].GetComponent<EnemyScript>().dead = true;
                }
                else if (Physics.Raycast(maincamera.transform.position, maincamera.transform.TransformDirection(Vector3.forward), out hitGun, 200) && hitGun.collider.gameObject == FindObjectOfType<WorldGen>().zombieArray[i] && (FindObjectOfType<WorldGen>().zombieArray[i].GetComponent<EnemyScript>().dead)) { 
                    hitGun.rigidbody.AddForce(player.transform.forward * 100);
                }
            }
        }
    }
}