using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageLogic
{
    public class Wheel
    {
        private readonly string     r_ManufacturerName;
        private float               m_CurrentAirPressure;
        private readonly float      r_MaxAirPressureByManufacture;

        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressureByManufacture
        {
            get
            {
                return r_MaxAirPressureByManufacture;
            }
        }

        public Wheel(string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure, float i_WheelsMaxAirPressureByManufacture)
        {
            r_ManufacturerName = i_WheelsManufacturerName;
            r_MaxAirPressureByManufacture = i_WheelsMaxAirPressureByManufacture;
            if(i_WheelsCurrentAirPressure > i_WheelsMaxAirPressureByManufacture)
            {
                throw new ValueOutOfRangeException("wheels air pressure", 0, i_WheelsMaxAirPressureByManufacture);
            }
            else
            {
                m_CurrentAirPressure = i_WheelsCurrentAirPressure;
            }  
        }

        private void airInflation(float i_AirPressureToAdd)
        {
            if(i_AirPressureToAdd < 0 || m_CurrentAirPressure + i_AirPressureToAdd > r_MaxAirPressureByManufacture)
            {
                throw new ValueOutOfRangeException("added air pressure", 0, r_MaxAirPressureByManufacture);
            }
            else
            {
                m_CurrentAirPressure = m_CurrentAirPressure + i_AirPressureToAdd;
            }
        }

        public void AirInflationToMax()
        {
            airInflation(r_MaxAirPressureByManufacture - m_CurrentAirPressure);
        }

        public override string ToString()
        {
            StringBuilder objectToString = new StringBuilder();

            objectToString.AppendFormat(string.Format("Wheel details:{0}Manufacturer name of the wheel is {1}.{0}Current air pressure of the wheel is {2} from max air pressure {3}.{0}", Environment.NewLine, r_ManufacturerName, m_CurrentAirPressure, r_MaxAirPressureByManufacture));

            return objectToString.ToString();
        }
    }
}
