using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GarageLogic.enums;

namespace GarageLogic
{
    public class ElectricCar : Car
    {
        private static readonly int     sr_NumberOfWheels = 4;
        private static readonly float   sr_MaxAirmaxPressure = 29;
        private static readonly float   sr_MaxBatteryTime = 3.3f;

        public ElectricCar(string i_ModelName, string i_LicensePlateNumber, float i_CurrentEnergyAmount, eColor i_CarColor, eNumberOfDoors i_NumberOfDoors, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
            : base(i_ModelName, i_LicensePlateNumber, i_CurrentEnergyAmount / sr_MaxBatteryTime, new ElectricEngine(i_CurrentEnergyAmount, sr_MaxBatteryTime), i_CarColor, i_NumberOfDoors, sr_NumberOfWheels ,i_WheelsManufacturerName, i_WheelsCurrentAirPressure, sr_MaxAirmaxPressure)
        { }
    }
}
