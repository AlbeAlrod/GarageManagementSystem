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
			Dictionary<string, string> paramsDict = new Dictionary<string, string>();
			paramsDict.Add("OwnerName", "Please enter owner name:");
			paramsDict.Add("OwnerPhoneNumber", "Please enter owner phone number:");
			return paramsDict;
		}

		public void UpdateCustomerParams(Dictionary<string, string> paramsDict)
		{
			m_PersonName = paramsDict["OwnerName"];
			m_PhoneNumber = paramsDict["OwnerPhoneNumber"];
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