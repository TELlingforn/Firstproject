using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegbugTest : MonoBehaviour
{
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
        Debug.LogWarning("test2");
        Debug.Log(sphere.name);
        //当前真正的激活状态
        Debug.Log(sphere.activeInHierarchy);
        //当前自身的激活状态
        Debug.Log(sphere.activeSelf);
        MeshRenderer mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
