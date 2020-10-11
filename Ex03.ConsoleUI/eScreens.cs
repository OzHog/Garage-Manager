using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
   internal enum eUIScreens
    {
        MainMenu,
        DisplayLicenseNumbers,
        FuelVehicleActions,
        ElectricityVehicleActions,
        DataInput,
        BoolInput,
        VehicleStatuses,
        FuelType,
        EnergySource,
        VehicleType,
        SetWheels,
        NumericalInput,
        DisplayMassage,
        AmountOfDoors,
        VehicleColor,
        LicenseType,
    }

   internal enum eMainMenuOptions
    {
        AddNewVehicle,
        DisplayLicenseNumbersInTheGarage,
        VehicleActions,
        Exit
    }

   internal enum eSetWheelMode
   {
       ApplyToAllWheels,
       Separately,
   }

    internal enum eDisplayLicensesOptions
    {
        DisplayAllVehicles,
        FilterVehiclesByStatus,
    }

   internal enum eElectricityVehicleActionsOptions
    {
        ChangeStatus,
        Inflate,
        DisplayVehicle,
        Charge,
        Back }

   internal enum eFuelVehicleActionsOptions
   {
       ChangeStatus,
       Inflate,
       DisplayVehicle,
       Fuel,
       Back
   }
}
