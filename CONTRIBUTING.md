# Guía de Contribución

¡Gracias por tomarte el tiempo de contribuir a **sistema-costo-viaje**! 

Este documento contiene las pautas e instrucciones necesarias para que puedas configurar tu entorno local, ejecutar pruebas y enviar tus contribuciones de manera ordenada.

---

## Requisitos Previos

Antes de comenzar, asegúrate de tener instalado en tu equipo:

* [.NET 10 SDK](https://dotnet.microsoft.com/download)

---

## Configuración del Entorno Local

1. **Clona el repositorio:**
   ```bash
   git clone <https://github.com/JSc20/sistema-costo-viaje.git>
   cd sistema-costo-viaje
2. **Restaura las dependencias del proyecto:**

   ```bash
   dotnet restore
   ```

3. **Compila la solución:**

   ```bash
   dotnet build
   ```

## Ejecución de Pruebas (Tests)

Antes de realizar un commit o enviar un Pull Request, asegúrate de que todas las pruebas pasen correctamente:

   ```bash
   dotnet test
   ```

## Flujo para Enviar Cambios (Pull Requests)					

1. Crea una nueva rama para tu trabajo desde main:

   ```bash
   git checkout main
   git pull origin main
   git checkout -b nombre-de-tu-rama
   ```
2.Realiza tus cambios y asegúrate de que el proyecto compile y los tests pasen.

3.Haz commit de tus cambios:

   ```bash
   git add .
   git commit -m "Descripción clara de los cambios realizados"
   ```
4.Sube tu rama al repositorio remoto:

   ```bash
   git push origin nombre-de-tu-rama
   ```
5.Abre un Pull Request (PR):

-Ve a la pestaña de Pull Requests en GitHub.

-Completa la información requerida utilizando la plantilla predeterminada de PR.

-Asocia la Issue correspondiente si aplica.

¡Gracias por colaborar! Tu ayuda es muy valiosa para el proyecto