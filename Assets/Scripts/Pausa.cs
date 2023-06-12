using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class Pausa : MonoBehaviour
    {
        
        public void PauseJuego(bool pausar)
        {
            int pausaInt = pausar ? 0 : 1;
            Time.timeScale = pausaInt;
        }

        public void SalirJuego()
        {
            GameManager.instance.resetGame();
        }
       

    }
}
