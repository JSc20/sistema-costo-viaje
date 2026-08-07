# Manual de Usuario — Sistema Costo Viaje

Guía práctica para nuevos usuarios de **Sistema Costo Viaje**, la herramienta de gestión y
cálculo de costos de viajes de **Grupo IEXCA S.A.** Este manual explica paso a paso cómo
instalar la aplicación, registrar los datos de los catálogos (vehículos, técnicos, destinos,
etc.) y crear un viaje con su desglose de costos.

---

## 1. Qué es el sistema

Sistema Costo Viaje permite:

- Registrar los **vehículos** de la empresa, su **rendimiento** (kilómetros por litro y costo
  por kilómetro) y sus **mantenimientos**.
- Registrar **técnicos**, **tipos de combustible**, **peajes**, **destinos** y **viáticos**.
- **Crear viajes** y ver el desglose de costos: combustible, ferry, viáticos y costo total.
- **Guardar toda la información** de forma permanente en una base de datos local.

Todo lo que usted ingrese se **guarda automáticamente en el equipo**, no se pierde al cerrar
el programa.

---

## 2. Requisitos del sistema

- Computadora con **Windows** (7, 10 u 11).
- **64 bits** (x64).
- El ejecutable descargado es **autónomo**: no es necesario instalar .NET ni ningún otro
  programa adicional.
- Espacio libre en disco: unos **300 MB**.

---

## 3. Instalación y primer uso

1. Descargue el archivo `sistema-costo-viaje.exe` desde la página de descargas
   (Release de la aplicación).
