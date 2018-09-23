# KISS Banking
Keep It Simple Stupid Banking, I named it this because I wanted to remind myself to not overcomplicate anything.

# My thoughts - The Plan

Starting this project off, I know I am going to be doing the web UI and console app. 
I also decided that I am going to emulate the way a system like this would be implemented. 
So, the structure is going to consist of a RESTful API, using ASP .NET with the two client apps, the Web UI using VueJS and a command line client using C# .NET. 
I am going to use VueJS because I have used it previously and want to learn more about it and it seemed like a good fit. 
I am going to use a template for ASP .Net and VueJS to hit the ground running and BootStrap components to make things look better with little effort. 
The database will be represented a lot like a normal one would be in a ASP .NET project, a singelton is added to the ASP .NET service and a instance is set in the constructor of the controllers that need access.  

For the Console App I am going to use HTTP request to get JSON reponses from ASP .NET and serialize those JSON responses back to their objects, this means that the web frontend and Console Apps both rely on the ASP .NET backend. 
With this setup, both views should be accessible at the same time as well as accounts.
With both Frontends using one backend, testing will be done on the API routes and responses depending on what's currently in the "database".
The views will handle validation with forms and making sure input is valid, the backend will make sure no invalid data or duplicate data is inserted.

## Structure
* RESTful API using ASP.NET MVC 
* VueJS Website hosted with the REST API
* Console App that can use HTTP calls on the REST API with MVP
* Unit Testing for REST API Controllers
* Unit Testing for Console App for View calls


## Schedule
I work 10 hours Monday - Thursday, I have about 4 - 3 hours avaliable those days and then Friday - Sunday

Tuesday(Night) | Wednesday(Night) | Thursday(Night) | Friday | Saturday
------------ | ------------- | ------------- | ------------- | -------------
ASP.NET/VueJS Setup  | Controllers | VueJS | Console APP | Unit Test


# Finished Product
Overall, I am pretty satisfied as to how this turned out. The only thing that was unsatisfactory was the testing for the Console App and the lack of controller over what the Model data started with without adding additional options for the constructor and making the class public.

## Deployment


### Development Environment
Web

1. Open KISSBanking.API project in Visual Studio or Visual Studio Code
2. Ctrl + F5 to build and run the REST API
3. Your default browser should open to the default page 

Console App

1. First make sure that the steps for deploying the Web environment has been followed
2. Open KISSBanking.Console project in Visual Studio or Visual Studio Code
3. Ctrl + F5 to build and run the Console App

### Production Environment
1. Unzip KISSBanking.zip
2. Run exe shortcuts for the API and Console App
