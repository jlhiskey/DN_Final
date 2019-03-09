# Maintain.NET

## Overview

### Deployed Site
https://####.azurewebsites.net/

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

* Display the last five completed task to user.

* "Complete" button allow users to submit data and update history.

### User Story 5 - Task Reminders/Recommendations

#### Features

* As a user I would like to receive email reminders and recommendation to complete a task.

* Email reminders will be generated based on set intervals and sent to the users. 

* Recommendations will be given for task intervals based on averages/seed data. 

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

![Db Schema](https://dev.azure.com/TeamRalph/7a0156dd-df26-431a-abd8-56ab70a7d6fa/_apis/git/repositories/02698f18-9781-4ce0-bd99-2358ab005d34/Items?path=%2Fassets%2FMaintainNETDBSchema.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=Friday-Prep&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)

## Wireframe
![Wireframe](https://dev.azure.com/TeamRalph/7a0156dd-df26-431a-abd8-56ab70a7d6fa/_apis/git/repositories/02698f18-9781-4ce0-bd99-2358ab005d34/Items?path=%2Fassets%2Fwf_landingpage.JPG&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=Friday-Prep&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)
![Wireframe](https://dev.azure.com/TeamRalph/7a0156dd-df26-431a-abd8-56ab70a7d6fa/_apis/git/repositories/02698f18-9781-4ce0-bd99-2358ab005d34/Items?path=%2Fassets%2Fwf_registration.JPG&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=Friday-Prep&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)
![Wireframe](https://dev.azure.com/TeamRalph/7a0156dd-df26-431a-abd8-56ab70a7d6fa/_apis/git/repositories/02698f18-9781-4ce0-bd99-2358ab005d34/Items?path=%2Fassets%2Fwf_login.JPG&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=Friday-Prep&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)
![Wireframe](https://dev.azure.com/TeamRalph/7a0156dd-df26-431a-abd8-56ab70a7d6fa/_apis/git/repositories/02698f18-9781-4ce0-bd99-2358ab005d34/Items?path=%2Fassets%2Fwf_managetasks.JPG&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=Friday-Prep&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)
![Wireframe](https://dev.azure.com/TeamRalph/7a0156dd-df26-431a-abd8-56ab70a7d6fa/_apis/git/repositories/02698f18-9781-4ce0-bd99-2358ab005d34/Items?path=%2Fassets%2Fwf_completedtasks.JPG&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=Friday-Prep&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)


## Credit
  Deziree Teague 
  Jason Few   
  Jason Hiskey https://github.com/jlhiskey  
  Ray Johnson 
  


