Details for creating a token
Request Body:

{
  "userName": "test",
  "password": "1234"
}

## 🚀 Run with Docker

### 🔧 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (optional for local development/testing)
- [Docker](https://www.docker.com/products/docker-desktop)
- [Docker Compose](https://docs.docker.com/compose/install/)

---

### 📦 Option 1: Docker CLI

Build and run manually using the Docker CLI:

```bash
# Build the image
docker build -t calculator-api .

# Run the container
docker run -d -p 5000:80 --name calculator-api calculator-api
```

Then visit: [http://localhost:5000](http://localhost:5000)

To stop and remove:

```bash
docker stop calculator-api
docker rm calculator-api
```

---

### ⚙️ Option 2: Docker Compose

Build and run using Docker Compose (recommended):

```bash
docker-compose up --build
```

This will:
- Build the image as defined in the `Dockerfile`
- Start the container as defined in `docker-compose.yml`
- Bind port `80` inside the container to port `5000` on your host

To shut it down:

```bash
docker-compose down
```"# CalculatorAPI" 
