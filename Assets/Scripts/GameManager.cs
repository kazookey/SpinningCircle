using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreTMP;
    public GameObject gameOverTMP;

    private int score = 0;
    private bool isGameOver = false;
    private InputAction clickAction;

    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        clickAction = new InputAction(type: InputActionType.Button, binding: "<Mouse>/leftButton");
        clickAction.performed += _ => OnClick();
        clickAction.Enable();
    }

    void OnDisable()
    {
        clickAction.Disable();
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;
        score += amount;
        scoreTMP.text = "Score: " + score;
    }

    public void TriggerGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        gameOverTMP.SetActive(true);

       
        Spawner spawner = FindObjectOfType<Spawner>();
        if (spawner != null)
        {
            spawner.StopSpawning();
        }
    }

    private void OnClick()
    {
        if (isGameOver)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
