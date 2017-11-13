using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
    {
        private static Text money;
        public static int CurrentMoney { get; private set; }
        // Use this for initialization
        internal void Start()
        {

     money = GetComponent<Text>();
            CurrentMoney = 50;
            UpdateScore();
        }
        public static void AddMoney(int value)
        {
            CurrentMoney += value;
            UpdateScore();
        }

        public static bool ConsumMoney(int value)
        {
            if(value > CurrentMoney)
            {
                return false;
            }
            CurrentMoney = CurrentMoney - value;
            UpdateScore();
            return true;
        }
            // Update is called once per frame
             private static void UpdateScore()
        {
            money.text = string.Format("{0}", CurrentMoney).PadLeft(4, '0');
        }
    }