namespace Ex03.GarageLogic
{
    public class ContactInfo
    {
        public string OwnerName { get; }
        public string PhoneNumber { get; }

        public ContactInfo(string i_OwnerName, string i_PhoneNumber)
        {
            OwnerName = i_OwnerName;
            PhoneNumber = i_PhoneNumber;
        }

        public override string ToString()
        {
            return $"Owner Name: {OwnerName}, Phone Number: {PhoneNumber}";
        }
    }
}