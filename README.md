# OrangeEshop

# E-Shop Application

This project is a simple E-Shop application built with ASP.NET Core. It allows users to perform CRUD (Create, Read, Update, Delete) operations on Categories and Products. The project is structured using a layered architecture, separating concerns into Business Logic (BLL), Data Access (DAL), and UI layers.

## Features

- **CRUD Operations for Categories:**
  - Create new categories.
  - View a list of categories.
  - Update existing categories.
  - Delete categories.

- **CRUD Operations for Products:**
  - Create new products.
  - View a list of products.
  - Update existing products.
  - Delete products.

- **Association of Products with Categories:**
  - Each product is associated with a category.
  - Category selection is mandatory when creating or updating a product.

## Project Structure

- **UI (User Interface):**
  - ASP.NET Core MVC views for interacting with the application.
  - Bootstrap is used for styling and layout.

- **BLL (Business Logic Layer):**
  - Handles business rules, validations, and operations on entities.

- **DAL (Data Access Layer):**
  - Manages data retrieval and persistence using Entity Framework Core.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) or any preferred IDE
- SQL Server (or any compatible database engine)

### Setup

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/yourusername/your-repo-name.git
   cd your-repo-name
