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