2. Guarde el archivo en una carpeta del equipo, por ejemplo `C:\SistemaCostoViaje\`.
   - Le recomendamos **no** ejecutarlo directamente desde la carpeta de descargas.
   - No necesita instalador: es un único archivo.
3. Haga **doble clic** sobre `sistema-costo-viaje.exe` para abrir el programa.
4. Se mostrará el **Menú Principal**.

> Al primer uso el programa crea automáticamente un archivo llamado
> `sistema_costo_viaje.db` en la misma carpeta del ejecutable. Ahí se guardan todos los
> registros. **No lo borre**: contiene sus datos.

---

## 4. Menú principal

Al abrir la aplicación aparece el **Menú Principal** con las siguientes opciones:

| Botón | Qué permite hacer |
|---|---|
| **Gestionar viajes** | Crear, consultar, editar, eliminar y exportar viajes |
| **Gestionar técnicos** | Registrar técnicos y sus costos de hora |
| **Gestionar vehículos** | Registrar vehículos, rendimiento y mantenimientos |
| **Gestionar viáticos** | Registrar los montos de viáticos |
| **Gestionar peajes** | Registrar los peajes y sus costos |
| **Gestionar destino** | Registrar destinos con sus kilómetros y peajes |
| **Gestionar combustible** | Registrar los tipos de combustible y sus precios |

Haga clic en el botón de la sección que desee trabajar. Para volver al menú, cierre la
ventana de la sección.

---

## 5. Gestionar vehículos

Pantalla dividida en **tres pestañas** y un listado de vehículos registrados.

### 5.1 Pestaña Vehículo

1. Escriba el **Modelo** del vehículo.
2. Escriba el **Kilometraje actual** (kilómetros recorridos hasta el momento).
3. Haga clic en **Guardar** para registrar el vehículo.
4. Para corregir un vehículo: selecciónelo en el listado, modifique los datos y haga clic en
   **Editar**.
5. Para eliminar un vehículo: selecciónelo en el listado y haga clic en **Eliminar**.

### 5.2 Pestaña Rendimiento

Registra cuánto combustible gasta el vehículo:

1. Seleccione el vehículo en el listado.
2. Indique el **Tipo de entorno** (por ejemplo: Ciudad, Carretera, Tráfico).
3. Escriba los **Km x litro** (cuántos kilómetros recorre con un litro).
4. El **Costo x kilómetro** se calcula con el precio del combustible. Puede ingresarlo o
   ajustarlo manualmente.
5. Haga clic en **Guardar**.

### 5.3 Pestaña Mantenimiento

Registra los gastos de mantenimiento del vehículo:

1. Seleccione el vehículo en el listado.
2. Escriba la **Descripción** (por ejemplo: Cambio de aceite, Filtro de aire).
3. Escriba el **Costo total** del mantenimiento.
4. Escriba el **Intervalo x km** (cada cuántos kilómetros se realiza).
5. El campo **Costo real x km** se calcula automáticamente.
6. Haga clic en **Guardar**.

---

## 6. Gestionar combustible

1. Escriba el **Nombre** del combustible (por ejemplo: Regular, Súper, Diésel).
2. Escriba el **Costo** (precio por litro).
3. Haga clic en **Guardar Combustible**.
4. Para corregir: seleccione el registro y use **Editar Combustible**.
5. Para eliminar: seleccione el registro y use **Eliminar Combustible**.

---

## 7. Gestionar técnicos

1. Escriba el **Nombre** del técnico.
2. Escriba el **Salario mensual**.
3. Escriba las **Horas de trabajo semanales**.
4. Escriba el **Costo de hora ordinaria** y el **Costo de hora extra**.
5. Haga clic en **Guardar Técnico**.
6. Use **Editar Técnico** o **Eliminar Técnico** para modificar o quitar un registro.

---

## 8. Gestionar peajes

1. Escriba el **Nombre** del peaje (por ejemplo: Escazú, San Rafael).
2. Escriba el **Costo** del peaje.
3. Haga clic en **Guardar Peaje**.
4. Para modificar o eliminar, seleccione el registro y use **Editar Peaje** o
   **Eliminar Peaje**.

---

## 9. Gestionar destino

1. Escriba el **Nombre** del destino (por ejemplo: Escazú, San Rafael, Atenas).
2. Escriba los **Kms de ida y vuelta**.
3. Indique el **Peaje** correspondiente al destino.
4. Haga clic en **Guardar Destino**.
5. Para modificar o eliminar, seleccione el destino y use **Editar Destino** o
   **Eliminar Destino**.

---

## 10. Gestionar viáticos

1. Escriba el **Nombre** del viático (por ejemplo: Desayuno, Almuerzo, Cena).
2. Escriba el **Costo** (monto del viático).
3. Haga clic en **Guardar Viático**.
4. Para modificar o eliminar, seleccione el registro y use **Editar Viático** o
   **Eliminar Viático**.

---

## 11. Gestionar viajes

Es la sección principal. Aquí se crea un viaje y se calcula su costo.

### 11.1 Crear un viaje

1. Haga clic en **Crear Viaje**.
2. Seleccione la **Fecha** del viaje.
3. Seleccione el **Vehículo** que realizará el viaje.
4. Seleccione el **Destino**.
5. Seleccione el **Combustible**.
6. Si aplica, ingrese el **Ferry** (costo).
7. Si aplica, indique los **Viáticos** del viaje.
8. Revise el **desglose de precio** que se calcula automáticamente:
   - Desglose de precio **solo de combustible**.
   - Desglose de **precio total** (combustible + ferry + viáticos + otros).
9. Haga clic en **Guardar viaje**.

### 11.2 Consultar, editar y eliminar

- El listado **Viajes registrados** muestra todos los viajes creados.
- Para **editar**: seleccione el viaje en el listado, modifique los datos y haga clic en
  **Editar Viaje**.
- Para **eliminar**: seleccione el viaje y haga clic en **Eliminar Viaje**.

### 11.3 Exportar registro

- El botón **Exportar Registro** permite guardar la información de los viajes en un archivo
  para compartirla o archivarla.

---

## 12. Cómo se guardan los datos (persistencia)

- Todos los registros se guardan de forma permanente en el archivo `sistema_costo_viaje.db`,
  que se crea **en la misma carpeta donde está el ejecutable**.
- La información **no se pierde** al cerrar el programa.
- Para **respaldar** sus datos, copie el archivo `sistema_costo_viaje.db` a otra ubicación
  (por ejemplo, un USB o una carpeta de respaldo).

---

## 13. Solución de problemas frecuentes

| Problema | Qué hacer |
|---|---|
| El programa no abre | Verifique que el archivo sea `sistema-costo-viaje.exe` y que la carpeta no esté bloqueada. Intente ejecutarlo como Administrador. |
| Al guardar aparece un mensaje de error | Cierre el programa, vuelva a abrirlo e intente nuevamente. Si persiste, revise que haya espacio libre en disco. |
| Se perdió la base de datos o está dañada | Si borró o dañó `sistema_costo_viaje.db`, al abrir el programa se creará una **nueva base de datos vacía** (se pierden los registros). Restaure la copia de respaldo si la tiene. |
| Quiero empezar de cero | Cierre el programa, borre el archivo `sistema_costo_viaje.db` y vuelva a abrirlo. Se crearán los datos de inicio. |
| El listado aparece vacío | Registre primero los catálogos (vehículos, combustible, destinos, etc.) antes de crear un viaje. |

---

## 14. Consejos de uso

- **Registre primero los catálogos** (vehículos, combustibles, destinos, peajes, técnicos,
  viáticos) y luego cree los viajes: las listas desplegables de los viajes se alimentan de
  esos registros.
- Haga **respaldos periódicos** del archivo `sistema_costo_viaje.db`.
- Use nombres **claros y sin abreviaturas** en los registros para identificarlos fácilmente
  al seleccionarlos en un viaje.
