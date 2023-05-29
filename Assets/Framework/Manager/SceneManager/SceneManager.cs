using System.Collections.Generic;
using UnityEngine;

namespace Framework.Manager.SceneManager
{
    public class SceneManager : MangerBase
    {
        //场景名称是后面的数字 存的是数字
        public List<string> sceneList = new List<string>();

        //当前场景在sceneList中的索引
        public int CurrentIndex = 0;
        //委托变量
        /*
         * 它表示一个不返回值（void）且接受一个 float 参数的方法。
         */
        private System.Action<float> CurrentAction;

        //当前场景对象
        private AsyncOperation Operation;
        public void LoadScene(string sceneName, System.Action<float> action)
        {
            CurrentAction = action;
            if (sceneList.Contains(sceneName))
            {
                //当前场景在sceneList中的索引
                CurrentIndex = sceneList.IndexOf(sceneName);
                //加载场景
                Operation=UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName,
                    UnityEngine.SceneManagement.LoadSceneMode.Single);
            }
        }
        // Start is called before the first frame update
        void Update()
        {
            if (Operation != null)
            {
                CurrentAction(Operation.progress);//进度条
                if (Operation.progress >= 1)
                {
                    Operation = null;
                }
            }
        }

        //加载上一个场景
        public void LoadPre(System.Action<float> action)
        {
            CurrentIndex--;
            LoadScene(sceneList[CurrentIndex],action);
        }
        //加载下一个场景
        public void LoadNext(System.Action<float> action)
        {
            CurrentIndex++;
            LoadScene(sceneList[CurrentIndex],action);
        }
        public override byte GetMessageType()
        {
            throw new System.NotImplementedException();
        }
    }
}
