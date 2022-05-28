using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GarageLogic;
using GarageLogic.enums; 

namespace GarageUI
{
    public class GarageConsoleUI
    {
        private readonly GarageManagement r_GarageMenagement;

        public GarageConsoleUI()
        {
            r_GarageMenagement = new GarageManagement(); 
        }

        public void ExecuteGarage()
        {
            bool menuRunsContinously = true;
            string userInput;

            while (menuRunsContinously)
            {
                menuDefualtMessage();
                getUserMenuDecision();
                Console.WriteLine("To go back to the menu perss -1, any other input will close the garage.");
                userInput = Console.ReadLine();
                if (!userInput.Equals("-1"))
                {
                    menuRunsContinously = false;
                }
            }

            Console.WriteLine("The garage close. Thank you.");
            System.Threading.Thread.Sleep(3000);
        }

        private void menuDefualtMessage()
        {
            Console.Clear();
            string menuDefaultMessage =
                string.Format("Welcome to the virtual garage!{0}" +
                              "Please choose one of the following options by entering the corresponding number:{0}" +
                              "(1) Insert a new vehicle into the garage.{0}" +
                              "(2) Display a list of the vehicles currently in the garage, with or without condition of vihecal.{0}" +
                              "(3) Change a vehicle's status.{0}" +
                              "(4) Inflate tires to maximum air pressure.{0}" +
                              "(5) Refuel a fuel-based vehicle.{0}" +
                              "(6) Charge an electric-based vehicle.{0}" +
                              "(7) Display a vehicle's information.{0}", Environment.NewLine);

            Console.WriteLine(menuDefaultMessage);
        }

        private void getUserMenuDecision()
        {
            string userDecision;
            eUserSelectionMainMenu userEnumInput = eUserSelectionMainMenu.InsertVehicle;
            bool isUserChoiceValid = false;

            while (!isUserChoiceValid)
            {
                Console.WriteLine("Enter your choose");
                userDecision = Console.ReadLine();
                if (Enum.TryParse(userDecision, out userEnumInput))
                {
                    isUserChoiceValid = true; 
                }
                else
                {
                    Console.WriteLine("Invalid choise, please try again");
                }
            }

            performUserDecision(userEnumInput); 
        }

        private void performUserDecision(eUserSelectionMainMenu i_UserInput)
        {
            switch (i_UserInput)
            {
                case eUserSelectionMainMenu.InsertVehicle:
                    insertVehicleToTheGarage();
                    break;
                case eUserSelectionMainMenu.LicenseList:
                    displayVehiclesInGarageList();
                    break;
                case eUserSelectionMainMenu.ChangeVehicleStatus:
                    changeVehicleCondition();
                    break;
                case eUserSelectionMainMenu.InflateWheels:
                    inflatingVehicleWheelsToMax(); 
                    break;
                case eUserSelectionMainMenu.RefuelVehicle:
                    vehicleRefuel();
                    break;
                case eUserSelectionMainMenu.ChargeVehicle:
                    vehicleCharge(); 
                    break;
                case eUserSelectionMainMenu.DisplayVehicleInformation:
                    displayVehicleInformation();
                    break; 
                default:
                    Console.WriteLine("Invalid input, please try again");
                    getUserMenuDecision();
                    break;
            }
        }

        private void insertVehicleToTheGarage()
        {
            string vehicleLicenceNumber;

            Console.WriteLine("Please enter vehiclel licence number");
            vehicleLicenceNumber = Console.ReadLine();
            if (r_GarageMenagement.r_Garage.CheckIfVehicleInGarage(vehicleLicenceNumber))
            {
                r_GarageMenagement.AddExistVehicelToGarage(vehicleLicenceNumber);
                Console.WriteLine("The vehicle is alerdy in the garage, Vehical status changed to - In Repair");
            }
            else
            {
                vehicleTypeSelectionMenu();
                getVehicleTypeSelection(vehicleLicenceNumber);
            }
        }

