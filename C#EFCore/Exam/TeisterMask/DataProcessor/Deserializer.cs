namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.Utils;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var rootName = "Projects";
            var dtos = XMLCustomSerializer.Deserialize<ProjectImportDTO[]>(xmlString, rootName);

            var validModels = new List<Project>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }
                var projectOpenDate = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var isDate = DateTime.TryParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime projectDueDate);

                var validTasks = new List<Task>();

                foreach (var task in dto.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(string.Format(ErrorMessage));
                        continue;
                    }
                    var taskOpenDate = DateTime.ParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var taskDueDate = DateTime.ParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (projectOpenDate > taskOpenDate || (isDate && projectDueDate < taskDueDate))
                    {
                        sb.AppendLine(string.Format(ErrorMessage));
                        continue;
                    }
                    var curTask = new Task 
                    { 
                        Name = task.Name, 
                        OpenDate = DateTime.ParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        DueDate = DateTime.ParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType
                    };
      
                    validTasks.Add(curTask);
                }

                var project = new Project
                {
                    Name = dto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = (DateTime?)projectDueDate,
                    Tasks = validTasks
                };

                validModels.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.AddRange(validModels);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var dtos = JsonConvert.DeserializeObject<IEnumerable<EmployeeInputDTO>>(jsonString);

            var validModels = new List<Employee>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var uniqueTasks = dto.Tasks.Distinct().ToList();
                List<int> realTasks = new List<int>();

                foreach (var taskId in uniqueTasks)
                {
                    if (!context.Tasks.Any(t => t.Id == taskId))
                    {
                        sb.AppendLine(string.Format(ErrorMessage));
                        continue;
                    }
                    realTasks.Add(taskId);
                }

                var emp = new Employee
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    EmployeesTasks = realTasks.Select(t => new EmployeeTask
                    {
                        TaskId = t
                    })
                    .ToList()
                };

                validModels.Add(emp);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, emp.Username, emp.EmployeesTasks.Count));
            }

            context.Employees.AddRange(validModels);
            context.SaveChanges();
            
            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}