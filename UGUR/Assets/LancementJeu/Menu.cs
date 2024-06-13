using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void ChangeScene(string Tanguy)
   {
        SceneManager.LoadScene(Tanguy);
   }

   public void Quit()
   {
        Application.Quit();
   }
   public void ResetTheGame()
    {
        SceneManager.LoadScene("Tanguy");
      
    }
}