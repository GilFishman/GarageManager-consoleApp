using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GarageLogic.enums;

namespace GarageLogic
{
    public class VehicleBuilder
    {
        public static Vehicle CreateNewElectricCar(string i_ModelName, string i_LicensePlateNumber, float i_CurrentEnergyAmount, Car.eColor i_CarColor, Car.eNumberOfDoors i_NumberOfDoors, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
        {
            return new ElectricCar(i_ModelName, i_LicensePlateNumber, i_CurrentEnergyAmount, i_CarColor, i_NumberOfDoors, i_WheelsManufacturerName, i_WheelsCurrentAirPressure);
        }

        public static Vehicle CreateNewFuelCar(string i_ModelName, string i_LicensePlateNumber, float i_CurrentEnergyAmount, Car.eColor i_CarColor, Car.eNumberOfDoors i_NumberOfDoors, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure) 
        {
            return new FuelCar(i_ModelName, i_LicensePlateNumber, i_CurrentEnergyAmount, i_CarColor, i_NumberOfDoors, i_WheelsManufacturerName, i_WheelsCurrentAirPressure);
        }

        public static Vehicle CreateNewElectricMotorcycle(string i_ModelName, string i_LicensePlateNumber, float i_CurrentEnergyAmount, Motorcycle.eLicenseType i_LicenseType, int i_CCEngineVolume, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
        {
            return new ElectricMotorcycle(i_ModelName, i_LicensePlateNumber, i_CurrentEnergyAmount, i_LicenseType, i_CCEngineVolume, i_WheelsManufacturerName, i_WheelsCurrentAirPressure);
        }

        public static Vehicle CreateNewFuelMotorcycle(string i_ModelName, string i_LicensePlateNumber, float i_CurrentEnergyAmount, Motorcycle.eLicenseType i_LicenseType, int i_CCEngineVolume, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
        {
            return new FuelMotorcycle(i_ModelName, i_LicensePlateNumber, i_CurrentEnergyAmount, i_LicenseType, i_CCEngineVolume, i_WheelsManufacturerName, i_WheelsCurrentAirPressure);
        }

        public static Vehicle CreateNewFuelTruck(string i_ModelName, string i_LicensePlateNumber, float i_CurrentEnergyAmount, bool i_IsDriveRefrigeratedContents, float i_CargoVolume, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
        {
            return new FuelTruck(i_ModelName, i_LicensePlateNumber, i_CurrentEnergyAmount, i_IsDriveRefrigeratedContents, i_CargoVolume, i_WheelsManufacturerName, i_WheelsCurrentAirPressure);
        }
    }
}
