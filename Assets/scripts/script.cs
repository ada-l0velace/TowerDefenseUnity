﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script : MonoBehaviour
{
    public Button button;
    public GameObject tower;
    public GameObject enemy;
    private int count = 0;
    private GameObject prev;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(this.clicked);
    }

    void clicked()
    {
        GameObject e = (GameObject) Instantiate(tower);
        e.transform.SetParent(gameObject.transform);
        e.transform.localPosition = new Vector3(Random.Range(-4, 4), 1, Random.Range(-4, 4));
    
        count++;
        Debug.Log("Count: " + count);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
