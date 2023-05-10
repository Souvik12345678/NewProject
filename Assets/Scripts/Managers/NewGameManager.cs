using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NewGameManager : MonoBehaviour
{
    public enum GameState { RUNNING, PAUSED, OVER }
    public enum GameMode { ENDLESS, ENDFUL }

    public GameState gameState;
    public GameMode currentGameMode;

    public PlayerScript2 player;
    public GameObject gameOverText;
    public GameObject endlessModeGameOverPanel;

    public DistanceCounter playerDistCounter;

    public AudioManager audioManager;

    private void OnEnable()
    {
        player.OnDed += OnPlayerDied;
    }

    private void OnDisable()
    {
        player.OnDed -= OnPlayerDied;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.RUNNING;
        audioManager.PlayRandomBgm();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            OnGameRestart();
        }
    }

    void OnPlayerDied() 
    {
        OnGameOver();    
    }

    //------------------
    //Game core events
    //------------------

    void OnGameOver()
    {
        //Debug.Log("Game Over");
        gameState = GameState.OVER;

        //gameOverText.SetActive(true);
        DisplayModalGameOverPanel();
    }

    void OnGameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void DisplayModalGameOverPanel()
    {
        if (currentGameMode == GameMode.ENDLESS)
        {
            endlessModeGameOverPanel.SetActive(true);
            endlessModeGameOverPanel.transform.Find("DistanceLabel").GetComponent<TMP_Text>().text = "Distance: " + playerDistCounter.prettyDistance;
            
            
        
        }
    }

}
