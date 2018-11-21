using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovLogic : MonoBehaviour 
{
    [SerializeField]
    private float lowImpulse;
    [SerializeField]
    private float highImpulse;

    private float impulseValue;

    private void Start()
    {
        impulseValue = 0f;
        
    }

    public IEnumerator PlayerMovement(InputManager input, Hero hero)
    {
        if (input != null)
        {
            while (true)
            {
                if (input.GetLongTap())
                {
                    //Debug.Log("DOUBLE TAPPPP");
                    impulseValue = highImpulse;
                }
                else
                {
                    impulseValue = lowImpulse;

                }
                if (input.GetRightTap() && input.GetHasTaped())
                {
                    hero.GetComponent<Hero>().Move(1, impulseValue, input.GetLongTapTimer());
                    //hero.GetComponent<Hero>().Tp(1);


                }
                else if (!input.GetRightTap() && input.GetHasTaped())
                {
                    hero.GetComponent<Hero>().Move(-1, impulseValue, input.GetLongTapTimer());

                }
                yield return null;
            }
        }
    }
}
