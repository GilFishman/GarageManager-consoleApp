using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GarageLogic.enums;

namespace GarageLogic
{
    public class ElectricEngine : Engine
    {
        public float RemainingHoursBattertTime
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

        public float MaxHoursBatteryTime
        {
            get
            {
                return base.MaxEnergyAmount;
            }
        }

        public ElectricEngine(float i_CurrentEnergyAmount, float i_MaxEnergyAmount) : base(i_CurrentEnergyAmount, i_MaxEnergyAmount)
        { }

        public void BatteryCharging(float i_BatteryHoursToAdd)
        {
            base.EnergyCharging(i_BatteryHoursToAdd);
        }

        public override string ToString()
        {
            StringBuilder objectToString = new StringBuilder();

            objectToString.Append(base.ToString());
            objectToString.AppendFormat(string.Format("This engine is from type Electric.{0}Remaining hours Of Battert time is {1} from {2} max hours of battery time.{0}", Environment.NewLine, RemainingHoursBattertTime, MaxHoursBatteryTime));
           
            return objectToString.ToString();
        }
    }
}
