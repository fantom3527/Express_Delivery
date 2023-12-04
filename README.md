# Express_Delivery
Courier Delivery App.

Api functionality: 
1. Register an application for receipt and delivery of cargo (with the status "New").
2. Display the register of applications.
3. Find the application by the text entered in the field, the search principle is "across all fields".
4. Submit the request for execution (the executors are couriers).
5. Edit the request. At the same time, editing implies:
  5.1. Editing data fields is allowed only if the application is in the "New" status
  5.2. Transferring the application to the "Submitted for execution" status
  5.3. Transferring the application to the "Completed" status
  5.4. Transferring the application to the "Canceled" status with a comment on the reason for cancellation
6. Add the cargo to the application.
7. Delete the application
