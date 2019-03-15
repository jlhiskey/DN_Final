# Maintain.NET

## Deployed Site
https://maintainnet.azurewebsites.net/

## Overview
Maintain.Net utilizes machine learning to help people stay on schedule with routine maintenance tasks.  Users will receive email reminders prompting the completion of a specific task according to its due date. 
The app determines the intervals at which the task will need to be completed based individual data input as well as input from other users doing the same task. 

## Languages Used
- C#
- HTML
- CSS

## Tools Used
- ML net
- Sendgrid
- ASP.NET Core MVC
- SQL Database
- Entity Framework Core
- Microsoft Identity
- Azure DevOps
- Visual Studio

## Data Flow
- When a user lands on our site, they are introduced to the maintenance task tracking service and given the option to either register or login.  
- On the registration page, the user must input their first name, last name, email, and password.  
- This information will be saved into a user identity database.  
- If an account has already been created, the user can log in using their email and password.  
- Upon login, the user will land on a dashboard which shows their personal tasks and allows them to select a new task to add to the list.  
- Users have the option to click an individual task that redirects to a completion page which outlines a history of completed tasks.  
- This completion page also allows a user to mark a task as complete which sends data to the external database that collects aggregate data from all users.  

## Getting Started

- Clone the repository in to your local  machine.
- Add migration for MaintainDbContext
- Add migration to IdentityMaintainDbContext
- Update database for MaintainDbContext
- Update database for IdentityMaintainDbContext
- Run the application

### Features
- Site Introduction Statement

- Registration form 
  - First name
  - Last name
  - Zip code
  - Email
  - Password
  - Password confirmation
  - Register button

- User login form
  - Email
  - Password
  - Login button
 

## Database Schema
- There will be two databases for this project.  
  - The first is the standard ASP.NET Core Identity database 
    - Database Name: IdentityContextDB 
    - Table: User
      - UserID/Email string (Primary Key)
      - First string
      - Last string
      - Zipcode int
  - The second database will be the main application database.
    - Database Name: MaintainContextDB
    - Table: UserMaintainenceTask
      - UserID string (Composite Key)
      - MaintainenceTaskID int (Composite Key)
      - LastComplete int
      - Navagation Properties
        - MaintainenceTask
        - User
        - ICollection<MaintenanceTaskData>
    - Table: MaintainenceTask
      - ID int (Primary Key)
      - Name string
      - RecommendedInterval int
      - Navagation Properties
        - ICollection<MaintenanceTaskData>
    - Table: MaintainenceTaskData
      - MaintainenceTaskID int (Foreign Key)
      - UserMaintenanceTaskID int 
      - ActualInterval int

![Db Schema](./assets/MaintainNETDBSchema.png)


## Wireframe
![Landing Wireframe](./assets/wf_landingpage.JPG)

![Registration Wireframe](./assets/wf_registration.JPG)

![Login Wireframe](./assets/wf_login.JPG)
![User Dashboard Wireframe](./assets/wf_userdashboard.JPG)
![Manage User Tasks Wireframe](./assets/wf_managetasks.JPG)
![Complete User Task](./assets/wf_completedtasks.JPG)


## Contributors
  Deziree Teague 
  
  Jason Few   
  
  Jason Hiskey https://github.com/jlhiskey  
  
  Ray Johnson 
  


