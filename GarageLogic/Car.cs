using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GarageLogic.enums;

namespace GarageLogic
{
    public abstract class Car : Vehicle
    {
        public enum eColor
        {
            Red,
            White,
            Green,
            Blue
        }

        public enum eNumberOfDoors
        {
            Two,
            Three,
            Four,
            Five
        }

        private readonly eColor         r_CarColor;
        private readonly eNumberOfDoors r_NumberOfDoors;

        public eColor CarColor
        {
            get
            {
                return r_CarColor;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return r_NumberOfDoors;
            }
        }

        public Car(string i_ModelName, string i_LicensePlateNumber, float i_LeftEnergyPercentageInEngine, Engine i_Engine, eColor i_CarColor, eNumberOfDoors i_NumberOfDoors, int i_NumberOfWheels, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure, float i_WheelsMaxAirPressureByManufacture) 
            : base(i_ModelName, i_LicensePlateNumber, i_LeftEnergyPercentageInEngine, i_Engine)
        {
            r_CarColor = i_CarColor;
            r_NumberOfDoors = i_NumberOfDoors;
            CreateVehicleWheels(i_NumberOfWheels, i_WheelsManufacturerName, i_WheelsCurrentAirPressure, i_WheelsMaxAirPressureByManufacture);
        }

        public override string ToString()
        {
            StringBuilder objectToString = new StringBuilder();

            objectToString.Append(base.ToString());
            objectToString.AppendFormat(string.Format("Car details:{0}Car color is {1}.{0}Car's number of doors plate number is {2}.{0}", Environment.NewLine, r_CarColor, r_NumberOfDoors));

            return objectToString.ToString();
        }
    }
}
