### **🏥 Taafi (Healthcare Management System)**

Taafi is a comprehensive backend system designed to bridge the gap between patients and healthcare providers. It streamlines medical appointments, facilitates real-time communication, and leverages AI to enhance the doctor-patient experience.

![Taafi Banner](Taafi.Api/Screenshots/banner.png)
### 🚀 Built With

This project is developed using a modern tech stack to ensure high performance and scalability:

Framework: .NET 10.0 Web API.

Database: PostgreSQL.

ORM: Entity Framework Core 10.0.

Background Processing: Hangfire with PostgreSQL storage.

API Documentation: Scalar API Reference & Scalar.

Security: JWT Bearer Authentication and Google OAuth.

AI Engine: Google Gemini AI integration for intelligent medical assistance.

### 🛠️ Key Features

Doctor Directory: Search and filter doctors by specialty, experience, and rating.

Smart Appointment System: Real-time booking with queue management and status tracking.

Instant Messaging: Secure chat system between patients and doctors.

AI-Powered Insights: Integration with Gemini AI to generate smart replies for doctors.

Automated Notifications: Email services and background tasks handled via Hangfire.

Cross-Platform Ready: Configured with forwarded headers for deployment behind Nginx/Reverse Proxy.

### 📂 Architecture

The project follows Clean Architecture principles to maintain a clear separation of concerns:

Taafi.Api: Interface layer (Controllers & Middleware).

Taafi.Application: Business logic, DTOs, and Service interfaces.

Taafi.Infrastructure: Data persistence, migrations, and external service implementations.

Taafi.Core: Domain entities and core constants.


### 🤝 Collaboration
This is a joint effort between:

Backend Developer: [Mustafa Aqeel]

Flutter Developer: [Huthaifa Mohammed] — [Repo](https://github.com/itzHTH/taffi)

## 🔧 Getting Started

### Clone the repository
```bash
git clone https://github.com/username/taafi.git
```
Configure Database: Update the connection string in appsettings.json.

Apply Migrations:

**Bash**
```bash
dotnet ef database update
```
Run the application:
```bash
dotnet run
```
