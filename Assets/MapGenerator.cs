﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform parent;

    [SerializeField]
    private GameObject hex;

    private void Awake()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        for (int z = 0, i = 0; z < 35; z++)
        {
            for (int x = 0; x < 15; x++)
            {
                Vector3 position;
                position.x = position.x = (x + z * 0.5f - z / 2) * (0.5f * 2f) * 0.4f;
                position.y = 0f;
                position.z = z * (0.5f * 1.5f) * 0.5f;
                var obj = Instantiate(hex, position, Quaternion.Euler(new Vector3(90, 0, 0)), parent);
            }
        }

        parent.localPosition = new Vector3(-8.2f, 1.06f, -5.78f);
        parent.localRotation = Quaternion.Euler(new Vector3(0, 45, 0));
    }
}