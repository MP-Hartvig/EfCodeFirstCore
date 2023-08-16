using EfCodeFirstCore.DataContext;
using EfCodeFirstCore.DataHandlers;
using EfCodeFirstCore.Models;
using EfCodeFirstCore.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.Managers
{
    internal class InitializationManager
    {
        EfCodeFirstCoreContext efContext = new EfCodeFirstCoreContext();

        public List<Developer> GetDeveloperList()
        {
            DeveloperDataHandler developerHandler = new DeveloperDataHandler(efContext);

            return developerHandler.SelectAllDevelopers();
        }

        public List<Manager> GetManagerList()
        {
            ManagerDataHandler managerHandler = new ManagerDataHandler(efContext);

            return managerHandler.SelectAllManagers();
        }

        public List<Department> GetDepartmentList()
        {
            DepartmentDataHandler departmentHandler = new DepartmentDataHandler(efContext);

            return departmentHandler.SelectAllDepartments();
        }

        public List<Location> GetLocationList()
        {
            LocationDataHandler locationHandler = new LocationDataHandler(efContext);

            return locationHandler.SelectAllLocations();
        }

        public bool CreateLocation(string input)
        {
            LocationDataHandler locationHandler = new LocationDataHandler(efContext);
            Location location = new Location();

            location.city = input;

            return locationHandler.CreateLocation(location);
        }

        public bool CreateDepartment(string departmentName, string locationNumber)
        {
            DepartmentDataHandler departmenthandler = new DepartmentDataHandler(efContext);
            ConvertStringToInt converter = new ConvertStringToInt();
            Department department = new Department();
            Location location = new Location();

            int temp = converter.ConvertStringToIntWithErrorHandling(locationNumber);
            location.id = (temp - 1);

            department.name = departmentName;
            department.location = location;

            return departmenthandler.CreateDepartment(department);
        }

        public bool CreateEmployee(string type, List<string> inputStrings, string departmentNumber)
        {
            ConvertStringToInt converter = new ConvertStringToInt();
            Department department = new Department();

            int temp = converter.ConvertStringToIntWithErrorHandling(departmentNumber);
            department.id = (temp - 1);

            if (type == "Developer")
            {
                Developer dev = new Developer();
                DeveloperDataHandler devDataHandler = new DeveloperDataHandler(efContext);

                dev.firstName = inputStrings[0];
                dev.lastName = inputStrings[1];
                dev.streetName = inputStrings[2];
                dev.streetName = inputStrings[3];
                dev.privatePhone = inputStrings[4];
                dev.primaryProgrammingLanguage = inputStrings[5];
                dev.department = department;

                return devDataHandler.CreateDeveloper(dev);
            }
            else
            {
                Manager mana = new Manager();
                ManagerDataHandler manaDataHandler = new ManagerDataHandler(efContext);

                mana.firstName = inputStrings[0];
                mana.lastName = inputStrings[1];
                mana.streetName = inputStrings[2];
                mana.streetName = inputStrings[3];
                mana.privatePhone = inputStrings[4];
                mana.workPhone = inputStrings[5];
                mana.department = department;

                return manaDataHandler.CreateManager(mana);
            }
        }
    }
}
