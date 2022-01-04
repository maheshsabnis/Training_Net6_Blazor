namespace Blazor_Wasm.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string? EmpName { get; set; }
        public string? DeptName { get; set; }
        public string? Designation { get; set; }
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
