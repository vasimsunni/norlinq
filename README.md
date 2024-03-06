Introduction:

As my expertise is more in the backend, I have focused more on implementing the robust backend API, but I have developed the frontend by scaffolding the standard VueJs framework based project. I have used SQL Server as the local database provider.


API: This API is developed using the Core 7 framework. I have tried to add the minimal version to the software architecture following the SOLID principles to showcase my expertise. I have divided the API into three different parts: core, infrastructure, and services. The core performs database-related tasks using the context of the database. It includes DbContext, Entities, and a generic repository, which can be converted to an entity type to perform DML and DQL queries to the database. The infrastructure contains the implementation for the application configurations and DTOs, which can be used to set up the application features, data return types, etc. The services include a service (note service), which performs the business logic, and a reference to the core (IRepository<Note>) to pass the data-related jobs. The controller references the services to perform the business tasks and returns the result from the service method.

Vue: I have used the VueJs 3.4 framework with vue-cli and vint to scaffold the project architecture. I have followed the standard vue architecture and added views, components, etc. to it. I imported a few libraries to make the project robust. I have used fetch, perform, get, push, put, and delete API calls. I have created a .env file to add and access the environment variable throughout the Vue application.


SetUp Steps:

Backend
1) Create the database by running the script on SQL Server. The script is located at 'Backend/note-app-db-script.sql'.
2) Open the backend API solution from Backend/NoteApp/NoteApp.sln in Visual Studio.
3) Clean and build the code for the solution.
4) Update the connection string in the 'appsettings.json' file to your local database connection string.
5) Rebuild the project and run it in IISExpress with debug and mixed platform mode.
6) The swagger document should appear, and it will allow you to test the crud task on swagger.
7) Collect the base url of the API from the browser; this will be required to be added as the base url of the endpoint in the frontend application.

Frontend
1) Go to 'Frontend\note-app' and open the command prompt.
2) Install the required libraries using the 'npm install' command on the command prompt.
3) Update the environment variable 'VITE_API_URL' in the .env file located at the root of the project. The 'VITE_API_URL' is used to access the API base URL in the project. The 'VITE_API_URL' should look like 'VITE_API_URL="your_api_base_url/api/"' (e.g., VITE_API_URL="https://localhost:54321/api/"), save the file.
4) To run the application, go to the same command prompt and run the command 'npm run dev'. Once you run the command, it will give you a URL where the Vue application is hosted on localhost. Copy the URL and open it in the browser through the application.
5) You can perform the crud application on the website; make sure the APIs are running on the localhost.


Note: If the CORS Policy fails, edit the 'appsettings.json' in the 'Backend/NoteApp/' and change the 'CORS:EnabledUrl' with the localhost base url of the frontend website. Please make sure to remove '/' from the end of the url (e.g., "EnabledUrl": "https://localhost:54321").