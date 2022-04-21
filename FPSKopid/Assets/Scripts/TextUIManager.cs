using UnityEngine;
using UnityEngine.UI;

public class TextUIManager : MonoBehaviour
{
    public Text AmmoLeftText;
    public Text TotalAmmoText;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        AmmoLeftText.text = player.GetComponent<PlayerShoot>().bulletsLeft.ToString();
        TotalAmmoText.text = player.GetComponent<PlayerShoot>().totalBullet.ToString();
    }
}
