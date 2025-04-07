using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
public static GameManager instance; // GameManager 的静态实例

    public int targetCoinCount1; // 第一种金币的目标数量
    private int currentCoinCount1 = 0; // 第一种金币当前数量
    private int currentCoinCount2 = 0; // 第二种金币当前数量

    public string sceneName;
    private GameObject winUI;
    private GameObject failUI;

    private void Awake()
    {
    // 检查是否存在其他 GameManager 实例，如果存在则销毁
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // 设置当前实例为 GameManager 的唯一实例
            instance = this;
        }
        // 获取成功界面和失败界面的引用
        winUI = GameObject.Find("WinUI");
        failUI = GameObject.Find("FailUI");

        // 设置初始状态为不可见
        winUI.SetActive(false);
        failUI.SetActive(false);
    }

    public void IncrementCoinCount(int coinType)
    {
        if (coinType == 1)
        {
            currentCoinCount1++;
        }
        else if (coinType == 2)
        {
            currentCoinCount1 += 5;
        }
    }

    public void CheckWinCondition()
    {
        if (currentCoinCount1 == targetCoinCount1)
        {
            Debug.Log("You win!"); // 当两种金币数量都达到目标数量时，输出胜利信息
            ShowWinUI(); // 在这里可以添加其他胜利逻辑，比如显示胜利界面、加载下一关等
            StartCoroutine(Wait());
            
        }
        else
        {
            Debug.Log("Try again!");
            ShowFailUI(); // 重新开始游戏的逻辑，可以在这里实现
            StartCoroutine(WaitAndReset()); // 启动协程等待几秒钟后重新开始游戏
        }
    }

    private IEnumerator WaitAndReset()
    {
        yield return new WaitForSeconds(2f);
        ResetGame();
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// 重新开始游戏的逻辑
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