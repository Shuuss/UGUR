using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void ChangeScene(string _Ugur)
   {
        SceneManager.LoadScene(_Ugur);
   }

   public void Quit()
   {
        Application.Quit();
   }
}
