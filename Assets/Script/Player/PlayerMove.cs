using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// キャラクターの移動
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float Speed;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        transform.position += new Vector3(h, 0, v);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(1);
        }
    }
}
