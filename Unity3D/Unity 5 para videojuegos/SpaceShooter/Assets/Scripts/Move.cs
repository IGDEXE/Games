using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Variaveis globais
    public float speed; // Velocidade
    // Start is called before the first frame update
    void Start()
    {
        // Defino a velocidade de movimento
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
