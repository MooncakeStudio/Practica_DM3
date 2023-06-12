using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Personaje
{
    // ATRIBUTOS

    string nombre;

    int vida;
    int ataque;
    int defensa;

    


    // CONSTRUCTOR

    public Personaje(string nombre = "",  int vida = 100, int ataque = 10, int defensa = 5)
    {
        this.nombre = nombre;

        this.vida = vida;
        this.ataque = ataque;
        this.defensa = defensa;
    }


    // GETTERS & SETTERS

    public string GetNombre() { return this.nombre; }
    public int GetVida() { return this.vida; }
    public int GetAtaque() { return this.ataque; }
    public int GetDefensa() { return this.defensa; }
    public void SetAtaque(int at){ this.ataque=at;}

    public void herida(int d) 
    { 
        vida -= d;
        
    }


    // METODOS

    virtual public void RealizarAtaque() { }

    virtual public void RealizarAtaqueEspecial() { }
}
