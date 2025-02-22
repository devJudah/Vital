# **VitalGuard** – Real-Time Patient Monitoring Dashboard

## **📖 Project Overview**
**VitalGuard** is a real-time patient monitoring dashboard designed for healthcare providers to track vital signs. The system allows medical professionals to monitor patient health metrics, receive alerts for abnormal readings, and access historical data for trends and reports.

### **🔧 Tech Stack**
- **Frontend**: Blazor
- **Backend**: ASP.NET Core
- **Real-Time Updates**: SignalR
- **Database**: SQL Server
- **Cloud**: (Add any cloud services if applicable)

### **⚡ Features**
- Real-time updates on patient vitals (Heart rate, Blood Pressure, SpO2, Temperature).
- Alerts and notifications for abnormal vital signs.
- Historical data and trend reports.
- Role-based access (Doctors, Nurses, Admin).
- Built with security and scalability in mind.

## **🛠️ Development Roadmap**

### **📦 Phase 1: Project Setup**
- [x] Define project architecture & database schema.
- [x] Set up ASP.NET Core backend.
- [x] Create basic API endpoints for patients and vitals.
- [ ] Set up database migrations (SQL Server).

### **📡 Phase 2: Real-Time Updates with SignalR**
- [ ] Implement SignalR for live vital sign updates.
- [ ] Add alert notification system for abnormal readings.
- [ ] Connect frontend to SignalR hub for real-time display.

### **🖥️ Phase 3: Frontend Development (Blazor)**
- [ ] Build real-time dashboard UI.
- [ ] Integrate SignalR for live updates.
- [ ] Display historical trends and data visualizations.

### **📊 Phase 4: Data Persistence & Reporting**
- [ ] Store historical vital signs in SQL Server.
- [ ] Generate health reports and trends for patient monitoring.

## **⚡ API Documentation**
### **1. Get Patient Vitals**
- **Endpoint**: `/api/vitals/{patientId}`
- **Method**: `GET`
- **Response**:
```json
{
  "heartRate": 75,
  "bloodPressure": "120/80",
  "spO2": 98,
  "temperature": 36.6
}
```
### **2. Post New Vital Sign**
- **Endpoint**: `/api/vitals`
- **Method**: `POST`
- **Request Body**:
```json
{
  "patientId": "12345",
  "heartRate": 76,
  "bloodPressure": "118/76",
  "spO2": 97,
  "temperature": 36.5
}
```


