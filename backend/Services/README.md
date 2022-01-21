# PROJECT STRUCTURE
## 1. Services

### Modules
- Api Endpoint (**AccountService**)
> Contains controllers containing api endpoints which using by client

- Domain (**AccountService.Domain**)
> Contains domain specific logic

- Repository (**AccountService.Repository**)
> Contains component access database

## Dependency
>(**AccountService**) ----- (**AccountService.Domain**)  
(**AccountService**) ----- (**AccountService.Repository**)  
(**AccountService.Domain**) ---- (**AccountService.Repository**)

## 2. Gateway (TBA)
