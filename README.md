# Maintain.NET

## Overview

### Deployed Site
https://maintainnet.azurewebsites.net/

## Example Usage

## User Stories

### User Story 1 - Landing Page

#### Features
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

#### Acceptance Criteria

* Ensure that user always is directed to the landing page upon opening of the application.

* Ensure there are registration and login options 

### User Story 2 - User Dashboard

#### Features 

- Task links that redirect to task completion page

- Drop down menu containing task options
  - Change Oil
  - Water plants
  - Clean fish tank

#### Acceptance Criteria

* User will be directed to user dashboard after login.

* User have the ability to navigate to task history.

### User Story 3 - Task Management

#### Features

- Delete button for each task 
  - Add prompt to confirm deletion

- Add new task button

#### Acceptance Criteria

* The delete button will delete the instance of the a task.

* Add task will create a new instance of a task based on drop down menu.

### User Story 4 - Task Completion Page

#### Features 

- Complete task button submits data to task database

- Display a table of task completion history

#### Acceptance

* Ensure that user will be able to view their last 5 completed task submissions.

* Ensure that "Complete" button allow users to submit data and update history.

### User Story 5 - Task Reminders/Recommendations

#### Features

- Use Microsoft Sendgrid to send reminder emails based on set intervals  

- Utilize machine learning data to recommend task completion time on dashboard. 

#### Acceptance Criteria

* Receive an email from our service notifying user that their scheduled task is due.

* Provide the user with a suggested interval to complete the selected task.  

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
  


