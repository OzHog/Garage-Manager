using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class VehicleProducer
    {
        public static Vehicle Produce(string i_LicenseNumber, eProducibleVehicles i_ToProduce)
        {
            Vehicle requiredVehicle = null;

            switch (i_ToProduce)
            {
                case eProducibleVehicles.Motorcycle:
                    requiredVehicle = new Motorcycle(i_LicenseNumber);
                    break;
                case eProducibleVehicles.Car:
                    requiredVehicle = new Car(i_LicenseNumber);
                    break;
                case eProducibleVehicles.Truck:
                    requiredVehicle = new Truck(i_LicenseNumber);
                    break;

                default:
                    //Vehicle is not producible
                    break;
            }

            return requiredVehicle;
        }

        public enum eProducibleVehicles
        {
            Motorcycle,
            Car,
            Truck
        }
    }
}
