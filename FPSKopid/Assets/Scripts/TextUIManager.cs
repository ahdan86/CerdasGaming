using UnityEngine;
using UnityEngine.UI;

public class TextUIManager : MonoBehaviour
{
    public Text AmmoLeftText;
    public Text TotalAmmoText;
    public GameObject player;
    public Text enemyCountText;

    // Update is called once per frame
    void Update()
    {
        AmmoLeftText.text = player.GetComponent<PlayerShoot>().bulletsLeft.ToString();
        TotalAmmoText.text = player.GetComponent<PlayerShoot>().totalBullet.ToString();
        enemyCountText.text = FindObjectOfType<GameManager>().enemyDieCount.ToString();
    }
}
