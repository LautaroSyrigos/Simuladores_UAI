using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public Transform CañonTransform;
    public GameObject Proyectil;
    public float VelocidadDisparo;

    public LineRenderer LineaDibujada;
    public int LineaPuntos;
    public float TiempoIntervalo;

    void Update()
    {
        Controles();
    }

    void Controles()
    {
        if (LineaDibujada != null)
        {
            if (Input.GetMouseButton(1))
            {
                DibujarTrayectoria();
                LineaDibujada.enabled = true;
            }
            else
            {
                LineaDibujada.enabled=false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            var _Proyectil =Instantiate(Proyectil, CañonTransform.position,CañonTransform.rotation);
            _Proyectil.GetComponent<Rigidbody>().velocity=VelocidadDisparo*CañonTransform.up;
        }
    }

    void DibujarTrayectoria()
    {
        Vector3 Origen=CañonTransform.position;
        Vector3 VelocidadInicial = VelocidadDisparo * CañonTransform.up;
        LineaDibujada.positionCount = LineaPuntos;

        float Tiempo = 0;

        for(int i = 0;i<LineaPuntos;i++)
        {
            var x = (VelocidadInicial.x * Tiempo) + (Physics.gravity.x / 2 * Tiempo * Tiempo);
            var y = (VelocidadInicial.y * Tiempo) + (Physics.gravity.y / 2 * Tiempo * Tiempo);
            Vector3 Punto=new Vector3(x,y,0);
            LineaDibujada.SetPosition(i, Origen + Punto);
            Tiempo += TiempoIntervalo;
        }
    }
}
