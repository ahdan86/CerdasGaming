using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text enemyCountText;
    public static bool isOver = false;
    public void Setup(int enemyCount)
    {
        gameObject.SetActive(true);
        isOver = true;
        enemyCountText.text = enemyCount.ToString() + " Virus";
    }
}
