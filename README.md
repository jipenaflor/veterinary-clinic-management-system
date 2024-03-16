# Veterinary Clinic Management System
A RESTful CRUD API for managing the records of a pet clinic using ASP.NET, Entity Framework, and PostgreSQL.

The application defines the following CRUD APIs:

## Owners
| Method | Url							 | Description			 | Request Body                |
|--------|-------------------------------|-----------------------|-----------------------------|
| GET    | /api/Owners/					 | Get all pet owners	 |							   |
| GET    | /api/Owners/{id}				 | Get owner by id		 |							   |
| POST   | /api/Owners					 | Create owner   		 |name, address, contact number|
| POST   | /api/Owners/{id}/Pets/{PetId} | Add pets to owner	 |							   |
| PUT    | /api/Owners/{id}				 | Update owner by id	 |name, address, contact number|
| DELETE | /api/Owners/{id}				 | Delete owner by id	 |							   |
| DELETE | /api/Owners/{id}/Pets/{PetId} | Remove pet from owner |							   |

## Veterinarians
| Method | Url					   | Description		   | Request Body       |
|--------|-------------------------|-----------------------|--------------------|
| GET    | /api/Veterinarians/	   | Get all veterinarians |					|
| GET    | /api/Veterinarians/{id} | Get vet by id		   |					|
| POST   | /api/Veterinarians	   | Create veterinarian   |name, contact number|
| PUT    | /api/Veterinarians/{id} | Update vet by id	   |name, contact number|
| DELETE | /api/Veterinarians/{id} | Delete vet by id	   |					|

## Pets
| Method | Url									| Description			  | Request Body					   |
|--------|--------------------------------------|-------------------------|------------------------------------|
| GET    | /api/Pets/							| Get all clinic patients |									   |
| GET    | /api/Pets/{id}						| Get pet by id	          |									   |
| POST   | /api/Pets							| Create pet   	          |name, species, breed, sex, birthdate|
| POST   | /api/Pets/{id}/Vaccines				| Add vaccines to pet  	  |name, date administered			   |
| POST   | /api/Pets/{id}/Veterinarians/{VetId} | Add pets to owner       |									   |
| PUT    | /api/Pets/{id}						| Update pet by id        |name, species, breed, sex, birthdate|
| DELETE | /api/Pets/{id}						| Delete pet by id        |									   |
| DELETE | /api/Pets/{id}/Vaccines/{VaxId}		| Remove vaccine from pet |									   |
| DELETE | /api/Pets/{id}/Veterinarians/{VetId}	| Remove vet from pet     |									   |