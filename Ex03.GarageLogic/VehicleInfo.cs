using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
				public class VehicleInfo
				{
								private Vehicle m_Vehicle;
								private CustomerInfo m_Customer;
								private VehicleStatus m_VehicleStatus;

								public VehicleInfo(Vehicle i_Vehicle, CustomerInfo i_Customer, VehicleStatus i_VehicleStatus)
								{
												m_Vehicle = i_Vehicle;
												m_Customer = i_Customer;
												m_VehicleStatus = i_VehicleStatus;
								}

								public override string ToString()
								{
												string res = $"License number: {m_Vehicle.LicenseNumber} ..";
												return res;
								}
				}
}
