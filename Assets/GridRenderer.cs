using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridRenderer : MonoBehaviour
{


    public void Awake()
    {
        gameObject.AddComponent<TriangleRenderer>();
    }




}
