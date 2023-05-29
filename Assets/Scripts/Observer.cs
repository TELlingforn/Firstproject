using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;

    public GameEnding gameEnding;

    private bool IsInRange = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            IsInRange = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IsInRange = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (IsInRange == true)
        {
            //为了严谨 可以直接gameover
            Vector3 dir = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, dir);
            //射线碰撞产生的消息
            RaycastHit raycastHit;
        
            //out和传引用一样 把函数中产生的参数当成值再传入函数中
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.Caught();
                }
            }
        }
    }
}
