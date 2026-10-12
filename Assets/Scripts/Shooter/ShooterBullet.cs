using UnityEngine;

public class ShooterBullet : Shooter
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public AudioSource audioSource;


    public override void Shoot()
    {
        // Create the bullet
        if (bulletSpawnPoint != null && bulletPrefab != null)
        {
            Instantiate(
                bulletPrefab,
                bulletSpawnPoint.position,
                bulletSpawnPoint.rotation
            );
        }


        // Play shooting sound
        if (GameManager.instance != null &&
            GameManager.instance.shootingSound != null &&
            audioSource != null)
        {
            audioSource.PlayOneShot(
                GameManager.instance.shootingSound,
                GameManager.instance.SFXVolume
            );
        }
    }


    public override void Start()
    {
    }


    public override void Update()
    {
    }
}