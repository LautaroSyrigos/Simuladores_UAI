using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaquinaDeGalton : MonoBehaviour
{
    public GameObject Prefab;               public GameObject[] PuntosGeneracion;
    public float TiempoDeIntervalo;

    void Start()
    {
        InvokeRepeating("GenerarPelotas", 0, TiempoDeIntervalo);
    }

    void GenerarPelotas()
    {
        foreach (GameObject PuntoGeneracion in PuntosGeneracion)
        {
            Instantiate(Prefab, PuntoGeneracion.transform.position, Quaternion.identity);
        }
    }

    public void RegresarAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {

        
    }
}
