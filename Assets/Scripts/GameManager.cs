using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables
    public int hp = 3;
    public int currentLevel;

    public Transform transition;
    Vector3 targetScale;
    
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip gameOverSound;
    AudioSource source;

    public List<string> levels;
    #endregion
    // singleton

    public static GameManager instance;
    
    private bool hasWon;

    private void Start()
    {
        Application.targetFrameRate = 60;
        source = GetComponent<AudioSource>();

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

    private void Update()
    {
        transition.localScale = Vector3.MoveTowards(transition.localScale, targetScale, 75 * Time.deltaTime);
    }

    public void Win()
    {
        hasWon = true;
        currentLevel++;
        targetScale = Vector3.one * 50;
        source.PlayOneShot(winSound);
        Invoke("LoadNextLevel", 0.6f);

    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(levels[currentLevel]);
        targetScale = Vector3.zero;
        hasWon = false;
    }

    public void Lose()
    {
        if (!hasWon)
        {
            targetScale = Vector3.one * 50;
            hp--;
            if (hp <= 0)
            {
                source.PlayOneShot(gameOverSound);
                currentLevel = 0;
                hp = 3;
            }
            else
               source.PlayOneShot(loseSound);
        
            Invoke("LoadNextLevel", 0.6f);
        }
    }
}
