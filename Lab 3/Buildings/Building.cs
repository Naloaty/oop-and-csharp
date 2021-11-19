using System;
using System.Xml.Serialization;

namespace Lab_3
{
    [XmlInclude(typeof(LivingBuilding))]
    [XmlInclude(typeof(NonLivingBuilding))]
    public abstract class Building
    {
        private string m_address;

        protected Building() { }

        protected Building(string address) 
        {
            Address = address;
        }

        public string Address 
        {
            get { return m_address; }

            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Address cannot be null or empty");

                m_address = value;
            } 
        }

        public virtual bool AreEqual(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException("Cannot compare Building to null");

            Building value = obj as Building;

            if (value is null)
                throw new ArgumentException("Object is not Building");

            if (value.Address != Address)
                return false;

            if (value.NumberOfPeople != NumberOfPeople)
                return false;

            return true;
        }

        public override string ToString()
        {
            return $"Type: {GetType()}, Address: {Address}, Number of people: {NumberOfPeople}";
        }

        public abstract int NumberOfPeople { get; }
    }
}
