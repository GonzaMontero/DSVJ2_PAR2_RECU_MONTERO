using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonOperator : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.FindData();
        GameManager.instance.LoadData();
    }
}
