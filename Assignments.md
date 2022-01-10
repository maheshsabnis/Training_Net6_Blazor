# Assignments

# Date: 04-Jan-2022

1. Modify the EmployeeForm Component for the following Requirements (Today)
	- When the Selected Employee Record is displayed in Text and Select Elemenet, Update the Employee Information and Save it back.
	- Generate a Delete Button for Each Table Row, when this button is clicked delete the Employee Record
	- Add Two Radio Buttons on the top of the Employee Table to Sort and Reverse the Employees Data in Ascending and Descending Order by EmpName and EmpNo (One at a time) 	
	- Generate the Employee Table Dynamically w/o any hardcoding for Table Header and Table Rows
		- Note: Use the PropertyInfo class from Reflection
2. Create a CheckboxList Component based on the Courses Array Passesed to it
	- Course Array will contains Course object with peroperties as {CourseName, Fees}
	- When the End-Use selects Courses, display total fees of selected courses 

# Date: 05-Jan-2022

1. Create a Re-Usable Table Component with the following Specifications (Today) (Refer this Compoennt as DataGrid )
	- This MUST accept the 'DataSource' Parameter of the type Array
	- Based on the DataSource, this Compoennt MUST generate Table Header and TableRows
	- This Component MUST have an Event Callback That will Emit the Selected Row Value to its Parent
    - Ref. https://www.webnethelper.com/2021/02/creating-blazor-server-app-for.html
2. Blazor WebAssembly Application (MUST be ready By Saturday (8-Jan-2022) and Share it to me using your git link )
	- CReate a ApplicationState object that will contains a collection of 'ShoppedData'
	- This Collection will be updated using following components
		- The Component that will show List of Grossaries Material as like below
			- ItemName, UnitPrice, QuantityPurchased, TotalPriceofSelectedGrossaries
		- The Component that will show List of Fashion Material as like below
			- ItemName, UnitPrice, QuantityPurchased, TotalPriceofSelectedGrossaries
		- The BillComponent That will display details Bill Imformation  as
			- Table Header will show the BillNo
			- Table Row will show items as
				- Grossaries
				- Fashion item
			- Table Follter will display the Total Bill
			- Re: https://www.webnethelper.com/2019/12/using-session-state-in-aspnet-core.html

# Date: 07-Jan-2022
1. Create a API Project with EF Core Db First Approach to Create DAL, The  Create repositoiry, Register DAL and Repository Classes for Department and Employee in DI COntainer and Create Department and Employee APIs

# Date : 10-Jan-2022

1. Create a SPA for Departments and Employees for CRUD Operations using API and Open API Specifications 3.0 Proxy
	- Create a Component that will Show Links (or buttons) for Department and Employee
	- When 'Department' button is clicked the DepartmenmtsList component MUST be shown. This component will have Button for Create a New Department. On DepartmenmtsList component, each Table row mujst have Edit and Delete Button. When the 'Edit' button is clicked, then the EditDeptComponent Must be displayed with record to be edited. Once the Create New Department and Edit Department is succefull on 'Save' button of each of corresponding component then Navigate to the DepartmentList component.
	- repeat this for Employee also.
2. Create a Search-Component, that will search Employees based on EmpName, DeptName, Designation using Server-Side search facility (Create a API for Server-Side Search) and display the Search result in Blazor Search Component 


		