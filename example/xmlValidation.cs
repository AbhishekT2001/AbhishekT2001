using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace XmlReader
{
    public class XmlValidation
    {
        public static Dictionary<string ,string > ValidateXmlInfo(Devices devices, out List<DeviceErroInfo> errorinfos)
        {
            bool hasError = false;
            errorinfos = new List<DeviceErroInfo>();
            Dictionary<string , string > dictionary = new Dictionary<string , string>();

            for (int i = 0; i < devices.DeviceList.Count; i++)
            {
                string password = devices.DeviceList[i].CommSetting.Password;
                string encryptedPassword = Encryption.EncryptString(password);

                var errorinfo = ValidateBranch(devices.DeviceList[i]);
                if (errorinfo == null)
                {
                    dictionary.Add(devices.DeviceList[i].SrNo, "");
                }
                else
                {
                    hasError = true;
                    errorinfos.Add(errorinfo);
                }
            }

            if (!hasError)
            {
                Console.WriteLine("All branches are valid.");
            }

            return !hasError;
        }

        private static DeviceErroInfo ValidateBranch(Device device)
        {
            DeviceErroInfo errorinfo = new DeviceErroInfo();
            bool isErrorExist = false;

            if (!ValidateSerialNumber(device.SrNo, out string error))
            {
                isErrorExist = true;
                errorinfo.SrNoError = error;
            }
            if (!ValidateIpAddress(device.Address, out error))
            {
                isErrorExist = true;
                errorinfo.AddressError = error;
            }
            if (!ValidateDevName(device.DevName, out error))
            {
                isErrorExist = true;
                errorinfo.DevNameError = error;
            }
            if (!ValidateModelName(device.ModelName, out error))
            {
                isErrorExist = true;
                errorinfo.ModelNameError = error;
            }
            if (!ValidateType(device.Type, out error))
            {
                isErrorExist = true;
                errorinfo.TypeError = error;
            }
            if (!ValidatePortNo(device.CommSetting.PortNo, out error))
            {
                isErrorExist = true;
                errorinfo.PortNoError = error;
            }

            if (!ValidateUseSSL(device.CommSetting.UseSSL.ToString(), out error))
            {
                isErrorExist = true;
                errorinfo.UseSSLError = error;
            }
            if (!ValidatePassword(device.CommSetting.Password, out error))
            {
                isErrorExist = true;
                errorinfo.PasswordError = error;
            }

            return isErrorExist ? errorinfo : null;
        }

        private static bool ValidateSerialNumber(string value, out string error)
        {
            bool result = true;
            error = $"SerialNumber: {value}";

            if (string.IsNullOrWhiteSpace(value))
            {
                error += "(Serial Number cannot be empty)";
                result = false;
            }
            if (!Regex.IsMatch(value, @"^[a-zA-Z0-9]+$"))
            {
                error += " (Serial Number contains invalid characters)";
                result = false;
            }
            return result;
        }

        private static bool ValidateIpAddress(string value, out string error)
        {
            bool result = true;
            error = $"IpAddress: {value}";

            if (!Regex.IsMatch(value, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"))
            {
                error += " (IpAddress is invalid)";
                result = false;
            }

            if (value.Length > 15)
            {
                error += "(IpAddress is too long)";
                result = false;
            }
            return result;
        }

        private static bool ValidateDevName(string value, out string error)
        {
            bool result = true;
            error = $"DevName: {value}";

            if (!Regex.IsMatch(value, @"^[a-zA-Z0-9\s]+$"))
            {
                error += " (DevName contains invalid characters)";
                result = false;
            }

            if (value.Length > 24)
            {
                error += "(DevName is too long)";
                result = false;
            }
            return result;
        }

        private static bool ValidateModelName(string value, out string error)
        {
            bool result = true;
            error = $"ModelName: {value}";

            if (!Regex.IsMatch(value, @"^[a-zA-Z0-9\s]+$"))
            {
                error += " (ModelName contains invalid characters)";
                result = false;
            }

            if (value.Length > 50)
            {
                error += "(ModelName is too long)";
                result = false;
            }
            return result;
        }

        private static bool ValidateType(string value, out string error)
        {
            bool result = true;
            error = $"Type: {value}";

            if (value.Length <= 0)  
            {
                error += "(Type cannot be empty)";
                result = false;
            }
            return result;
        }

        private static bool ValidatePortNo(int value, out string error)
        {
            bool result = true;
            error = $"PortNo: {value}";

            if (value <= 0)
            {
                error += "(PortNo must be a positive integer)";
                result = false;
            }
            return result;
        }


        private static bool ValidateUseSSL(string value, out string error)
        {
            bool result = true;
            error = $"UseSSL: {value}";

            if (string.IsNullOrEmpty(value))
            {
                error += "(UseSSL cannot be empty)";
                result = false;
            }
            else if (!bool.TryParse(value, out _))
            {
                error += "(UseSSL is not valid)";
                result = false;
            }
            return result;
        }

        private static bool ValidatePassword(string value, out string error)
        {
            bool result = true;
            error = $"Password: {value}";

            if (value.Length < 1 || value.Length > 64)
            {
                error += "(Password length is not valid)";
                result = false;
            }
            if (!Regex.IsMatch(value, @"^[a-zA-Z0-9\s\#$%]+$"))
            {
                error += "(Password contains invalid characters)";
                result = false;
            }
            return result;
        }
    }
}
