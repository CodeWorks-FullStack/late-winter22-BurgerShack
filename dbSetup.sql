CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

/* SECTION TABLE DEFINITION */
CREATE TABLE IF NOT EXISTS burgers(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name TEXT NOT NULL,
  description TEXT,
  price DECIMAL(8, 2)
) default charset utf8;

/* CRUD */

/* POST */
INSERT INTO burgers 
(name, description, price)
VALUES
("Mick McBurger", "This is just a plate of nachos....", 14.54);

/* GET */
SELECT * FROM burgers;

/* GET BY ___ */
SELECT * FROM burgers WHERE id = 3;

/* PUT */
UPDATE burgers
SET
  name = "Jeremy and Jam",
  description = "This burger has Jalapeno Jam, and cat hair"
WHERE id = 7;


/* DELETE */
DELETE FROM burgers WHERE id = 6 LIMIT 1;


/* DANGER ZONE */
/* Remove all data from table */
DELETE FROM burgers; 

/* REMOVE ENTIRE TABLE */
DROP TABLE burgers;

/* REMOVE ENTIRE DB */
DROP DATABASE DevDatabase;