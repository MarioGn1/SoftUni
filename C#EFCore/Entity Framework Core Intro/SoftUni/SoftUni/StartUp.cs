using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            //TASK 3
            //var result = GetEmployeesFullInformation(db);
            //TASK 4
            //var result = GetEmployeesWithSalaryOver50000(db);
            //TASK 5
            //var result = GetEmployeesFromResearchAndDevelopment(db);
            //TASK 6
            //var result = AddNewAddressToEmployee(db);
            //TASK 7
            //var result = GetEmployeesInPeriod(db);
            //TASK 8
            //var result = GetAddressesByTown(db);
            //TASK 9
            //var result = GetEmployee147(db);
            //TAKS 10
            //var result = GetDepartmentsWithMoreThan5Employees(db);
            //TASK 11
            //var result = GetLatestProjects(db);
            //TASK 12
            //var result = IncreaseSalaries(db);
            //TASK 13
            //var result = GetEmployeesByFirstNameStartingWithSa(db);
            //TASK 14
            //var result = DeleteProjectById(db);
            //TASK 15
            var result = RemoveTown(db);
            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var result = context.Employees
                .Select(x => new { x.EmployeeId, x.FirstName, x.LastName, x.MiddleName, x.JobTitle, x.Salary })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in result)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var result = context.Employees
                .Where(x => x.Salary > 50000)
                .Select(x => new { x.FirstName, x.Salary })
                .OrderBy(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in result)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var result = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new { x.FirstName, x.LastName, DepartmentName = x.Department.Name, x.Salary })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in result)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var emp = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            emp.Address = address;

            context.SaveChanges();

            var result = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(x => new { text = x.Address.AddressText })
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in result)
            {
                sb.AppendLine($"{employee.text}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var result = context.Employees
                .Where(emp => emp.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001))
                .Select(emp => new { emp.FirstName, emp.LastName, managerFName = emp.Manager.FirstName, managerLName = emp.Manager.LastName, empProj = emp.EmployeesProjects.Select(proj => proj.Project).ToList() })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in result)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.managerFName} {employee.managerLName}");
                foreach (var project in employee.empProj)
                {
                    var endDate = project.EndDate == null ? "not finished" : ((DateTime)project.EndDate).ToString("M/d/yyyy h:mm:ss tt");
                    sb.AppendLine($"--{project.Name} - { project.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {endDate}");
                }
            }
            return sb.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var result = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(t => t.Town.Name)
                .ThenBy(at => at.AddressText)
                .Select(x => new { x.AddressText, name = x.Town.Name, count = x.Employees.Count })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var address in result)
            {
                sb.AppendLine($"{address.AddressText}, {address.name} - {address.count} employees");
            }
            return sb.ToString().Trim();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var emp = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    projects = x.EmployeesProjects.Select(y => y.Project.Name)
                    .OrderBy(y => y)
                    .ToList()
                }).FirstOrDefault();

            string finalResult = $"{emp.FirstName} {emp.LastName} - {emp.JobTitle}" + Environment.NewLine + string.Join(Environment.NewLine, emp.projects);
            return finalResult.Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var result = context.Departments
                .Where(dep => dep.Employees.Count > 5)
                .OrderBy(dep => dep.Employees.Count)
                .ThenBy(dep => dep.Name)
                .Select(dep => new
                {
                    dep.Name,
                    managerFName = dep.Manager.FirstName,
                    managerLName = dep.Manager.LastName,
                    emps = dep.Employees
                    .Select(emp => new { emp.FirstName, emp.LastName, emp.JobTitle })
                    .OrderBy(emp => emp.FirstName)
                    .ThenBy(emp => emp.LastName)
                    .ToList()
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var department in result)
            {
                sb.AppendLine($"{department.Name} - {department.managerFName} {department.managerLName}");
                foreach (var employee in department.emps)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }
            return sb.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var result = context.Projects
                .OrderByDescending(proj => proj.StartDate)
                .Take(10)
                .OrderBy(proj => proj.Name)
                .ToList();

            var sb = new StringBuilder();
            foreach (var proj in result)
            {
                sb.AppendLine($"{proj.Name}");
                sb.AppendLine($"{proj.Description}");
                sb.AppendLine($"{proj.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }
            return sb.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var result = context.Employees
                .Where(emp => emp.Department.Name == "Engineering"
                    || emp.Department.Name == "Tool Design"
                    || emp.Department.Name == "Marketing"
                    || emp.Department.Name == "Information Services")
                .OrderBy(emp => emp.FirstName)
                .ThenBy(emp => emp.LastName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var emp in result)
            {
                emp.Salary = emp.Salary * 1.12M;
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            }

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var result = context.Employees
                .Where(emp => emp.FirstName.StartsWith("Sa"))
                .OrderBy(emp => emp.FirstName)
                .ThenBy(emp => emp.LastName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var emp in result)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");
            }

            return sb.ToString().Trim();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projToRemove = context.Projects.FirstOrDefault(x => x.ProjectId == 2);

            var mapTable = context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToList();

            foreach (var item in mapTable)
            {
                context.EmployeesProjects.Remove(item);
            }
            context.Projects.Remove(projToRemove);
            context.SaveChanges();

            var result = context.Projects.Take(10).ToList();

            var sb = new StringBuilder();

            foreach (var proj in result)
            {
                sb.AppendLine(proj.Name);
            }

            return sb.ToString().Trim();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            string targetTown = "Seattle";
            var employees = context.Employees
                .Where(emp => emp.Address.Town.Name == targetTown)
                .ToList();

            foreach (var emp in employees)
            {
                emp.AddressId = null;
            }

            context.SaveChanges();

            var addresses = context.Addresses
                .Where(x => x.Town.Name == targetTown)
                .ToList();
            int addressesCount = addresses.Count;

            foreach (var item in addresses)
            {
                context.Addresses.Remove(item);
            }

            context.SaveChanges();

            var town = context.Towns
                .FirstOrDefault(x => x.Name == targetTown);

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{addressesCount} addresses in {targetTown} were deleted";
        }
    }
}
