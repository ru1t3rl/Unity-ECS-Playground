using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Entities;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get { return instance ??= FindFirstObjectByType<GameManager>(); }
    }

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float xBound = 3f;
    [SerializeField] private float yBound = 3f;
    [SerializeField] private float ballSpeed = 3f;
    [SerializeField] private float respwanDelay = 2f;
    [SerializeField] private int[] playerScores;

    [SerializeField] private Label mainText;
    [SerializeField] private Label[] playerTexts;

    private Entity ballEntityPrefab;
    private EntityManager manager;

    private WaitForSeconds oneSecond;
    private WaitForSeconds delay;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        playerScores = new int[2];

        oneSecond = new WaitForSeconds(1f);
        delay = new WaitForSeconds(respwanDelay);

        var root = FindFirstObjectByType<UIDocument>().rootVisualElement;
        mainText = root.Q<Label>("Main");
        playerTexts = new[]
        {
            root.Q<Label>("Score_Player_01"),
            root.Q<Label>("Score_Player_02")
        };

        StartCoroutine(CountdownSpawnBall());
    }

    public void PlayerScored(int playerID)
    {
        playerScores[playerID]++;
        for (int i = 0; i < playerScores.Length && i < playerTexts.Length; i++)
        {
            playerTexts[i].text = playerScores[i].ToString();
        }

        StartCoroutine(CountdownSpawnBall());
    }

    private IEnumerator CountdownSpawnBall()
    {
        mainText.text = "Get Ready";
        yield return delay;

        mainText.text = "3";
        yield return oneSecond;

        mainText.text = "2";
        yield return oneSecond;

        mainText.text = "1";
        yield return oneSecond;

        SpawnBall();
    }

    private void SpawnBall()
    {
    }
}