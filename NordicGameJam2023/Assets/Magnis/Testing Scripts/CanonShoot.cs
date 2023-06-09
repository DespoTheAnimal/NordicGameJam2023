using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class CanonShoot : MonoBehaviour
{
    private PlayerController playerController;

    public bool canonEnabled = false;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject shootFrom;
    [SerializeField] private Animator animator;

    private bool isPlayerOne;



    public int projectileSpeed = 10;
    public int destroyProjectileTime = 2;
    public float shotDelay = 2;
    private bool isShooting = false;
    

    
    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        isPlayerOne = playerController.isPlayerOne;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerOne)
        {
            if (Input.GetButtonDown("Shoot_P1")) // and if have ammo
            {
                if (isShooting == false)
                {
                    StartCoroutine(ShootDelay());
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Shoot_P2"))
            {
                if (isShooting == false)
                {
                    StartCoroutine(ShootDelay());
                }
            }
        }

    }



    private IEnumerator ShootDelay()
    {
        isShooting = true;
        animator.SetTrigger("isShooting");
        Shoot();
        yield return new WaitForSeconds(shotDelay);
        isShooting = false;
    }
    [SerializeField] private GameObject muzzleFlash;
    private void Shoot()
    {
        GameObject clone = Instantiate(muzzleFlash, shootFrom.transform.position, shootFrom.transform.rotation);

        GameObject temporaryBulletHandler;
        temporaryBulletHandler = Instantiate(bullet, shootFrom.transform.position, shootFrom.transform.rotation) as GameObject;

        if(isPlayerOne)
        {
            temporaryBulletHandler.name = "P1";
        }
        else
        {
            temporaryBulletHandler.name = "P2";
        }

        Rigidbody temporaryRB;
        temporaryRB = temporaryBulletHandler.GetComponent<Rigidbody>();

        temporaryRB.AddForce(transform.up * projectileSpeed);

        Destroy(temporaryBulletHandler, destroyProjectileTime);
    }
}
