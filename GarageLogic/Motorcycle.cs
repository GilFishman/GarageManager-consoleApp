using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GarageLogic.enums;

namespace GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A1,
            B1,
            BB
        }

        private readonly eLicenseType   r_LicenseType;
        private readonly int            r_CCEngineVolume;

        public eLicenseType LicenseType
        { 
            get
            {
                return r_LicenseType;
            }
        }

        public int CCEngineVolume
        {
            get
            {
                return r_CCEngineVolume;
            }
        }

        public Motorcycle(string i_ModelName, string i_LicensePlateNumber, float i_LeftEnergyPercentageInEngine, Engine i_Engine, eLicenseType i_LicenseType, int i_CCEngineVolume, int i_NumberOfWheels,string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure, float i_WheelsMaxAirPressureByManufacture)
           : base(i_ModelName, i_LicensePlateNumber, i_LeftEnergyPercentageInEngine, i_Engine)
        {
            r_LicenseType = i_LicenseType;
            r_CCEngineVolume = i_CCEngineVolume;
            CreateVehicleWheels(i_NumberOfWheels, i_WheelsManufacturerName, i_WheelsCurrentAirPressure, i_WheelsMaxAirPressureByManufacture);
        }

        public override string ToString()
        {
            StringBuilder objectToString = new StringBuilder();

            objectToString.Append(base.ToString());
            objectToString.AppendFormat(string.Format("Motorcycle details:{0}Motorcycler license type is {1}.{0}Motorcycle's cc engine volume is {2}.{0}", Environment.NewLine, r_LicenseType, r_CCEngineVolume));

            return objectToString.ToString();
        }
    }
}
