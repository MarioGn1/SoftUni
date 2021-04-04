using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ProjectImportDTO
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public List<TaskInputPartialDTO> Tasks { get; set; }
    }

    [XmlType("Task")]
    public class TaskInputPartialDTO
    {
        [StringLength(40, MinimumLength = 2)]
        [Required]
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Required]
        [EnumDataType(typeof(ExecutionType))]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Required]
        [EnumDataType(typeof(LabelType))]
        public int LabelType { get; set; }
    }
}

//•	Name - text with length [2, 40] (required)
//•	OpenDate - date and time(required)
//•	DueDate - date and time(required)
//•	ExecutionType - enumeration of type ExecutionType, with possible values (ProductBacklog, SprintBacklog, InProgress, Finished) (required)
//•	LabelType - enumeration of type LabelType, with possible values (Priority, CSharpAdvanced, JavaAdvanced, EntityFramework, Hibernate) (required)
//•	ProjectId - integer, foreign key(required)
//•	Project - Project
//•	EmployeesTasks - collection of type EmployeeTask

//•	Name - text with length [2, 40] (required)
//•	OpenDate - date and time(required)
//•	DueDate - date and time(can be null)
//•	Tasks - collection of type Task

//< Project >
//    < Name > S </ Name >
//    < OpenDate > 25 / 01 / 2018 </ OpenDate >
//    < DueDate > 16 / 08 / 2019 </ DueDate >
//    < Tasks >
//      < Task >
//        < Name > Australian </ Name >
//        < OpenDate > 19 / 08 / 2018 </ OpenDate >
//        < DueDate > 13 / 07 / 2019 </ DueDate >
//        < ExecutionType > 2 </ ExecutionType >
//        < LabelType > 0 </ LabelType >
//      </ Task >
//      < Task >
//        < Name > Upland Boneset </ Name >

//           < OpenDate > 24 / 10 / 2018 </ OpenDate >

//           < DueDate > 11 / 06 / 2019 </ DueDate >

//           < ExecutionType > 2 </ ExecutionType >

//           < LabelType > 3 </ LabelType >

//         </ Task >

//       </ Tasks >

//     </ Project >
