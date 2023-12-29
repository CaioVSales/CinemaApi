```markdown
# Cinema API

Welcome to the Cinema API project! This is a dotnet 7 project for studying purposes.

## Prerequisites

Before running the application, make sure you have the following installed:

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

## Getting Started

Follow these steps to run the Cinema API:

1. Clone the repository:

   ```bash
   git clone https://github.com/CaioVSales/CinemaApi.git
   cd CinemaApi
   ```

2. Build and run the Docker containers:

   ```bash
   docker-compose up --build
   ```

   This command will build the necessary images and start the containers.

3. Access the application:

   - API: 
        Development - [http://localhost:5271](http://localhost:5271)
        Production - [http://localhost:7256](http://localhost:7256)

4. Swagger API Documentation:

   Access the Swagger API documentation at [http://localhost:5271/swagger](http://localhost:5271/swagger).

5. Clean up (optional):

   When you are done, you can stop and remove the Docker containers:

   ```bash
   docker-compose down
   ```

## Troubleshooting

If you encounter any issues, please check the error messages in the console and consult the project documentation.
