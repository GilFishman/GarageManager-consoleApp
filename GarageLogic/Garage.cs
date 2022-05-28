using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GarageLogic.enums;

namespace GarageLogic
{
    public class Garage
    {
        public enum eConditionOfVehicleInGarage
        {
            InRepair,
            Fixed,
            PaidUp
        }

        private Dictionary<string, VehicleGarageDetails>    m_GarageCustomersNow;
        private const string                                k_NotFoundError = "Vehicle not found on this garage. Please try another license plate number";

        public Dictionary<string, VehicleGarageDetails> GarageCustomersNow
        {
            get
            {
                return m_GarageCustomersNow;
            }
        }

        public Garage()
        {
            m_GarageCustomersNow = new Dictionary<string, VehicleGarageDetails>();
        }

        public void AddNewVehiclesToGarage(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            VehicleGarageDetails vehicleGarageDetails = new VehicleGarageDetails(i_OwnerName, i_OwnerPhone, i_Vehicle);

            if (CheckIfVehicleInGarage(i_Vehicle.LicensePlateNumber))
            {
                throw new ArgumentException(k_NotFoundError);
            }
            else
            {
                m_GarageCustomersNow.Add(i_Vehicle.LicensePlateNumber, vehicleGarageDetails);
            }
        }

        public void AddExistVehicalToTheGarage(string i_VehicleLicensePlateNumber)
        {
            VehicleGarageDetails vehicleGarageDetailsOfExistVehicle;
            bool isOnTheGarage;

            isOnTheGarage = m_GarageCustomersNow.TryGetValue(i_VehicleLicensePlateNumber, out vehicleGarageDetailsOfExistVehicle);
            if (isOnTheGarage)
            {
                ChangeConditionOfVehicleOnGarage(i_VehicleLicensePlateNumber, eConditionOfVehicleInGarage.InRepair);
            }
            else
            {
                throw new ArgumentException(k_NotFoundError);
            }
        }

        public bool CheckIfVehicleInGarage(string i_VehicleLicensePlateNumber)
        {
            return m_GarageCustomersNow.ContainsKey(i_VehicleLicensePlateNumber);
        }

        public void ChangeConditionOfVehicleOnGarage(string i_VehicleLicensePlateNumber, eConditionOfVehicleInGarage i_NewCondition)
        {
            VehicleGarageDetails vehicleGarageDetails;
            bool isOnTheGarage;

            isOnTheGarage = m_GarageCustomersNow.TryGetValue(i_VehicleLicensePlateNumber, out vehicleGarageDetails);
            if (isOnTheGarage)
            {
                vehicleGarageDetails.ConditionOfVehicleInGarage = i_NewCondition;
            }
            else
            {
                throw new ArgumentException(k_NotFoundError);
            }
        }

        public void InflatingVehicleWheelsToMax(string i_LicensePlateNumber)
        {
            VehicleGarageDetails vehicleGarageDetails; 
            bool isOnTheGarage;

            isOnTheGarage = m_GarageCustomersNow.TryGetValue(i_LicensePlateNumber, out vehicleGarageDetails);
            if (isOnTheGarage)
            {
                vehicleGarageDetails.Vehicle.AirInflationToMax();
            }
            else
            {
                throw new ArgumentException(k_NotFoundError);
            }
        }

        public void VehicleRefueling(string i_LicensePlateNumber, FuelEngine.eFuelType i_FuelType, float i_LitersAmountToAdd)
        {
            VehicleGarageDetails vehicleGarageDetails;
            bool isOnTheGarage;
            FuelEngine fuelEngineOfVehicle;

            isOnTheGarage = m_GarageCustomersNow.TryGetValue(i_LicensePlateNumber, out vehicleGarageDetails);
            if (isOnTheGarage)
            {
                if(vehicleGarageDetails.Vehicle.Engine is FuelEngine)
                {
                    fuelEngineOfVehicle = (FuelEngine)vehicleGarageDetails.Vehicle.Engine;
                    fuelEngineOfVehicle.Refueling(i_LitersAmountToAdd, i_FuelType);
                }
                else
                {
                    throw new ArgumentException("Can not refule electric vehicle.");
                }
            }
            else
            {
                throw new ArgumentException(k_NotFoundError);
            }
        }

        public void VehicleCharge(string i_LicensePlateNumber, float i_ChargeMinutes)
        {
            VehicleGarageDetails vehicleGarageDetails;
            bool isOnTheGarage;
            ElectricEngine electricEngineOfVehicle;

            isOnTheGarage = m_GarageCustomersNow.TryGetValue(i_LicensePlateNumber, out vehicleGarageDetails);
            if (isOnTheGarage)
            {
                if (vehicleGarageDetails.Vehicle.Engine is ElectricEngine)
                {
                    electricEngineOfVehicle = (ElectricEngine)vehicleGarageDetails.Vehicle.Engine;
                    electricEngineOfVehicle.BatteryCharging(i_ChargeMinutes / 60);
                }
                else
                {
                    throw new ArgumentException("Can not change fuel vehicle.");
                }
            }
            else
            {
                throw new ArgumentException(k_NotFoundError);
            }
        }

        public List<string> VehicleListInGarage()
        {
            List<string> licensePlateNumberList = new List<string>();

            foreach (string licensePlateNumber in m_GarageCustomersNow.Keys)
            {
                licensePlateNumberList.Add(licensePlateNumber);
            }

            return licensePlateNumberList;
        }

        public List<string> VehicleListInGarageAccordingToCondition(eConditionOfVehicleInGarage i_NewCondition)
        {
            List<string> licensePlateNumberList = new List<string>();

            foreach (VehicleGarageDetails vehicleGarageDetails in m_GarageCustomersNow.Values)
            {
                if (vehicleGarageDetails.ConditionOfVehicleInGarage.Equals(i_NewCondition))
                {
                    licensePlateNumberList.Add(vehicleGarageDetails.Vehicle.LicensePlateNumber);
                }
            }

            return licensePlateNumberList;
        }

        public VehicleGarageDetails GetVehicleFromGarage(string i_LicensePlateNumber)
        {
            VehicleGarageDetails vehicleGarageDetailsOfExistVehicle;
            bool isOnTheGarage;

            isOnTheGarage = m_GarageCustomersNow.TryGetValue(i_LicensePlateNumber, out vehicleGarageDetailsOfExistVehicle);
            if (!isOnTheGarage)
            {
                throw new ArgumentException(k_NotFoundError);
            }

            return vehicleGarageDetailsOfExistVehicle;
        }
    }
}
