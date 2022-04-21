using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    public float xRotation = 0f;
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update(){

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        //Debug.Log("x:" + mouseX + ", y:" + mouseY);

        //kalkulasi rotasi kamera (liat atas bawah, player gk ikut kamera doang)
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0 ,0);
        //kalkulasi rotasi player (liat kiri kanan, kamera pasti bakal ngikut)
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
