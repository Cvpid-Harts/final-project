using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public bool HasSpecialKey = false;
    public TextMeshProUGUI gameOverText;
    public float speed = 12f;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpecialKey"))
        {
            HasSpecialKey = true;
            Destroy (other.gameObject);
        }

        if (other.gameObject.CompareTag("Exit"))
        {
            gameOverText.gameObject.SetActive(true);
        }
    }

}
