# FEL Republica Dominicana

---

## Tabla de Contenido

1. [Info](#Info)
2. [Tecnologías](#Tecnologías)
3. [Instalación](#Instalación)
4. [Colaboración](#Colaboración)
5. [Control de versiones](#Versiones)

## Info

---

Aplicación dedicada a la firma de documentos electrónicos FEL para Republica Dominicana desde aplicación Aspel SAE 7.0 en adelante.

## Tecnologías

---

Un listado de las tecnologías utilizadas:

- [C#](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/introduction-to-wpf?view=netframeworkdesktop-4.8): Net Framework 4.6.1 WPF

## Instalación

---

Pasos para la instalación

```
$ git clone https://github.com/wmedinasam/FEL_RDOM.git
$ cd ../path/to/the/file
$ code.
```

## Colaboración

Crear una nueva rama y subir el código, crear un nuevo pull request y será revisado antes de hacer el merge.

- @wmedinasam
- @steeven781

## Versiones

#### v.1.0.0.1 - 04/11/2025

**Correcciones**

- Se agregó un serializable para el nodo de totales como extensión para mantener el orden de las propiedades y formato de decimales cuando se necesite.

#### v.1.0.0.2 - 05/11/2025

**Correcciones**

- Se modificó la lógica de la suma de los impuestos por linea y resultado colocado en los totales del XML.

#### v.1.0.0.3 - 13/11/2025

**Correcciones**

- Se agregó un nuevo tag en el nodo de Totales llamado "SaldoAnterior" para poder enviar en el request XML el descuento total de la factura.

#### v.1.0.0.4 - 24/11/2025

**Correcciones**

- Se le agrega la lógica al campo eNCF de las facturas fiscales como se usa en las facturas normales.

#### v.1.0.0.5 - 26/12/2025

**Correcciones**
- Se corrige el nodo de TablaTelefonoReceptor ya que el serializado no estaba realizandose de manera correcta.

#### v.1.0.0.6 - 26/12/2025

**Correcciones**
- Se añade una validación del campo TelefonoEmisor para que respete el formato de teléfono de RD (2{d}-d{2}-d{3}).
- Se corrige el orden en que es serializado el nodo Receptor den encabezado para todos los tipos de documento.

#### v.1.0.0.7 - 29/12/2025

**Correcciones**
- Se corrige el nodo de MontoPago dentro de la TablaFormasDePago para que siempre tenga 2 decimales truncados o si le falta un decimal le agregue un cero.

#### v.1.0.0.8 - 30/12/2025

**Correcciones**
- Se añaden todos los tags en el nodo de totales de la factura de credito fiscal.