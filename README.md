# EngiePowerPlantCodingChallenge

Implementation of the [GEM-SPaaS (Engie) power plant coding challenge](https://github.com/gem-spaas/powerplant-coding-challenge) for my application.

## Get started

### Requirements

#### Mandatory

- [.NET 7.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- Docker or [Docker Desktop](https://www.docker.com/products/docker-desktop/) (if you want to build and run the Docker image)

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

## Docker

This API can be packaged and run using Docker.

### Build image

```sh
docker build . --tag "snyssen/powerplant-api"
```

### Run image

This repo comes bundled with a `docker-compose.yml` file for easy build and start of the Docker image:

```sh
docker compose up [-d] [--build]
```

> Arguments surrounded by `[]` are optional.
> 
> `-d` is used to run image as detached (i.e. in the background). In such case you have to use the following command to stop the container:
>
> ```sh
> docker compose down
> ```
>
> Otherwise you can stop the container by using <kbd>ctrl</kbd>+<kbd>C</kbd>.
>
> `--build` is used to force a rebuild of the image, otherwise it will use the already compile image (if present), which won't include any recent change you have made to the project.
