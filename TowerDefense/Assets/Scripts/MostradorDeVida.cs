using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostradorDeVida : MonoBehaviour {

    Text campoTexto;
    public DadosJogador jogador;

	void Start () {
        campoTexto = GetComponent<Text>();
	}

	void Update () {
        campoTexto.text = "Vida: "+ jogador.GetVida();
	}
}
