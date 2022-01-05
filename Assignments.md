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