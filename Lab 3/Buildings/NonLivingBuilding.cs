using System;

namespace Lab_3
{
    public class NonLivingBuilding : Building
    {
        private double m_square;

        public NonLivingBuilding() { }

        public NonLivingBuilding(string address, double square)
            : base(address)
        {
            Square = square;
        }

        public double Square 
        {
            get { return m_square; }

            set 
            {
                if (value < 0)
                    throw new ArgumentException("Building square cannot be negative");

                m_square = value;
            }
        }

        public override int NumberOfPeople 
        { 
            get { return Convert.ToInt32(Square * 0.2); }
        }

        public override bool AreEqual(object obj)
        {
            if (!base.AreEqual(obj))
                return false;

            NonLivingBuilding value = obj as NonLivingBuilding;

            if (value is null)
                throw new ArgumentException("Object is not NonLivingBuilding");

            if (value.Square != Square)
                return false;

            return true;
        }
    }
}
