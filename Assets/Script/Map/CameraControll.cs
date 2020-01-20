using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    GameObject Player;
    [SerializeField] float RotateSpeed;
    Vector3 PlyPos;
    Transform CameraPos;
    void Start()
    {
        Player = (GameObject)Resources.Load("Prefab/Player/Player()");
        if (Camera.main != null)
        {
            CameraPos = Camera.main.transform;
        }
    }

    void Update()
    {

    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
    }
}
