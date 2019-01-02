using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public void doQuit()
    {
        Application.Quit();
    }
    public void restart()
    {
        SceneManager.LoadScene("Level1");
    }
}
