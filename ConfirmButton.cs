using UnityEngine;
using UnityEngine.UI;

public class ConfirmButton : MonoBehaviour
{
    private GameManager gameManager;

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

    public void OnConfirmButtonClick()
    {
        if (gameManager != null)
        {
            gameManager.CheckWinCondition();
        }
    }
}
