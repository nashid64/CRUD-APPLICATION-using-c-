# CRUD APPLICATION using C#

# Student Information CRUD application

## Project Overview
This project demonstrates how to implement CRUD (Create, Read, Update, Delete) operations using C# and SQL Server within a Windows Forms Application. It provides a user-friendly interface for managing student records.

## Table of Contents

## Technologies Used
- **C#**: Core programming language
- **.NET Framework/Core**: Application framework
- **Entity Framework**: ORM for database access
- **SQL Server** or **SQLite**: Database (choose one based on my project)
- **Visual Studio**: IDE for development

  ### Prerequisites

- Visual Studio 2022 or later
- SQL Server 
- SQL Server Management Studio


  ## Features

- **Add New User**: Users can input details such as `ID`, `Name`, and `Age`. When the "Insert" button is clicked, the new user details is added to the list and the database.
  
- **View/Show Student Information**: The application displays all the records in a grid format, showing the ID, name, and age.

- **Update Information**: Users can select an existing user from the grid and update their details using the "Update" button. This will modify the selected user's information in the database.

- **Delete Records**: Select an user from the grid and click the "Delete" button to remove their record from the system.


-  **Schema Diagram:**



  ![Screenshot 2024-09-23 233920](https://github.com/user-attachments/assets/21cd63ba-7b83-41ad-b452-243612ba1fef)


## Set Up SQL Server Database:
Open SQL Server Management Studio (SSMS) and connect to your SQL Server instance.

**Create the Database**:

- Open the `.sql` file located in folder.
    - Copy the queries from the `.sql` file and execute them in your new database to set up the schema and initial data.
    - Use `Ctrl+F` to search for `connectionString` within the project files.
        ```csharp
       string conString = "Data Source=DESKTOP-TCVB1HR;Initial Catalog=CRUD;Integrated Security=True;TrustServerCertificate=True";;
    - Update this to:
        ```csharp
        string conString = "Server=<YOUR DATABASE SERVER/SOURCE>;Initial Catalog=<DATABASENAME>;Integrated Security=True;TrustServerCertificate=True";
        
        
**Create a Table for Student Information:**

CREATE TABLE Students (

    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) L,
    Age FLOAT
);
GO

This table will store Id, Name, and Age.

**Create a C# Windows Forms Application:**

- Open Visual Studio.

**Create a New Project:**
- Select C# > Windows Forms App (.NET Framework).
- Choose a project name and location.

**Design Your Form:**
- Add text boxes for Id, Name, and Age.
- Add buttons for Insert, Update, Delete, and Show.
- Add a DataGridView to display records.

**Add SQL Server Connection:**
To connect your application to the SQL Server database, you need to configure a connection string.

**Install SQL Server NuGet Package (optional if not already available):**

- In Solution Explorer, right-click on the project and select Manage NuGet Packages.
- Search for System.Data.SqlClient and install it.

**Set up the Connection String in your C# code:**
In your code-behind file (e.g., Form1.cs), define the connection string:

- string connectionString = "Data Source=YOUR_SERVER_NAME;Initial Catalog=CRUD;Integrated Security=True;";
- Replace (YOUR_SERVER_NAME) with the actual name of your SQL Server (you can find this in SSMS).

### C# Code Implementation
#### insert data function sample
```csharp 
 private void button1_Click(object sender, EventArgs e)
 {
     SqlConnection con = new SqlConnection(conString);
     con.Open();
     SqlCommand cmd = new SqlCommand("INSERT INTO CRUDTable(id, name, age) VALUES(@id, @name, @age)", con);
     cmd.Parameters.AddWithValue("@id", int.Parse(IDTABLE.Text));
     cmd.Parameters.AddWithValue("@name", NAMETABLE.Text);
     cmd.Parameters.AddWithValue("@age", double.Parse(AGETABLE.Text));
     cmd.ExecuteNonQuery();
     con.Close();

     MessageBox.Show("Inserted Successfully ");
 }
```
#### Update data function sample
```csharp 
  private void button3_Click(object sender, EventArgs e)
 {
     SqlConnection con = new SqlConnection(conString);
     con.Open();
     SqlCommand cmd = new SqlCommand("UPDATE CRUDTable SET name=@name, age=@age WHERE id=@id", con);
     cmd.Parameters.AddWithValue("@id", int.Parse(IDTABLE.Text));
     cmd.Parameters.AddWithValue("@name", NAMETABLE.Text);
     cmd.Parameters.AddWithValue("@age", double.Parse(AGETABLE.Text));
     cmd.ExecuteNonQuery();
     con.Close();

     MessageBox.Show("Updated Successfully");

```
**Delete Operation**
```csharp 
 private void button2_Click(object sender, EventArgs e)
 {
     SqlConnection con = new SqlConnection(conString);
     con.Open();
     SqlCommand cmd = new SqlCommand("DELETE CRUDTable WHERE id=@id", con);
     cmd.Parameters.AddWithValue("@id", int.Parse(IDTABLE.Text));
     cmd.ExecuteNonQuery();
     con.Close();

     MessageBox.Show("Deleted Successfully");
 }
```
**Show**
```csharp 
 private void button4_Click(object sender, EventArgs e)
 {
     SqlConnection con = new SqlConnection("Data Source=DESKTOP-JELVURO;Initial Catalog=CRUD_OPERATION;Integrated Security=True");
     con.Open();
     SqlCommand cmd = new SqlCommand($"select * from ut where id like {textBox1.Text.Trim()}" , con);
     SqlDataAdapter da   = new SqlDataAdapter(cmd);
     DataTable dt=new DataTable();
     da.Fill(dt);
     dataGridView1.DataSource = dt;
     
 }
```
**Load Data into DataGridView**
Call this method in the form's Load event to display the data when the application starts.
```csharp 
 private void button4_Click(object sender, EventArgs e)
 {

     SqlConnection con = new SqlConnection(conString);
     con.Open();
     SqlCommand cmd = new SqlCommand("SELECT * FROM CRUDTable WHERE id=@id", con);
     cmd.Parameters.AddWithValue("@id", int.Parse(IDTABLE.Text));
     SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
     DataTable data = new DataTable();
     dataAdapter.Fill(data);
     dataGridView1.DataSource = data;
 }
```
## Screenshots
Below is a screenshot of the application interface showing the CRUD operation functionality:
![Screenshot 2024-09-23 235610](https://github.com/user-attachments/assets/eb223ba7-4a3a-416b-a8c0-f49aa5a42646)

### Event Handling
- Implement event handlers for each button (e.g., `Create`, `Edit`, `Delete`).
- When a button is clicked, the corresponding CRUD operation will be executed (e.g., creating a new record or deleting an existing one).

## User Flow
1. When the application is opened, existing records are displayed in the `DataGridView`.
2. Users can:
   - **Insert**: new records by clicking the "Insert" button and submitting the form.
   - **Delete**: records by selecting a row and confirming deletion.
   - **Update**: user can update any data from data grid view.

## Challenges and Considerations
- **Error Handling**: Implement error handling for database connection failures or invalid inputs.

## **Build and Run the Application**:
    Open the project in Visual Studio, build it, and run the application.

## How to Run the Project
1. **Clone the Repository**: Download this repository to your local machine..
   ```bash
   git clone https://github.com/nashid64/CRUD-APPLICATION-using-c-.git
   ```
2. **Set Up the Database**: Configure your SQL Server database and modify the connection settings as specified in the `script.sql` file.
3. **Build the Project**: Launch the project in Visual Studio and compile the solution.
4. **Run the Application**: After compiling, execute the application to manage records using the Windows Forms interface.



