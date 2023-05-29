using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Person
{
    public string name;
    public int age;
}
[Serializable]
public class Persons
{
    public Person[] persons;
}

public class JsonUtilityTest : MonoBehaviour
{
    
    void Start()
    {
        //创建json
        Person person1 = new Person();
        person1.name = "1";
        person1.age = 18;
        Person person2 = new Person();
        person2.name = "2";
        person2.age = 18;
        Persons persons = new Persons();
        persons.persons = new[] { person1, person2 };
        string jsonStr = JsonUtility.ToJson(persons);
        Debug.Log(jsonStr);
        
        //解析json
        Persons ps = JsonUtility.FromJson<Persons>(jsonStr);
        foreach (var VARIABLE in ps.persons)
        {
            Debug.Log(VARIABLE.name);
        }
        
    }


}
