using UnityEngine;
using UnityEngine.UI;

public class TipsButton : MonoBehaviour
{
    public GameObject uiPanel; // UI界面的Panel
    public Button openButton; // 触发打开UI界面的按钮
    public Button exitButton; // 退出UI界面的按钮

    private void Start()
    {
        // 注册按钮点击事件
        openButton.onClick.AddListener(OpenUIPanel);
        exitButton.onClick.AddListener(ExitUIPanel);

        // 初始设置UI界面不可见
        uiPanel.SetActive(false);
    }

    private void OpenUIPanel()
    {
        // 打开UI界面
        uiPanel.SetActive(true);
    }

    private void ExitUIPanel()
    {
        // 退出UI界面
        uiPanel.SetActive(false);
    }
}
