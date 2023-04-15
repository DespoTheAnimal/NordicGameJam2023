using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanonShoot : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject shootFrom;

    [SerializeField] private GameInput gameInput;

    public int projectileSpeed = 10;
    public int destroyProjectileTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        gameInput.PlayerInput.Controls.Shoot.performed += GameInput_Shoot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShootProjectile()
    {
        GameObject temporaryBulletHandler;
        temporaryBulletHandler = Instantiate(bullet, shootFrom.transform.position, shootFrom.transform.rotation) as GameObject;

        Rigidbody temporaryRB;
        temporaryRB = temporaryBulletHandler.GetComponent<Rigidbody>();

        temporaryRB.AddForce(transform.right * projectileSpeed);

        Destroy(temporaryBulletHandler, destroyProjectileTime);
    }

    void GameInput_Shoot(InputAction.CallbackContext callback)
    {
        ShootProjectile();
    }
}
