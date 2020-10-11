using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
       private readonly GarageManager r_GarageManager;
       private readonly Dictionary<eUIScreens, Screen> r_Screens;

        // $G$ CSS-025 (-3) Symbols are not spaced properly.

        private string mainMenu = @"Garage Options:
    1. Add New Vehicle
    2. Display License Numbers In The Garage
    3. Vehicle Actions
    4. Exit";

        public UI()
        {
            r_GarageManager = new GarageManager();
            r_Screens  = getScreens();
        }

        // $G$ CSS-027 (-1) Unnecessary blank lines.

        private static Dictionary<eUIScreens, Screen> getScreens()
        {

            Dictionary<eUIScreens, Screen> screens = new Dictionary<eUIScreens, Screen>();
            Screen displayMassage = new Screen();
            MenuScreen mainMenuScreen = new MenuScreen(typeof(eMainMenuOptions), "Garage Options: ");
            MenuScreen displayLicensesScreen = new MenuScreen(
                typeof(eDisplayLicensesOptions),
                "Display License Numbers In The Garage:");
            MenuScreen vehicleStatusScreen = new MenuScreen(
                typeof(eVehicleStatus),
                "Select Status To Filet By:");
            MenuScreen fuelScreen = new MenuScreen(typeof(eFuel), "Select Vehicle Fuel:");
            MenuScreen vehicleTypeScreen = new MenuScreen(
                typeof(VehicleProducer.eProducibleVehicles),
                "Select Vehicle:");
            MenuScreen energySourceScreen = new MenuScreen(typeof(eEnergySource), "Select Vehicle Energy Source:");
            MenuScreen setWheelsScreen = new MenuScreen(typeof(eSetWheelMode), "Select How To Set Wheels:");
            MenuScreen amountOfDoors = new MenuScreen(typeof(eAmountOfDoors), "Select How Many Doors:");
            MenuScreen vehicleColor = new MenuScreen(typeof(eVehicleColor), "Select Vehicle Color:");
            MenuScreen vehicleLicenseType = new MenuScreen(typeof(eLicenseType), "Select Vehicle License Type:");
            MenuScreen electricityVehicleActionsScreen = new MenuScreen(typeof(eElectricityVehicleActionsOptions), "Select Vehicle Action:");
            MenuScreen fuelVehicleActionsScreen = new MenuScreen(typeof(eFuelVehicleActionsOptions), "Select Vehicle Action:");

            DataInputScreen dataInputScreen = new DataInputScreen();
            NumericalInputScreen numericalInputScreen = new NumericalInputScreen();
            BoolInputScreen boolInputScreen = new BoolInputScreen();

            screens.Add(eUIScreens.MainMenu, mainMenuScreen);
            screens.Add(eUIScreens.DisplayLicenseNumbers, displayLicensesScreen);
            screens.Add(eUIScreens.DataInput, dataInputScreen);
            screens.Add(eUIScreens.VehicleStatuses, vehicleStatusScreen);
            screens.Add(eUIScreens.FuelType, fuelScreen);
            screens.Add(eUIScreens.VehicleType, vehicleTypeScreen);
            screens.Add(eUIScreens.EnergySource, energySourceScreen);
            screens.Add(eUIScreens.SetWheels, setWheelsScreen);
            screens.Add(eUIScreens.NumericalInput, numericalInputScreen);
            screens.Add(eUIScreens.AmountOfDoors, amountOfDoors);
            screens.Add(eUIScreens.VehicleColor, vehicleColor);
            screens.Add(eUIScreens.BoolInput, boolInputScreen);
            screens.Add(eUIScreens.LicenseType, vehicleLicenseType);
            screens.Add(eUIScreens.ElectricityVehicleActions, electricityVehicleActionsScreen);
            screens.Add(eUIScreens.FuelVehicleActions, fuelVehicleActionsScreen);
            screens.Add(eUIScreens.DisplayMassage, displayMassage);


            return screens;
        }

        public void addNewVehicle()
        {
            DataInputScreen dataInputScreen = r_Screens[eUIScreens.DataInput] as DataInputScreen;
            NumericalInputScreen numericalInputScreen = r_Screens[eUIScreens.NumericalInput] as NumericalInputScreen; 
            ScreenUtils.Clear();

            dataInputScreen.SetMassageToDisplay("Enter Vehicle License Number");
            dataInputScreen.Display(out string licenseNumber);
            r_GarageManager.AddVehicle(licenseNumber);

            VehicleInfo vehicleInfo = r_GarageManager.GetVehicleInfo(licenseNumber);
            try
            {
                string userData;

                dataInputScreen.SetMassageToDisplay("Enter Vehicle Owner Name");
                dataInputScreen.Display(out userData);
                vehicleInfo.VehicleOwnerName = userData;

                numericalInputScreen.SetMassageToDisplay("Enter Vehicle Owner Phone Number");
                numericalInputScreen.Display(out userData);
                vehicleInfo.VehicleOwnerPhoneNumber = userData;

                vehicleInfo.Vehicle = getNewVehicleFromUser(licenseNumber);

            }
            catch(Exception i_Exception)
            {
                ScreenUtils.Display(i_Exception.ToString());
                ScreenUtils.Freeze();
            }
        }

        // $G$ DSN-002 (-10) The UI should not know Car\Truck\Motorcycle
        private Vehicle getNewVehicleFromUser(string i_LicenseNumber)
        {
            (r_Screens[eUIScreens.VehicleType] as MenuScreen).Display(out string vehicleType);

            VehicleProducer.eProducibleVehicles vehicleToProduce =
                (VehicleProducer.eProducibleVehicles)parseMenuOption(vehicleType);
            Vehicle vehicle = VehicleProducer.Produce(i_LicenseNumber, vehicleToProduce);

            getVehicleData(ref vehicle);

            switch (vehicleToProduce)
            {
                case VehicleProducer.eProducibleVehicles.Car:
                    Car car = (vehicle as Car);
                    getCarDataFromUser(ref car);
                    break;
                case VehicleProducer.eProducibleVehicles.Motorcycle:
                    Motorcycle motorcycle = (vehicle as Motorcycle);
                    getMotorcycleDataFromUser(ref motorcycle);
                    break;

                case VehicleProducer.eProducibleVehicles.Truck:
                    Truck truck = (vehicle as Truck);
                    getTruckDataFromUser(ref truck);
                    break;
            }

            return vehicle;
        }

        // $G$ DSN-002 (-10) The UI should not know Car\Truck\Motorcycle
        private void getVehicleData(ref Vehicle io_Vehicle)
        {
            DataInputScreen dataInputScreen = r_Screens[eUIScreens.DataInput] as DataInputScreen;

            dataInputScreen.SetMassageToDisplay("Enter Vehicle Model Name");
            dataInputScreen.Display(out string userInput);
            io_Vehicle.ModelName = userInput;
            io_Vehicle.EnergySource = getEnergySourceFromUser(io_Vehicle is Truck);
            if (io_Vehicle is Car)
            {
                getWheelsDataFromUser(eVehicleNumberOfWheels.Car, ref io_Vehicle);
            }
            else
            {
                if(io_Vehicle is Motorcycle)
                {
                    getWheelsDataFromUser(eVehicleNumberOfWheels.Motorcycle, ref io_Vehicle);
                }
                else
                {
                    getWheelsDataFromUser(eVehicleNumberOfWheels.Truck, ref io_Vehicle);
                }
            }
        }

        private static int parseMenuOption(string i_MenuOption)
        {
            return int.Parse(i_MenuOption) - 1;
        }
        
        private EnergySource getEnergySourceFromUser(bool i_ForTruck)
        {
            DataInputScreen dataInputScreen = r_Screens[eUIScreens.DataInput] as DataInputScreen;
            eEnergySource energySourceType = eEnergySource.Fuel;
            EnergySource energySource = null;
            if (!i_ForTruck)
            {
                MenuScreen energySourceScreen = r_Screens[eUIScreens.EnergySource] as MenuScreen;
                energySourceScreen.Display(out string energySourInput);
                energySourceType = (eEnergySource)parseMenuOption(energySourInput);
            }

            if(energySourceType == eEnergySource.Fuel)
            {
                MenuScreen FuelType = r_Screens[eUIScreens.FuelType] as MenuScreen;
                FuelType.Display(out string fuelTypeStr);
                eFuel fuel = (eFuel)parseMenuOption(fuelTypeStr);
                dataInputScreen.SetMassageToDisplay("Enter Fuel Tank Capacity");
                dataInputScreen.Display(out string fuelTankCapacity);
                float capacity = float.Parse(fuelTankCapacity);

                energySource = new FuelTank(fuel, capacity);
            }
            else
            {
                dataInputScreen.SetMassageToDisplay("Enter Maximum Time Capacity");
                dataInputScreen.Display(out string timeCapacity);
                float capacity = float.Parse(timeCapacity);

                energySource = new Battery(capacity);
            }

            return energySource;
        }

        // $G$ DSN-002 (-5) The UI should not know Car\Truck\Motorcycle
        private void getMotorcycleDataFromUser(ref Motorcycle io_Motorcycle)
        {
            string userInput;
            MenuScreen licenseTypeScreen = r_Screens[eUIScreens.LicenseType] as MenuScreen;
            NumericalInputScreen numericalInputScreen = r_Screens[eUIScreens.NumericalInput] as NumericalInputScreen;

            licenseTypeScreen.Display(out userInput);
            eLicenseType licenseType = (eLicenseType)parseMenuOption(userInput);
            io_Motorcycle.LicenseType = licenseType;

            numericalInputScreen.SetMassageToDisplay("Enter Engine Capacity");
            numericalInputScreen.Display(out userInput);
            int engineCapacity = parseMenuOption(userInput);
            io_Motorcycle.EngineCapacity = engineCapacity;
        }

        // $G$ DSN-002 (-5) The UI should not know Car\Truck\Motorcycle
        private void getCarDataFromUser(ref Car io_Car)
        {
            string userInput;
            MenuScreen doorsAmountScreen = r_Screens[eUIScreens.AmountOfDoors] as MenuScreen;
            MenuScreen carColorScreen = r_Screens[eUIScreens.VehicleColor] as MenuScreen;

            doorsAmountScreen.Display(out userInput);
            eAmountOfDoors amountOfDoors = (eAmountOfDoors)parseMenuOption(userInput);
            io_Car.AmountOfDoors = amountOfDoors;

            carColorScreen.Display(out userInput);
            eVehicleColor carColor = (eVehicleColor)parseMenuOption(userInput);
            io_Car.Color = carColor;
        }

        // $G$ DSN-002 (-5) The UI should not know Car\Truck\Motorcycle
        private void getTruckDataFromUser(ref Truck io_Truck)
        {
            NumericalInputScreen numericalInputScreen = r_Screens[eUIScreens.NumericalInput] as NumericalInputScreen;
            BoolInputScreen boolInputScreen = r_Screens[eUIScreens.BoolInput] as BoolInputScreen;
             
            boolInputScreen.SetMassageToDisplay("Is Truck Contain Hazardous Materials");
            boolInputScreen.Display(out bool containsHazardousMaterials);
            io_Truck.ContainsHazardousMaterials = containsHazardousMaterials;

            numericalInputScreen.SetMassageToDisplay("Enter Cargo Volume");
            numericalInputScreen.Display(out string cargoVolumeStr);
            float cargoVolume = float.Parse(cargoVolumeStr);
            io_Truck.CargoVolume = cargoVolume;
        }

        private void getWheelsDataFromUser(eVehicleNumberOfWheels i_AmountOfWheels, ref Vehicle io_Vehicle)
        {
            int amountOfWheels = (int)i_AmountOfWheels;
            List<Wheel> vehicleWheels = io_Vehicle.Wheels;
            MenuScreen setWheelsModeScreen = r_Screens[eUIScreens.SetWheels] as MenuScreen;

            setWheelsModeScreen.Display(out string setWheelsMode);
            eSetWheelMode setMode = (eSetWheelMode)parseMenuOption(setWheelsMode);
            
                Wheel wheel = getWheelFromUser();
                vehicleWheels.Add(wheel);

            for (int i = 0; i < amountOfWheels - 1; i++)
            {
                if (setMode == eSetWheelMode.ApplyToAllWheels)
                {
                    wheel = new Wheel(wheel.ManufacturerName, wheel.MaximumAirPressure);
                }
                else
                {
                    wheel = getWheelFromUser();
                }

                vehicleWheels.Add(wheel);
            }
        }

        private Wheel getWheelFromUser()
        {
            NumericalInputScreen numericalInputScreen = r_Screens[eUIScreens.NumericalInput] as NumericalInputScreen;
            DataInputScreen dataInputScreen = r_Screens[eUIScreens.DataInput] as DataInputScreen;

            dataInputScreen.SetMassageToDisplay("Enter Wheel Manufacturer Name");
            dataInputScreen.Display(out string manufacturerName);
            numericalInputScreen.SetMassageToDisplay("Enter Wheel Maximum Air Pressure");
            numericalInputScreen.Display(out string maximumAirPressureStr);
            float maximumAirPressure = float.Parse(maximumAirPressureStr);

            return new Wheel(manufacturerName, maximumAirPressure);
        }

        public void startEngine()
        { 
            ScreenUtils.Clear();
            ScreenUtils.Display("=============Garage Manager=============");
            manageGarage();

        }

        private void manageGarage()
        {
            bool exit = false;

            while(!exit)
            {
                (r_Screens[eUIScreens.MainMenu] as MenuScreen).Display(out string userInput);

                eMainMenuOptions userOption = (eMainMenuOptions)parseMenuOption(userInput);

                switch(userOption)
                {
                    case eMainMenuOptions.AddNewVehicle:
                        addNewVehicle();
                        break;
                    case eMainMenuOptions.DisplayLicenseNumbersInTheGarage:
                        displayLicenseNumbersInTheGarage();
                        break;
                    case eMainMenuOptions.VehicleActions:
                        displayVehicleActions();
                        break;
                    case eMainMenuOptions.Exit:
                        exit = true;
                        break;
                }

                
            }
        }

        private void displayLicenseNumbersInTheGarage()
        {
            string userInput;
            eVehicleStatus? filerStatus = null;

            (r_Screens[eUIScreens.DisplayLicenseNumbers] as MenuScreen).Display(out  userInput);
            eDisplayLicensesOptions userOption = (eDisplayLicensesOptions)parseMenuOption(userInput);
            if(userOption == eDisplayLicensesOptions.FilterVehiclesByStatus)
            {
                (r_Screens[eUIScreens.VehicleStatuses] as MenuScreen).Display(out userInput);
                filerStatus  = (eVehicleStatus)parseMenuOption(userInput);
            }

            List<string> LicenseNumbers = r_GarageManager.GetLicenseNumbers(filerStatus);
            if(LicenseNumbers.Count > 0)
            {
                foreach(string licenseNumber in LicenseNumbers)
                {
                    ScreenUtils.Display(licenseNumber);
                }
            }
            else
            {
                ScreenUtils.Display("There Are No Vehicles In The Garage For This Request");
            }

            ScreenUtils.Freeze();

        }

        private void displayVehicleActions()
        {
            string licenseNumber;
            DataInputScreen screen = r_Screens[eUIScreens.DataInput] as DataInputScreen;

            ScreenUtils.Clear();

            screen.SetMassageToDisplay("Enter Vehicle License Number");
            screen.Display(out licenseNumber);

            try
            {
                VehicleInfo vehicleInfo  = r_GarageManager.GetVehicleInfo(licenseNumber);
                if(vehicleInfo != null)
                {
                    MenuScreen menu;
                    if(vehicleInfo.Vehicle.EnergySource is Battery)
                    {
                        menu = r_Screens[eUIScreens.ElectricityVehicleActions] as MenuScreen;
                    }
                    else
                    {
                        menu = r_Screens[eUIScreens.FuelVehicleActions] as MenuScreen;
                    }

                    bool back = false;
                    while(!back)
                    {
                        menu.Display(out string userInput);
                        vehicleActionHandler(vehicleInfo, userInput, out back);
                    }
                }
            }
            catch(Exception i_Exception)
            {
               ScreenUtils.Display(i_Exception.ToString());
               ScreenUtils.Freeze();
            }
        }

        private void vehicleActionHandler(VehicleInfo vehicleInfo, string userInput, out bool o_Back)
        {
            o_Back = false;
            string licenseNumber = vehicleInfo.Vehicle.LicenseNumber;

            eElectricityVehicleActionsOptions action = (eElectricityVehicleActionsOptions)parseMenuOption(userInput);

            switch(action)
            {
                case eElectricityVehicleActionsOptions.ChangeStatus:
                    changeVehicleStatus(licenseNumber);
                    break;
                case eElectricityVehicleActionsOptions.Inflate:
                    inflate(licenseNumber);
                    break;
                case eElectricityVehicleActionsOptions.Back:
                    o_Back = true;
                    break;
                case eElectricityVehicleActionsOptions.DisplayVehicle:
                    displayVehicle(vehicleInfo);
                    break;
                default:
                    eEnergySource energySource = eEnergySource.Fuel;
                    if(vehicleInfo.Vehicle.EnergySource is Battery)
                    {
                        energySource = eEnergySource.Electricity;
                    }

                    addEnergy(licenseNumber, energySource);
                    break;
            }
        }

        private void displayVehicle(VehicleInfo i_VehicleInfo)
        {
            ScreenUtils.Display(i_VehicleInfo.ToString());
            ScreenUtils.Freeze();
        }

        private void addEnergy(string i_LicenseNumber, eEnergySource i_EnergySource)
        {
            NumericalInputScreen numericalInputScreen = r_Screens[eUIScreens.NumericalInput] as NumericalInputScreen;
            eFuel? fuel = null;
            if(i_EnergySource == eEnergySource.Electricity)
            {
                numericalInputScreen.SetMassageToDisplay("Enter Time To Add");
            }
            else
            {
                MenuScreen fuelScreen = r_Screens[eUIScreens.FuelType] as MenuScreen;
                fuelScreen.Display(out string fuelTypeStr);
                fuel = (eFuel)parseMenuOption(fuelTypeStr);
                numericalInputScreen.SetMassageToDisplay("Enter Amount of Fuel To Add");
            }

            numericalInputScreen.Display(out string energyToAddStr);
            float energyToAdd = float.Parse(energyToAddStr);

            try
            {
                if(i_EnergySource == eEnergySource.Electricity)
                {
                    r_GarageManager.ChargeVehicle(i_LicenseNumber, energyToAdd);
                }
                else
                {
                    r_GarageManager.FuelVehicle(i_LicenseNumber, fuel.Value, energyToAdd);
                }
            }
            catch(Exception exception)
            {
                ScreenUtils.Display(exception.ToString());
                ScreenUtils.Freeze();
            }

        }

        private void changeVehicleStatus(string i_LicenseNumber)
        {
            MenuScreen statusScreen = r_Screens[eUIScreens.VehicleStatuses] as MenuScreen;
            statusScreen.Display(out string userInput);

            eVehicleStatus changeStatusTo = (eVehicleStatus)parseMenuOption(userInput);
            r_GarageManager.ChangeVehicleStatus(i_LicenseNumber, changeStatusTo);
        }

        private void inflate(string i_LicenseNumber)
        {
            Screen screen = r_Screens[eUIScreens.DisplayMassage];
            r_GarageManager.InflateWheelsToMaximum(i_LicenseNumber);

            screen.SetMassageToDisplay("Inflate Succeeded");
            screen.Display();
            ScreenUtils.Freeze();
        }
    }
}
