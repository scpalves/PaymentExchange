# PaymentExchange
Post Operation Step- Information for the tests
 
 The tests should be made with example Schema as you can see in below:  
 Only three fields have to be insert manually with information
 "clientName": "string",     -Insert the name of the client
 "invoiceTotalEarnings": 0,  -Insert the Bill value
 "clientPayment": 0,         -Insert the cliente Bill value payment (This value have to be bigger than previous Bill value field
 To get the exchange value, calculated by application. All other fields are calculated fields by program
 
 POST / Todo  - Example Schema for the tests
       {
        "clientName": "Rui",
        "invoiceTotalEarnings": 10,
         "clientPayment": 70,
         "invoiceLines": []
       }
