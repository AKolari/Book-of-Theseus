using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    public string sceneToLoad, exitName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("testing the exit scripts");
        PlayerPrefs.SetString("lastExitName", exitName);
        SceneManager.LoadScene(sceneToLoad);
    }
}
