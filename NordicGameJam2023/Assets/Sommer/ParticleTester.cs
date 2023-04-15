using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTester : MonoBehaviour
{
    private MenUI MUI = new MenUI();
    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        MUI = GetComponent<MenUI>();
    }
    /*private void OnTriggerEnter(Collider other)
    {
        foreach (string player in MUI._playerList)
        {
            switch (player)
            {
                case "Player2":
                    if (other.gameObject.name == "Player2")
                    {
                        var main = ps.main;
                        main.startColor = Color.red;
                    }
                    break;

                case "Player1":
                    if (other.gameObject.name == "Player1")
                    {
                        var main = ps.main;
                        main.startColor = Color.green;
                    }
                    break;
            }
        }
            /*if(other.gameObject.name == "Player")
            {
                var main = ps.main;
                main.startColor = Color.red;
            }
    }*/
}
