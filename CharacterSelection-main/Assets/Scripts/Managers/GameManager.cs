using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    None,
    Gameplay,
    Credits,
}

public class GameManager : MonoBehaviour
{
    private PlayerState playerState;
    public static GameManager instance { get; private set; }

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
        if (playerState == PlayerState.DEAD && gameState == GameState.Credits)
        {
            playerLostUI.SetActive(true);
        }

        if (playerState == PlayerState.ALIVE && numberOfEnemies <= 0)
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

}
