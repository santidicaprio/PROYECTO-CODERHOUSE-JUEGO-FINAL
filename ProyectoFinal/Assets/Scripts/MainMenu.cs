
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioS;
   public void Play()
    {
        SceneManager.LoadScene(1);
    }

   public void Quit()
   {
        Application.Quit();

   }
    public void PlaySound(AudioClip _clip)
    {
        audioS.clip = _clip;
        audioS.Play();

    }
 


   
}
