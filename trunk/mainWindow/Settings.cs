using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myprojekt
{
    /*
     * Singleton
     */
    class Settings
    {
              
        private static Settings instance;

        private String m_serverAddress;
        private int m_updateRate;

        public String serverAddress
        {
            get
            {
                return m_serverAddress;
            }
        }

        public int updateRate
        {
            get
            {
                return m_updateRate;
            }
        }
       
        private Settings() { }

        public static Settings Instance 
        {    
            get   
            {    
                if (instance == null)
                {      
                    instance = new Settings();   
                }
                return instance;
            }
        }

        public void loadSettings()
        {
        }

        public void saveSettings()
        {
        }

    }
}
