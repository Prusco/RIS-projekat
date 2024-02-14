# Informacioni Sistem za Aviokompaniju (RIS)

## Pregled

Ovaj folder sadrži izvorni kod za Informacioni Sistem za Aviokompaniju (RIS projekat 2023/2024) razvijen za potrebe upravljanja letovima, pilotima, članovima posade i srodnim informacijama radi olakšavanja efikasnih operacija aviokompanije.

## Funkcionalnosti

- Upravljanje letovima: Kreiranje, ažuriranje i brisanje zapisa o letovima.
- Informacije o pilotima: Praćenje detalja o pilotima, uključujući iskustvo i kvalifikacije.
- Upravljanje posadom: Dodjeljivanje i upravljanje članovima posade za svaki let.
- Detalji o aerodromima: Čuvanje informacija o aerodromima polaska i dolaska.

## Korištene Tehnologije

- C# za backend razvoj
- MySQL za upravljanje bazom podataka
- WPF (Windows Presentation Foundation) za korisnički interfejs

## Napomena
- Ovaj projekat u potpunosti nije urađen jer nema jos mogucnosti pretrage.
- Također ako želite pokrenuti ovaj projekat na svom računaru trebate promjenuti unutar Klase KonekcijaBaza te upisati svoj username i password za konekciju sa bazom
## Upustvo za instalaciju i korištenje aplikacije
- U ovom projektu za korištenje ove aplikacije Vam je potrebno jedno od razvojnih okruženja koji koristi C# WPF tehnologije, preporucujem Visual Studio 2022, i MySQL Server sa MySQL Workbench za koristenje 
  skripte unutar file-a. U sljedećoj poruci se nalaze linkovi za download:
- Visual Studio 2022 : https://visualstudio.microsoft.com/vs/
- MySQL Server : https://dev.mysql.com/downloads/mysql/
- MySQL Workbench : https://dev.mysql.com/downloads/workbench/
- Nakon instalacije navedenih stavki potrebno je izvršiti SQL skriptu unutar MySQL workbench-a, te nakon toga potrebno je otvoriti aplikaciju unutar Visual Studia i promjeniti Konekciju sa bazom.
- Konekcija sa bazom se nalazi unutar foldera Connection i otvoriti KonekcijaStringBaza.cs te upisati/promjeniti User i Password sa vašim podacima za pristup MySQL bazi.

