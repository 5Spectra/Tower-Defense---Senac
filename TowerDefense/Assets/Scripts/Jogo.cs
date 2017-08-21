using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogo : MonoBehaviour {

    [SerializeField] GameObject torrePrefab;
    [SerializeField] GameObject gameover;
    [SerializeField] DadosJogador jogador;

    void Start() {
        gameover.SetActive(false);
    }
    void Update () {

        if (JogoAcabou())
            gameover.SetActive(true);
        else 
        if (ClicouComBotaoPrimario())
            ConstroiTorre();
	}

    bool JogoAcabou() {
        return !jogador.EstarVivo();
    }

    public void Recomeca() {
        SceneManager.LoadScene (0);
    }

    bool ClicouComBotaoPrimario()
    {
        return Input.GetMouseButtonDown(0);
    }

    void ConstroiTorre() {
        Vector3 posicaoClique = Input.mousePosition;
        RaycastHit elementoAtingidoPeloRaio = DisparaRaioDaCameraAtePonto(posicaoClique);

        if (elementoAtingidoPeloRaio.collider != null) {
            Vector3 posicaoElemento = elementoAtingidoPeloRaio.point;
            Instantiate(torrePrefab, posicaoElemento, Quaternion.identity);
        }
       }

    private RaycastHit DisparaRaioDaCameraAtePonto (Vector3 ponto)
    {
        Ray raio = Camera.main.ScreenPointToRay(ponto);
        RaycastHit elementoAtingidoPeloRaio;
        float comprimentoMaxRaio = 100f;

        Physics.Raycast(raio, out elementoAtingidoPeloRaio, comprimentoMaxRaio);

        return elementoAtingidoPeloRaio;
    }
}
