using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    // Variaveis globais
    public GameObject player; // Aponta o jogador
    private Vector3 posINI; // Configura a posicao
    // Start is called before the first frame update
    void Start()
    {
        // Configura a distancia inicial
        posINI = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Atualiza posicao
        this.transform.position = player.transform.position + posINI;
    }
}
