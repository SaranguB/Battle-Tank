using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    None,
    Gameplay,
    Credits,
}

public class GameManager : MonoBehaviour
{
    private PlayerState playerState;

    private static GameManager instance;
    public static GameManager Instance {  get { return instance; } }

    [SerializeField] private GameObject playerLostUI;
    [SerializeField] private GameObject playerWonUI;

    private EnemySpawner enemySpawner;
    private GameState gameState;
    private int numberOfEnemies;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        playerState = PlayerState.ALIVE;
        numberOfEnemies = 5;
        enemySpawner = FindObjectOfType<EnemySpawner>();
        gameState = GameState.Gameplay;
    }

    private void Update()
    {
        if (playerState == PlayerState.DEAD && gameState == GameState.Credits && !playerWonUI.activeInHierarchy)
        {
            playerLostUI.SetActive(true);
        }

        if (playerState == PlayerState.ALIVE && numberOfEnemies <= 0 && !playerLostUI.activeInHierarchy)
        {
            gameState = GameState.Credits;
            playerWonUI.SetActive(true);
        }
    }

    public void SpawnEnemy()
    {
        StartCoroutine(EnemySpawnCoroutine(5, 3f));
    }

    private IEnumerator EnemySpawnCoroutine(int count, float time)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(time);

            enemySpawner.SpawnEnemy();
        }
    }

    public void SetGameState(GameState state)
    {
        gameState = state;
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public PlayerState GetPlayerState()
    {
        return playerState;
    }

    public void SetPlayerState(PlayerState state)
    {
        this.playerState = state;
    }

    public void ReduceEnemyCount()
    {
        if (numberOfEnemies > 0)
            numberOfEnemies--;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

}
