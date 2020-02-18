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
    float x;
    float y;
    float z;

    private void Awake()
    {
        x = PlayerPrefs.GetFloat("X");
        y = PlayerPrefs.GetFloat("Y");
        z = PlayerPrefs.GetFloat("Z");
        if (z == 0)
        {
            PlayerPrefs.DeleteKey("X");
            PlayerPrefs.DeleteKey("Y");
            PlayerPrefs.DeleteKey("Z");
            x = 33;
            y = 0.5f;
            z = 6;
        }
        transform.position = new Vector3(x, y, z);
    }
    // Update is called once per frame
    void Update()
    {
        float lsh = Input.GetAxis("LStick_Horizontal") * Speed;
        float lsv = Input.GetAxis("LStick_Vertical") * Speed;
        transform.position += transform.forward * Time.deltaTime * lsv;
        transform.position += transform.right * Time.deltaTime * lsh;

        float rsh = Input.GetAxis("RStick_Horizontal");
        transform.Rotate(0, rsh * 2, 0);
        if (Input.GetKeyDown("joystick button 7"))
        {
            PlayerPrefs.DeleteKey("X");
            PlayerPrefs.DeleteKey("Y");
            PlayerPrefs.DeleteKey("Z");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerPrefs.SetInt("Battle", 1);
            SceneManager.LoadScene(1);
            PlayerPrefs.SetFloat("X", transform.position.x);
            PlayerPrefs.SetFloat("Y", transform.position.y);
            PlayerPrefs.SetFloat("Z", transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boss")
        {
            PlayerPrefs.SetInt("Battle", 2);
            SceneManager.LoadScene(2);
        }
    }
}
