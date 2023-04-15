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
        
    }

    public void EnableCanon(bool state)
    {
        if(state)
        {
            gameInput.PlayerInput.Controls.Shoot.performed += GameInput_Shoot;
        }
        else
        {
            gameInput.PlayerInput.Controls.Shoot.performed -= GameInput_Shoot;
        }
    }

    void GameInput_Shoot(InputAction.CallbackContext callback)
    {
        if (isShooting == false)
        {
            StartCoroutine(ShootDelay());
        }
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
