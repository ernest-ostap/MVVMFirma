# MVVMFirma

## Opis projektu (PL)
**MVVMFirma** to aplikacja napisana w technologii **WPF (Windows Presentation Foundation)** z wykorzystaniem wzorca architektonicznego **MVVM (Model–View–ViewModel)**.  
Projekt został stworzony jako przykład/system do zarządzania danymi firmy, z rozdzieleniem warstw odpowiedzialnych za logikę biznesową, warstwę prezentacji oraz komunikację z bazą danych.

### Struktura projektu
- **App.xaml / App.xaml.cs** – konfiguracja startowa aplikacji, rejestracja zasobów.  
- **Helper/** – pomocnicze klasy, np. `BaseCommand` implementujący mechanizm poleceń (ICommand) dla MVVM.  
- **Models/**
  - **BusinessLogic/** – logika biznesowa, klasy odpowiedzialne za operacje na danych (`DatabaseClass`, `KategorieB`, `KlienciB`, `ProduktyB`).  
  - **EntitiesForView/** – modele DTO/VM wykorzystywane do wyświetlania danych w widokach (np. `ProduktForAllView`, `ZamowienieForAllView`).  
- **Validators/** – walidatory danych (`PositiveNumberValidator`, `StringLengthValidator`, `StringValidator`).  
- **ViewModel/** – główne ViewModele aplikacji (`MainViewModel`, `ViewModelLocator`).  
- **ViewModels/** – bazowe klasy i dodatkowe VM (`BaseViewModel`, `CommandViewModel`, `MainWindowViewModel`).  
- **Themes/** – pliki XAML definiujące style i motywy.  
- **Properties/** – pliki konfiguracyjne projektu WPF.  

### Wykorzystane technologie
- **C#** – język programowania  
- **WPF (.NET Framework)** – framework do tworzenia interfejsu graficznego  
- **MVVM** – wzorzec architektoniczny  
- **XAML** – deklaratywny język UI  
- **ADO.NET / Logika biznesowa** – operacje na danych  

### Uruchamianie projektu
1. Otwórz plik `MVVMFirma.sln` w **Visual Studio**  
2. Przywróć paczki NuGet (`Restore NuGet Packages`)  
3. Skonfiguruj połączenie z bazą danych w `DatabaseClass`  
4. Uruchom projekt (`F5` lub `Ctrl+F5`)  

### Funkcjonalności
- Obsługa encji: produkty, kategorie, klienci, zamówienia, płatności, stany magazynowe itd.  
- Oddzielenie warstw logiki biznesowej, widoku i modelu  
- Walidacja danych po stronie klienta  
- Obsługa akcji UI poprzez ICommand  
- Łatwa rozbudowa o nowe widoki i ViewModele  

---

## Project Description (EN)
**MVVMFirma** is a **WPF (Windows Presentation Foundation)** application built using the **MVVM (Model–View–ViewModel)** architectural pattern.  
The project serves as an example/company management system, separating the business logic, presentation layer, and data access.

### Project Structure
- **App.xaml / App.xaml.cs** – application entry point and resource registration  
- **Helper/** – utility classes, e.g., `BaseCommand` implementing the `ICommand` interface for MVVM command handling  
- **Models/**
  - **BusinessLogic/** – business logic classes responsible for data operations (`DatabaseClass`, `KategorieB`, `KlienciB`, `ProduktyB`)  
  - **EntitiesForView/** – DTO/VM classes for displaying data in the UI (`ProduktForAllView`, `ZamowienieForAllView`, etc.)  
- **Validators/** – input validation (`PositiveNumberValidator`, `StringLengthValidator`, `StringValidator`)  
- **ViewModel/** – main application ViewModels (`MainViewModel`, `ViewModelLocator`)  
- **ViewModels/** – base and additional ViewModels (`BaseViewModel`, `CommandViewModel`, `MainWindowViewModel`)  
- **Themes/** – XAML style and theme definitions  
- **Properties/** – WPF project configuration files  

### Technologies Used
- **C#** – programming language  
- **WPF (.NET Framework)** – UI framework for Windows desktop applications  
- **MVVM** – architectural pattern for separation of concerns  
- **XAML** – declarative UI markup language  
- **ADO.NET / Custom Business Logic** – database interaction in `BusinessLogic` classes  

### How to Run
1. Open the `MVVMFirma.sln` file in **Visual Studio**  
2. Restore NuGet packages if prompted (`Restore NuGet Packages`)  
3. Configure your database connection inside `DatabaseClass`  
4. Build and run the project (`F5` or `Ctrl+F5`)  

### Features
- Entity management: products, categories, clients, orders, payments, stock levels, etc.  
- Clear separation between business logic, view, and model layers  
- Client-side data validation  
- ICommand-based UI action handling  
- Easily extendable with new views and ViewModels  

---

## License
Educational/demonstration project.  
Author: **ernest-ostap**
