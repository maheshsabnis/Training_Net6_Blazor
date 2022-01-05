using System.ComponentModel.DataAnnotations;

namespace Blazor_Wasm.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "EmpNo is Required")]
        public int EmpNo { get; set; }
        [Required(ErrorMessage = "EmpName is Required")]
        public string? EmpName { get; set; }
        [Required(ErrorMessage = "DeptName is Required")]
        public string? DeptName { get; set; }
        [Required(ErrorMessage = "Designation is Required")]
        public string? Designation { get; set; }
        [Required(ErrorMessage = "Salary is Required")]
        public int Salary { get; set; }
    }


    public class Employees : List<Employee>
    {
        public Employees()
        {
            Add(new Employee() {EmpNo=101,EmpName="Mahesh", DeptName="IT", Designation="Manager", Salary=120000  });
            Add(new Employee() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR", Designation = "Manager", Salary = 110000 });
        }
    }

    
}
