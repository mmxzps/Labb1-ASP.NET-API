# Restaurant Booking API

This API manages reservations for a restaurant. It allows customers to book tables, and administrators to manage available tables, bookings and customers. The API is built with ASP.NET Core and uses a SQL Server database.

# EndPoints:

## Bookings
### <center>⏺️Show all bookings:<br>
* Method:   GET
* URL: ```/api/bookings/ShowAllBookings ```<br><br>

Request Body:
```
none
````
Output: 
```
[
  {
    "id": 5,
    "customerId": 1,
    "customerName": "Kalle Kaviar",
    "customerPhoneNumber": "0723456789",
    "amountGuest": 4,
    "bookingDate": "2024-09-02 19:00",
    "tableId": 1,
    "tableNumber": 1
  },
    "id": 6,
    "customerId": 4,
    "customerName": "Sven Ahl",
    "customerPhoneNumber": "0703456000",
    "amountGuest": 4,
    "bookingDate": "2024-09-02 21:00",
    "tableId": 2,
    "tableNumber": 2
  },
]
```
Responses:<br>
- 200 : *Success*<br>
- 404 : *Error = "No bookings found!"*

### <center>⏺️Get booking by Id:<br>
* Method:   GET
* URL: ```/api/bookings/GetBookingById/6 ```<br><br>

Request Body:
```
none
````
Output Body: 
```
[
    "id": 6,
    "customerId": 4,
    "customerName": "Sven Ahl",
    "customerPhoneNumber": "0703456000",
    "amountGuest": 4,
    "bookingDate": "2024-09-02 21:00",
    "tableId": 2,
    "tableNumber": 2
  },
]
```
Responses:<br>
- 200 OK: *Success*<br>
- 404 Bad Request: *Error = "No bookings with id.2 found!"*

### <center>⏺️Add booking:<br>
* Method:   POST
* URL: ```/api/bookings/AddBooking ```<br><br>

Request Body:
```
[
  {
    "firstName": "string",
    "lastName": "string",
    "phoneNumber": "2985295143",
    "amountGuest": 0,
    "bookingTime": "2024-09-01 20:54",
    "tableId": 0
  }
]
````
Output Body:
```
none
````
Responses:<br>
- 204 : *Success*<br>
- 409 : *Error = "Table 2 cant fit 6 guests."*
- 409 : *Error = "Table 1 is not available on 2024-09-01 20:00"*
- 400 : *Error = "Phone number must be 10 digits long."*   
- 400 : *Error = "Enter only digits."*

### <center>⏺️Edit booking:<br>
* Method:   PUT
* URL: ```/api/bookings/EditBooking/5 ```<br><br>

Request Body:
```
[
  {
    "customerId": 5,
    "amountGuest": 4,
    "bookingDate": "2024-09-01 22:00",
    "tableId": 1
  }
]
````
Output Body:
```
none
````
Responses:<br>
- 200 : *Success*<br>
- 409 : *Error = "Table 2 cant fit 6 guests."*
- 409 : *Error = "Table 1 is not available on 2024-09-01 20:00"*
- 400 : *Error = "Phone number must be 10 digits long."*   
- 400 : *Error = "No table with id.1 found!"*
- 400 : *Error = "No customer with id.2 found!"*

### <center>⏺️Add booking:<br>
* Method:   POST
* URL: ```/api/bookings/AddBooking ```<br><br>

Request Body:
```
[
  {
    "firstName": "string",
    "lastName": "string",
    "phoneNumber": "2985295143",
    "amountGuest": 0,
    "bookingTime": "2024-09-01 20:54",
    "tableId": 0
  }
]
````
Output Body:
```
none
````
Responses:<br>
- 204 : *Success*<br>
- 409 : *Error = "Table 2 cant fit 6 guests."*
- 409 : *Error = "Table 1 is not available on 2024-09-01 20:00"*
- 400 : *Error = "Phone number must be 10 digits long."*   
- 400 : *Error = "Enter only digits."*

### <center>⏺️Edit booking:<br>
* Method:   PUT
* URL: ```/api/bookings/DeleteBooking/5 ```<br><br>

Request Body:
```
none
````
Output Body:
```
none
````
Responses:<br>
- 200 : *Success*<br>
- 400 : *Error = "No customer with id.2 found!"*