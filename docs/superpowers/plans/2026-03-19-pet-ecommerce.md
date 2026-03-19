# ZQ Pet Store – Children's Web Game Plan
**Date:** 2026-03-19  
**Project:** Pet E-commerce Game for Children

## Overview
A fun, colorful children's web application built with .NET ASP.NET Core that lets kids:
- Browse virtual pets in the **Pet Shop**
- **Adopt** pets using in-game coins
- Play the **"Guess the Pet!"** mini-game to earn more coins
- View their collection in **My Pets**

## Tech Stack
- **Backend:** .NET 10 / ASP.NET Core (Minimal API)
- **Frontend:** HTML5, CSS3, Vanilla JavaScript (served as static files)
- **Data:** In-memory store (no database required)

## API Endpoints
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/pets` | List available (unadopted) pets |
| GET | `/api/pets/all` | List all pets including adopted |
| GET | `/api/pets/{id}` | Get pet details |
| POST | `/api/pets/{id}/adopt` | Adopt a pet |
| GET | `/api/adoptions` | Get adoption history |

## Pet Catalog
8 starter pets: Fluffy (Cat), Buddy (Dog), Tweety (Bird), Bubbles (Fish), Hoppy (Bunny), Spike (Turtle), Zippy (Hamster), Goldie (Fish)

## Game Mechanics
- Start with **200 coins**
- Adopting a pet costs coins (15–75 depending on species)
- Play "Guess the Pet!" to earn **+10 coins** per correct answer
- **Streak bonus:** 3+ correct in a row earns extra coins 🔥

## Directory Structure
```
zqpet-apps/
├── PetStore.Api/
│   ├── Models/
│   │   └── Pet.cs
│   ├── wwwroot/
│   │   └── index.html        ← children's game UI
│   ├── Program.cs            ← API endpoints
│   └── PetStore.Api.csproj
├── docs/
│   └── superpowers/
│       └── plans/
│           └── 2026-03-19-pet-ecommerce.md
└── README.md
```

## How to Run
```bash
cd PetStore.Api
dotnet run
# Open browser at http://localhost:5000
```

## Future Enhancements
- [ ] Add user accounts / profiles
- [ ] Pet care mini-games (feeding, grooming)
- [ ] More pet species and rare pets
- [ ] Leaderboard for high scores
- [ ] Persistent storage with SQLite/EF Core
