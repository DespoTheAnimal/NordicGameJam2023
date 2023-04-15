using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanonShoot : MonoBehaviour
{
    public bool canonEnabled = false;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject shootFrom;
    public Transform playerPositionOfTheMechanic;

    [SerializeField] private GameInput gameInput;

    public int projectileSpeed = 10;
    public int destroyProjectileTime = 2;
    public float shotDelay = 2;
    private bool isShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Shoot_P1") && p1)
        {
            if (isShooting == false)
            {
                StartCoroutine(ShootDelay());
            }
        }

        if (Input.GetButtonDown("Shoot_P2") && p2)
        {
            if (isShooting == false)
            {
                StartCoroutine(ShootDelay());
            }
        }
    }

    private bool p1 = false;
    private bool p2 = false;


    public void EnableCanon(bool state, bool isPlayerOne)
    {
        if(state)
        {
            if(isPlayerOne)
            {
                p1 = true;
                p2 = false;
            }
            else
            {
                p1 = false;
                p2 = true;
            }
        }
        else
        {
            p1 = false;
            p2 = false;
        }

        //if(state)
        //{
        //    gameInput.PlayerInput.Controls.Shoot.performed += GameInput_Shoot;
        //}
        //else
        //{
        //    gameInput.PlayerInput.Controls.Shoot.performed -= GameInput_Shoot;
        //}

        //if (isPlayerOne)
        //{
        //    float x = Input.GetAxis("Horizontal_P1");
        //    readGoodValues = new Vector3(x, 0, 0);
        //}
        //else
        //{
        //    float x = Input.GetAxis("Horizontal_P2");
        //    readGoodValues = new Vector3(x, 0, 0);
        //}
    }



    private IEnumerator ShootDelay()
    {
        isShooting = true;
        Shoot();
        yield return new WaitForSeconds(shotDelay);
        isShooting = false;
    }

    private void Shoot()
    {
        GameObject temporaryBulletHandler;
        temporaryBulletHandler = Instantiate(bullet, shootFrom.transform.position, shootFrom.transform.rotation) as GameObject;

        Rigidbody temporaryRB;
        temporaryRB = temporaryBulletHandler.GetComponent<Rigidbody>();

        temporaryRB.AddForce(transform.right * projectileSpeed);

        Destroy(temporaryBulletHandler, destroyProjectileTime);
    }
}
