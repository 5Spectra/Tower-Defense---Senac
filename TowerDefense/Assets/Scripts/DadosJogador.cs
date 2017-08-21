using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadosJogador : MonoBehaviour {

    [SerializeField]
    int vida;
    
    public int GetVida() {
        return vida;
    }

    public void PerdeVida() {
        if (EstarVivo())
        vida --;
    }

    public bool EstarVivo() {
        return vida > 0;
    }
}
