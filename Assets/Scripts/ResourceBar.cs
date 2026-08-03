using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceBar : MonoBehaviour
{
    public static ResourceBar instance;

    [Header("Resource Bar")]
    public Slider resourceSlider;
    public float maxResource = 100f;
    private float currentResource;

    [Header("Drain Settings")]
    public float drainAmount = 5f;
    public float drainInterval = 3f;
    private float drainTimer;

    [Header("Game Over")]
    public TextMeshProUGUI gameOverText;

    private bool isGameOver = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentResource = 15f;
        resourceSlider.maxValue = maxResource;
        resourceSlider.value = currentResource;

        drainTimer = drainInterval;

        // Make sure the text is hidden at the start
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isGameOver) return;

        drainTimer -= Time.deltaTime;

        if (drainTimer <= 0f)
        {
            currentResource -= drainAmount;

            if (currentResource <= 0f)
            {
                currentResource = 0f;
                TriggerGameOver();
            }

            resourceSlider.value = currentResource;
            drainTimer = drainInterval;
        }
    }

    private void TriggerGameOver()
    {
        isGameOver = true;

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "You ran out of battery and fuel power, you lose!";
            gameOverText.color = Color.red;
        }
    }

    public void AddBattery(float amount)
    {
        if (isGameOver) return;

        currentResource += amount;

        if (currentResource > maxResource)
            currentResource = maxResource;

        resourceSlider.value = currentResource;
    }

    public void AddCanister(float amount)
    {
        if (isGameOver) return;

        currentResource += amount;

        if (currentResource > maxResource)
            currentResource = maxResource;

        resourceSlider.value = currentResource;
    }
}

