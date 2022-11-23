using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject fadePanel;

    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 60;

        if (sharedInstance == null)
        {
            sharedInstance = this;
        } else
        {
            Destroy(sharedInstance);
        }
    }

    private void Start()
    {
        fadePanel.GetComponent<Animation>().Play();
        Cursor.visible = false;

    }
    public GameObject GetCamera()
    {
        return mainCamera;
    }

    public void TooglePause()
    {
        if (pauseScreen.activeInHierarchy)
        {
            pauseScreen.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
        } else
        {
            pauseScreen.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if (!fadePanel.GetComponent<Animation>().isPlaying)
        {
            fadePanel.SetActive(false);
        }
        
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
