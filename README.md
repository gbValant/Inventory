# Inventory
Code Exercise For Valant

Final Status after 4 hours
Items 1 & 2 complete and unit tested, but no integration tests written (project and first stub in place)
Item 3 has scaffolding but no actual functionality
Item 4 not complete due to open questions saved for last

Why go through the trouble of injecting the simple providers into the controller?
Testability in the face of ambibuity, my schedule didn't allow for a deep dive and correspondence around the specific requirements, but my solution allows for extension when definitions become available while still making mockable testable progress in known areas.

I probably burned more time than I should have in setting up the in memory repository (in the "provider" object) for concurrency, but it was an interesting exercise and I didn't want the test framework itself to run into synch issues. The remove case still needs revisited and has a todo so that if an unexpected state is encountered a 409 conflict could be thrown.

Basically only got far enough on the notifications to make them mockable, not implemented. Had I corresponded earlier, I would have inquired as to whether expiration was expected to be immediate and accomplished by some sort of Interval event in the inmemory data store or if some other intent for "expiry" checking was intended. I could see the in memory timer events getting way out of control really fast.

I didn't add anything security related here, a couple of options would be to use OWIN Security and tickets around the endpoints and marking them with the proper attributes. Another option if this was an internal system would be to just use AD security in IIS if all of the users were domain participants, etc.

The biggest assumption made here was that more than one of the same item could exist in inventory. Though that wasn't specifically mentioned in the requirements, I made accommodations for it which kind of make the Item endpoint sub-optimal since you can only get a list of items in inventory but because the quantity is currently in a different object, a new Inventory endpoint would be needed to expose counts. I stayed pure int he controller to the models I created, but would likely refactor this to just be an InventoryItems endpoint so that the count could be included. From a strictly RESTful standpoint this would kind of muddy up the Post and Put since item counts wouldn't make sense as part of the resource itself when performing a create or update operation.

I'd love to take the time to delve deeper into these questions if you're interested in chatting about what I've put together here.

Thanks a million for the opportunity to play around with this and I hope my delayed engagement of the challenge isn't a major inconvenience.

Gary

