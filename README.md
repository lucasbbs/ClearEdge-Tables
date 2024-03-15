# Web Application Security Course Project: ClearEdge Tables eCommerce App

Welcome to the ClearEdge Tables eCommerce app developed as part of the Web Application Security course. This project focuses on the security aspects of developing an eCommerce platform specifically tailored for selling tables.

## Introduction

The ClearEdge Tables eCommerce app is designed to provide a secure platform for users to browse, select, and purchase tables. It incorporates various security measures to protect user data and ensure secure transactions.

## Features

- User authentication and authorization.
- Browse and search for tables by category, price, etc.
- Add tables to the shopping cart and proceed to checkout.
- Secure payment processing with integration to a payment gateway. (TO-DO)
- View order history and track order status. (TO-DO)

## Entities

The app is built around five main entities:

1. **Tables**: Represents the tables available for purchase, including details such as name, description, price, and image.
2. **ShoppingCarts**: Stores the items added by customers for purchase.
3. **Customers**: Represents the users of the app, including their personal information and login credentials.
4. **Orders**: Contains information about customer orders, such as order date, total amount, and shipping details.
5. **OrderDetails**: Provides a detailed view of each item in an order, including quantity, price.

![](https://app.eraser.io/workspace/miYqFbDtNhCMZhvRNFQ9/preview?elements=DvGmzJYoAyn4iYD79lclyg&type=embed)

## Installation

(TO-DO)

## Configuration

(TO-DO)

## Usage

- Register an account, login, and browse the available tables.
- Add desired tables to the shopping cart and proceed to checkout.
- Complete the checkout process.

## Authorization and Authentication
- As for the authorization for admin users: to register a table, you should be authenticated as an admin, which involves verifying your identity through the app's authentication system. Currently, there is only one admin user in the app. Although it is possible to create more than one, this feature has not yet been implemented.
- As for the authorization for customer users: You can browse the products, but to add them to the cart, as well as to check your cart, you should be authenticated through the app's authentication system. Normal users can be created by following the standard registration process, which involves verifying user credentials and granting access based on authentication tokens or session management.

## Security Measures Implemented

(TO-DO)

## Testing

(TO-DO)

## Deployment

(TO-DO)

## Red Team vs Blue Team Exercise

(TO-DO)

## References

For further reading on web application security principles and practices, refer to the following resources:
- [OWASP Top Ten](https://owasp.org/www-project-top-ten/)
- [Web Security Academy](https://portswigger.net/web-security)
- [Microsoft Security Development Lifecycle (SDL)](https://www.microsoft.com/en-us/securityengineering/sdl)

