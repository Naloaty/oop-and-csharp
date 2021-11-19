using System;


namespace Lab_3
{
    public class LivingBuilding : Building
    {
        private int m_rooms;
        private int m_apartments;

        public LivingBuilding() { }

        public LivingBuilding(string address, int apartments, int rooms)
            : base(address)
        {
            Apartments = apartments;
            Rooms = rooms;
        }

        public int Rooms 
        {
            get { return m_rooms; }

            set 
            {
                if (value < 0)
                    throw new ArgumentException("Number of rooms cannot be negative");

                m_rooms = value;
            }
        }

        public int Apartments 
        {
            get { return m_apartments; }

            set 
            {
                if (value < 0)
                    throw new ArgumentException("Number of apartments cannot be negative");

                m_apartments = value;
            }
        }

        public override int NumberOfPeople
        {
            get { return Convert.ToInt32(Apartments * Rooms * 1.3); }
        }

        public override bool AreEqual(object obj)
        {
            if (!base.AreEqual(obj))
                return false;

            LivingBuilding value = obj as LivingBuilding;

            if (value is null)
                throw new ArgumentException("Object is not LivingBuilding");

            if (value.Apartments != Apartments)
                return false;

            if (value.Rooms != Rooms)
                return false;

            return true;
        }
    }
}
