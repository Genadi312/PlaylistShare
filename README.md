# PlaylistShare
Async C# Project for Uni.

Program is running using SwaggerUI.
The Project contains:
- 3 layers (Models, Data and Business) which are connected via interfaces.

  * **Models** layer contains:
    - Configurations for MongoDb
    - Health Checks
    - Models  (Requests, Responses and the base models)
  * **Data** layer (DL) contains:
    - Repositories and interfaces for them.
  
  * **Business** layer (BL) contains:
    - Services and interfaces for them.
- **Main Project** contains:
  - Controllers
  - AutoMapper
  - HealthChecks
  - Validators
