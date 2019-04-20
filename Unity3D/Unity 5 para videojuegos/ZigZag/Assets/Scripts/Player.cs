using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Variaveis globais
    public Text txtScore; // Mostra os pontos
    public Text txtTime; // Mostra o tempo
    public GameObject contentCoins; // Moedas
    public float force; // Gravidade
    private bool changeDir; // Mudar direcao
    private Vector3 dir; // Direcao
    private Rigidbody rb; // Corpo
    private int score; // Pontos
    private float time; // Tempo
    // Start is called before the first frame update
    void Start()
    {
        // Configuracoes iniciais
        changeDir = false;
        rb = GetComponent<Rigidbody>();
        dir = new Vector3(0,0,0);
        score = 0;
        time = 30;
    }

    // Update is called once per frame
    void Update()
    {
        // Configura o tempo
        time -= Time.deltaTime;
        if (time <= 0)
        {
           restartGame(); 
        }
        txtTime.text = "Tiempo: " + time.ToString("F2");
        // Se o personagem cair, volta para a posicao inicial
        if (transform.position.y < -2)
        {
            restartGame();
        }
        // Verifica quando o mouse eh apertado
        if (Input.GetMouseButtonDown(0))
        {
            rb.Sleep();
            if (changeDir)
            {
                dir = new Vector3(0,0,1);
                changeDir = false;
            }
            else
            {
                dir = new Vector3(1,0,0);
                changeDir = true;
            }
        }
    }

    // Atualiza o movimento
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + dir * Time.deltaTime * force);
    }

    // Colisao
    void OnTriggerEnter(Collider obj)
    {
        // Verifica colisao com as moedas
        if (obj.gameObject.tag == "Coin")
        {
            // Deixa invisivel
            obj.gameObject.SetActive(false);
            // Configura os pontos
            score++;
            txtScore.text = "Score: " + score.ToString();
        }
        // Verifica se completou o jogo
        if (obj.gameObject.tag == "Win")
        {
            restartGame();
        }
    }

    // Reinicia o jogo
    void restartGame()
    {
        // Posicao inicial
        this.transform.position = new Vector3(-4,0.6f,-4);
        rb.Sleep();
        dir = new Vector3(0,0,0);
        // Ativa as moedas
        for(int i = 0; i < contentCoins.transform.GetChildCount(); i++)
        {
            contentCoins.transform.GetChild(i).gameObject.SetActive(true);
        }
        // Volta aos valores padroes
        score = 0;
        time = 30;

    }
}
