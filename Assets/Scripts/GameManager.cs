using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int hp = 3;
    public int currentLevel;

    public List<string> levels;

    // singleton

    public static GameManager instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Win()
    {
        Invoke("LoadNextLevel", 0.5f);
    }

    void LoadNextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(levels[currentLevel]);
    }

    public void Lose()
    {
        hp--;
        if (hp == 0)
        {
            currentLevel = 0;
            hp = 3;
        }
        SceneManager.LoadScene(levels[currentLevel]);
    }
}
