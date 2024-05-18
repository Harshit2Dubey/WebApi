dotnet new webapi --name Console_webapi
dotnet add package Microsoft.entityframeworkcore
dotnet add package Microsoft.entityframeworkcore.design
dotnet add package Microsoft.entityframeworkcore.sqlserver
dotnet add package Microsoft.entityframeworkcore.tools


Q1. Can you explain the working of Program.cs file?
Q2. When we open the program.cs file we get-
Sol. a. builder -- Can u explain the object of builder object?
     b. app -- Can u explain the object of app  object?

Q3. What is WebApplication.CreateBuilder?
Sol. CreateBuilder function intenally calls Kestral server.

20-apr-24

Q1. can u explain the migration architecture of dotnet core app?
sol. when we release the migration command dotnet core provides Migration class which has 2 major methods-
     a. Up: create tables
     b. Down: drop tables



24/04/24

1. We have to work on service layer to define the context.
2. Need to understand the workflow of this application with diagram.
3. What are the limitations of this app?

agenda

Q2. Can u explain the tight coupling in dotnet core?

Q3. Can u explain the loose coupling in dotnet core?

Q4. What is inversion of control(IOC)?

Q5. What is DI(Dependency Injection)?

Q6. Difference b/w addtransient, addsingleton and addscope.

Q7. Explain the app with the help of diagram.


25/04/24

1. Need to understand the workflow of this application with diagram.
2. Explain the app with the help of diagram.

limitations-

EmployeeController ? (why new)... IEmployeeOperation ... EmployeeService ? (why new) ... EmployeeDBcontext ... DBSet ... Database

A. Why EmployeeController class is creating an object of EmployeeService class wrt. IEmployeeOperation interface(breakdown SRP)?
B. Why EmployeeService class is creating an object of EmployeeDBcontext class(breakdown SRP)?

Reply A. When .net core supports auto-instantiation then why we involve to allocate the memory of - 
     1. EmployeeService --> EmployeeController
     2. EmployeeDBcontext --> EmployeeService

a. There is no design pattern and SOLID principles are implemented in the given app.
b. Whole application is based on tight coupling process or there are no .net core features are applied.
c. No inversion of principle and DI are applied in given application.

Design patterns-

1. FluentAPI design pattern (missing).
2. Fluent model validation (missing).


30/04/24

Practical implementation of IOC using DI:

1. Why EmployeeService class object is created by EmployeeController class?(again Tight coupling)

sol. dotnet core supports instance management-
     a. add transient (per call - it means, for every request a new object will be created. Better for performance.
                       Object should not persist for next request. New instance should be created for every new request.)
                       eg - Service layer which represents table operations will be based on per call. 
     b. add scope (New instance of EmployeeDBcontext should not be created for every request that hits the controller.)
                       eg - DBContext based inherited class (EmployeeDBcontext) should be based on Add scope.
     c. add singleton (Universal object)
                       eg - to handle the exception globally like logger (NLog package).

01/05/24

Practical implementation of Add Transient & Add Scope-

1. IOC of IEmployeeOperation & DI. 

     builder.Services.AddTransient<IEmployeeOperation, EmployeeService>(); 

02/05/24

Now we are implementing IOC using DI for EmployeeDBcontext-

eg of AddScoped - builder.Services.AddDbContext<EmployeeDBcontext>();  

08/05/24

limitations of this program-

     1. there is no DTO in this app.
     2. there is no automapper included in this app.
     3. no exception handling done.
     4. ***how to deploy this app on IIS server.

*What is DTO?

     1. DTO is a snapshot of any entity or also known as clone i.e. we should not expose our actual entity or model to controller.
     2. I want to post data in 3 tables

a. What is projection query?
 where to apply - I want to fetch certain columns of DB table.
b. why DTO?
     To perform projection query(fetching selected columns from one or multiple tables) we use DTOs.

c. **What are the limitations of DTO?
     Automapper

09/05/24

Implementation on DTO & Automapper

now we have applied DTO, but limitation of DTO is if  we have more no. of properties in a model and assigning in a bitwise operator is a time consuming process.
this is the reason, we need to apply design pattern(automapper) to prevent from explicit mapping from one object to another.

Q. What are the steps to implement automapper in .net core?
     1. Install the automapper package from nuget.
     2. Configure the automapper package in program.cs using builder object.
     3. Create Mapper folder and provide the cs file(EmployeeMapper.cs)
     4. Profile is a root class in automapper namespace carrying CreateMap function.
     5. When properties names are different and no. of properties mismatch then we have to use forMember function
     6. no we apply DI for automapper package.

Q. ForMember is a function of Profile class for explicit mapping when properties name differ in source and destination 


14/05/24

Finally we have registered the Automapper in program.cs file.(IOC)

Now we have to apply DI for automapper in controller.

Now we will start-
     Relationship,  

     so far we have run the dotnet core for basic pratice and achieve major topic 
     automapper
     2.IOC
     3.DI
     4.code first approach migration
     5.DTO mapping with automapper