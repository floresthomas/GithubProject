# Github Project

Este proyecto es una aplicación de consola que simula algunos de los comandos básicos de Git, como `add`, `commit`, `push`, `status`, `log`, y `revert`.

## Funcionalidades

### Comandos implementados

- **git add `<file_name>`**: Agrega un archivo al área de preparación (staging area).
- **git commit `<message>`**: Realiza un commit de los archivos en el área de preparación con un mensaje de commit.
- **git push**: Envía los commits locales al servidor remoto.
- **git status**: Muestra el estado de los archivos y commits.
- **git log**: Muestra el historial de commits.
- **git revert**: Revierte el último commit.
- **git help**: Muestra la lista de comandos disponibles.
- **git exit**: Sale de la interfaz de Git.

##Funcionalidades adicionales

### Comando `git revert`

Este comando revierte el último commit realizado, ya sea en el repositorio local o remoto. Si hay commits en el repositorio remoto, se revertirá el último commit remoto. Si no hay commits remotos pero sí locales, se revertirá el último commit local.

### Comando `git status`

Este comando muestra el estado actual del repositorio, proporcionando una visión general de los cambios realizados en los archivos desde el último commit. Muestra qué archivos han sido modificados, añadidos al área de preparación o confirmados.

## Requisitos

- .NET SDK 6.0 o superior

## Ejecución local

1. **Clonar el repositorio:**

    ```sh
    git clone https://github.com/floresthomas/GithubProject.git
    cd GithubProject
    ```

2. **Construir y ejecutar la aplicación:**

    ```sh
    dotnet build
    dotnet run
    ```

## Tests

Descripción de los Tests
Este proyecto incluye una serie de tests unitarios para asegurar el correcto funcionamiento de los comandos implementados. Los tests están escritos utilizando xUnit y cubren los siguientes escenarios:

AddCommand_Execute_AddsFileToRepository: Verifica que el comando add añade correctamente un archivo al área de preparación.

CommitCommand_Execute_CommitsStagedFiles: Verifica que el comando commit realiza correctamente un commit de los archivos en el área de preparación, vacía el área de preparación y añade el commit a la lista de commits locales.

PushCommand_Execute_PushesLocalCommitsToRemote: Verifica que el comando push envía correctamente los commits locales al servidor remoto.

StatusCommand_Execute_DisplaysCurrentStatus: Verifica que el comando status muestra el estado actual del repositorio.

LogCommand_Execute_DisplaysCommitHistory: Verifica que el comando log muestra correctamente el historial de commits.

RevertCommand_Execute_RevertsLastCommit: Verifica que el comando revert revierte correctamente el último commit.

## Ejecutando los Tests
Para ejecutar los tests, sigue estos pasos:

**Instalar los paquetes necesarios:**
```sh
Copiar código
dotnet add package xunit
dotnet add package xunit.runner.visualstudio
dotnet add package Microsoft.NET.Test.Sdk
```

**Ejecutar los tests:**
    ```sh
    cd TestCommandsGit
    dotnet test
    ```

Estos tests aseguran que cada comando funciona como se espera y ayudan a mantener la estabilidad del código al detectar posibles errores durante el desarrollo.
