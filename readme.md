## Changelog

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
