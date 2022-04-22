using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenceManganger : MonoBehaviour
{
    public void Play(string name)
    {
        GetComponent<AudioSource>().Play();
        if (name == "Help")
        {
            Invoke(nameof(Help), 0.7f);
        }
       else if (name == "Lina")
        {
            Invoke(nameof(Lina), 0.7f);
        }
       else if (name == "Menu")
        {
            Invoke(nameof(Menu), 0.7f);
        }
    }
    public void Help()
    {
        SceneManager.LoadScene(1);
    }
    public void Lina()
    {
        SceneManager.LoadScene(2);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
