using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Torre : MonoBehaviour {

    public GameObject projetilPrefab;
    public float tempoDeRecarga = 1f;

    float momentoDoUltimoDisparo;

    Missil sn;

    [SerializeField]
    float raioAlcance;

    void Update() {
        Inimigo alvo = EscolheAlvo();

        if (alvo != null)
        Atira(alvo);
    }

    void Atira(Inimigo inimigo)
    {
        float tempoAtual = Time.time;
        if (tempoAtual > momentoDoUltimoDisparo + tempoDeRecarga)
        {
            momentoDoUltimoDisparo = tempoAtual;

            GameObject pontoDeDisparo = transform.Find("CanhaoDaTorre/PontoDeDisparo").gameObject;

            Vector3 posicaoDoPontoDeDisparo = pontoDeDisparo.transform.position;

            GameObject projetilObject = (GameObject) Instantiate(projetilPrefab, posicaoDoPontoDeDisparo, Quaternion.identity);
            Missil missel = projetilObject.GetComponent<Missil>();
            missel.DefineAlvo(inimigo);
        }
    }

    Inimigo EscolheAlvo() {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
        foreach (GameObject inimigo in inimigos) {
            if (EstaNoRaioAlcance (inimigo)) {
                return inimigo.GetComponent<Inimigo>();
            }
        }
            return null;
    }

    bool EstaNoRaioAlcance(GameObject inimigo)
    {
        Vector3 posicaoInimigoNoPlano = Vector3.ProjectOnPlane(inimigo.transform.position, Vector3.up);
        Vector3 posicaoDaTorreNoPlano = Vector3.ProjectOnPlane(transform.position, Vector3.up);
        float distanciaParaInimigo = Vector3.Distance(posicaoDaTorreNoPlano, posicaoInimigoNoPlano);
        return distanciaParaInimigo <= raioAlcance;
    }
}
