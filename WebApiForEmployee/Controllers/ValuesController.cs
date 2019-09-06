using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiForEmployee.Controllers
{
    public class Manager
    {
        public int Mid;
        public double salary;
        public string name;
        public List<Employee> employee; 
    }
    public class Employee
    {
        public int id = 3;
        public string name = "ujjwal";
        public int age = 22;
        public double salary = 46000;
    }
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Manager> Get()
        {
            string text = System.IO.File.ReadAllText(@"c:\Users\csingh\source\Employee.json");
            var jobject = JsonConvert.DeserializeObject<List<Manager>>(text) ?? new List<Manager>();
            return jobject;
        }

        // GET api/values/5
        public object Get(int id)
        {
            int flag = 0;
            string text1 = string.Empty;
            string text = System.IO.File.ReadAllText(@"c:\Users\csingh\source\Employee.json");
            // object jobject = JsonConvert.DeserializeObject<object>(text);
            var managerlist = JsonConvert.DeserializeObject<List<Manager>>(text) ?? new List<Manager>();
            for (int index = 0; index < managerlist.Count; index++)
            {
                if (managerlist[index].Mid == id)
                    return managerlist[index];
                else
                {
                    for (int count = 0; count < managerlist[index].employee.Count; count++)
                    {
                        if (managerlist[index].employee[count].id == id)
                            return managerlist[index].employee[count];
                    }
                    //return null;
                }
                    
            }

            return null;
        }
        // POST api/values

        public void Post()
        {
            var filepath = @"c:\Users\csingh\source\Employee.json";
           

            var jsonData = System.IO.File.ReadAllText(filepath);
            // De-serialize to object or create new list
            var employeeList = JsonConvert.DeserializeObject<List<Manager>>(jsonData)
                                  ?? new List<Manager>();

            // Add any new employees
            employeeList.Add(new Manager()
            {
                employee = new List<Employee>()
                {
                   new Employee()
                   {
                       id=12817837,
                       name="j",
                       salary=46000,
                       age=23
                   }
                },
                Mid = 10805,
                name = "sai",
                salary = 5000000,
            });
            employeeList.Add(new Manager()
            {
                employee = new List<Employee>()
                {
                   new Employee()
                   {
                       id=12817847,
                       name="T",
                       salary=46000,
                       age=23
                   }
                },
                Mid = 108885,
                name = "sai",
                salary = 5000000,
            });

            // Update json data string
            jsonData = JsonConvert.SerializeObject(employeeList);
            System.IO.File.WriteAllText(filepath, jsonData);
        }
    }

    
}
