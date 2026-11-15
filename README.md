Test-Taste Console Application

Overview:

The C# console application provides the following functionality:

Lists all planets and their moons.

Lists moons and displays their mass.

Lists planets that have at least one moon and displays the average temperature of their moons.


Technologies Used:

C#

.NET 10

Visual Studio Community

Solar System REST API

API Authentication

The application requires an API key to communicate with the Solar System OpenData API.


Generate an API key:

Visit https://api.le-systeme-solaire.net/generatekey.html



Configure the key as an environment variable named SOLAR_SYSTEM_API_KEY.

Configure the environment variable on Windows

Open PowerShell and execute:

[Environment]::SetEnvironmentVariable(
    "SOLAR_SYSTEM_API_KEY",
    "YOUR_API_KEY",
    "User"
)

Replace YOUR_API_KEY with your actual API key.

Restart Visual Studio or open a new terminal after setting the variable.

The application reads the API key from the environment variable and sends it through the HTTP Authorization header using the Bearer authentication scheme.

Important: Never hard-code the API key in the source code or commit it to Git.


Application Structure:

The application uses separate classes for API communication, data transfer, domain objects, business logic and console output.


API communication:

HttpClientService.cs configures the HTTP client, including the API base address, JSON response format and authentication header.


Data transfer objects:

MoonDto.cs and PlanetDto.cs represent the data received from the API.

The moon DTO includes the avgTemp field to receive the average temperature provided by the API.


Domain objects:

Moon.cs represents a moon and stores its mass and average temperature.

Planet.cs represents a planet and its moons. It calculates the average temperature of the available moon temperature values.


Services:

PlanetService.cs retrieves planets and their associated moon information.

MoonService.cs retrieves moon data and mass information.

ScreenOutputService.cs handles displaying the application results in the console.


Average Moon Temperature Calculation:

The application retrieves the avgTemp field for moons from the API.

The average moon temperature for a planet is calculated using the available temperature values of its moons.

Moons without an available temperature value are excluded from the calculation.

If none of a planet's moons has a temperature value, the application displays N/A instead of an incorrect zero.

Temperatures are displayed in Kelvin (K), as provided by the API.


API Changes:

The API query used to retrieve moon data has been extended to include the avgTemp field.

This allows the application to receive moon temperature information without introducing a separate API or changing the existing data source.


Domain Model Changes:

The MoonDto class was extended to deserialize the moon temperature field returned by the API.

The Moon domain object was extended to store the temperature.

The Planet domain object calculates the average temperature of its moons. Keeping this calculation in the domain model ensures that the temperature calculation belongs to the planet and its associated moon data rather than the console presentation layer.

The existing output functionality was updated to display average moon temperature instead of the previous average moon gravity placeholder.


Running the Application:

Clone or open the repository.

Configure the SOLAR_SYSTEM_API_KEY environment variable.

Open Test-Taste-Console-Application.sln in Visual Studio.

Build the solution.

Run the console application.


Security:

The API key is stored outside the source code in a user-level environment variable. Each developer must configure their own API key before running the application.