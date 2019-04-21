using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variaveis globais
    public GameObject shot; // Tiro
    public Transform shotContent; // Capsulas
    public float fireRate; // Cadencia
    public float nextFire; // Quantidade de tiros
    public float xMin, xMax, zMin, zMax; // Limites do cenario
    private Rigidbody rb; // Corpo
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Configura os disparos
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotContent.position, shotContent.rotation);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Recebe os dados de controle
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // Posicao da nave
        Vector3 vector = new Vector3(h,5f,v);
        // Velocidade de movimento
        rb.velocity = vector * 10;
        // Configura os limites de movimento
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, xMin,xMax),
            6.0f,
            Mathf.Clamp(rb.position.z, zMin, zMax)
        );
        // Rotacao da nave
        rb.rotation = Quaternion.Euler(0.0f,0.0f,rb.velocity.x * -2);
    }
}
