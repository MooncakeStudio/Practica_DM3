using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Personaje
{
    // ATRIBUTOS

    string nombre;

    int vida;
    int vidaMax;
    int ataque;
    int defensa;

    


    // CONSTRUCTOR

    public Personaje(string nombre = "",  int vida = 100, int ataque = 10, int defensa = 5)
    {
        this.nombre = nombre;
        this.vidaMax = vida;
        this.vida = vida;
        this.ataque = ataque;
        this.defensa = defensa;
    }


    // GETTERS & SETTERS

    public string GetNombre() { return this.nombre; }
    public int GetVida() { return this.vida; }
    public int GetVidaMax() { return this.vidaMax; }
    public int GetAtaque() { return this.ataque; }
    public int GetDefensa() { return this.defensa; }
    public void SetAtaque(int at){ this.ataque=at;}

    public void herida(int d) 
    { 
        vida -= d;
        
    }

    public void Curar(int d)
    {
        vida += d;
        if(vida > vidaMax)
            vida = vidaMax;
    }

    public void AumentarVidaMax(int d)
    {
        this.vidaMax += d;
    }

    // METODOS

    virtual public void RealizarAtaque() { }

    virtual public void RealizarAtaqueEspecial() { }
}
