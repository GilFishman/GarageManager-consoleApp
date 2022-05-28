using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GarageLogic.enums;

namespace GarageLogic
{
    public class GarageManagement
    {
        public readonly Garage r_Garage;

        public GarageManagement()
        {
            r_Garage = new Garage(); 
        }

        public void ChangeVehicleCondition (string i_VehicleLicensePlateNumber, Garage.eConditionOfVehicleInGarage i_NewCondition)
        { 
            r_Garage.ChangeConditionOfVehicleOnGarage(i_VehicleLicensePlateNumber, i_NewCondition);
        }

        public void AddExistVehicelToGarage(string i_VehicleLicensePlateNumber)
        {
            r_Garage.AddExistVehicalToTheGarage(i_VehicleLicensePlateNumber);
        }

        public List<string> VehicleListInGarage()
        {
            return r_Garage.VehicleListInGarage();
        }

        public List<string> VehicleListInGarageAccordingToCondition(Garage.eConditionOfVehicleInGarage i_NewCondition)
        {
            return r_Garage.VehicleListInGarageAccordingToCondition(i_NewCondition);
        }

        public void InflatingVehicleWheelsToMax(string i_LicensePlateNumber)
        {
            r_Garage.InflatingVehicleWheelsToMax(i_LicensePlateNumber);
        }

        public void VehicleCharge(string i_LicensePlateNumber, float i_ChargeMinutes)
        {
            r_Garage.VehicleCharge(i_LicensePlateNumber, i_ChargeMinutes);
        }

        public void VehicleRefuel(string i_LicensePlateNumber, FuelEngine.eFuelType i_FuelType, float i_LitersOfFuel)
        {
            r_Garage.VehicleRefueling(i_LicensePlateNumber, i_FuelType, i_LitersOfFuel);
        }

        public VehicleGarageDetails DisplayVehicleInformation(string i_LicensePlateNumber)
        {
            return r_Garage.GetVehicleFromGarage(i_LicensePlateNumber);
        }

        public void AddNewVehicleToGarage (string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            r_Garage.AddNewVehiclesToGarage(i_OwnerName, i_OwnerPhone, i_Vehicle);
        }
    }
}
