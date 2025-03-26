using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeLock : MonoBehaviour
{
    int digitOne;
    int digitTwo;
    int digitThree;
    int digitFour;

    public int combination; //if the combination given here does not have 4 digits, the code will supply a 0 at the begining for each missing digit
    int comboOne;
    int comboTwo;
    int comboThree;
    int comboFour;

    public float antiBrute;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.unscaledTime;
        
        float holder = combination;
        float digOne;
        if (combination < 1000)
        {
            digOne = 0;
        }
        else
        {
            digOne = holder - (holder % 1000);
            digOne = digOne / 1000;
        }
        float digTwo;
        if (combination < 100)
        {
            digTwo = 0;
        }
        else
        {
            digTwo = holder - (digOne * 1000);
            digTwo = digTwo - (digTwo % 100);
            digTwo = digTwo / 100;
        }
        float digThree;
        if (combination < 10)
        {
            digThree = 0;
        }
        else
        {
            digThree = holder - (digOne * 1000) - (digTwo * 100);
            digThree = digThree - (digThree % 10);
            digThree = digThree / 10;
        }
        float digFour;
        digFour = holder - (digOne * 1000) - (digTwo * 100) - (digThree * 10);
        comboOne = (int)digOne;
        comboTwo = (int)digTwo;
        comboThree = (int)digThree;
        comboFour = (int)digFour;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //increase assumes that when true, the player is trying to increase the number on the safe, i.e. 1 to 2, or 9 to 0
    //it also assumes that when false, the player is trying to decrease the number on the safe, i.e. 9 to 8, or 0 to 9
    public int DigitSpin(int digit, bool increase) 
    {
        currentTime = Time.unscaledTime;
        if (increase == true)
        {
            if (digit == 9)
            {
                return 0;
            }
            else
            {
                digit++;
                return digit;
            }
        }
        else
        {
            if (digit == 0)
            {
                return 9;
            }
            else
            {
                digit--;
                return digit;
            }
        }
    }

    //specifically checks the time since the digit change made on the safe
    public bool ComboSubmitted(int first, int second, int third, int fourth) //this will only return true when all the digits input are correct and the anti brute time has passed
    {
        if (first == comboOne)
        {
            if (second == comboTwo)
            {
                if (third == comboThree)
                {
                    if (fourth == comboFour)
                    {
                        if (Time.unscaledTime - currentTime >= antiBrute) //prevents spamming through the numbers and brute forcing the safe
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
