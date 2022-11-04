# Client
<p>
Aplikacja Internetowa do kupna, przeglądania i recenzjonowania książek, filmów i gier.
</p>

## Architektura

  ![diagramAplikacji(1)](https://user-images.githubusercontent.com/89195542/197585931-b2c05544-7515-4fdd-8e37-af5e6ae2c328.png)

## Backend

Założenia:

- Czysta architektura (Onion architecture)
- Stronicowanie wyników
- Cache'owanie niektórych danych (w celu poprawy wydajności)
- Operacje na bazie danych (EFCore)
- Autentykacja i autoryzacja za pomocą tokenu JWT
- System logów (w celu wykrycia błędów)
- Zgodnie z zasadami projektowania REST

## Frontend

Założenia:

- Przejrzysty i prosty w obsłudze interfejs
- Responsywny
- Wysyła zapytanie HTTP na server za pomocą Axiosa
- Autentykacja za pomocą JWT
- Obsługa koszyka

![Untitled Workspace](https://user-images.githubusercontent.com/89195542/197602754-e0c4422d-fba6-433f-9dae-1b479ce288ff.png)
