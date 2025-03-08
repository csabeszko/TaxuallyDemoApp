# TaxuallyDemoApp

# Project Structure

The project consists of three main components:

1. **Taxually.Hosting.TechnicalTest**: The main hosting project for the web application. Contains the web API.
2. **Taxually.Contracts.TechnicalTest**: Includes the public interfaces, contracts that are accessible to everyone.
3. **Taxually.BizLogic.TechnicalTest**: Contains the business logic, which is not exposed publicly.

### Registration Process

The registration process has been refactored from a `switch-case` structure into a more flexible polymorphic approach using a public interface (`IVatRegistration`). The application now utilizes a factory pattern (`IVatRegistrationFactory`) that generates the required registration component based on the incoming request.
