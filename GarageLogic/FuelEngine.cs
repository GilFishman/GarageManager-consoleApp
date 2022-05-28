using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GarageLogic.enums;

namespace GarageLogic
{
    public class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private readonly eFuelType r_FuelType;

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public float CurrentLitersFuelAmount
        {
            get
            {
                return base.CurrentEnergyAmount;
            }
            set
            {
                base.CurrentEnergyAmount = value;
            }
        }

        public float MaxLitersFuelAmount
        {
            get
            {
                return base.MaxEnergyAmount;
            }
        }

        public FuelEngine(eFuelType i_FuelType, float i_CurrentEnergyAmount, float i_MaxEnergyAmount) : base(i_CurrentEnergyAmount, i_MaxEnergyAmount)
        {
            r_FuelType = i_FuelType;
        }

        public void Refueling(float i_LitersAmountToAdd, eFuelType i_FuelTypeToAdd)
        {
            if (!i_FuelTypeToAdd.Equals(r_FuelType))
            {
                throw new ArgumentException("Given Fuel different from the vehicle's fuel");
            }
            else
            {
                base.EnergyCharging(i_LitersAmountToAdd);
            }
        }

        public override string ToString()
        {
            StringBuilder objectToString = new StringBuilder();

            objectToString.Append(base.ToString());
            objectToString.AppendFormat(string.Format("This engine is from type Fuel.{0}Vehicle fuel type is {1}.{0}Current liters fuel amount is {2} from {3} max liters fuel amount.{0}", Environment.NewLine, r_FuelType , CurrentLitersFuelAmount, MaxLitersFuelAmount));

            return objectToString.ToString();
        }
    }
}
