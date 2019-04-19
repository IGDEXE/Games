using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Cria as variaveis globais
    public float force; // Pondera a fisica
    public GameObject myCamera; // Configuracoes da camera
    public Text txtScore; // Caixa de texto para os pontos
    public Button btnRestart; // Botao para reiniciar o jogo
    private Vector3 offset; // Posicao da camera
    private Rigidbody rb; // Configura a fisica
    private int score; // Para os pontos

    // Inicia junto com o jogo
    void Start()
    {
        // Vincula a variavel ao corpo
        rb = GetComponent<Rigidbody>();
        // Distancia padrao da camera
        offset = myCamera.transform.position;
        // Zera os pontos
        score = 0;
        // Deixa o botao invisivel
        btnRestart.gameObject.SetActive(false);
    }

    // Sempre verificado
    void Update()
    {
        // Recebe o movimento
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // Configura o movimento
        Vector3 vector = new Vector3(h, 0.5f, v);
        rb.AddForce(vector * force * Time.deltaTime);
        // Configura a posicao da camera junto ao player
        myCamera.transform.position = this.transform.position + offset;
    }

    // Verifica contato
    void OnTriggerEnter(Collider obj)
    {
        //Destroy(obj.gameObject); Para destruir o obj
        // Verifica a tag do obj
        if (obj.gameObject.tag == "Coin")
        {
            // Deixa ele invisivel
            obj.gameObject.SetActive(false);
            // Aumenta os pontos
            score++;
            // Mostra na tela
            txtScore.text = "Contador: " + score.ToString();
            // Verifica se ganhou o jogo
            if (score >= 9) 
            {
                txtScore.text = "Ganhou!!";
                btnRestart.gameObject.SetActive(true);
            }
        }
    }

    // Reinicia o jogo
    public void reloadGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
