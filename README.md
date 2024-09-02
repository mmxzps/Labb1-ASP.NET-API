# Restaurant Booking API

This API manages reservations for a restaurant. It allows customers to book tables, and administrators to manage available tables, bookings and customers. The API is built with ASP.NET Core and uses a SQL Server database.

# EndPoints:
  - [Bookings](#bookings)
  - [Customer](#customer)
  - [Menu](#menu)
  - [Tables](#tables)

<div align="center">
    
# Bookings

</div>

<table><tr><td>

<div align="center">

### ⏺️Show all bookings:<br>

</div>

* Method:   GET
* URL:  ```/api/bookings/ShowAllBookings ``` <br><br>

Request Body:
```json
none
````
Output: 
```json
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
  }
]
```

Responses:<br>
- 200 : *Success*<br>
- 404 : *Error = "No bookings found!"*

</td></tr></table>


<table><tr><td>

<div align="center">

### ⏺️Get booking by Id:<br>

</div>

* Method:   GET
* URL: ```/api/bookings/GetBookingById/6 ```<br><br>

Request Body:
```json
none
````
Output Body: 
```json
[
    "id": 6,
    "customerId": 4,
    "customerName": "Sven Ahl",
    "customerPhoneNumber": "0703456000",
    "amountGuest": 4,
    "bookingDate": "2024-09-02 21:00",
    "tableId": 2,
    "tableNumber": 2
  }
]
```
Responses:<br>
- 200 OK: *Success*<br>
- 404 Bad Request: *Error = "No bookings with id.2 found!"*

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Add booking:<br>

</div>

* Method:   POST
* URL: ```/api/bookings/AddBooking ```<br><br>

Request Body:
```json
[
  {
    "firstName": "Kalle",
    "lastName": "Kaviar",
    "phoneNumber": "2985295143",
    "amountGuest": 4,
    "bookingTime": "2024-09-01 20:00",
    "tableId": 2
  }
]
````
Output Body:
```json
none
````
Responses:<br>
- 204 : *Success*<br>
- 409 : *Error = "Table 2 cant fit 6 guests."*
- 409 : *Error = "Table 1 is not available on 2024-09-01 20:00"*
- 400 : *Error = "Phone number must be 10 digits long."*   
- 400 : *Error = "Enter only digits."*

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Edit booking:<br>

</div>

* Method:   PUT
* URL: ```/api/bookings/EditBooking/5 ```<br><br>

Request Body:
```json
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
```json
none
````
Responses:<br>
- 200 : *Success*<br>
- 409 : *Error = "Table 2 cant fit 6 guests."*
- 409 : *Error = "Table 1 is not available on 2024-09-01 20:00"*
- 400 : *Error = "Phone number must be 10 digits long."*   
- 400 : *Error = "No table with id.1 found!"*
- 400 : *Error = "No customer with id.2 found!"*

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Delete booking:<br>

</div>

* Method:   DELETE
* URL: ```/api/bookings/DeleteBooking/5 ```<br><br>

Request Body:
```json
none
````
Output Body:
```json
none
````
Responses:<br>
- 200 : *Success*<br>
- 400 : *Error = "No customer with id.2 found!"*

</td></tr></table>

----

  <div align="center">
    
# Customer

</div>

<table><tr><td>

<div align="center">

### ⏺️Get all customers:<br>

</div>

* Method:   GET
* URL: ```/api/customers/GetAllCustomers ```<br><br>

Request Body:
```json
none
````
Output Body:
```json
[
  {
    "id": 3,
    "firstName": "Kalle",
    "lastName": "Kaviar",
    "phoneNumber": "8134087882"
  },
  {
    "id": 4,
    "firstName": "Lina",
    "lastName": "Larsson",
    "phoneNumber": "2985295143"
  }
]
````
Responses:<br>
- 200 : *Success*<br> 
- 400 : *Error = "No customers found!"*

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Get customers with Id:<br>

</div>

* Method:   GET
* URL: ```/api/customers/GetCustomersById/3 ```<br><br>

Request Body:
```json
none
````
Output Body:
```json
  {
    "id": 3,
    "firstName": "Kalle",
    "lastName": "Kaviar",
    "phoneNumber": "8134087882"
  }
````
Responses:<br>
- 200 : *Success*<br> 
- 400 : *Error = "No customer found!"*

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Get customers with phone number:<br>

</div>

* Method:   GET
* URL: ```/api/customers/GetCustomersByPhoneNumber/8134087882 ```<br><br>

Request Body:
```json
none
````
Output Body:
```json
  {
    "id": 3,
    "firstName": "Kalle",
    "lastName": "Kaviar",
    "phoneNumber": "8134087882"
  }
````
Responses:<br>
- 200 : *Success*<br> 
- 400 : *Error = "No customers found!"*

</td></tr></table>

<table><tr><td>
  
<div align="center">

### ⏺️Add customers:<br>

</div>

* Method:   POST
* URL: ```/api/customers/AddCustomer ```<br><br>

Request Body:
```json
{
  "firstName": "John",
  "lastName": "Hellman",
  "phoneNumber": "1883258667"
}
````
Output Body:
```json
 none
````
Responses:<br>
- 200 : *Success*<br> 
- 400 : *Error = "Name field is required and must be a string with a minimum length of 2 and a maximum length of 30."*
- 400 : *Error = "PhoneNumber field is required and must be 10 digits long."*

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Edit customers:<br>

</div>

* Method:   PUT
* URL: ```/api/customers/EditCustomer/5 ```<br><br>

Request Body:
```json
{
  "firstName": "Johnny",
  "lastName": "Hellman",
  "phoneNumber": "1883258667"
}
````
Output Body:
```json
 none
````
Responses:<br>
- 200 : *Success*<br> 
- 400 : *Error = "Name field is required and must be a string with a minimum length of 2 and a maximum length of 30."*
- 400 : *Error = "PhoneNumber field is required and must be 10 digits long."*
- 400 : *Error = "Given customerId doesnt exist."*
- 400 : *Error = "This number is already connected to a customer"*

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Delete customers:<br>

</div>

* Method:   DELETE
* URL: ```/api/customers/DeleteCustomer/5 ```<br><br>

Request Body:
```json
none
````
Output Body:
```json
 none
````
Responses:<br>
- 200 : *Success*<br> 
- 400 : *Error = "Given customerId doesnt exist."*

</td></tr></table>

----

<div align="center">
    
# Menu

</div>

<table><tr><td>

<div align="center">

### ⏺️Get all menu items:<br>

</div>

* Method:   GET
* URL: ```/api/Menu/GetAllMenuItems ```<br><br>

Request Body:
```json
none
````
Output Body:
```json
[
  {
    "id": 1,
    "foodName": "Kebabpizza",
    "price": 180,
    "isAvailable": false
  },
  {
    "id": 2,
    "foodName": "Pad Thai",
    "price": 120,
    "isAvailable": true
  }
]
````
Responses:<br>
- 200 : *Success*<br> 
- 400 : *Error = "No items found!"*

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Get menu item with Id:<br>

</div>

* Method:   GET
* URL: ```/api/Menu/GetAllMenuItemById/1```<br><br>

Request Body:
```json
none
````
Output Body:
```json
  {
    "id": 1,
    "foodName": "Kebabpizza",
    "price": 180,
    "isAvailable": false
  }
````
Responses:<br>
- 200 : *Success*<br> 

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Add menu item: <br>

</div>

* Method:   POST
* URL: ```/api/Menu/AddMenuItem```<br><br>

Request Body:
```json
  {
    "foodName": "Kebabpizza",
    "price": 180,
    "isAvailable": true
  }
````
Output Body:
```json
none
````
Responses:<br>
- 200 : *Success*<br> 

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Edit menu item: <br>

</div>

* Method:   PUT
* URL: ```/api/Menu/EditMenuItem/1```<br><br>

Request Body:
```json
  {
    "foodName": "Kebabpizza",
    "price": 110,
    "isAvailable": true
  }
````
Output Body:
```json
none
````
Responses:<br>
- 200 : *Success*<br> 

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Delete menu item: <br>

</div>

* Method:   DELETE
* URL: ```/api/Menu/DeleteMenuItem/1```<br><br>

Request Body:
```json
none
````
Output Body:
```json
none
````
Responses:<br>
- 200 : *Success*<br> 

</td></tr></table>

------

<div align="center">
    
# Tables

</div>

<table><tr><td>

<div align="center">

### ⏺️Get all tables:<br>

</div>

* Method:   GET
* URL: ```/api/Table/GetAllTables ```<br><br>

Request Body:
```json
none
````
Output Body:
```json
[
  {
    "id": 1,
    "tableNumber": 1,
    "tableSeats": 4
  },
  {
    "id": 2,
    "tableNumber": 2,
    "tableSeats": 4
  }
]
````
Responses:<br>
- 200 : *Success*<br> 
- 400 : *Error = "No items found!"*

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Get tables by Id:<br>

</div>

* Method:   GET
* URL: ```/api/Table/GetTablesById/1 ```<br><br>

Request Body:
```json
none
````
Output Body:
```json
  {
    "id": 1,
    "tableNumber": 1,
    "tableSeats": 4
  }
````
Responses:<br>
- 200 : *Success*<br> 
- 400 : *Error = "No items found!"*

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Add table:<br>

</div>

* Method:   POST
* URL: ```/api/Table/AddTable ```<br><br>

Request Body:
```json
  {
    "tableNumber": 10,
    "tableSeats": 4
  }
````
Output Body:
```json
none
````
Responses:<br>
- 200 : *Success*<br> 
- 400 : *Error = "No items found!"*

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Edit table:<br>

</div>

* Method:   PUT
* URL: ```/api/Table/EditTable/1 ```<br><br>

Request Body:
```json
  {
    "tableNumber": 1,
    "tableSeats": 6
  }
````
Output Body:
```json
none
````
Responses:<br>
- 200 : *Success*<br> 
- 400 : *Error = "No items found!"*

</td></tr></table>

<table><tr><td>

<div align="center">

### ⏺️Delete table:<br>

</div>

* Method:   DELETE
* URL: ```/api/Table/DeleteTable/1 ```<br><br>

Request Body:
```json
none
````
Output Body:
```json
none
````
Responses:<br>
- 200 : *Success*<br> 
- 400 : *Error = "No items found!"*

</td></tr></table>