        private void vehicleTypeSelectionMenu()
        {
            string vehicleTypeSelection =
                string.Format("please choose the vehicle type {0}" +
                              "(1) Fuel Motorcycle.{0}" +
                              "(2) Electric Motorcycle.{0}" +
                              "(3) Fuel car.{0}" +
                              "(4) Electric car.{0}" +
                              "(5) Fule truck.{0}" , Environment.NewLine);

            Console.WriteLine(vehicleTypeSelection);
        }

        private void getVehicleTypeSelection(string i_VehicleLicenceNumber)
        {
            string userSelection;
            eUserSelectionCreateVehicleMenu userEnumInput;

            try
            {
                Console.WriteLine("Enter your choose");
                userSelection = Console.ReadLine();
                if (Enum.TryParse(userSelection, out userEnumInput))
                {
                    switch (userEnumInput)
                    {
                        case eUserSelectionCreateVehicleMenu.FuelMotorcycle:
                            createAndAddNewFuelMotorcycleToGarage(i_VehicleLicenceNumber);
                            break;
                        case eUserSelectionCreateVehicleMenu.ElectricMotorcycle:
                            createAndaddNewElectricMotorcycleToGarage(i_VehicleLicenceNumber);
                            break;
                        case eUserSelectionCreateVehicleMenu.FuelCar:
                            createAndAddFuelCarToGarage(i_VehicleLicenceNumber);
                            break;
                        case eUserSelectionCreateVehicleMenu.ElectricCar:
                            createAndAddElectricCarToGarage(i_VehicleLicenceNumber);
                            break;
                        case eUserSelectionCreateVehicleMenu.FuleTruck:
                            createAndAddFuelTruckToGarage(i_VehicleLicenceNumber);
                            break;
                        default:
                            Console.WriteLine("Invalid choise, please try again.");
                            getVehicleTypeSelection(i_VehicleLicenceNumber);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choise, please try again.");
                    getVehicleTypeSelection(i_VehicleLicenceNumber);
                }
            }
            catch (FormatException errorMessege)
            {
                Console.WriteLine("Invalid choise, please try again");
                getVehicleTypeSelection(i_VehicleLicenceNumber);
            }
        }

        private void createBasicVehicalDetails(out string o_ModelName, out string o_WheelsManufacturerName, out string o_OwnerName, out string o_OwnerPhone, out float o_WheelsCurrentAirPressure)
        {
            o_ModelName = getModelName();
            o_WheelsManufacturerName = getWheelsManufacturerName();
            o_OwnerName = getOwnerName();
            o_OwnerPhone = getOwnerPhone();
            o_WheelsCurrentAirPressure = getWheelsCurrentPressure();
        }

        private void createAndAddFuelTruckToGarage(string i_VehivleLicenceNumber)
        {
            string modelName, wheelsManufacturerName, ownerName, ownerPhone;
            float currentFuelAmount, wheelsCurrentAirPressure, cargoVolume;
            bool isDriveRefrigeratedContents;
            Vehicle newVehicle;

            createBasicVehicalDetails(out modelName, out wheelsManufacturerName, out ownerName, out ownerPhone, out wheelsCurrentAirPressure);
            currentFuelAmount = getCurrentLitersFuelAmount();
            cargoVolume = getCCEngineVolume();
            isDriveRefrigeratedContents = getIsDriveRefrigeratedContents(); 
            try
            {
                newVehicle = VehicleBuilder.CreateNewFuelTruck(modelName, i_VehivleLicenceNumber,
                    currentFuelAmount, isDriveRefrigeratedContents,cargoVolume, wheelsManufacturerName, wheelsCurrentAirPressure);
                r_GarageMenagement.AddNewVehicleToGarage(ownerName, ownerPhone, newVehicle);
                Console.WriteLine("The new vehical added to the garage");
            }
            catch (ArgumentException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
                createAndAddFuelTruckToGarage(i_VehivleLicenceNumber);
            }
            catch (ValueOutOfRangeException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
                Console.WriteLine("Let's try again..");
                createAndAddFuelTruckToGarage(i_VehivleLicenceNumber);
            }
        }

        private void createAndAddElectricCarToGarage(string i_VehivleLicenceNumber)
        {
            string modelName, wheelsManufacturerName, ownerName, ownerPhone;
            float currentBatteryAmount, wheelsCurrentAirPressure;
            Car.eColor color;
            Car.eNumberOfDoors numberOfDoors;
            Vehicle newVehicle;

            createBasicVehicalDetails(out modelName, out wheelsManufacturerName, out ownerName, out ownerPhone, out wheelsCurrentAirPressure);
            currentBatteryAmount = getCurrentBatteryMinutesAmount();
            color = getColor();
            numberOfDoors = getNumberOfDoors();
            try
            {
                newVehicle = VehicleBuilder.CreateNewElectricCar(modelName, i_VehivleLicenceNumber,
                    currentBatteryAmount, color, numberOfDoors, wheelsManufacturerName, wheelsCurrentAirPressure);
                r_GarageMenagement.AddNewVehicleToGarage(ownerName, ownerPhone, newVehicle);
                Console.WriteLine("The new vehical added to the garage");
            }
            catch(ArgumentException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
                createAndAddElectricCarToGarage(i_VehivleLicenceNumber);
            }
            catch (ValueOutOfRangeException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
                Console.WriteLine("Let's try again..");
                createAndAddElectricCarToGarage(i_VehivleLicenceNumber);
            }
        }

        private void createAndAddFuelCarToGarage(string i_VehivleLicenceNumber)
        {
            string modelName, wheelsManufacturerName, ownerName, ownerPhone;
            float currentFuelAmount, wheelsCurrentAirPressure;
            Car.eColor color;
            Car.eNumberOfDoors numberOfDoors;
            Vehicle newVehicle;

            createBasicVehicalDetails(out modelName, out wheelsManufacturerName, out ownerName, out ownerPhone, out wheelsCurrentAirPressure);
            currentFuelAmount = getCurrentLitersFuelAmount();
            color = getColor();
            numberOfDoors = getNumberOfDoors();
            try
            {
                newVehicle = VehicleBuilder.CreateNewFuelCar(modelName, i_VehivleLicenceNumber,
                     currentFuelAmount, color, numberOfDoors, wheelsManufacturerName, wheelsCurrentAirPressure);
                r_GarageMenagement.AddNewVehicleToGarage(ownerName, ownerPhone, newVehicle);
                Console.WriteLine("The new vehical added to the garage");
            }
            catch (ArgumentException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
                createAndAddFuelCarToGarage(i_VehivleLicenceNumber);
            }
            catch (ValueOutOfRangeException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
                Console.WriteLine("Let's try again..");
                createAndAddFuelCarToGarage(i_VehivleLicenceNumber);
            }
        }

        private void createAndaddNewElectricMotorcycleToGarage(string i_VehivleLicenceNumber)
        {
            string modelName, wheelsManufacturerName, ownerName, ownerPhone;
            float currentBatteryAmount, wheelsCurrentAirPressure;
            Motorcycle.eLicenseType licenseType;
            int CCEngineVolume;
            Vehicle newVehicle;

            createBasicVehicalDetails(out modelName, out wheelsManufacturerName, out ownerName, out ownerPhone, out wheelsCurrentAirPressure);
            currentBatteryAmount = getCurrentBatteryMinutesAmount();
            licenseType = getLicenseType();
            CCEngineVolume = getCCEngineVolume();
            try
            {
                newVehicle = VehicleBuilder.CreateNewElectricMotorcycle(modelName, i_VehivleLicenceNumber,
                currentBatteryAmount, licenseType,CCEngineVolume, wheelsManufacturerName, wheelsCurrentAirPressure);
                r_GarageMenagement.AddNewVehicleToGarage(ownerName, ownerPhone, newVehicle);
                Console.WriteLine("The new vehical added to the garage");
            }
            catch (ArgumentException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
                createAndaddNewElectricMotorcycleToGarage(i_VehivleLicenceNumber);
            }
            catch (ValueOutOfRangeException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
                Console.WriteLine("Let's try again..");
                createAndaddNewElectricMotorcycleToGarage(i_VehivleLicenceNumber);
            }
        }

        private void createAndAddNewFuelMotorcycleToGarage (string i_VehivleLicenceNumber)
        {
            string modelName, wheelsManufacturerName, ownerName, ownerPhone;
            float currentFuelAmount, wheelsCurrentAirPressure;
            Motorcycle.eLicenseType licenseType;
            int CCEngineVolume;
            Vehicle newVehicle;

            createBasicVehicalDetails(out modelName, out wheelsManufacturerName, out ownerName, out ownerPhone, out wheelsCurrentAirPressure);
            currentFuelAmount = getCurrentLitersFuelAmount();
            licenseType = getLicenseType();
            CCEngineVolume = getCCEngineVolume();
            try
            {
                newVehicle = VehicleBuilder.CreateNewFuelMotorcycle(modelName, i_VehivleLicenceNumber,
                 currentFuelAmount, licenseType, CCEngineVolume, wheelsManufacturerName, wheelsCurrentAirPressure);
                r_GarageMenagement.AddNewVehicleToGarage(ownerName, ownerPhone, newVehicle);
                Console.WriteLine("The new vehical added to the garage");
            }
            catch (ArgumentException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
                createAndAddNewFuelMotorcycleToGarage(i_VehivleLicenceNumber);
            }
            catch (ValueOutOfRangeException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
                Console.WriteLine("Let's try again..");
                createAndAddNewFuelMotorcycleToGarage(i_VehivleLicenceNumber);
            }
        }

        private bool getIsDriveRefrigeratedContents()
        {
            bool isDriveRefrigeratedContents;
            string userInput; 

            Console.WriteLine("Does the trunk drive refrigerated contents? (Y/N)");
            userInput = Console.ReadLine();
            while (!(userInput.Equals("Y") || userInput.Equals("y") || userInput.Equals("N") || userInput.Equals("n")))
            {
                Console.WriteLine("Does the trunk drive refrigerated contents? (Y/N)") ;
                userInput = Console.ReadLine();
            }

            if (userInput.Equals("Y") || userInput.Equals("y"))
            {
                isDriveRefrigeratedContents = true;
            }
            else
            {
                isDriveRefrigeratedContents = false;
            }

            return isDriveRefrigeratedContents;
        }

        private string getOwnerName()
        {
            string ownerName;

            Console.WriteLine("Please enter the owner name");
            ownerName = Console.ReadLine();
            if (ownerName.Length == 0)
            {
                Console.WriteLine("Invalid input, please try again");
                ownerName = Console.ReadLine();
            }

            return ownerName;
        }

        private string getOwnerPhone()
        {
            string ownerPhone;

            Console.WriteLine("Please enter the owner phone");
            ownerPhone = Console.ReadLine();
            while (!ownerPhone.All(char.IsDigit))
            {
                Console.WriteLine("Invalid input, please try again");
                ownerPhone = Console.ReadLine();
            }

            return ownerPhone; 
        }

        private int getCCEngineVolume()
        {
            int CCEngineVolume;
            bool isValidInput;

            Console.WriteLine("Please enter the CCEngine Volume");
            isValidInput = int.TryParse(Console.ReadLine(), out CCEngineVolume);
            while (!isValidInput)
            {
                Console.WriteLine("Invalid Input, please try again");
                isValidInput = int.TryParse(Console.ReadLine(), out CCEngineVolume);
            }

            return CCEngineVolume;
        }

        private Motorcycle.eLicenseType getLicenseType()
        {
            Motorcycle.eLicenseType userInputEnum = Motorcycle.eLicenseType.A;
            string userInput;
            bool isValidInput;

            Console.WriteLine("Please enter the licence type: (1) A, (2) A1, (3) B1, (4) BB");
            userInput = Console.ReadLine();
            isValidInput = isValidLicenseType(userInput, ref userInputEnum);
            while (!isValidInput)
            {
                Console.WriteLine("Invalid choise, please try again");
                userInput = Console.ReadLine();
                isValidInput = isValidLicenseType(userInput, ref userInputEnum);
            }

            return userInputEnum; 
        }

        private Car.eColor getColor()
        {
            Car.eColor userInputEnum = Car.eColor.Red;
            string userInput;
            bool isValidInput;

            Console.WriteLine("please choose color: (1) Red, (2) White, (3) Green or (4) Blue");
            userInput = Console.ReadLine();
            isValidInput = isValidCarColor(userInput, ref userInputEnum);
            while (!isValidInput)
            {
                Console.WriteLine("Invalid choise, please try again");
                userInput = Console.ReadLine();
                isValidInput = isValidCarColor(userInput, ref userInputEnum);
            }

            return userInputEnum; 
        }

        private Car.eNumberOfDoors getNumberOfDoors()
        {
            Car.eNumberOfDoors numberOfDoors = Car.eNumberOfDoors.Two;
            string userInput;
            bool isValidInput;

            Console.WriteLine("please choose number of doors: (1) Two, (2) Three, (3) Four, (4) Five");
            userInput = Console.ReadLine();
            isValidInput = isValidNumberOfDoors(userInput, ref numberOfDoors);
            while (!isValidInput)
            {
                Console.WriteLine("Invalid choise, please try again");
                userInput = Console.ReadLine();
                isValidInput = isValidNumberOfDoors(userInput, ref numberOfDoors);
            }

            return numberOfDoors;
        }

        private float getCurrentBatteryMinutesAmount()
        {
            float currentEnergyAmount;
            bool isValidInput;

            Console.WriteLine("Please enter the current battery minutes of the vehicle");
            isValidInput = float.TryParse(Console.ReadLine(), out currentEnergyAmount);
            while (!isValidInput)
            {
                Console.WriteLine("Invalid choise, please try again");
                isValidInput = float.TryParse(Console.ReadLine(), out currentEnergyAmount);
            }

            return currentEnergyAmount;
        }

        private float getCurrentLitersFuelAmount()
        {
            float currentEnergyAmount;
            bool isValidInput;

            Console.WriteLine("Please enter the current liters of Fuel of the vehicle");
            isValidInput = float.TryParse(Console.ReadLine(), out currentEnergyAmount);
            while (!isValidInput)
            {
                Console.WriteLine("Invalid choise, please try again");
                isValidInput = float.TryParse(Console.ReadLine(), out currentEnergyAmount);
            }

            return currentEnergyAmount;
        }

        private float getWheelsCurrentPressure()
        {
            float wheelsCurrentPressure;
            bool isValidInput;

            Console.WriteLine("Please enter the current pressure for the vehicles wheels");
            isValidInput = float.TryParse(Console.ReadLine(), out wheelsCurrentPressure);
            while (!isValidInput)
            {
                Console.WriteLine("Wheels pressure must be a float number. Please try again");
                isValidInput = float.TryParse(Console.ReadLine(), out wheelsCurrentPressure);
            }
           
            return wheelsCurrentPressure;
        }

        private string getWheelsManufacturerName()
        {
            string wheelManufacturer;

            Console.WriteLine("Please enter Wheels's manufacturer name");
            wheelManufacturer = Console.ReadLine(); 
            while (wheelManufacturer.Length == 0)
            {
                Console.WriteLine("Invalid input. Please try again.");
                wheelManufacturer = Console.ReadLine();
            }

            return wheelManufacturer;
        }

        private string getModelName()
        {
            string vehicleModel;

            Console.WriteLine("please enter vehicle model name"); 
            vehicleModel = Console.ReadLine();
            while (vehicleModel.Length == 0)
            {
                Console.WriteLine("Invalid input. Please try again");
                vehicleModel = Console.ReadLine();
            }

            return vehicleModel;
        }

        private void changeVehicleCondition()
        {
            string newConditionString;
            string vehicleLicenceNumber;
            Garage.eConditionOfVehicleInGarage newVehicalConditionEnum = Garage.eConditionOfVehicleInGarage.InRepair;

            Console.WriteLine("Please enter vehical License plate number");
            vehicleLicenceNumber = Console.ReadLine();
            Console.WriteLine("Please enter the new vehicle condition (1) InRepair, (2) Fixed, (3) PaidUp");
            newConditionString = Console.ReadLine();
            try
            {
                if (isVehicalConditionExist(newConditionString, ref newVehicalConditionEnum))
                {
                    r_GarageMenagement.ChangeVehicleCondition(vehicleLicenceNumber, newVehicalConditionEnum);
                    Console.WriteLine(string.Format("The condition of the vehical change to {0}.", newVehicalConditionEnum.ToString()));
                }
                else
                {
                    Console.WriteLine("The selected conditions doen't exist. Please try again");
                    changeVehicleCondition();
                }
            }
            catch(ArgumentException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
            }
        }

        private void inflatingVehicleWheelsToMax()
        {
            string licensePlateNumber;

            Console.WriteLine("Please enter vehical License plate number");
            licensePlateNumber  = Console.ReadLine();
            try
            {
                r_GarageMenagement.InflatingVehicleWheelsToMax(licensePlateNumber);
                Console.WriteLine("The vehical wheels were inflated to maximum pressure");
            }
            catch(ArgumentException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
            }
        }

        private void displayVehiclesInGarageList()
        {
            string userDecision;

            Console.WriteLine("Do you want to filter the vehical list on the garage by vehical consition? (Y/N)");
            userDecision = Console.ReadLine();
            if(userDecision.Equals("Y") || userDecision.Equals("y"))
            {
                displayVehiclesInGarageAccordingToConditionList();
            }
            else if (userDecision.Equals("N") || userDecision.Equals("n"))
            {
                displayAllVehiclesInGarageList();
            }
            else
            {
                Console.WriteLine("Invalide input. Please try again.");
                displayVehiclesInGarageList();
            }
        }

        private void displayAllVehiclesInGarageList()
        {
            List<string> vehiclesInGarageList = r_GarageMenagement.VehicleListInGarage();

            if (vehiclesInGarageList.Count() != 0)
            {
                Console.WriteLine("Vehicals list:");
                foreach (string vehicle in vehiclesInGarageList)
                {
                    Console.WriteLine(vehicle.ToString());
                }
            }
            else
            {
                Console.WriteLine("There are no vehicles in the garage");
            }
        }

        private void displayVehiclesInGarageAccordingToConditionList()
        {
            string vehivelConditionToDisplay;
            Garage.eConditionOfVehicleInGarage vehicleCondition = Garage.eConditionOfVehicleInGarage.InRepair;
            List<string> vehiclesInGarageAccordingToConditionList;

            Console.WriteLine("Please enter the vehicle condition (1) InRepair, (2) Fixed, (3) PaidUp");
            vehivelConditionToDisplay = Console.ReadLine();
            if (isVehicalConditionExist(vehivelConditionToDisplay, ref vehicleCondition))
            {
                vehiclesInGarageAccordingToConditionList = r_GarageMenagement.VehicleListInGarageAccordingToCondition(vehicleCondition);
                if (vehiclesInGarageAccordingToConditionList.Count() != 0)
                {
                    Console.WriteLine("Vehicals list:");
                    foreach (string vehicle in vehiclesInGarageAccordingToConditionList)
                    {
                        Console.WriteLine(vehicle.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("There are no vehicles in the garage");
                }
            }
            else
            {
                Console.WriteLine("The selected conditions doen't exist. Please try again.");
                displayVehiclesInGarageAccordingToConditionList();
            }
        }

        private void vehicleCharge()
        {
            string licensePlateNumber;
            float chargeMinutes;

            Console.WriteLine("Please enter vehical License plate number");
            licensePlateNumber = Console.ReadLine();
            try
            {
                Console.WriteLine("Please enter charge minutes to add");
                chargeMinutes = float.Parse(Console.ReadLine());
                if (chargeMinutes < 0)
                {
                    Console.WriteLine("charge minutes must be a positive number. Please try again");
                    vehicleRefuel();
                }
                else
                {
                    r_GarageMenagement.VehicleCharge(licensePlateNumber, chargeMinutes);
                    Console.WriteLine("Battery refilled successfully");
                }
            }
            catch (FormatException errorMessege)
            {
                Console.WriteLine("Invalid input - charge minutes must be a number");
                vehicleCharge();
            }
            catch (ArgumentException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
            }
            catch (ValueOutOfRangeException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
                Console.WriteLine("Let's try again..");
                vehicleCharge();
            }
        }

        private void vehicleRefuel()
        {
            string licensePlateNumber, fuleTypeString;
            float litersOfFuel;
            FuelEngine.eFuelType fuleTypeEnum = FuelEngine.eFuelType.Soler;

            Console.WriteLine("Please enter vehical License plate number");
            licensePlateNumber = Console.ReadLine();
            try
            {
                Console.WriteLine("Please enter liters of fuel to add");
                litersOfFuel = float.Parse(Console.ReadLine());
                if(litersOfFuel < 0)
                {
                    Console.WriteLine("Liters of fuel must be a positive number. Please try again");
                    vehicleRefuel();
                }
                else
                {
                    Console.WriteLine("Please enter fuel type (1) Soler, (2) Octan95, (3) Octan96, (4) Octan98");
                    fuleTypeString = Console.ReadLine();
                    if (isValidFuleType(fuleTypeString, ref fuleTypeEnum))
                    {
                        r_GarageMenagement.VehicleRefuel(licensePlateNumber, fuleTypeEnum, litersOfFuel);
                        Console.WriteLine("Refueling was successful");
                    }
                    else
                    {
                        Console.WriteLine("The selected fule type doen't exist. Please try again");
                        vehicleRefuel();
                    }
                }
            }
            catch (FormatException errorMessege)
            {
                Console.WriteLine("Invalid input - liters of fuel must be a number");
                vehicleRefuel();
            }
            catch (ArgumentException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
            }
            catch (ValueOutOfRangeException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
                Console.WriteLine("Let's try again..");
                vehicleRefuel();
            }
        }

        private void displayVehicleInformation()
        {
            string licensePlateNumber;

            Console.WriteLine("Please enter vehical License plate number");
            licensePlateNumber = Console.ReadLine();
            try
            {
                Console.WriteLine(r_GarageMenagement.DisplayVehicleInformation(licensePlateNumber).ToString()); 
            }
            catch(ArgumentException errorMessege)
            {
                Console.WriteLine(errorMessege.Message);
            }
        }

        private bool isValidFuleType(string i_UserInput, ref FuelEngine.eFuelType o_FuleType)
        {
            bool isFuleTypeExist;
            bool isUserInputValid;
            int userInput;

            isUserInputValid = int.TryParse(i_UserInput, out userInput);
            if (isUserInputValid)
            {
                if (userInput <= Enum.GetNames(typeof(FuelEngine.eFuelType)).Length && userInput >= 1)
                {
                    switch (userInput)
                    {
                        case 1:
                            o_FuleType = FuelEngine.eFuelType.Soler;
                            break;
                        case 2:
                            o_FuleType = FuelEngine.eFuelType.Octan95;
                            break;
                        case 3:
                            o_FuleType = FuelEngine.eFuelType.Octan96;
                            break;
                        case 4:
                            o_FuleType = FuelEngine.eFuelType.Octan98;
                            break;
                    }
                    isFuleTypeExist = true;
                }
                else
                {
                    isFuleTypeExist = false;
                }
            }
            else
            {
                isFuleTypeExist = false;
            }

            return isFuleTypeExist;
        }

        private bool isValidLicenseType(string i_UserInput, ref Motorcycle.eLicenseType o_LicenseType)
        {
            bool isLicenseTypeExist;
            bool isUserInputValid;
            int userInput;

            isUserInputValid = int.TryParse(i_UserInput, out userInput);
            if (isUserInputValid)
            {
                if (userInput <= Enum.GetNames(typeof(Motorcycle.eLicenseType)).Length && userInput >= 1)
                {
                    switch (userInput)
                    {
                        case 1:
                            o_LicenseType = Motorcycle.eLicenseType.A;
                            break;
                        case 2:
                            o_LicenseType = Motorcycle.eLicenseType.A1;
                            break;
                        case 3:
                            o_LicenseType = Motorcycle.eLicenseType.B1;
                            break;
                        case 4:
                            o_LicenseType = Motorcycle.eLicenseType.BB;
                            break;
                    }
                    isLicenseTypeExist = true;
                }
                else
                {
                    isLicenseTypeExist = false;
                }
            }
            else
            {
                isLicenseTypeExist = false;
            }

            return isLicenseTypeExist;
        }

        private bool isValidCarColor(string i_UserInput, ref Car.eColor o_Color)
        {
            bool isColorExist;
            bool isUserInputValid;
            int userInput;

            isUserInputValid = int.TryParse(i_UserInput, out userInput);
            if (isUserInputValid)
            {
                if (userInput <= Enum.GetNames(typeof(Car.eColor)).Length && userInput >= 1)
                {
                    switch (userInput)
                    {
                        case 1:
                            o_Color = Car.eColor.Red;
                            break;
                        case 2:
                            o_Color = Car.eColor.White;
                            break;
                        case 3:
                            o_Color = Car.eColor.Green;
                            break;
                        case 4:
                            o_Color = Car.eColor.Blue;
                            break;
                    }
                    isColorExist = true;
                }
                else
                {
                    isColorExist = false;
                }
            }
            else
            {
                isColorExist = false;
            }

            return isColorExist;
        }

        private bool isValidNumberOfDoors(string i_UserInput, ref Car.eNumberOfDoors o_NumberOfDoors)
        {
            bool isDoorNumberExist;
            bool isUserInputValid;
            int userInput;

            isUserInputValid = int.TryParse(i_UserInput, out userInput);
            if (isUserInputValid)
            {
                if (userInput <= Enum.GetNames(typeof(Car.eNumberOfDoors)).Length && userInput >= 1)
                {
                    switch (userInput)
                    {
                        case 1:
                            o_NumberOfDoors = Car.eNumberOfDoors.Two;
                            break;
                        case 2:
                            o_NumberOfDoors = Car.eNumberOfDoors.Three;
                            break;
                        case 3:
                            o_NumberOfDoors = Car.eNumberOfDoors.Four;
                            break;
                        case 4:
                            o_NumberOfDoors = Car.eNumberOfDoors.Five;
                            break;
                    }
                    isDoorNumberExist = true;
                }
                else
                {
                    isDoorNumberExist = false;
                }
            }
            else
            {
                isDoorNumberExist = false;
            }

            return isDoorNumberExist;
        }

        private bool isVehicalConditionExist(string i_conditionToCheck, ref Garage.eConditionOfVehicleInGarage o_Condition)
        {
            bool isConditionExist;
            bool isUserInputValid;
            int userInput;

            isUserInputValid = int.TryParse(i_conditionToCheck, out userInput);
            if (isUserInputValid)
            {
                if (userInput <= Enum.GetNames(typeof(Garage.eConditionOfVehicleInGarage)).Length && userInput >= 1)
                {
                    switch (userInput)
                    {
                        case 1:
                            o_Condition = Garage.eConditionOfVehicleInGarage.InRepair;
                            break;
                        case 2:
                            o_Condition = Garage.eConditionOfVehicleInGarage.Fixed;
                            break;
                        case 3:
                            o_Condition = Garage.eConditionOfVehicleInGarage.PaidUp;
                            break;
                       
                    }
                    isConditionExist = true;
                }
                else
                {
                    isConditionExist = false;
                }
            }
            else
            {
                isConditionExist = false;
            }

            return isConditionExist;
        }
    }
}
