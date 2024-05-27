# Joshua-POE-CLDV
Joshua John Pillai	ST10272691	CLDV-POE-PART2
KhumaloCraft E-Commerce Application
Description
KhumaloCraft is an artisanal e-commerce platform showcasing and selling handmade crafts. This web application allows users to browse various craft items, add them to a cart, and complete purchases through a checkout process. The application also includes user authentication, allowing users to register, log in, and manage their cart.
Features
•	Display a list of craft items
•	User authentication (registration and login)
•	Shopping cart functionality
•	Checkout process
•	Notification service using Azure Notification Hubs
Technologies Used
•	ASP.NET Core (Backend)
•	Entity Framework Core (Database ORM)
•	Microsoft SQL Server (Database)
•	Azure Notification Hubs (Notification Service)
•	HTML, CSS, JavaScript (Frontend)
Prerequisites
•	.NET Core SDK
•	SQL Server
•	Visual Studio or Visual Studio Code
•	Azure Subscription (for Notification Hubs)

Getting Started
1. Clone the Repository
Git Clone: https://github.com/Notz05/Joshua-POE-CLDV.git

2. Apply Migrations and Create the Database
Open the Package Manager Console in Visual Studio and run the following commands:
dotnet ef database update

3. Run the Application
In the terminal, run:
dotnet run

Usage
Adding Craft Items to the Database
To insert craft items into the database, open SQL Server Management Studio (SSMS) and execute the following SQL query: 
INSERT INTO Craftwork (Name, Description, Price, ImageUrl) 
VALUES
('Handmade Vase', 'A beautifully crafted vase.', 49.99, '/images/vase.jpg'),
('Knitted Scarf', 'A warm and cozy scarf.', 29.99, '/images/scarf.jpg');

Registering and Logging In
1.	Open the application in your browser.
2.	Navigate to the registration page and create a new account.
3.	Log in with your new account.
Adding Items to the Cart and Checking Out
1.	Browse the available craft items.
2.	Add items to your cart.
3.	Navigate to the cart page to review your items.
4.	Click the "Checkout" button to place your order.
Sending Notifications
To send notifications to users, make a POST request to the api/notifications/send endpoint with the following JSON body:

{
  "message": "Your custom notification message",
  "userTag": "user_tag"
}
 References: 
 Mrzyglod, K. (2022). Azure for Developers 2nd Edition. In K. Mrzyglod, Azure for Developers (p. 944). Birmingham: Pakt Publishing Ltd.
