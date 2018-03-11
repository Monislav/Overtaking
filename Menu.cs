using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public void GameMenu(string Level)
    {
        SceneManager.LoadScene(Level);
    }
}
