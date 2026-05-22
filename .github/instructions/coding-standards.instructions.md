---
description: "Use when reviewing or writing C# code for coding standards compliance, security checks, and quality enforcement. Covers OWASP, SOLID, naming, async patterns, and .NET conventions."
applyTo: "**/*.cs"
---
# C# Coding Standards

## Security (OWASP Top 10)
- Validate and sanitize all external inputs at system boundaries
- Use parameterized queries — never concatenate user input into SQL
- Encode output to prevent XSS (use Razor's default encoding, avoid `@Html.Raw`)
- Do not expose stack traces or internal details in error responses
- Use HTTPS and enforce `[RequireHttps]` or HSTS in production
- Avoid hardcoded secrets — use `IConfiguration` or a secrets manager
- Apply `[Authorize]` on all endpoints that require authentication
- Use anti-forgery tokens (`[ValidateAntiForgeryToken]`) for state-changing actions

## SOLID Principles
- **Single Responsibility**: One reason to change per class
- **Open/Closed**: Extend via interfaces, not by modifying existing code
- **Liskov Substitution**: Derived types must be substitutable for base types
- **Interface Segregation**: Small focused interfaces over large general ones
- **Dependency Inversion**: Depend on abstractions (`IProductService`), inject via DI

## Naming Conventions
- PascalCase for public members, types, namespaces, and methods
- camelCase for local variables and private fields (prefix `_` for private fields)
- Prefix interfaces with `I` (e.g., `IProductService`)
- Use meaningful names — avoid abbreviations except well-known ones (`id`, `url`)
- Async methods must end with `Async` suffix

## Code Quality
- Keep methods under 30 lines; extract when longer
- Cyclomatic complexity ≤ 10 per method
- No empty catch blocks — log or rethrow with context
- Use `nullable` reference types and avoid `null` where possible
- Prefer `record` for immutable data transfer objects
- Use collection expressions and pattern matching where clearer

## Async/Await
- Never use `.Result` or `.Wait()` — always `await`
- Use `CancellationToken` in async APIs
- Return `Task` not `void` from async methods (except event handlers)

## ASP.NET MVC / Web API
- Return `IActionResult` from controller actions
- Use model validation (`[Required]`, `[Range]`, etc.) and check `ModelState`
- Keep controllers thin — delegate to services
- Register services in DI with appropriate lifetimes (`Scoped` > `Transient` > `Singleton`)

## Testing
- Follow Arrange-Act-Assert pattern
- One logical assertion per test
- Name tests: `MethodName_Scenario_ExpectedResult`
- Use `xUnit` with `[Fact]` and `[Theory]` attributes
- Mock external dependencies; do not depend on real I/O in unit tests
