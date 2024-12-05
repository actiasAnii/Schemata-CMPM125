using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneTrans : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Overworld()
    {
        SceneManager.LoadScene("overworld");
    }

    public void Nightmare()
    {
        SceneManager.LoadScene("Nightmare Puzzle");
    }

    public void Resolution()
    {
        SceneManager.LoadScene("Resolution Puzzle");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
