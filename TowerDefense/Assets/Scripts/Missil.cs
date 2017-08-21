using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missil : MonoBehaviour {

	float velocidade = 10;
	Inimigo alvo;

	[SerializeField]
    int pontosDeDano;

    void Start() 
	{
  		AutoDestroiDepoisDeSegundos (5);
	}
	
	void Update () {
		Anda();
		if (alvo != null) {
			AlterarDirecao ();
		}
  	}
	void Anda(){
		Vector3 posicaoAtual = transform.position;
		Vector3 deslocamento = transform.forward * Time.deltaTime * velocidade;
		transform.position = posicaoAtual + deslocamento;
	}
	void AlterarDirecao(){
		Vector3 posicaoAtual = transform.position;
		Vector3 posicaoDoAlvo = alvo.transform.position;
		Vector3 direcaoDoAlvo = posicaoDoAlvo - posicaoAtual;
		transform.rotation = Quaternion.LookRotation (direcaoDoAlvo);
	}
	void OnTriggerEnter(Collider elementoColidido)
	{
		if (elementoColidido.CompareTag ("Inimigo")) 
		{
			Destroy (this.gameObject);
			Inimigo inimigo = elementoColidido.GetComponent<Inimigo> ();
			inimigo.RecebeDano(pontosDeDano);
		}
	}
	void AutoDestroiDepoisDeSegundos (float segundos)
	{
		Destroy (this.gameObject, segundos);
	}

    public void DefineAlvo (Inimigo inimigo) {
        alvo = inimigo;
    }

}