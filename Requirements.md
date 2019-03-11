# VISION

The vision of this product is to help users complete routine task for a variety of items . 

The pain point this project solves is to help users keep on schedule with taking care of routine task people often forget.

This product introduces machine learning and allows users to contribute to a network of a self improving maintenance tracking.

# SCOPE

This project WILL...

* Allow a user to create a profile and sign in  
* Allow a user to select the task they would like track
* Allow a user to record when they conduct a specific task
* Allow a user to view their past maintenance/task 
* Provide user with recommendations based on complied data.
* App will predict future maintenance needs

This project WILL NOT...

* Provide health or fitness recommendations based on machine learning data.

# GOALS
## MVP 

1. Login and registration
2. Tracking of a single object
3. Manage tasks
4. Email Reminders
5. Machine Learning Based Recommendations

## Stretch Goals

1. QR Code
2. Amazon dash button
3. User ability to create a new task

#FUNCTIONAL REQUIREMENTS

* User can create an account and log in 
* User can view all maintenance tasks
* User can add and delete tasks
* User can view task history
* User can make submissions to database

#NON-FUNCTIONAL REQUIREMENTS

1. Testability: Tests will be consistent, unambiguous, quantitative, and verifiable in practice. Each test will only have one assertion and will only test a singluar method.

Testing will include:
- Models 
    - Getters
    - Setters
    - Nav Props
- Services
    - All methods

- Test Coverage: 
    - Minimum Test Coverage: 70%

2. Security: Security measures include user authorization and access control.

#DATA FLOW

When a user lands on our site, they are introduced to the maintenance task tracking service and given the option to either register or login.  On the registration page, the user must input their first name, last name, email, and password.  This information will be saved into a user identity database.  If an account has already been created, the user can log in using their email and password.  Upon login, the user will land on a dashboard which shows their personal tasks and allows them to select a new task to add to the list.  Users have the option to click an individual task that redirects to a completion page which outlines a history of completed tasks.  This completion page also allows a user to mark a task as complete which sends data to the external database that collects aggregate data from all users.  






