using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WayPointsPatrol : MonoBehaviour
{
    //导航组件
    private NavMeshAgent navMeshAgent;
    //导航点的数组
    public Transform[] waypoints;
    //当前巡逻的目标点
    int m_currentpointIndex;
    // Start is called before the first frame update
    void Start()
    {
        //获取NavMeshAgent组件
        navMeshAgent = GetComponent<NavMeshAgent>();
        //从起点到达第一个巡逻点
        navMeshAgent.SetDestination(waypoints[0].position);
    }
 
    // Update is called once per frame
    void Update()
    {
        //remainingDistance是到指定路径点的剩余距离 stoppingDistance是导航组件中的距离意思是说 小于这个距离了就默认已经达到了指定的位置
        if (navMeshAgent.remainingDistance<navMeshAgent.stoppingDistance)
        {
            //%是循环
            m_currentpointIndex=(m_currentpointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_currentpointIndex].position);
        }
    }
}