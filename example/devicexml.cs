using System.Xml.Serialization;
using System.Collections.Generic;

namespace XmlReader
{
    public enum DeviceType { A3, A4 }

    [Serializable]
    [XmlRoot("Devices")]
    public class Devices
    {
        [XmlElement("Dev")]
        public List<Device> DeviceList { get; set; }
    }

    public class Device
    {
        [XmlAttribute("SrNo")]
        public string SrNo { get; set; }
        public string Address { get; set; }
        public string DevName { get; set; }
        public string ModelName { get; set; }
        public string Type { get; set; }

        public CommSetting CommSetting { get; set; }
    }

    public class CommSetting
    {
        public int PortNo { get; set; }
        public bool UseSSL { get; set; }
        public string Password { get; set; }
    }

    public class DeviceErroInfo
    {
        public string SrNoError { get; set; }
        public string AddressError { get; set; }
        public string DevNameError { get; set; }
        public string ModelNameError { get; set; }
        public string TypeError { get; set; }
        public string PortNoError { get; set; }
        public string UseSSLError { get; set; }
        public string PasswordError { get; set; }

        public CommSetting CommSetting { get; set; }
    }

    public class commSettingerrorinfo
    {
        public string PortNoerror { get; set; }
        public string UseSSLerror { get; set; }
        public string Passworderror { get; set; }
    }
}
