using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigo : MonoBehaviour {

    [SerializeField]
    GameObject inimigo;

    float momentoUltimoDisparo;

    [Range(0, 3)]
    [SerializeField]
    float tempoCriacao = 2f;

	void Update () {
        GeraInimigo();
	}

    void GeraInimigo() {
        float tempoAtual = Time.time;
        if (tempoAtual > momentoUltimoDisparo + tempoCriacao) {
            momentoUltimoDisparo = tempoAtual;
            Vector3 posicaoGerador = transform.position;
            Instantiate(inimigo, posicaoGerador, Quaternion.identity);

        }
    }
}
