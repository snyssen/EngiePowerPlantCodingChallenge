# EngiePowerPlantCodingChallenge

Implementation of the [GEM-SPaaS (Engie) power plant coding challenge](https://github.com/gem-spaas/powerplant-coding-challenge) for my application.

## Get started

### Requirements

#### Mandatory

- [.NET 7.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

#### Recommended

- [Visual Studio or Visual Studio Code](https://visualstudio.microsoft.com) (I use the latter)

### Clone the project

```sh
git clone https://github.com/snyssen/EngiePowerPlantCodingChallenge.git && cd EngiePowerPlantCodingChallenge
```

### Build the project

```sh
dotnet build
```

### Run the tests

```sh
dotnet test
```

### Run the API

```sh
dotnet run --project src/EngiePowerPlantCodingChallenge.WebApi/EngiePowerPlantCodingChallenge.WebApi.csproj
```

Or:

```sh
cd src/EngiePowerPlantCodingChallenge.WebApi && dotnet run
```

Or open Visual Studio or Visual Studio Code and start with <kbd>F5</kbd>.

The API is accessible on port `8888` and provides a single endpoint at `/productionplan`. It also comes bundled with a Swagger, which can be accessed at [`/swagger`](http://localhost:8888/swagger/index.html). You can either use Swagger to hit the endpoint, or an independent HTTP client such as [Postman](https://www.postman.com)
