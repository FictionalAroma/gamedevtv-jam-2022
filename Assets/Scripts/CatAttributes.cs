using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class CatAttributes : MonoBehaviour
    {
        public const float HungerMax = 100f;
        
        public float HungerLevel = 100.0f;

        public float ThirstLevel = 100.0f;

        [Tooltip("the time in seconds after eating before cat starts getting hungry again")]

        public float HungerDelay = 60.0f;
        public float ThirstDelay = 60.0f;

        public float CurrentHungerDelay = 1.0f;
        public float CurrentThirstDelay = 1.0f;

        [Tooltip("Hunger loss rate per second")]
        public float HungerLossRate = 1.0f;
        public float ThirstLossRate = 1.0f;

        public TextMeshProUGUI HungerValueText;
        public TextMeshProUGUI ThirstValueText;
        public DropableItem HeldObject { get; set; }

        public void Update()
        {
            if (CurrentHungerDelay > float.Epsilon)
            {
                CurrentHungerDelay = DecayValues(CurrentHungerDelay, HungerLossRate);
            }
            else
            {
                HungerLevel = DecayValues(HungerLevel, HungerLossRate);
            }

            if (CurrentThirstDelay > float.Epsilon)
            {
                CurrentThirstDelay = DecayValues(CurrentThirstDelay, ThirstLossRate);
            }
            else
            {
                ThirstLevel = DecayValues(ThirstLevel, ThirstLossRate);
            }



            HungerValueText.text = HungerLevel.ToString("###", CultureInfo.InvariantCulture);
            ThirstValueText.text = ThirstLevel.ToString("###", CultureInfo.InvariantCulture);
        }

        private float DecayValues(float statToDecay, float decayLossRate)
        {
            statToDecay -= (decayLossRate * Time.deltaTime);
            return statToDecay = Math.Max(0f, statToDecay);
        }

        public float GetFoodNumberToEat => HungerMax - HungerLevel;

        public float EatFood(float foodAmount)
        {
            var maxEats = GetFoodNumberToEat;
            var amountEats = 0f;
            amountEats = maxEats < foodAmount
                                    ? foodAmount - maxEats
                                    : foodAmount;

            foodAmount -= amountEats;
            HungerLevel += amountEats;
            CurrentHungerDelay = HungerDelay;

            return foodAmount;
        }

        public bool HasSpaceInBag(DropableItem item)
        {
            return false;
        }

        public bool HasSpaceInBagPostCrafting(PickupableItem item)
        {
            return false;
        }


        public void PutInBag(DropableItem item)
        {
            
        }

        public void PutInBagPostCrafting(PickupableItem item)
        {

        }

    }
}
