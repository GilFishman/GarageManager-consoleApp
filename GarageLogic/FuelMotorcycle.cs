using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GarageLogic.enums;

namespace GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        private static readonly int                     sr_NumberOfWheels = 2;
        private static readonly float                   sr_MaxAirmaxPressure = 31;
        private static readonly FuelEngine.eFuelType    sr_FuelType = FuelEngine.eFuelType.Octan98;
        private static readonly float                   sr_LiterFuelTank = 6.2f;

        public FuelMotorcycle(string i_ModelName, string i_LicensePlateNumber, float i_CurrentEnergyAmount, eLicenseType i_LicenseType, int i_CCEngineVolume, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
          : base(i_ModelName, i_LicensePlateNumber, i_CurrentEnergyAmount / sr_LiterFuelTank, new FuelEngine(sr_FuelType, i_CurrentEnergyAmount, sr_LiterFuelTank), i_LicenseType, i_CCEngineVolume, sr_NumberOfWheels, i_WheelsManufacturerName, i_WheelsCurrentAirPressure, sr_MaxAirmaxPressure)
        { }
    }
}
