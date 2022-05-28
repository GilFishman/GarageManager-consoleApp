using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GarageLogic.enums;

namespace GarageLogic
{
    public class VehicleGarageDetails
    {
        private readonly string                     r_OwnerName;
        private readonly string                     r_OwnerPhone;
        private Garage.eConditionOfVehicleInGarage  m_ConditionOfVehicleInGarage;
        private Vehicle                             m_Vehicle;

        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return r_OwnerPhone;
            }
        }

        public Garage.eConditionOfVehicleInGarage ConditionOfVehicleInGarage
        {
            get
            {
                return m_ConditionOfVehicleInGarage;
            }
            set
            {
                m_ConditionOfVehicleInGarage = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }

        public VehicleGarageDetails(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhone = i_OwnerPhone;
            m_Vehicle = i_Vehicle;
            m_ConditionOfVehicleInGarage = Garage.eConditionOfVehicleInGarage.InRepair;
        }

        public override string ToString()
        {
            StringBuilder objectToString = new StringBuilder();

            objectToString.AppendFormat(m_Vehicle.ToString());
            objectToString.AppendFormat(string.Format("vehicle Garage Details:{0}The owner of the vehicle is {1}.{0}Owner phone is {2}.{0}The condition of the vehicle in the garage is: {3}.{0}", Environment.NewLine, r_OwnerName, r_OwnerPhone, m_ConditionOfVehicleInGarage));

            return objectToString.ToString();
        }
    }
}
