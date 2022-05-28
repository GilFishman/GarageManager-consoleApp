using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
            set
            {
                m_MaxValue = value;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
            set
            {
                m_MinValue = value;
            }
        }

        public ValueOutOfRangeException(string i_Input, float i_MaxValue, float i_MinValue)
            : base(string.Format("The value of {0} is out of range. The value should be between {1} to {2}", i_Input, i_MaxValue, i_MinValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
