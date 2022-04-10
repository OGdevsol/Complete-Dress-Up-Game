using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
   public void SelectLevel(int levelIndex)
   {
      PlayerPrefs.SetInt("SelectedLevel",levelIndex);
      SceneManager.LoadScene("Gameplay");
   }
}
