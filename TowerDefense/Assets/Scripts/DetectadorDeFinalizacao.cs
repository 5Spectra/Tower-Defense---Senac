using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectadorDeFinalizacao : MonoBehaviour {

    [SerializeField]
    DadosJogador jogador;

    void OnTriggerEnter(Collider coll) {

        if (coll.CompareTag("Inimigo"))
        {
            Destroy(coll.gameObject);
            jogador.PerdeVida();
        }
    }
}

