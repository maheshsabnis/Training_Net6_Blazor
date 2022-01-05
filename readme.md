# Blazor with .NET 6
1. EntityFramework Core (EF Core)
2. Creating Blazor Application
	- One DEMO for Server-Hosted App
		- appsettings.json
			- DB Connection String
			- Application Level Configuration Values e.g. JWT Secret
			- AzureAD Security Settings
			- WebApplication Builder with its 'Configuration' property will be used to read the Serttings in appsettings.json	
		- Program.cs
			- WebApplication Buidler
	- WebAssembly Application
		- WebAssemblyHostBuilder
			- Host class that is used to manage the Blazor WASM project execution in Browser using followng
				- Loading App level Configuration
					- Initializing DI Container
					- Using In-Memory Collections
					- The UI Rendering of component
					- Data Binding with UI
					- Events on UI
	- .cshtml, they are the Razor Views which will be executed on the server and will be responsible to act as a platform for rendering Blazor UI 
	- .razor, they are Blazor Component
	- Directives
		- @page: the directive for component so that it can be used for Routing. It is always a URL
		- @inject: for Dependency Injection
		- @using: to refer and load the namespace
		- @namespace: to define a namespace (IT iks default based on the folder strructure)
		- @addTagHelper: for Registring the Custom Tag Helper
3. Components
	- Usning Standard Components
			- InputText, InputNumber, InputCheck, InputRadio, InputSelect
			- EditForm
				- Mandatory for Form Elements e.g. InputComponent
				- Model
					- Used to bind the CLR Entity Object for Value Updates
					- OnValidSubmit
						- Submit the form with the Validation Evaluation loaded on UI Thread 
					- DataAnnotationValidator
						- USed to Evaluate the ASnnotation Validation Rules
					- ValidationSummary
						- Load the HTML UI for showing validation

			- ComponentBase as a Blase Class
				- Contain following Feature for Each Component
					- Property System
						- Properties for Data and Events	
					- Initialization
						- Default Data and Rendering of the Components
					- Lifecycle Methods
						- Rendering
						- PreRendering
						- StateChanges
				- Parameters
					- Data Properties accepted from the Parent Component
					- Used for Communication Across Component with Parent-Child Relationships
				- CascadeParameters
					- Data folw from Parent-to-each child and grand children in a UI Compositional Tree		 
	- When a new Razor Component file is added into the project, the file-name is itself is a 'CUSTOM-CONMPONENT-TAG'
		- It will be compiled as a Component and willbe used by the application 
						
		- Validations
			- 
		- Databinding
			- A Mechanism of Linkink a Data Memeber of the Component with UI Element
				- @bind-Value for all Input Elements
					- @bind-Value="The-DATA-MEMBER"
					- This will be a Two-Way Binding
					- @bind-Value, will invoke a default 'Keyup-Change' event (blur) on the Input element to update the data proeprty
				- @DATA-MEMBER-NAME
					- the One-Way binding from Component Code to UI
				- @event-name
					- An Event Binding
					- Bind the Method from the Component Code with the Event of UI Element Element
						- @onclick="@METHOD-NAME"
		- Routing
		- Authentication
		- Authorization
	- Using Re-Usable Components
		- Rules for Defining Re-Usable Components
			- MUST be generic as far as possible
			- MUST define parameters for the Communication toi accept data from Parent Component
				- All these parameters MUST be public property
				- This property MUST be decorated with 'Parameter' Attribute
			- MUST define Events or EventCallback to Emit Data to parent component
				- To Emit data from Child to parent, the Handler event MUST be Asynchronous 
		- Component Communication
			- Parent-Child Relationship
				- Parameters and Custom Events
			- State-Management aka Sessioning
				- Client-Side Data Storage
				- Handling Application State		
		- Auto-Navigate across Components using the 'NavigationManager' class
			- This is already registred in the WebHostBuilder as a Transient Object
			- This is the 'NavigateTo(COMPONENT-URL-TO-NAVIGATE)' method
	- Templates
	- Server-Side Communication
		- APIs
			- HTTP Endpoints
			- OAS 3.0
			- Security
				- UserBased Security
				- Role Based Security
				- Token Based Security
				- AD Integrations
	- Consuming API in Blazor WebAssembly Apps
		- Direct Access
		- Secure Access
		- AD Security for Blazor Apps and API Apps
4. Application Deployment
	- As Web App
	- As Static App with Git Integration for CI/CD

5. .NET 6, ASP.NET Core 6 Eco-System with Dependency Injection in Blazor WebAssembly
	- WebAssemblyHostBuilder
		- The 'Services' property of the type IServiceCollection 
		- Register Dependencies
			- IServiceCollection with the 'ServiceDescriptor' class
				- The ServiceDescriptor class defines instance of dependency with the Lifetime 
				- Lifetime
					- Manage the Scope of the Dependency Object so that whne it is injected its data-State will be maintained
					- Singleton
						- The Object will live forever till the application is running
						- To Share data across Components 
					- Scopped
						- The Object will be lived for the complete Lifecycle of a Component and its children
						- For all heavy load objects those are constlier for instantiation e.g. HttpClient 
					- Transient
						- The object will be live only for the specific component
						- An object that is required only for lightweight operations
		- Inject Dependecnies





