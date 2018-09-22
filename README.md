# My thoughts and reasons

Starting this project off, I knew I was going to be doing the web UI and console app. 
I also decided that I was going to emulate the way a system like this would be implemented. 
So, the structure was going to consit of a RESTful API, using ASP .NET with the two client apps, the Web UI using VueJS and a commandline client using C# .NET. 
I am going to use VueJS because I have used it previously and want to learn more about it and it seemed like a good fit. 
I am going to use a template for ASP .Net and VueJS to hit the ground running and BootStrap components to make things look better with little effort. 
The database was to represented a lot like a normal one would be in a ASP .NET project, a singelton is added to the ASP .NET service and a instance is set in the contructor of the controllers that need access.  
For  the Console App I am going to use HTTP request to get JSON reponses from ASP .NET and serialize those JSON responses back to their objects, this means that the web frontend and Console Apps both rely on the ASP .NET backend. 
With this setup, both views should be accessible at the same time as well as accounts.
With both Frontends using one backend, testing will be done on the API routes and responses depending on what's currently in the "database".
The views will handle validation with forms and making sure input is valid, the backend will make sure no invalid data or duplicate data is inserted.
