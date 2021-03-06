using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;

    public float shootForce, upwardForce;

    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    public int bulletsLeft, bulletsShot, totalBullet;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;

    public bool allowInvoke = true;
    public bool click_pressed = false;
    public bool r_pressed = false;

    public float arcRange = 1f;

    void Awake()
    {
        bulletsLeft = magazineSize;
        totalBullet = 90;
        bulletsShot = 0;
        readyToShoot = true;
    }

    void Update()
    {
        if (!PauseScreen.isPaused)
        {
            if (Input.GetKey(KeyCode.R))
            {
                r_pressed = true;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                click_pressed = true;
            }
            //Debug.Log(bulletsLeft);
            MyInput();
        }
    }

    public void MyInput()
    {
        if (allowButtonHold) shooting = click_pressed;
        else
        {
            shooting = click_pressed;
            click_pressed = false;
        }

        if (r_pressed && bulletsLeft < magazineSize && !reloading && totalBullet > 0) Reload();
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0 && totalBullet > 0) Reload();

        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            // Debug.Log("Masuk Pak Eko");
            // Debug.Log(bulletsShot);
            // bulletsShot = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        currentBullet.transform.forward = directionWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        iTween.PunchPosition(currentBullet, new Vector3(Random.Range(-arcRange, arcRange),Random.Range(-arcRange, arcRange),0), Random.Range(0.5f, 2));


        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        //Debug.Log("reloading");
        if (totalBullet < bulletsShot) bulletsLeft += totalBullet;
        else bulletsLeft += bulletsShot;
        totalBullet -= bulletsShot;

        if(totalBullet<0) totalBullet = 0;
        
        reloading = false;
        r_pressed = false;
        bulletsShot = 0;
    }
}
