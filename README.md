# 🚀 TODO List API

**API do zarządzania zadaniami (TODO list) z obsługą CRUD, filtrowaniem i sortowaniem**

---

## 📖 Spis treści
- [Opis projektu](#-opis-projektu)
- [Wymagania](#-wymagania)
- [Technologie](#-technologie)
- [Instalacja](#-instalacja)
- [Konfiguracja](#-konfiguracja)
- [Endpointy](#-endpointy)
- [Przykłady użycia](#-przykłady-użycia)
- [Licencja](#-licencja)

---

## 🌟 Opis projektu
RESTful API do zarządzania zadaniami z możliwością:
- Dodawania, edycji, usuwania i przeglądania zadań (CRUD).
- Filtrowania zadań po **statusie** i **priorytecie**.
- Sortowania zadań według daty utworzenia (od najnowszych lub najstarszych).

Każde zadanie zawiera:
- Tytuł (`title`)
- Opis (`description`)
- Status (`status`: `ToDo`, `InProgress`, `Done`)
- Priorytet (`priority`: `Low`, `Medium`, `High`)
- Datę utworzenia (`createdAt`)

---

## 🛠️ Wymagania
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server) lub Docker
- [Entity Framework Core Tools](https://docs.microsoft.com/ef/core/cli/dotnet)

---

## 💻 Technologie
- **.NET 8**
- **Entity Framework Core**
- **SQL Server**
- **Swagger** (dokumentacja API)
- **C#**

---

## 📥 Instalacja
1. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/adakde/ToDoApi.git
   cd ToDoApi

   Zainstaluj zależności:

bash
dotnet restore
🔧 Konfiguracja
Zmodyfikuj connection string w appsettings.json:

json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TWÓJ_SERWER;Database=TodoDb;Trusted_Connection=True;Encrypt=False;"
  }
}
Uruchom migracje:

bash
dotnet ef database update
🌐 Endpointy
Metoda	Endpoint	Opis
GET	/api/tasks	Pobierz wszystkie zadania
GET	/api/tasks/{id}	Pobierz zadanie po ID
POST	/api/tasks	Dodaj nowe zadanie
PUT	/api/tasks/{id}	Edytuj istniejące zadanie
DELETE	/api/tasks/{id}	Usuń zadanie
Parametry zapytań (GET /api/tasks):
status: Filtruj po statusie (ToDo, InProgress, Done)

priority: Filtruj po priorytecie (Low, Medium, High)

sortOrder: Sortuj (newest lub oldest)

🚦 Przykłady użycia
1. Dodaj zadanie
bash
curl -X POST "https://localhost:7203/api/tasks" \
-H "Content-Type: application/json" \
-d '{
  "title": "Zrobić zakupy",
  "description": "Mleko, jajka, chleb",
  "status": "ToDo",
  "priority": "Medium"
}'
2. Pobierz zadania (sortowane od najstarszych)
bash
curl "https://localhost:7203/api/tasks?sortOrder=oldest"
3. Przykładowa odpowiedź
json
Copy
[
  {
    "id": 1,
    "title": "Zrobić zakupy",
    "description": "Mleko, jajka, chleb",
    "status": "ToDo",
    "priority": "Medium",
    "createdAt": "2024-05-15T10:00:00Z"
  }
]
📜 Licencja
MIT License
