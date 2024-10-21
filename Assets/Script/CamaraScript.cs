using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 position = transform.position;
            position.x = player.transform.position.x;
            transform.position = position;

        }
    }
}
