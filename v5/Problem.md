# Projekat: Jednostavni Sistem Upravljanja Inventarom

## Pregled
Potrebno je napraviti konzolnu aplikaciju za sistem za upravljanje inventarom za malu maloprodajnu radnju. Obrađivat će osnovne operacije poput dodavanja, uklanjanja i pregleda item-a u inventaru.

## Moduli i Namespaces-i

- **MainModule**: EntryPoint aplikacije, zadužen za prikaz glavnog menija i interakciju s korisnicima.
- **InventoryModuel**: Sadrži logiku za upravljanje inventarom (dodavanje, uklanjanje, ažuriranje, pregled item-a).
- **ReportingModule**: Upravlja generisanjem jednostavnih izvještaja (npr. trenutni zalihe, item-i sa niskim zaliha).
- **UtilityModule**: Sadrži pomoćne funkcije poput validacije unosa, formatiranja izlaza itd.

## Namespaces

- **RetailStore.InventoryManagement**: Bazni namespace za cijelu aplikaciju.
- Sub-namespace poput **RetailStore.InventoryManagement.Inventory**, **RetailStore.InventoryManagement.Reporting** itd.

## Karakteristike

1. **Glavni Meni**: Kada se aplikacija pokrene, prikazuje opcije poput "Dodaj Item", "Ukloni Item", "Pregled Inventara", "Generiši Izvještaj", "Izađi".
2. **Upravljanje Inventarom**:
   - Dodaj Stavku: Unos detalja poput imena, količine, cijene.
   - Ukloni Stavku: Odabir stavke iz liste za uklanjanje.
   - Ažuriraj Stavku: Modifikacija detalja postojećih stavki.
   - Pregled Inventara: Prikaz svih stavki sa njihovim detaljima.
3. **Izvještavanje**:
   - Generisanje osnovnih izvještaja poput liste stavki ispod određene količine.

## Upravljanje Projektom

- Koristiti `.fsproj` datoteke za upravljanje projektom itd.
- Razdvojiti projekt na različite module i namespaces-e za bolju organizaciju i održivost.
- Koristiti `dotnet` CLI za zadatke poput izgradnje, pokretanja i pakovanja aplikacije.

## Skladištenje Podataka

- Za skladištenje podataka koristiti SQLite bazu.

## Testiranje

- Uključiti neke osnovne unit testove za Module Inventara i Izvještaja.

## Korisničko Iskustvo

- Aplikacija bi trebala biti jednostavna za navigaciju s jasnim uputama i validacijom unosa.