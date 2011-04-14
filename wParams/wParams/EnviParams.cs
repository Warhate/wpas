using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wParams
{
    [Serializable]
    public class EnviParams
    {
        
        /*
         * 1 - N (север)
         * 2 - S (юг)
         * 3 - W (запад)
         * 4 - E (восток)
         * 5 - NW
         * 6 - SW
         * 7 - NE
         * 8 - SE
         */
        private int m_windDirection;
        
        // метры в секунду, 
        // или фиг его знает.
        private int m_windForce;
        
        public int Windforce
        {
            get { return m_windForce; }
            set { m_windForce = value; }
        }
        public int WindDirection
        {
            get { return m_windDirection; }
            set { m_windDirection = value; }
        }
    }
}
