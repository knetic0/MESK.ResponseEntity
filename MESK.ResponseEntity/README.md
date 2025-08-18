# MESK.ResponseEntity

**MESK.ResponseEntity** is a lightweight and generic response wrapper for .NET projects.  
It provides a standardized way to return API responses with success/failure states, messages, validation errors, status codes, and optional data payloads.  

---

## 🚀 Features
- ✅ **Generic type support** → return any type as response `Data`.  
- ✅ **Factory methods** → `Success`, `Failure`, `ValidationError`.  
- ✅ **Fluent API** → e.g. `.WithValidationErrors(...)`, `.WithMessage(...)`.  
- ✅ **HttpStatusCode integration** for consistent responses.  
- ✅ **System.Text.Json support** → `[JsonConstructor]` and `ToString()` override.  
- ✅ Easy to **unit test** and integrate with Web APIs.  

---

## 📦 Installation

Add via NuGet:

```bash
dotnet add package MESK.ResponseEntity
```

## 📖 Usage

#### Success Response

```csharp
    var result = ResponseEntity<string>.Succeeded()
            .WithData("Hello World!")
            .WithMessage("Testing from MESK.ResponseEntity!");
```

#### Failure Response

```csharp
    var result = ResponseEntity<string>.Failure()
            .WithValidationErrors(validationErrors);
```

## Contributing

Contributions are welcome! Please open issues or submit pull requests for bug fixes, new features, or improvements. Make sure to follow the existing code style and include relevant tests.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.