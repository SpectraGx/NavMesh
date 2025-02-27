using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaca : MonoBehaviour
{
    public float velocidad = 5f;
    public float comida = 100;
    public float resistencia = 100;
    public float lactancia = 30;
    public float estres = 0;
    public Transform zonaPastar;
    public Transform establo;
    public Transform zonaOrdeño;
    public GameObject explosionEfecto;
    private EstadoVaca estadoActual;
    
    private void Start()
    {
        estadoActual = EstadoVaca.Idle;
        StartCoroutine(ActualizarEstado());
    }
    
    private IEnumerator ActualizarEstado()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            EvaluarEstado();
        }
    }
    
    private void EvaluarEstado()
    {
        switch (estadoActual)
        {
            case EstadoVaca.Idle:
                comida -= 3;
                estres++;
                if (comida < 30) CambiarEstado(EstadoVaca.Pastar);
                else if (estres > 70) CambiarEstado(EstadoVaca.Jugar);
                else if (lactancia > 80) CambiarEstado(EstadoVaca.Ordeña);
                break;
            
            case EstadoVaca.Pastar:
                comida += 7;
                estres -= 0.3f;
                MoverA(zonaPastar.position);
                if (comida > 95) CambiarEstado(EstadoVaca.Idle);
                break;
            
            case EstadoVaca.Jugar:
                estres -= 5;
                comida -= 3;
                resistencia -= 5;
                if (estres < 21) CambiarEstado(EstadoVaca.Idle);
                if (resistencia < 30) CambiarEstado(EstadoVaca.Descanso);
                break;
            
            case EstadoVaca.Escapar:
                estres += 5;
                resistencia -= 5;
                comida -= 2;
                MoverA(establo.position);
                if (estres > 90 || (estres > 60 && comida < 50)) Explotar();
                else if (Vector3.Distance(transform.position, establo.position) < 1f) CambiarEstado(EstadoVaca.Descanso);
                break;
            
            case EstadoVaca.Ordeña:
                lactancia = 0;
                comida -= 2;
                MoverA(zonaOrdeño.position);
                if (comida < 40) CambiarEstado(EstadoVaca.Pastar);
                break;
            
            case EstadoVaca.Descanso:
                resistencia += 7;
                estres -= 5;
                comida -= 2;
                if (resistencia > 85) CambiarEstado(EstadoVaca.Idle);
                if (estres > 60) CambiarEstado(EstadoVaca.Jugar);
                if (comida < 30) CambiarEstado(EstadoVaca.Pastar);
                break;
        }
    }
    
    private void CambiarEstado(EstadoVaca nuevoEstado)
    {
        estadoActual = nuevoEstado;
    }
    
    private void MoverA(Vector3 destino)
    {
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
    }
    
    private void Explotar()
    {
        Instantiate(explosionEfecto, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

public enum EstadoVaca
{
    Idle,
    Pastar,
    Jugar,
    Escapar,
    Ordeña,
    Descanso
}

