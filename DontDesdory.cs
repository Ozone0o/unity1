using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    private static BGMPlayer instance;

    void Awake()
    {
        // 如果已经存在一个实例，则销毁当前游戏对象
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            // 保持该游戏对象不被销毁
            DontDestroyOnLoad(gameObject);
        }
    }
}
