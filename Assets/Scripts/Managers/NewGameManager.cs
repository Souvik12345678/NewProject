using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameManager : MonoBehaviour
{
    public enum GameState { RUNNING, PAUSED, OVER }

    public GameState gameState;

    public PlayerScript2 player;
    public GameObject gameOverText;

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

        gameOverText.SetActive(true);
    }

    void OnGameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
