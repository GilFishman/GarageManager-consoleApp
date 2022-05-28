using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicensePlateNumber;
        private float           m_LeftEnergyPercentageInEngine;
        List<Wheel>             m_Wheels;
        private Engine          m_Engine;

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicensePlateNumber
        {
            get
            {
                return r_LicensePlateNumber;
            }
        }

        public float LeftEnergyPercentageInEngine
        {
            get
            {
                return m_LeftEnergyPercentageInEngine;
            }
            set
            {
                m_LeftEnergyPercentageInEngine = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        public Vehicle(string i_ModelName, string i_LicensePlateNumber, float i_LeftEnergyPercentageInEngine, Engine i_Engine)
        {
            r_ModelName = i_ModelName;
            r_LicensePlateNumber = i_LicensePlateNumber;
            if(i_LeftEnergyPercentageInEngine > 1)
            {
                throw new ValueOutOfRangeException("left enery", 0, 1);
            }
            else
            {
                m_LeftEnergyPercentageInEngine = i_LeftEnergyPercentageInEngine;
            }
           
            m_Wheels = new List<Wheel>();
            m_Engine = i_Engine;
        }

        protected void CreateVehicleWheels(int i_NumberOfWheels, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure, float i_WheelsMaxAirPressureByManufacture)
        {
            for(int i = 0; i < i_NumberOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_WheelsManufacturerName, i_WheelsCurrentAirPressure, i_WheelsMaxAirPressureByManufacture));
            }
        }

        public void AirInflationToMax()
        {
            for (int i = 0; i < m_Wheels.Count(); i++)
            {
                m_Wheels[i].AirInflationToMax();
            }
        }

        public override string ToString()
        {
            StringBuilder objectToString = new StringBuilder();

            objectToString.AppendFormat(string.Format("Vehicle details:{0}Model name is {1}.{0}License plate number is {2}.{0}Left energy percentage in the engine is {3}.{0}Number of wheels is {4}.{0}", Environment.NewLine, r_ModelName, r_LicensePlateNumber, m_LeftEnergyPercentageInEngine, m_Wheels.Count()));
            objectToString.Append(m_Engine.ToString());
            if(m_Wheels.Count() > 0)
            {
                objectToString.Append(m_Wheels[0].ToString());
            }

            return objectToString.ToString();
        }
    }
}
