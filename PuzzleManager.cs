using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    public PuzzlePiece[] puzzlePieces;
    public Transform[] correctPositions;
    public float snapDistance = 0.5f;
    public string sceneName;
    private GameObject winUI;
    private GameObject failUI;
    public Button confirmButton;

    void Awake()
    {
        instance = this;
        winUI = GameObject.Find("WinUI");
        failUI = GameObject.Find("FailUI");

        // 设置初始状态为不可见
        winUI.SetActive(false);
        failUI.SetActive(false);
        confirmButton.onClick.AddListener(CheckAllPieces);
    }

    void Start()
    {
        ShufflePuzzlePieces();
    }

    void ShufflePuzzlePieces()
    {
        foreach (var piece in puzzlePieces)
        {
            piece.transform.position = new Vector3(Random.Range(4, 6), Random.Range(3, 5), 0);
        }
    }

    public void CheckPiecePosition(PuzzlePiece piece)
    {
        for (int i = 0; i < correctPositions.Length; i++)
        {
            if (Vector3.Distance(piece.transform.position, correctPositions[i].position) < snapDistance)
            {
                piece.transform.position = correctPositions[i].position;
            }
        }
    }

    void CheckAllPieces()
    {
        bool allCorrect = true;
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (Vector3.Distance(puzzlePieces[i].transform.position, correctPositions[i].position) > snapDistance)
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            Debug.Log("You win!"); // 当两种金币数量都达到目标数量时，输出胜利信息
            ShowWinUI(); // 在这里可以添加其他胜利逻辑，比如显示胜利界面、加载下一关等
            StartCoroutine(WaitAndLoadNextScene());
        }
        else
        {
            Debug.Log("Try again!");
            ShowFailUI(); // 重新开始游戏的逻辑，可以在这里实现
            StartCoroutine(WaitAndReset());
        }
    }

    private IEnumerator WaitAndReset()
    {
        yield return new WaitForSeconds(2f);
        ResetGame();
    }

    private IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }

    private void ResetGame()
    {
        // 重新加载当前场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ShowWinUI()
    {
        // 激活成功界面
        winUI.SetActive(true);
    }

    private void ShowFailUI()
    {
        // 激活失败界面
        failUI.SetActive(true);
    }
}
