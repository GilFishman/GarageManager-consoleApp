using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GarageLogic.enums;

namespace GarageLogic
{
    public class FuelTruck : Truck
    {
        private static readonly int                     sr_NumberOfWheels = 16;
        private static readonly float                   sr_MaxAirmaxPressure = 24;
        private static readonly FuelEngine.eFuelType    sr_FuelType = FuelEngine.eFuelType.Soler;
        private static readonly float                   sr_LiterFuelTank = 120;

        public FuelTruck(string i_ModelName, string i_LicensePlateNumber, float i_CurrentEnergyAmount, bool i_IsDriveRefrigeratedContents, float i_CargoVolume, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
         : base(i_ModelName, i_LicensePlateNumber, i_CurrentEnergyAmount / sr_LiterFuelTank, new FuelEngine(sr_FuelType, i_CurrentEnergyAmount, sr_LiterFuelTank), i_IsDriveRefrigeratedContents, i_CargoVolume, sr_NumberOfWheels, i_WheelsManufacturerName, i_WheelsCurrentAirPressure, sr_MaxAirmaxPressure)
        { }
    }
}
