using System;
using System.Text;

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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"License number: {m_Vehicle.LicenseNumber}");
            sb.AppendLine($"Vehicle type: {m_Vehicle.GetType().Name}");
            sb.AppendLine($"Car model: {m_Vehicle.Model}");
            sb.AppendLine($"Vehicle status: {m_VehicleStatus}");
            sb.AppendLine($"Owner name: {PersonName}");
            sb.AppendLine($"Owner phone: {PhoneNumber}");
            return sb.ToString();
        }

        public void SetVehicleStatus(VehicleStatus i_VehicleStatus)
        {
            m_VehicleStatus = i_VehicleStatus;
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public CustomerInfo Owner
        {
            get { return m_Customer; }
        }

        public string PersonName
        {
            get { return m_Customer != null ? m_Customer.PersonName : string.Empty; }
        }

        public string PhoneNumber
        {
            get { return m_Customer != null ? m_Customer.PhoneNumber : string.Empty; }
        }

        public VehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
        }
    }
}