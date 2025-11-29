using System.Collections;
using UnityEngine;

public class Canon : MonoBehaviour
{

    public GameObject projectilePrefab;

    //Time between shooting
    public float timeBeforeShooting;

    private bool canShoot;


    //Spawnpoint for projectiles
    public Transform spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canShoot = false;
        StartCoroutine(WaitForShooting());


    }

    // Update is called once per frame
    void Update()
    {

        if (canShoot)
        {
           GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().direction = transform.right;
            canShoot=false;
            StartCoroutine(WaitForShooting());

        }

    }

    IEnumerator WaitForShooting()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(timeBeforeShooting);
        canShoot = true;
        print("WaitAndPrint " + Time.time);
    }
}
