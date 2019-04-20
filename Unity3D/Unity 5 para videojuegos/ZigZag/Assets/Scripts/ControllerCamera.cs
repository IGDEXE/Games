using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    // Variaveis globais
    public GameObject player; // Jogador
    private Vector3 posINI; // Posicao inicial
    // Start is called before the first frame update
    void Start()
    {
        // Configura a posicao inicial
        posINI = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Atualiza com o movimento do jogador
        this.transform.position = player.transform.position + posINI;
    }
}
