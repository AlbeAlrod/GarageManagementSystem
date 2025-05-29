using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class CustomerInfo
    {
        private string m_PersonName;
        private string m_PhoneNumber;

        public CustomerInfo()
        {
            m_PersonName = string.Empty;
            m_PhoneNumber = string.Empty;
        }

        public Dictionary<string, string> CreateParametersDictForUser()
        {
            Dictionary<string, string> parametersForUser = new Dictionary<string, string>();
            parametersForUser.Add("OwnerName", "Please enter owner name:");
            parametersForUser.Add("OwnerPhoneNumber", "Please enter owner phone number:");
            return parametersForUser;
        }

        public void UpdateCustomerParams(Dictionary<string, string> i_ParametersFromUser)
        {
            m_PersonName = i_ParametersFromUser["OwnerName"];
            m_PhoneNumber = i_ParametersFromUser["OwnerPhoneNumber"];
        }

        public string PersonName
        {
            get { return m_PersonName; }
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
        }
    }
}