using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    //[SerializeField]
    private MovLogic mov;

    [SerializeField]
    private GameObject hero;

    [SerializeField]
    private GameObject generator;

    //[SerializeField]
    private InputManager input;

    [SerializeField]
    private Score score;

    [SerializeField]
    private Life life;

    [SerializeField]
    private float lavaDamage;

    [SerializeField]
    private float speedUpPowerUp;
   
    public int DebugScore;

	// Use this for initialization
	void Start () {
        input = GetComponent<InputManager>();
        mov = GetComponent<MovLogic>();
        score = GetComponent<Score>();

        //pUpLogic = GetComponent<PowerUpLogic>();
        //life = GetComponent<Life>();

        StartCoroutine(mov.PlayerMovement(input, hero.GetComponent<Hero>()));
	}


	// Update is called once per frame
	void Update () {
        if(life.isDead) {
            hero.SetActive(false);
        }
        else if(hero.GetComponent<Hero>().PlayerIsOnTile() == false) 
        {
            //life.Damage(lavaDamage);
            //hero.GetComponent<Hero>().ChangeSprite(life.lifePoints, hero.GetComponent<SpriteRenderer>());
            hero.GetComponent<Hero>().UpdateSize();
        }
       
        if(hero.GetComponent<Hero>().HasCollidedWithHeal()) 
        {
            life.Heal(20);

            hero.GetComponent<Hero>().UpdateCollidedWithHeal(false);
        }

        score.ScoreCounterText(GameObject.Find("Score"));

        if (hero.GetComponent<Hero>().HasCollidedWithPoint())
        {

            score.GetComponent<Score>().SetScore(1);

            hero.GetComponent<Hero>().UpdateCollidedWithPoint(false);
            
        }

        if (hero.GetComponent<Hero>().HasCollidedWithSpeedUp())
        {
            this.GetComponent<Scroll>().SetSpeedUp(speedUpPowerUp);

            hero.GetComponent<Hero>().UpdateCollidedWithSpeedUp(false);

            StartCoroutine(GetComponent<Scroll>().NormaliseSpeedUp());
        }
    }

}
