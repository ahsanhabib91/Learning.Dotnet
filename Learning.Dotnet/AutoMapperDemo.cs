using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Dotnet
{
    public class AutoMapperDemo
    {
        private readonly MapperConfiguration config;

        public AutoMapperDemo()
        {
            config = new MapperConfiguration(cfg => // cfg.CreateMap<TSource, TDestination>()
                cfg.CreateMap<Employee, EmployeeDTO>()
                    // Mapping destination property with source property where sourceProperty is not equal to destinationProperty
                    .ForMember(destinationMember => destinationMember.FullName, action => action.MapFrom(src => src.Name))
                    .ForMember(destinationMember => destinationMember.Dept, action => action.MapFrom(src => src.Department))
                ); 

            //Creating the source object
            Employee emp = new Employee
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT"
            };

            //Using automapper
            var mapper = new Mapper(config);

            var empDTO = mapper.Map<EmployeeDTO>(emp);
            //OR
            //var empDTO2 = mapper.Map<Employee, EmployeeDTO>(emp);
            Console.WriteLine("Name:" + empDTO.FullName + ", Salary:" + empDTO.Salary + ", Address:" + empDTO.Address + ", Department:" + empDTO.Dept);
            Console.ReadLine();
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class EmployeeDTO
    {
        //public string Name { get; set; }
        public string FullName { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        //public string Department { get; set; }
        public string Dept { get; set; }
    }
}

/*
 * Useful Links: https://dotnettutorials.net/lesson/automapper-in-c-sharp/
 * Qus: How to map two properties when the names are different using automapper?
 * ANS: ForMember
 */
