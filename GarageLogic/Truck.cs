using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private bool            m_IsDriveRefrigeratedContents;
        private readonly float  r_CargoVolume;

        public bool IsDriveRefrigeratedContents
        {
            get
            {
                return m_IsDriveRefrigeratedContents;
            }
            set
            {
                m_IsDriveRefrigeratedContents = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return r_CargoVolume;
            }
        }

        public Truck(string i_ModelName, string i_LicensePlateNumber, float i_LeftEnergyPercentageInEngine, Engine i_Engine, bool i_IsDriveRefrigeratedContents, float i_CargoVolume, int i_NumberOfWheels, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure, float i_WheelsMaxAirPressureByManufacture)
            : base(i_ModelName, i_LicensePlateNumber, i_LeftEnergyPercentageInEngine, i_Engine)
        {
            m_IsDriveRefrigeratedContents = i_IsDriveRefrigeratedContents;
            r_CargoVolume = i_CargoVolume;
            CreateVehicleWheels(i_NumberOfWheels, i_WheelsManufacturerName, i_WheelsCurrentAirPressure, i_WheelsMaxAirPressureByManufacture);
        }

        public override string ToString()
        {
            StringBuilder objectToString = new StringBuilder();

            objectToString.Append(base.ToString());
            if (m_IsDriveRefrigeratedContents)
            {
                objectToString.AppendFormat(string.Format("Truck details:{0}Truck drives refrigerated contents.{0}Truck's cargo volume is {1}.{0}", Environment.NewLine, r_CargoVolume));
            }
            else
            {
                objectToString.AppendFormat(string.Format("Truck details:{0}Truck does not drives refrigerated contents.{0}Truck's cargo volume is {1}.{0}", Environment.NewLine, r_CargoVolume));
            }

            return objectToString.ToString();
        }
    }
}
