using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparoenemigo : MonoBehaviour
{
    public Transform controladorDisparo;
    public float distanciaLinea;

    public LayerMask capaJugador;

    public bool jugadorEnRango;
    public GameObject balaEnemigo;
    public float tiempoDisparos;
    public float tiempoUltimoDisparo;
    public float tiempoEsperaDisparo;

    private void Update()
    {
        jugadorEnRango = Physics2D.Raycast(controladorDisparo.position, transform.right*-1, distanciaLinea, capaJugador);

        if (jugadorEnRango) 
        { 
            if(Time.time > tiempoDisparos + tiempoUltimoDisparo)
            {
                tiempoUltimoDisparo = Time.time;
                Invoke(nameof(Disparar), tiempoEsperaDisparo);
            }
        
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position + transform.right*-1 * distanciaLinea);
    }

    private void Disparar()
    {
        Instantiate(balaEnemigo, controladorDisparo.position, controladorDisparo.rotation);
    }

    
}
