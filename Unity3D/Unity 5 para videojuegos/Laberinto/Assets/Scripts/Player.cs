using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Variaveis globais
    public float force; // Configura a forca
    public Text txtTime; // Caixa de texto
    public Button btnRestart; // Botao para reiniciar
    private float timeValue; // Guarda o tempo
    private bool gameOver; // O estado da partida
    // Start is called before the first frame update
    void Start()
    {
        // Tempo inicial
        timeValue = 30;
        // Deixa o botao invisivel
        btnRestart.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se o usuario esta jogando
        if (gameOver != true)
        {
            // Configura o movimento
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 vector = new Vector3(h, 0.5f, v);
            // Configura a fisica
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(vector * force * Time.deltaTime);
            // Faz o tempo diminuir
            timeValue -= Time.deltaTime;
            // Verifica se o tempo acabou
            if (timeValue <= 0f)
            {
                timeValue = 0.0f;
                gameOver = true;
                btnRestart.gameObject.SetActive(true);
            }
            // Mostra o tempo na tela
            txtTime.text = "Tiempo: " + timeValue.ToString("F2");
        }
    }

    // Verifica contato
    void OnTriggerEnter(Collider obj)
    {
        // Verifica se teve contato com o enlace
        if (obj.gameObject.tag == "Enlace")
        {
            // Verifica em qual tela esta
            if (Application.loadedLevelName == "Main")
            {
                Application.LoadLevel("Scene1");
            }
            else
            {
                Application.LoadLevel("Main");
            }
        }
    }

    // Reinicia o jogo
    public void reloadGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
