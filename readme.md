# A simple API service for schedule automation

Phoenix is a medical automation complex that is used in some local clinics (dental mostly). It is a desktop network-based application written in Visual FoxPro, so it's based on the FoxPro database.
The task was to integrate this application with the smart voice service to automate the process of the appointment booking, so the patient calls a certain phone number and makes an appointment using a voice robot. The profit of such automation is in a decrease of a clinic reception load. This is the basic scenario, and there are some more - such as automatic appointment confirmation, audio questionary generation and some other stuff.

## Phoenix Schedule Service

All of the actual voice automation was of course made by the third-party service and the actual business logic stays within the Phoenix application, this particular application just provides the connection point between the two of them.
This project was actually an act of charity to my first employer, so it was made in free time and took about a week to complete.
