"# DVLD-Project" 
🚦 DVLD Smart Driving Licenses Management System
The Ultimate Software Solution for Licensing & Testing Operations in Traffic Departments 🚗💡
A comprehensive training project developed as part of Course 19 (Full Real Project) from Dr. Abu Hadhoud’s roadmap.
This system simulates real-world driver and vehicle licensing operations, focusing on software engineering, systems analysis, and database design.

🧰 Technologies Used
C# - Windows Forms (WinForms)
SQL Server
ADO.NET
3-Tier Architecture (Presentation - Business Logic - Data Access)
OOP: Events, Delegates, Composition
🧾 System Overview
DVLD offers a wide range of services related to driving licenses, relying on a central database to organize driver, application, exam, and license information.
The system is designed to reflect real workflows in traffic departments, with future scalability in mind.

🧩 Key Features
📄 Supported Applications
Service	Application Fee
First-time License Issuance	$5
Re-examination	$5
License Renewal	$5
Lost License Replacement	$5
Damaged License Replacement	$5
License Release (from hold)	$5
International License Issuance	$5
Notes:

Exam and license fees are added to the application fee.
Duplicate applications of the same type are not allowed if a previous one is still pending.
🧑‍💼 Applicant Information
National ID (primary & unique)
Full Name
Date of Birth
Address
Phone Number
Email
Nationality
Personal Photo
🪪 License Categories
Category	Description	Minimum Age	License Fee	Validity
1	Small Motorcycles	18	$15	5 years
2	Heavy Motorcycles	21	$30	5 years
3	Light Vehicles / Cars	18	$20	10 years
4	Taxis / Limousines	21	$200	10 years
5	Agricultural Vehicles	21	$50	10 years
6	Small & Medium Buses	21	$250	10 years
7	Trucks & Heavy Vehicles	21	$300	10 years
🧪 License Exams
Vision Test: $10
Theory Test: $20 (graded out of 100)
Practical Test: Fee depends on category
Applicants cannot proceed to the next exam without passing the previous one.
All results and appointments are recorded in the database.

📋 Additional Services
International License Issuance:
Only available for holders of an active, unheld Category 3 license.
Only one active international license per driver is allowed.
Re-examination:
Available only after failing an exam and is linked to the original application.
License Release (from hold):
Requires paying the fine and recording the release date.
🔐 System Management
User Management: Add/Edit/Freeze/Delete users, link each user to a real person, assign permissions.
Person Management: Prevent duplicate national IDs, edit data, advanced search.
Application Management: Filter by status, link application to person, manage application fees.
Category & Exam Management: Fixed categories with editable properties, adjustable exam fees.
💡 Developer Highlights
✅ Professional code separation using 3-Tier Architecture
✅ Reusable UserControls
✅ Use of Delegates and Events for UI interaction
✅ Comprehensive database design with real constraints
✅ Advanced DataGridView handling
✅ Error handling and data validation
