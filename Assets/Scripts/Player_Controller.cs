using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private bool GodMode = false;

    [SerializeField] private Rigidbody2D rg2d;
    [SerializeField] public float AdditionForce = 1f; //minus or addition this guy (when hit ability ball)

    //[SerializeField] private GameObject PlayerLivingRange;  //originally use for OnColliderExit.
    public GameObject MinusBall;
    public GameObject MinusBall1;
    public GameObject MinusBall2;
    public GameObject PlusBall;
    public GameObject PlusBall1;
    public GameObject Meteorite;
    public GameObject Meteorite1;
    public GameObject Meteorite2;
    public GameObject Meteorite3;
    public GameObject DeadBall;
    public GameObject Player;

    //--------------------------------------------------------//

    //ball ability, +1sp when every 5 hits the score giving meteor. a special ability to stop all the force the player has.
    //public Collider coll; move this into another meteor ability script.
    private float OneO = 0;
    public float Player_Score = 0;
    //private int score = 0;

    //--------------------------------------------------------//

    [SerializeField] public TextMeshProUGUI ct; //textmeshpro name ct for score
    public GameObject gameOverText; //text for gameover reappear

    //--------------------------------------------------------//

    //animation and sound
    private Animator anim; //didn't have enough time to remake the art and animation

    public AudioClip BounceSound;
    public AudioClip ButtonSound;
    public AudioClip DeadSound;
    public AudioClip Dead_Soundtrack;
    [SerializeField] private AudioSource audiSource;

    //--------------------------------------------------------//
    //check if dead?
    [SerializeField] public bool PlayerIsDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        //PlayerLivingRange = GetComponent<GameObject>();
        anim = GetComponent<Animator>();
    }

private void FixedUpdate()
    {
        if (!PlayerIsDead)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rg2d.AddForce(new Vector3(AdditionForce * -5f, 5f, 0f));
            }
            if (Input.GetKey(KeyCode.D))
            {
                rg2d.AddForce(new Vector3(AdditionForce * 5f, 5f, 0f));
            }
            if (Input.GetKey(KeyCode.W))
            {
                rg2d.AddForce(new Vector3(0f, AdditionForce * 10f, 0f));
            }
            if (Input.GetKey(KeyCode.S))
            {
                rg2d.AddForce(new Vector3(0f, AdditionForce * -5f, 0f));
            }
        }
        

        /*

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rg2d.AddForce(movement.normalized * speed);

        */
        /*
        Vector2 movingVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rg2d.AddForce(transform.up * movingVector.y * MaxSpeed);
        */
    }

    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Debug.Log("1");
        }
    }
    */

    private void Update()
    {
        if (PlayerIsDead)
        {
            if (Input.GetKey(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (!PlayerIsDead)
        {
            if (Player_Score == 5)
            {
                MinusBall.SetActive(true);
                if (OneO == 0)
                {
                    audiSource.PlayOneShot(DeadSound);
                    OneO = 1;
                } 
            }
            if (Player_Score == 10)
            {
                PlusBall.SetActive(true);
                if (OneO == 1)
                {
                    audiSource.PlayOneShot(DeadSound);
                    OneO = 0;
                }
            }
            if (Player_Score == 15)
            {
                Meteorite.SetActive(true);
                if (OneO == 0)
                {
                    audiSource.PlayOneShot(DeadSound);
                    OneO = 1;
                }
            }
            if (Player_Score == 20)
            {
                Meteorite2.SetActive(true);
                if (OneO == 1)
                {
                    audiSource.PlayOneShot(DeadSound);
                    OneO = 0;
                }
            }
            if (Player_Score == 25)
            {
                MinusBall1.SetActive(true);
                if (OneO == 0)
                {
                    audiSource.PlayOneShot(DeadSound);
                    OneO = 1;
                }
            }
            if (Player_Score == 30)
            {
                Meteorite1.SetActive(true);
                if (OneO == 1)
                {
                    audiSource.PlayOneShot(DeadSound);
                    OneO = 0;
                }
            }
            if (Player_Score == 35)
            {
                PlusBall1.SetActive(true);
                if (OneO == 0)
                {
                    audiSource.PlayOneShot(DeadSound);
                    OneO = 1;
                }
            }
            if (Player_Score == 40)
            {
                Meteorite3.SetActive(true);
                if (OneO == 1)
                {
                    audiSource.PlayOneShot(DeadSound);
                    OneO = 0;
                }
            }
            if (Player_Score == 45)
            {
                MinusBall2.SetActive(true);
                if (OneO == 0)
                {
                    audiSource.PlayOneShot(DeadSound);
                    OneO = 1;
                }
            }
            if (Player_Score == 50)
            {
                DeadBall.SetActive(true);
                if (OneO == 1)
                {
                    audiSource.PlayOneShot(DeadSound);
                    OneO = 0;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ScriptMeteorAbility function_sma = gameObject.GetComponent<ScriptMeteorAbility>(); //call function from another script
        //GameManagement function_gm = gameObject.GetComponent<GameManagement>(); //NullReferenceException

        if (!PlayerIsDead)
        {
            if (collision.gameObject.tag == "Score") //just add score
            {
                //Debug.Log("I hit the score");
                //function_gm.PlayerScore();
                if (GodMode)
                {
                    Player_Score += 5;
                }
                else
                {
                    Player_Score++;
                }
                
                ct.text = "Score: " + Player_Score.ToString();
                UseSound();


                //AdditionForce *= 10f;
                //Debug.Log("Mine Collision with " + collision.gameObject.name);
            }
            
            if (collision.gameObject.tag == "Minus") //call function from another
            {
                //MinusBall.rigidbody2D.gravityScale = 2;
                //MinusBall.GetComponent<Rigidbody2D>.
                //function_sma.MinusBouncingStats();

                if (AdditionForce >= 0)
                {
                    AdditionForce++;
                }
                
            }
            if (collision.gameObject.tag == "Plus") //call function from another
            {
                if (AdditionForce != 0)
                {
                    AdditionForce--;
                }
                
                //function_sma.PlusBouncingStats();
            }
            if (collision.gameObject.tag == "Meteorite") //call function from another
            {
                // function_sma.PlusBouncingStats();
                Vector2 direction = new Vector2((float)Random.Range(-5, 5), (float)Random.Range(-5, 5));

                float force = (float)Random.Range(1, 5);
                Player.GetComponent<Rigidbody2D>().AddForce(direction * force);
            }

            if (collision.gameObject.tag == "DeadBall")
            {
                PlayerIsDead = true;
                GameSetting();
            }

            if (collision.gameObject.tag == "Border") //setPlayerStatusBoolToDeath
            {

                //Debug.Log("I hit the Border!");
                //function_gm.GameEnding();
                //Debug.Log(function_gm);

                if (!GodMode)
                {
                    PlayerIsDead = true;
                    GameSetting();
                }
                else
                {
                    return; //do nothing
                }
                
                
            }
        }
    }

    public void GameSetting()
    {
        //useForGameEnd
        if (PlayerIsDead)
        {            
            audiSource.PlayOneShot(Dead_Soundtrack);
            gameOverText.SetActive(true);
        }
    }
    public void UseSound()
    {
        audiSource.PlayOneShot(BounceSound);
    }

}
