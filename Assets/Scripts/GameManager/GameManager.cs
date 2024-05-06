using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

/// <summary>
/// Local game manager yang digunakan pada scene permainan.
/// </summary>

public class GameManager : MonoBehaviour
{
    [Header("Sync")]
    [Tooltip("Banyak perahu yang ada pada scene permainan.")]
    [SerializeField] public List<Movement> boats = new List<Movement>();

    [Tooltip("Text. Berada pada bagian canvas -> countDownPanel.")]
    [SerializeField] private TextMeshProUGUI countDownText;
    [Tooltip("Panel. Berada pada bagian canvas.")]
    [SerializeField] private GameObject countDownPanel;

    [Tooltip("Panel. Berada pada bagian canvas.")]
    [SerializeField] private GameObject pausePanel;

    [Tooltip("Panel. Berada pada bagian canvas.")]
    [SerializeField] private GameObject pauseButton;

    [Tooltip("Panel. Berada pada bagian canvas.")]
    [SerializeField] private GameObject winPanel;

    [Tooltip("Panel. Berada pada bagian canvas.")]
    [SerializeField] private GameObject losePanel;

    [Tooltip("Panel. Berada pada bagian canvas.")]
    [SerializeField] private GameObject UIPanel;

    [Tooltip("Nama scene home")]
    [SerializeField] private string homeSceneName = "Home";

    [Tooltip("Current level")]
    [SerializeField] private int level;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    private bool onPause;

    [SerializeField] string music;
    [SerializeField] string winSFX;
    [SerializeField] string loseSFX;
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    #endregion
    #region GameplayManager
    private void Start()
    {
        // UI Check
        countDownText.text = "";
        countDownPanel.SetActive(true);

        pausePanel.SetActive(false);
        pauseButton.SetActive(false);

        winPanel.SetActive(false);
        losePanel.SetActive(false);

        UIPanel.SetActive(true);

        if (AudioManager.instance != null) AudioManager.instance.Play(music);
        // Start the game on 1f
        Invoke("StartTheGame", 1f);
    }

    private void StartTheGame()
    {
        StartCoroutine(StartAnim());
    }

    IEnumerator StartAnim()
    {
        if (AudioManager.instance != null) AudioManager.instance.Play("Countdown");
        // Animation
        countDownText.text = "1";
        yield return new WaitForSeconds(1f);

        countDownText.text = "2";
        yield return new WaitForSeconds(1f);

        countDownText.text = "3";
        yield return new WaitForSeconds(1f);

        countDownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        countDownText.text = "";
        countDownPanel.SetActive(false);

        // Make the boat avaliable to move
        foreach (Movement boat in boats)
        {
            boat.isStart = true;
        }

        yield return new WaitForSeconds(1f);
        pauseButton.SetActive(true);
    }

    // Ketika player boat berhasil sampai jalur finish
    public void PlayerFinish(int ranking)
    {
        if(ranking == 1)
        {
            winPanel.SetActive(true);
            UIPanel.SetActive(false);

            PlayerPrefs.SetInt($"Level{level+1}", 1);
            if (AudioManager.instance != null) AudioManager.instance.Play(winSFX);
        }
        else
        {
            losePanel.SetActive(true);
            UIPanel.SetActive(false);
            if (AudioManager.instance != null) AudioManager.instance.Play(loseSFX);
        }
    }
    #endregion

    #region GameSystem
    // Scene manager. Change to home scene.
    public void HomeScene()
    {
        if (onPause)
            Unpause();

        SceneManager.LoadScene(homeSceneName, LoadSceneMode.Single);
    }

    public void Pause()
    {
        Time.timeScale = 0f;

        UIPanel.SetActive(false);

        onPause = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;

        UIPanel.SetActive(true);

        onPause = false;
    }

    public void Restart()
    {
        if (onPause)
            Unpause();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    public void EndCameraFollow()
    {
        cinemachineVirtualCamera.Follow = null;
    }
    public void LoadNext()
    {
        Loader.Scene loadedScene = Loader.LoadedSceneData.Scene;
        Loader.Load(loadedScene + 1);
        // Get the current scene index
        // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene
        // SceneManager.LoadScene(currentSceneIndex + 1);
    }
    #endregion
}
