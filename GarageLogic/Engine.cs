using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageLogic
{
    public abstract class Engine
    {
        private float           m_CurrentEnergyAmount;
        private readonly float  r_MaxEnergyAmount;

        public float CurrentEnergyAmount
        {
            get
            {
                return m_CurrentEnergyAmount;
            }
            set
            {
                m_CurrentEnergyAmount = value;
            }
        }

        public float MaxEnergyAmount
        {
            get
            {
                return r_MaxEnergyAmount;
            }
        }

        public Engine(float i_CurrentEnergyAmount, float i_MaxEnergyAmount)
        {
            r_MaxEnergyAmount = i_MaxEnergyAmount;
            if(i_CurrentEnergyAmount > i_MaxEnergyAmount)
            {
                throw new ValueOutOfRangeException("enrge amount", 0, i_MaxEnergyAmount);
            }
            else
            {
                m_CurrentEnergyAmount = i_CurrentEnergyAmount;
            }
        }

        public void EnergyCharging(float i_EnergyToAdd)
        { 
            if (i_EnergyToAdd < 0 || m_CurrentEnergyAmount + i_EnergyToAdd > r_MaxEnergyAmount)
            {
                throw new ValueOutOfRangeException("added enrgy", 0, r_MaxEnergyAmount);
            }
            else
            {
                m_CurrentEnergyAmount = m_CurrentEnergyAmount + i_EnergyToAdd;
            }
        }

        public override string ToString()
        {
            StringBuilder objectToString = new StringBuilder();

            objectToString.AppendFormat(string.Format("Engine details:{0}", Environment.NewLine));

            return objectToString.ToString();
        }
    }
}
