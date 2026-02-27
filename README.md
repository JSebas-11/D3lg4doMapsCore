D3lg4doMaps.Core is the foundational library for the D3lg4doMaps SDK ecosystem.  
It provides the core infrastructure required by all Google Maps API modules, including:

- Centralized configuration (API key, region, language, timeouts)
- HttpClient integration and API request pipeline
- Shared abstractions (IMapsApiClient, serializers, builders)
- Internal utilities for request building and JSON processing
- Custom exception hierarchy for Maps API errors
- Logging configuration and diagnostics support

This package contains no API-specific logic (e.g., Places, Directions).  
Its purpose is to offer a clean, scalable, and consistent foundation for building high-level Maps API clients.