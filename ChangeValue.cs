using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions
{
    [Category("✫ Custom")]
    [Description("Send targetCoinCount1 to the GameManager")]
    public class SendCoinCountsToGameManager : ActionTask<Transform>
    {
        public BBParameter<int> targetCoinCount1;

        protected override string info {
            get { return string.Format("Send Coin Counts ({0}) to GameManager", targetCoinCount1); }
        }

        protected override void OnExecute() {
            // 订阅场景加载完成事件
            SceneManager.sceneLoaded += OnSceneLoaded;
            // 加载目标场景
            SceneManager.LoadScene("game_2");
        }

        // 场景加载完成后的回调方法
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // 如果加载的是目标场景
            if (scene.name == "game_2")
            {
                // 获取 GameManager 的实例
                GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
                // 如果 GameManager 实例存在，则发送消息
                if (gameManager != null) {
                    gameManager.targetCoinCount1 = targetCoinCount1.value;
                } else {
                    Debug.LogError("GameManager instance not found!");
                }
                // 取消订阅场景加载完成事件，避免重复调用
                EndAction();
            }
        }
    }
}


