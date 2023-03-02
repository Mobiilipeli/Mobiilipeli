using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{

    private void OnTriggerEnter2d(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager2.MyInstance.Finish();
        }
    }
}
