using System.Collections.Generic;
using UnityEngine;

namespace Framework.Manager.PoolManager
{
    public class PoolStack
    {
        private Stack<UnityEngine.Object> Stack = new Stack<Object>();
        private int MaxCount = 100;

        public void Push(UnityEngine.Object go)
        {
            if (Stack.Count < MaxCount)
            {
                Stack.Push(go);
            }
            else
            {
                Object.Destroy(go);
            }
        }

        public UnityEngine.Object Pop()
        {
            if (Stack.Count > 0)
            {
                return Stack.Pop();
            }

            return null;
        }

        public void Clear()
        {
            foreach (UnityEngine.Object VARIABLE in Stack)
            {
                Object.Destroy(VARIABLE);
            }
            Stack.Clear();
        }
    }
    public class PoolManager : MySingletonBase<PoolManager>
    {
        //对象池字典
        private Dictionary<string, PoolStack> poolDic = new Dictionary<string, PoolStack>();

        //从对象池中取对象.没有就创建一个
        public UnityEngine.Object Spawn(string poolNmae, UnityEngine.Object prefab)
        {
            //没有对应的对象池就创建一个对象池
            poolDic.TryAdd(poolNmae, new PoolStack());

            UnityEngine.Object go = poolDic[poolNmae].Pop();
            if (go == null)
            {
                go = GameObject.Instantiate(prefab);
                poolDic[poolNmae].Push(go);
            }

            return go;
        }

        public void UnSpawn(string poolName)
        {
            if (!poolDic.ContainsKey(poolName)) return;
            poolDic[poolName].Clear();
            poolDic.Remove(poolName);
        }
        
    }
}