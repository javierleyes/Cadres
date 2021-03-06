## Notas EF 6

Entity states and SaveChanges
An entity can be in one of five states as defined by the EntityState enumeration. These states are:

Added: the entity is being tracked by the context but does not yet exist in the database
Unchanged: the entity is being tracked by the context and exists in the database, and its property values have not changed from the values in the database
Modified: the entity is being tracked by the context and exists in the database, and some or all of its property values have been modified
Deleted: the entity is being tracked by the context and exists in the database, but has been marked for deletion from the database the next time SaveChanges is called
Detached: the entity is not being tracked by the context
SaveChanges does different things for entities in different states:

Unchanged entities are not touched by SaveChanges. Updates are not sent to the database for entities in the Unchanged state.
Added entities are inserted into the database and then become Unchanged when SaveChanges returns.
Modified entities are updated in the database and then become Unchanged when SaveChanges returns.
Deleted entities are deleted from the database and are then detached from the context.

https://docs.microsoft.com/en-us/ef/ef6/saving/change-tracking/entity-state