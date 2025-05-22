using System;

namespace Ex03.GarageLogic
{
	public class ContactInfo
	{
		public string PersonName { get; private set; }
		public string PhoneNumber { get; private set; }

		public ContactInfo(string i_PersonName, string i_PhoneNumber)
		{
			PersonName = i_PersonName;
			PhoneNumber = i_PhoneNumber;
		}
	}

}
