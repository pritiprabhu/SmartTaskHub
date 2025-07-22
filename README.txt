# SmartTaskHub - Team Task Management System

SmartTaskHub is a web-based task management system built with ASP.NET Core MVC, Web API, and MongoDB.
It allows users to manage projects, create tasks, assign them, set deadlines, and track progress.

## Project Architecture

| Layer         | Technology                     |
| ------------- | ------------------------------- |
| Frontend     | ASP.NET Core MVC + Razor Views |
| Backend API  | ASP.NET Core Web API            |
| Database     | MongoDB                         |
| Auth (Planned)| ASP.NET Identity + JWT         |

---

## Features Implemented
- ✅ CRUD operations for Task Items via Web API
- ✅ ASP.NET Core MVC Frontend consuming API using HttpClient
- ✅ MongoDB integration for task persistence
- ✅ CORS enabled for cross-project API calls
- ✅ Bootstrap-styled views with Razor Pages

---

## How to Run

1. **Start MongoDB**  
   - `mongod` in your terminal (or MongoDB Compass for GUI)

2. **Run the API Project (SmartTaskHub.API)**  
   - Open in Visual Studio  
   - Check the API URL in `Program.cs`  
   - Run and test via Swagger (`https://localhost:xxxx/swagger`)

3. **Run the MVC Project (SmartTaskHub.MVC)**  
   - Make sure API is running  
   - Check `ApiService.cs` for correct API URL  
   - Run and use UI for CRUD operations  

---

## Roadmap (Planned Features)
- User Authentication & Role-based Access
- Project Management & User Assignment
- Dashboard with Status Summary
- Search, Filter & Pagination
- Real-time Notifications & Activity Feed
- Angular Frontend Integration (Optional Phase 2)

---

## Author
Priti Prabhu

---

## License
This project is for learning and demonstration purposes.

