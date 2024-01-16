using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawnerScript : MonoBehaviour
{
    public float playerSpeed = 4f;

    Vector2 initialSpawnerPosition;

    public string horizontalAxe;

    public Rigidbody2D rb;

    Rigidbody2D currentSlimeRB;
    
    Vector2 direction;
    //Array de Slimes que podemos spawnear
    public GameObject[] slimesToSpawn;

    //El objeto actual instanciado
    GameObject currentSlime;

    //Variable para generar un número aleatorio
    int random;

    //Booleana para saber si puedo pulsar
    bool canPress;

    public UIController uIReference;
   
    // Start is called before the first frame update
    void Start()
    {
        initialSpawnerPosition = transform.position;
        //Generamos un número aleatorio entre 0 y 4
        random = Random.Range(0, 5); //El último número es excluido por la función
        //Hacemos hijo al Slime del Spawner
        SpawnSlime();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canPress)
        {
            float horizontalMovement = Input.GetAxis(horizontalAxe);

            direction = new Vector2(horizontalMovement, 0f).normalized;

            rb.velocity = direction * playerSpeed;

            //Si este objeto Slime tiene padre
            if (currentSlime.transform.parent != null)
            {
                //Hacemos que la velocidad del Slime sea igual a la del spawner
                currentSlimeRB.velocity = rb.velocity;
            }

            //Si pulsamos la tecla espacio
            if (Input.GetKeyDown(KeyCode.Space))
            {
                canPress = false;
                currentSlime.transform.parent = null;
                //Hacemos que el Slime tenga su gravedad normal
                currentSlimeRB.gravityScale = 1f;
                //Ponemos la velocidad del slime a 0
                currentSlimeRB.velocity = Vector2.zero; //Vector2.zero == new Vector2(0f, 0f);

                SpawnSlime();
            }
        }
    }

    void SpawnSlime()
    {
        StartCoroutine(SpawnSlimeCO());
    }
    private IEnumerator SpawnSlimeCO()
    {
        yield return new WaitForSeconds(1f);
        //Hacemos aparecer el Slime aleatorio en una posición y con una rotación dadas. Para poder actuar sobre un objeto instanciado, lo referencio.
        currentSlime = Instantiate(slimesToSpawn[random], transform.position, transform.rotation);
        //De ese objeto cogemos el RigidBody2D
        currentSlimeRB = currentSlime.GetComponent<Rigidbody2D>();
        //Ponemos la gravedad a cero para que no caiga cuando el slime es creado
        currentSlimeRB.gravityScale = 0f;
        //Hacemos hijo al Slime del Spawner
        currentSlime.transform.parent = transform;
        //Generamos un número aleatorio entre 0 y 4
        random = Random.Range(0, 5); //El último número es excluido por la función

        transform.position = initialSpawnerPosition;

        uIReference.nextSlime.sprite = slimesToSpawn[random].GetComponent<SpriteRenderer>().sprite;

        //Permitimos de nuevo que se pueda pulsar
        canPress = true;
    }
}
