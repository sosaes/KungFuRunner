using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Jump : MonoBehaviour {

    public static Player_Jump playerJumpInstance;

	private float jumpForce = 15f;

	private float secondJumpForce = 15f; 

	private Rigidbody2D myBody;

	public bool grounded;

	public Button jumpButton;

	public LayerMask whatIsGround;

	private Collider2D myCollider;

	private Animator anim;

	public Button attackButton;

	private bool canDoubleJump;




	public GameObject goodShade;
    public GameObject infiniteGoodShade;
	Transform goodShadePos;

	private bool timeToAttackPassed;
    public float timeBetweenAttacks; // = 0.75f; //Get from player preferences
	private float timestamp;

    public GameObject instructions;


    //Bool for superPower
    public static bool gravityOn;


    //Dodge variables
    private Vector3 fp;
    private Vector3 lp;
    float dragDistance = Screen.height * 15 / 100;


    // Use this for initialization
    void Start () {
        MakeInstance();

		myBody = GetComponent<Rigidbody2D> ();
		myCollider = GetComponent<Collider2D> ();

		//jumpButton = GameObject.Find ("Jump Button").GetComponent<Button> ();
		jumpButton.onClick.AddListener (() => Jump());

		anim = GetComponent<Animator> ();

		//attackButton = GameObject.Find ("Attack Button").GetComponent<Button> ();
		attackButton.onClick.AddListener (() => Attack());


		goodShadePos = transform.Find ("GoodShade");

        gravityOn = true;

        //timeBetweenAttacks = CharSelectionController.instance.GetPlayerAttackCooldown();
        SetTimeBetweenAttacks();


	}

    public void SetTimeBetweenAttacks()
    {
        //value = GameplayController.instance.GetPlayerAttackCooldownFromCharSelection();
        //timeBetweenAttacks = CharSelectionController.instance.GetPlayerAttackCooldown();
        timeBetweenAttacks = GameplayController.instance.GetPlayerAttackCooldownFromCharSelection();
    }
	
	// Update is called once per frame
	void Update () {
		
		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		anim.SetBool ("Grounded", grounded);

		if (grounded) {
			canDoubleJump = true;
            //Sound Effect----------------------------------
            //SoundController.instance.RunSound();
		}


		if (Time.time >= timestamp) {
			timeToAttackPassed = true;
			timestamp = Time.time + timeBetweenAttacks;
		}

        //Dodge();


	}

    void MakeInstance()
    {
        if (playerJumpInstance == null)
            playerJumpInstance = this;
    }

	public void Jump() {
		if (grounded) {
			myBody.velocity = new Vector2 (0, jumpForce);
		}

		if (canDoubleJump || !gravityOn) {
			myBody.velocity = new Vector2 (0, secondJumpForce);
			canDoubleJump = false;
			anim.SetTrigger ("DoubleJump");
		}

        instructions.SetActive(false);
	}

	public void Attack() {
		if(timeToAttackPassed) {
			anim.SetTrigger ("attack");
			Instantiate (goodShade, goodShadePos.position, transform.rotation);
			timeToAttackPassed = false;
            //Sound Effect-----------------------------------
            //SoundController.instance.PlayAttack();
		}

        instructions.SetActive(false);
	}

    public void SuperPower()
    {
        InvokeRepeating("LaunchGoodShadesRepeatedly", 0, 0.4f);
    }

    public void LaunchGoodShadesRepeatedly()
    {
        Instantiate(infiniteGoodShade, new Vector3(goodShadePos.position.x, goodShadePos.position.y + 0.3f,
            goodShadePos.position.z), transform.rotation);
    }

    public void AfterSuperPower()
    {
        CancelInvoke();
    }


    
    public void Dodge()
    {
        //Vector3 fp;
        //Vector3 lp;
        

        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                //fp = touch.position;
                //lp = touch.position;
            }

            else if(touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;
            }

            else if(touch.phase == TouchPhase.Ended)
            {
                lp = touch.position;
                if(Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                    if(Mathf.Abs(lp.x - fp.x) < Mathf.Abs(lp.y - fp.y))
                    {
                        if(lp.y > fp.y) //Up Swipe
                        {
                            Jump();
                        }
                        else //Down Swipe
                        {
                            StartCoroutine(DodgeAid());

                        }
                    }
                }
            }
        }
        
    }

    IEnumerator DodgeAid()
    {
        if (grounded)
        {
            //float timestampD;
            transform.Rotate(0, 0, 90);
            yield return new WaitForSeconds(0.75f);
            transform.Rotate(0, 0, -90);
        }

        else
        {
            myBody.AddForce(new Vector2(0,200), ForceMode2D.Impulse);
        }
    }
		
}
