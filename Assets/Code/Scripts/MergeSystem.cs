using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSystem : MonoBehaviour
{
    //Generamos una enumeración con todos los tipos de slimes disponibles
    public enum SlimeType { slime0, slime1, slime2, slime3, slime4, slime5, slime6, slime7, slime8, slime9}

    //Referencia para conocer de qué tipo es este slime
    public SlimeType slimeType;

    //Obtenemos una referencia al Game Manager
    GameManager gMReference;
    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la referencia al GameManager
        //GameObject.Find("Objeto") => Busca el objeto por nombre en la escena
        gMReference = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si está por encima de la línea roja
        if (transform.position.y > 7.5f && transform.parent == null)
        {
            gMReference.GameOver();
        }
    }
    //Método para trabajar con las colisiones entre los slimes
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si el objeto que ha colisionado es un slime y es el mismo tipo de slime que este
        if(collision.gameObject.CompareTag("Slime") && collision.gameObject.GetComponent<MergeSystem>().slimeType == slimeType)
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            //Para sumar 1 a un número antes de usarlo, ++numero en vez de numero++
            Instantiate(gMReference.slimes[(int)++slimeType], transform.position, transform.rotation);
        }
    }
}
