# 🚦 DVLD - Driving License Management System

[![Windows](https://img.shields.io/badge/Platform-Windows-0078D6?logo=windows)](https://www.microsoft.com/windows)
[![.NET](https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/sql-server)

> **The Ultimate Solution for Driving License Management**  
> Developed as part of Course 19 (Full Real Project) from Dr. Abu Hadhoud's roadmap

## 📌 Table of Contents
- [Technologies Used](#-technologies-used)
- [System Overview](#-system-overview)
- [Key Features](#-key-features)
- [System Management](#-system-management)
- [Developer Highlights](#-developer-highlights)

## 🧰 Technologies Used
- **Frontend**: Windows Forms (WinForms)
- **Backend**: C#, ADO.NET
- **Database**: SQL Server
- **Architecture**: 3-Tier (Presentation-Business-Data)
- **OOP Concepts**: Events, Delegates, Composition

## 🧾 System Overview
DVLD is a comprehensive system that simulates real-world driver licensing operations including:
- License applications and renewals
- Theory and practical exams
- International license issuance
- Centralized database for all operations

## 🧩 Key Features

### 📄 Application Services
| Service Type | Fee | Restrictions |
|-------------|-----|--------------|
| First-time License | $5 | - |
| International License | $5 | Requires active Category 3 |
| License Renewal | $5 | Must be expired/expiring |

### 🪪 License Categories
| Category | Description | Min Age | Fee | Validity |
|----------|-------------|---------|-----|----------|
| 3 | Light Vehicles | 18 | $20 | 10 years |
| 4 | Taxis | 21 | $200 | 10 years |
| 7 | Heavy Vehicles | 21 | $300 | 10 years |

### 🧪 Testing Process
1. **Vision Test** ($10)
2. **Theory Test** ($20, graded out of 100)
3. **Practical Test** (Category-based fee)
   - Sequential completion required
   - All results stored permanently

## 🔐 System Management
- **User Management**: Add/Edit/Freeze/Delete users
- **Person Management**: Prevent duplicate national IDs
- **Application Management**: Filter by status
- **Exam Management**: Adjustable exam fees

## 💡 Developer Highlights
✅ 3-Tier Architecture  
✅ Reusable UserControls  
✅ Delegates & Events implementation  
✅ Comprehensive database design  
✅ Advanced DataGridView handling  
✅ Robust error handling

## 📸 Screenshots
*(Add your screenshots here)*

## 🛠️ Installation
1. Clone the repository
2. Execute `DVLD_DB.sql` to create database
3. Configure connection string in `app.config`
4. Build and run the solution

## 📜 License
MIT License
