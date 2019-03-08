# Maintain.NET

## Overview

### Deployed Site
https://####.azurewebsites.net/

## Example Usage


## User Stories

### User Story 1 - Landing Page.

#### Features

* As a user I would like an informative landing page with register and login options

* The user will be informed about the purpose and usage of the site.  Register and Login buttons will redirect to separate pages.  
#### Acceptance Criteria

* Ensure that user always is directed to the landing page upon opening of the application.

* Ensure there are register and login options 

### User Story 2 - User Dashboard

#### Features 

* As a user, I would like to have access to a dashboard that allows me to view my tasks.

* The dashboard will contain a list of user tasks links that will link to task details page as well as link to manage tasks.

#### Acceptance Criteria

* User will be directed to user dashboard after login.

* User have the option to see tasks details.

* User will have a link to manage tasks.


### User Story 3 - Task Manager

#### Features

* As a user, I would like the ability to manage my tasks

* Upon selecting the manage link user will be directed to a task management page.  The user will have the ability to add new tasks and delete existing tasks.

#### Acceptance Criteria

* The delete option will delete the instance of the task.

* There will be a drop down menu containing maintenance task options.

* Add task will create a new instance of a task.


### User Story 4 - Task Completion Page

#### Features 

* As a user I would like to see my maintenance task history and have the ability to mark a task as completed.

* The user will be able to view a history of the last five of the completions of a specific task.  The user can also click the "complete" button to update task history and update universal data.


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
  Deziree Teague 
  Jason Few   
  Jason Hiskey https://github.com/jlhiskey  
  Ray Johnson 
  


