
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDGame : MonoBehaviour
{
    public TMP_Text textoLevel;
    public TMP_Text textoHealth;
    public static int shootCounter = 0;
    public static int healthCounter = 1000;
    
    void Update()
    {
        textoLevel.text = "Level: " + shootCounter.ToString(); ;
        textoHealth.text = "Health: " + healthCounter.ToString(); ;
    }
}
