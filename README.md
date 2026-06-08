# Anime Newsletter

A newsletter platform that aggregates anime-related information and delivers curated updates to subscribers. The system collects data from external sources, processes and summarizes content, and distributes newsletter emails on a scheduled basis.

## Features

* Email subscription management
* Automated newsletter generation
* Anime release tracking
* News aggregation from external sources
* AI-generated summaries
* Scheduled email delivery
* User preference management
* Responsive web interface
* REST API for frontend integration
* PostgreSQL data storage

## Architecture

The project is organized into multiple services:

### Frontend

Responsible for:

* Landing page
* Subscription forms
* User-facing newsletter information
* Preference management

### Backend API

Responsible for:

* Subscriber management
* Authentication and authorization
* Data persistence
* Business logic
* Newsletter generation workflows
* Integration with external APIs

### Database

Stores:

* Subscribers
* Newsletter content
* User preferences
* Delivery history
* Application data

### Automation Layer

Responsible for:

* Scheduled data collection
* Content processing
* Newsletter generation
* Email delivery workflows
* External service integrations

## Technology Stack

### Frontend

* React
* TypeScript
* Vite
* Tailwind CSS

### Backend

* ASP.NET Core
* Entity Framework Core

### Database

* PostgreSQL

### Infrastructure

* Docker
* Nginx
* VPS Hosting

### Automation

* n8n

## Project Structure

```text
anime-newsletter/
│
├── Frontend/
│   ├── src/
│   ├── public/
│   └── ...
│
├── Backend/
│   ├── Controllers/
│   ├── Services/
│   ├── Data/
│   ├── Models/
│   └── ...
│
├── Workflows/
│   └── n8n/
│
├── Infrastructure/
│   ├── docker/
│   └── nginx/
│
└── README.md
```

## Getting Started

### Prerequisites

* Node.js
* .NET SDK
* PostgreSQL
* Docker (optional)

### Clone Repository

```bash
git clone https://github.com/your-username/anime-newsletter.git

cd anime-newsletter
```

### Backend Setup

```bash
cd backend

dotnet restore

dotnet ef database update

dotnet run
```

### Frontend Setup

```bash
cd frontend

npm install

npm run dev
```

## Environment Variables

### Backend

- Mostly appsettings.json

```env
ConnectionStrings__DefaultConnection=
Jwt__Key=
Jwt__Issuer=
Jwt__Audience=

Email__Host=
Email__Port=
Email__Username=
Email__Password=
```

### Frontend

```env
VITE_API_URL=
```

## Deployment

The application is designed to be deployed using Docker containers behind a reverse proxy.

Typical deployment configuration:

```text
Internet
    │
    ▼
Nginx
    │
 ┌──┴──┐
 ▼     ▼
Frontend  Backend API
             │
             ▼
        PostgreSQL
```

Automation workflows may be deployed independently and communicate with the API through secured endpoints.