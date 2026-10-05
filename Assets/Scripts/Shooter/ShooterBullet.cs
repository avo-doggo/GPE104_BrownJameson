using UnityEngine;
using UnityEngine.Audio;

public class ShooterBullet : Shooter
{
    public Transform bulletSpawnPoint;

    public GameObject bulletPrefab;

    public AudioSource audioSource;

    public override void Shoot()
    {
        if (bulletSpawnPoint != null && bulletPrefab != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
        if (GameManager.instance != null)
        {
            audioSource.PlayOneShot(GameManager.instance.shootingSound, GameManager.instance.SFXVolume);
        }

   
    }

    public override void Start()
    {


    }

    public override void Update()
    {

    }
}
