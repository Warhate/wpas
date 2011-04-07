using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace Myprojekt
{
    /*
     * Singleton
     */
    public class Settings
    {
              
        private static Settings instance;

        // имя файла для сохранения настроек
        private String m_settingsFilename = "wpasSettings.xml";

        // адрес сервера для получения данных
        private String m_serverAddress;
        // частота обновления данных
        private int m_updateRate;

        public String serverAddress
        {
            get
            {
                return m_serverAddress;
            }
            set
            {
                m_serverAddress = value;
            }
        }

        public int updateRate
        {
            get
            {
                return m_updateRate;
            }
            set
            {
                m_updateRate = value;
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
            XPathDocument doc = new XPathDocument(m_settingsFilename);
            XPathNavigator settingsNav = doc.CreateNavigator();

            m_serverAddress = settingsNav.SelectSingleNode("/mainSettings/updatesPath").Value;
            m_updateRate = int.Parse(settingsNav.SelectSingleNode("/mainSettings/updatesRate").Value);
        }

        public void saveSettings()
        {
            XmlTextWriter xmlWriter = new XmlTextWriter(m_settingsFilename, null);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("mainSettings");

            //сервер обновлений
            xmlWriter.WriteStartElement("updatesPath");
            xmlWriter.WriteString(m_serverAddress);
            xmlWriter.WriteEndElement();

            //частота обновлений
            xmlWriter.WriteStartElement("updatesRate");
            xmlWriter.WriteString(m_updateRate.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

    }
}
