# Introduction
This REST API will allow the website and desktop software for the Hotel Management System (HMS) to communicate back to the database while having less client side code to retrieve the information needed.

# API Endpoint
> http://guestbook.eastus.cloudapp.azure.com/GuestBook/RestServiceImpl.svc/

# Content Types
You can POST data using:
> Content-Type: application/json

# Authentication
For each GET and POST request a valid token must be supplied. The token consists of a 32 alphanumeric characters. If a new token is needed one must request a temporary token which you will receive a link in your email and once navigated to the provided link a real token may be generated.

# HTTP Status Codes
* 200 - OK
* 201 - Created
* 204 - No Content
* 400 - Bad Request
* 401 - Unauthorized
* 404 - Not Found
* 405 - Method Not Allowed
* 409 - Conflict

# Resource Routes
### Rooms
`/rooms?token={token}`  
`/rooms/{room_number}?token={token}`

### Tokens
`/tokens/temporary`  
`/tokens/temporary?token={token}`

### Employees
`/employees?token={token}`  
`/employees/{id}?token={token}`  
`/employees/authenticate?token={token}`  
`/employees/create?token={token}`  
`/employees/check/username?token={token}`  
`/employees/check/email?token={token}`  
`/employees/create/resetkey?token={token}`  
`/employees/salt?token={token}`  


## Room Infomration
Rooms can not be created or deleted using this API. This is for safety and can only be done on initial deployment.

`/rooms?token={token}`  
`/rooms/{room_number}?token={token}`  

### Example Request (curl)
> curl -H "X-Pretty: true" http://guestbook.eastus.cloudapp.azure.com/GuestBook/RestServiceImpl.svc/rooms?token=68f2f755c5e1408fb4a1e3c39ba371b3

### Response
> {
    "room_number": "1",  
    "room_type": "Guest",  
    "max_occupancy": 10,  
    "last_cleaned": "2016-02-04T11: 07: 00",  
    "beds": 3  
  }
  
  
## Tokens
If you generate a temporary token by default, the token will expire in 30 minutes of being generated for security reasons.

`/tokens/temporary`  
`/tokens/create?token={token}`  


## Employees

`/employees?token={token}`  
`/employees/{id}?token={token}`  
`/employees/authenticate?token={token}`  
`/employees/create?token={token}`  
`/employees/check/username?token={token}`  
`/employees/check/email?token={token}`  
`/employees/create/resetkey?token={token}`  
`/employees/salt?token={token}`  

### /employees?token={token}
Returns JSON data of all employee objects.

### /employees/{id}?token={token}
Returns JSON object of employee with the corresponding id.

### /employees/authenticate?token={token}
Returns JSON object of employee if authenticated.  
If authentication fails, then HTTP Status Code 204 is thrown

### /employees/create?token=(toekn)
If employee is successfully created, then HTTP Status Code 201 is thrown.  
If employee creation fails, then HTTP Status Code 409 is thrown.