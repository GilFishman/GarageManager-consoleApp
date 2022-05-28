using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GarageLogic.enums;

namespace GarageLogic
{
    public class FuelCar : Car
    {
        private static readonly int                     sr_NumberOfWheels = 4;
        private static readonly float                   sr_MaxAirmaxPressure = 29;
        private static readonly FuelEngine.eFuelType    sr_FuelType = FuelEngine.eFuelType.Octan95;
        private static readonly float                   sr_LiterFuelTank = 38;

        public FuelCar(string i_ModelName, string i_LicensePlateNumber, float i_CurrentEnergyAmount, eColor i_CarColor, eNumberOfDoors i_NumberOfDoors, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
           : base(i_ModelName, i_LicensePlateNumber, i_CurrentEnergyAmount / sr_LiterFuelTank, new FuelEngine(sr_FuelType, i_CurrentEnergyAmount, sr_LiterFuelTank), i_CarColor, i_NumberOfDoors, sr_NumberOfWheels, i_WheelsManufacturerName, i_WheelsCurrentAirPressure, sr_MaxAirmaxPressure)
        { }
    }
}
