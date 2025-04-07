using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool isDragging = false;
    private GameManager gameManager;
    public int coinType; // 1表示第一种金币，2表示第二种金币
    private bool isInsideTargetArea = false; // 标记金币是否在目标区域内

    private void Awake()
    {
        GameObject gameManagerObject = GameObject.Find("GameManager");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        else
        {
            Debug.LogError("GameManager not found!");
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        if (isInsideTargetArea)
        {
            // 如果金币在目标区域内，则通知 GameManager 增加金币数量
            if (gameManager != null)
            {
                gameManager.IncrementCoinCount(coinType);
            }
            else
            {
                Debug.LogError("GameManager not initialized!");
            }
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;
        }
    }

    // 进入目标区域
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TargetArea"))
        {
            isInsideTargetArea = true;
        }
    }
}
