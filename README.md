# ProjectTimeManager-Knockout
This is a .Net application that utilizes Dapper and Knockout (KO). The basis of the application is a project time management system that allows a user to view all the time allocated to specific project. Functionality consists of the basic CRUD on the following entities: employees, projects, time logs.

Tools Needed: Visual Studios and Microsoft SQL Server Management Studio (For development, Visual Studios Community 2015 and Microsoft SQL Sever Management Studio 2016 were used).

The application is split into three primary components: Presentation, Logic, and Data Access.

1. Presentation

		1.1 The WebApp project is the MVC Web App Application.

2. Logic

		2.1 The Global project contains the configurator.cs which establishes whether the application is in development or production as well as the connection string that will be used.

		2.2 The DataBridge project bridges the DataAccess project and Model project together.

			2.2.1 The DataBridge applies the conversion between the Dapper model classes and the model classes used in the MVC Web App.
			
			2.2.3 The DataBridge also contains the DataBridgeModelRepository.cs
			
		2.3 The Model project contains the model classes as well as the IModelRepository used in the WebApp project.
		
3. Data Access

		3.1 The DataAccess project contains a Managers folder, SQL Scripts folder, and Dapper Model Classes folder, and a DatabaseSeeder.cs
		
			3.1.1 The SQL Scripts folder contains the create script for the database as well as the seed data
			
			3.1.1.1 **Make sure you read the ReadMe.txt for more information on how to get the database created**
			
			3.1.2 The Dapper Model Classes folder contains the model classes used in the Dapper query/execution statements
			
			3.1.3 The Managers folder contains all the manager classes which contains all the methods used to extract or load data into the various tables
			
			3.1.3.1 Ex) The EmployeeManager.cs pertains to anything related to the dbo.Employee table in the database
			
			3.1.4 The DatabaseSeeder.cs is used in the Startup.cs in the WebApp to seed the data in the tables **if there is no data.
