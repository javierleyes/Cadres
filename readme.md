## Changelog

**01-04-19, Hash: e15263412f75c65c8bf67c4e68b969eb4e411ce4**

* Agrego archivos para docker
* Hash commit en footer

**30-03-19, Hash: c414b666faab036a612987970dd5f0b5253a2a49**

* Agrego validations en vista de varillas y calcular precio.
* Paginado de varillas

**27-03-19, Hash: 4e9f45e7e146906b17d188575c8f3f52e3ee27ea**

* Refactorizo vista Details de calcular precio, en dropdownlist con entity y binding automatic

**24-03-19, Hash: 6cc7275664280ae9e829373bd74910c537c8dc4a**

* Vista para calcular el precio de un marco ingresando sus medidas y su varilla correspondiente

**23-03-19, Hash: a9fdbce2d351404f5598ad991a0cd1d0d69c6007**

* Integración de Ninject con proyecto Web
* ABM básico de varilla

**17-03-19, Hash: df5134fc1e1f14f9940070ddd2b7e8bf5f734415**

* Agrego proyecto para assembler con AutoMapper, falta integrarlo con Ninject

**14-03-19, Hash: ffe3d1b63f00b44d6ca9f2451349b737a8e8c93f**

* Reestructuración de servicios
* Test Integración

**05-03-19, Hash: 9a5256597ae31fee7ac3898a06eda4c620ddb308**

* Reestructuración de proyecto
* Agrego test marco repository

**16-09-18, Hash: c8a76a65fde92c50118ed88a32d7fc62047f7a80**

* Dependency injection with Ninject (Final) en Test

**09-09-18, Hash: 483ecb812ddb467125d689e947efb637a0ded8f0**

* Dependency injection with Ninject (Partial)

**01-09-18, Hash: 019d65f6128119fa99be8b7925d680f5f894e742**

* Se implementa Filter para buscar en entidad Varilla y Pedido.

**25-08-18, Hash: 2f3ab964103a73ffee3353c5ed3c497e5d540901**

* Se implementan metodos Add y Update en GenericDAO (Cascade update #46). Mas info en Misc
* Se crea proyecto Assembler con implementación temporal.

**20-08-18, Hash: 045fb9deb127953518e1b15918f5b89bd7e0a142**

* Se crea entidad Comprador.
* Se crea entidad Marco, se desacoplado de la entidad Pedido.
* Refactorizacion de proyectos, se crea carpeta Base, en DAO y Service.
* Se incluye calculo de precio en MarcoService.
* Diagrama DER.
* Test Integración, con modalidad mas usual.

**12-08-18, Hash: 74ec0d0537f3d3781818db4af6827c37475a6013**

* Se implementa nueva arquitectura en DAO y Service (Supertype por capa con genericos) By Blaz77
* Se crea CadresContext By Blaz77
* Se agrega Entidad pedido (Entidad, DAO, Services, Test DAO y Test Service).
* Se agrega proyecto Base, contiene enumerados usados en la aplicación.
* Se agrego carpeta Common en el proyecto de Test con clase Utils para test.
* Se agrega clase EntityConverter en el proyectos entidades, realizar las conversiones entre entidad y DTO provisoriamente.
