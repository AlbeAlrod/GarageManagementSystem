using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.GarageLogic
{
				public class CustomerInfo
				{
								private string m_PersonName { get; set; }
								private string m_PhoneNumber { get; set; }
								
								

								public CustomerInfo()
								{
					
								}

								public Dictionary<string,string> CreateParametersDictForUser()
								{
												Dictionary<string, string> paramsDict = new Dictionary<string, string>();

												paramsDict.Add("OwnerName", "Please enter owner name:");
												paramsDict.Add("OwnerPhoneNumber", "Please enter owner phone number:");

												return paramsDict;
								}

								public void UpdateCustomerParams(Dictionary<string,string> paramsDict)
								{
												m_PersonName = paramsDict["OwnerName"];
												m_PhoneNumber = paramsDict["OwnerPhoneNumber"];
								}

				}

}
