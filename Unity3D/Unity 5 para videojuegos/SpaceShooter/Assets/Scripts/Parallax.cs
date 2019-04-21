using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Variaveis globais
    public float speed = 0; // Velocidade
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move a tela
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0f,(Time.time*speed)%1);
    
    }
}
