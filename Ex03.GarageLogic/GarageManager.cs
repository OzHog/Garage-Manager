using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, VehicleInfo> r_Vehicles;

        public GarageManager()
        {
            r_Vehicles = new Dictionary<string, VehicleInfo>(0);
        }

        public void AddVehicle(string i_LicenseNumber)
        {
            r_Vehicles.Add(i_LicenseNumber,new VehicleInfo());
        }

        private List<string> getAllLicenseNumbers()
        {
            List<string> licenseNumbers = new List<string>(r_Vehicles.Count);

            foreach (KeyValuePair<string, VehicleInfo> vehicle in r_Vehicles)
            {
                licenseNumbers.Add((vehicle.Key));
            }

            return licenseNumbers;
        }

        private List<string> getLicenseNumbersByStatus(eVehicleStatus i_StatusFilter)
        {
            List<String> licenseNumbers = new List<string>(0);

            foreach (KeyValuePair<string, VehicleInfo> vehicle in r_Vehicles)
            {
                if(vehicle.Value != null)
                {
                    if(vehicle.Value.Status == i_StatusFilter)
                    {
                        licenseNumbers.Add((vehicle.Key));
                    }
                }
                
            }

            return licenseNumbers;
        }

        public List<string> GetLicenseNumbers(eVehicleStatus? i_StatusFilter = null)
        {
            List<string> requiredLicenseNumbers;

            if(i_StatusFilter == null)
            {
                requiredLicenseNumbers = getAllLicenseNumbers();
            }
            else
            {
                requiredLicenseNumbers = getLicenseNumbersByStatus(i_StatusFilter.Value);
            }

            return requiredLicenseNumbers;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewVehicleStatus)
        {
            r_Vehicles[i_LicenseNumber].Status = i_NewVehicleStatus;
        }
        
        public void InflateWheelsToMaximum(string i_LicenseNumber)
        {
            if(r_Vehicles[i_LicenseNumber] != null)
            {
                foreach(Wheel wheel in r_Vehicles[i_LicenseNumber].Vehicle.Wheels)
                {
                    float amountOfMissingAirPressure = wheel.MaximumAirPressure - wheel.CurrentAirPressure;
                    wheel.Inflate(amountOfMissingAirPressure);
                }
            }
        }

        public void FuelVehicle(string i_LicenseNumber, eFuel i_FuelType, float i_AmountOFuelToAdd)
        {
            VehicleInfo vehicleInfo = r_Vehicles[i_LicenseNumber];
            if (vehicleInfo.Vehicle != null)
            {
                FuelTank fuelTank = vehicleInfo.Vehicle.EnergySource as FuelTank;
                if(i_FuelType == fuelTank.FuelType)
                {
                    fuelTank.Fuel(i_AmountOFuelToAdd);
                }
                else
                {
                    throw new FuelTypeException(i_FuelType, fuelTank.FuelType);
                }
            }
            else
            {
                throw new VehicleNotExistException(i_LicenseNumber);
            }
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_AmountOfMinutesToAdd)
        {
            VehicleInfo vehicleInfo = r_Vehicles[i_LicenseNumber];
            if(vehicleInfo.Vehicle != null)
            {
                if(r_Vehicles[i_LicenseNumber].Vehicle != null)
                {
                    Battery battery = r_Vehicles[i_LicenseNumber].Vehicle.EnergySource as Battery;
                    battery.Charge(i_AmountOfMinutesToAdd);
                }
                else
                {
                    throw new VehicleNotExistException(i_LicenseNumber);
                }
            }
            else
            {
                throw new VehicleNotExistException(i_LicenseNumber);
            }

        }

        public VehicleInfo GetVehicleInfo(string i_LicenseNumber)
        {
            VehicleInfo vehicleInfo = null;
            try
            {
                vehicleInfo = r_Vehicles[i_LicenseNumber];
            }
            catch(Exception e)
            {
                throw new VehicleNotExistException(i_LicenseNumber);
            }

            return vehicleInfo;
        }

    }
}
