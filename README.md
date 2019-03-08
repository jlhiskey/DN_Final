# Tracker.NET

## Overview

### Deployed Site
https://####.azurewebsites.net/

## Example Usage


## User Stories

### User Story 1 - As a user I would like to land on an informative landing page.

#### Features

* There will be a home page with a description of the application and some helpful hints about how to use it.

* I would like a navigation menu with register and login in links.
 
#### Acceptance Criteria

* Ensure that user always is directed to the landing page upon opening of the application.

* Ensure there is a navigation menu with links.

### User Story 2 - As a user I would like a user dashboard

#### Features 

* The dashboard will contain a list of user tasks links that will link to task details page.

* The dashboard will contain a link to manage tasks.

* The dashboard will contain link to logout 

#### Acceptance Criteria

* User will be directed to user dashboard after login.

* User have the option to see tasks details.

* User will have a link to manage tasks.

### User Story 3 As a user I would like the ability to manage my tasks

#### Features

* Upon selecting the manage link user will be directed to a manage page.

* The user will have the ability to delete a task.

* The user will have the ability to create a new task.

#### Acceptance Criteria

* The link to manage page will direct user to manage page.

* The delete option will delete the instance of the task.

* The create options will create a new instance of a task.

### User Story 4 - As a user I would like to see my maintenance history and ability to mark task complete

#### Features 

* We will create a way to provide the user with a history of the last five of the completed task.  

* We will also create a submit button to update task history and to update universal data.


#### Acceptance

* Display the last five completed task to user.

* Have a button on the task panel to allow users to complete the selected task.

### User Story 5 As a user I would like to have Reminder/Recommendation for task

#### Features

* We want to generate email reminders based on set intervals that are sent to the users. 

* We would also like to generate in-app recommendations for task intervals based on averages/seed data. 

#### Acceptance Criteria

* Receive an email from our service notifying user that their scheduled task is due.

* Provide the user with a suggested interval to complete the selected task. 



## Database Schema

There will be two databases for this project.  The first is the standard ASP.NET Core Identity database. The second will consist of of three tables, table one is the MaintenanceTaks table (Colulms: ID, Name, RecommendedInterval and MaintenanceDataID).  Table two the UserMaintenanceTask (Colulms: ID, FK UserID, FK MaintenanceTaksID, and ActualInterval).  The third table is the MaintenanceTaskData table (Colulms: ID, FK MaintenanceTaksID, FK UserMaintenanceTaskID and ActualInterval)
![Db Schema](assets/db_schema.png)

## Wireframe
![Wireframe](https://dev.azure.com/TeamRalph/7a0156dd-df26-431a-abd8-56ab70a7d6fa/_apis/git/repositories/02698f18-9781-4ce0-bd99-2358ab005d34/Items?path=%2Fassets%2Fwf_landingpage.JPG&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=Friday-Prep&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)
![Wireframe](https://dev.azure.com/TeamRalph/7a0156dd-df26-431a-abd8-56ab70a7d6fa/_apis/git/repositories/02698f18-9781-4ce0-bd99-2358ab005d34/Items?path=%2Fassets%2Fwf_registration.JPG&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=Friday-Prep&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)
![Wireframe](https://dev.azure.com/TeamRalph/7a0156dd-df26-431a-abd8-56ab70a7d6fa/_apis/git/repositories/02698f18-9781-4ce0-bd99-2358ab005d34/Items?path=%2Fassets%2Fwf_login.JPG&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=Friday-Prep&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)
![Wireframe](https://dev.azure.com/TeamRalph/7a0156dd-df26-431a-abd8-56ab70a7d6fa/_apis/git/repositories/02698f18-9781-4ce0-bd99-2358ab005d34/Items?path=%2Fassets%2Fwf_userdashboard.JPG&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=Friday-Prep&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)
![Wireframe](https://dev.azure.com/TeamRalph/7a0156dd-df26-431a-abd8-56ab70a7d6fa/_apis/git/repositories/02698f18-9781-4ce0-bd99-2358ab005d34/Items?path=%2Fassets%2Fwf_managetasks.JPG&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=Friday-Prep&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)
![Wireframe](https://dev.azure.com/TeamRalph/7a0156dd-df26-431a-abd8-56ab70a7d6fa/_apis/git/repositories/02698f18-9781-4ce0-bd99-2358ab005d34/Items?path=%2Fassets%2Fwf_completedtasks.JPG&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=Friday-Prep&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)


## Credit
  Jason Few   
  Jason Hiskey https://github.com/jlhiskey  
  Ray Johnson 
  Deziree Teague 


