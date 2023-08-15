INSERT INTO Categories(categoryName)
VALUES ('Didactics');

INSERT INTO Categories(categoryName)
VALUES ('Programing');


INSERT INTO Categories(categoryName)
VALUES ('Healthy');


INSERT INTO Books(title,bookDescription,publishDate,price,idCategory)
VALUES ('The Great Novel', 'An epic tale of love and adventure', '2023-08-13',  29.99, 1),
('Mystery Unveiled', 'A thrilling mystery that keeps you on the edge', '2022-05-20', 24.95, 2),
('Fantasy Realm', 'Journey into a world of magic and creatures', '2021-11-07',  19.99, 3);

INSERT INTO Books (title, bookDescription, publishDate, price, idCategory)
VALUES
('Healthy Cooking', 'Delicious and nutritious recipes for a healthier you', '2022-08-10', 16.75, 3);

CREATE TABLE Review (
	ReviewId INT NOT NULL IDENTITY PRIMARY KEY,
	VoteName NVARCHAR(100) NOT NULL,
	StarNumber INT  NOT NULL,
	Comment NVARCHAR(3000) NOT NULL,
	idBook INT NOT NULL,
	CONSTRAINT Fk_Review_Book_idBook FOREIGN KEY (idBook) REFERENCES Books (idBook)
);

CREATE TABLE OfertPrice(
	PriceOfertId INT IDENTITY NOT NULL,
	NewPrice  NUMERIC(7,2) NOT NULL,
	PromotionalText NVARCHAR(120) NOT NULL,
	idBook INT NOT NULL
);
ALTER TABLE OfertPrice
ADD CONSTRAINT Pk_OffertPrice PRIMARY KEY(PriceOfertId);

-- relacion 1 a 1
ALTER TABLE OfertPrice
ADD CONSTRAINT Uc_OffertPrice_idBook UNIQUE(idBook);

ALTER TABLE OfertPrice
ADD CONSTRAINT Fk_OfertPrice_Books FOREIGN KEY(idBook) REFERENCES dbo.Books(idBook) ON DELETE CASCADE;

CREATE TABLE Author(
	AuthorId INT IDENTITY NOT NULL,
	NameAuthor NVARCHAR(120) NOT NULL,
	WebUrl NVARCHAR(120)  NULL
);

ALTER TABLE Author
ADD CONSTRAINT Pk_Autjor PRIMARY KEY(AuthorId);

CREATE TABLE AuthorBook(
	BookAuthorId INT NOT NULL IDENTITY,
	authorId INT NOT NULL,
	idBook INT NOT NULL,
	Orden INT NOT NULL

) 

ALTER TABLE AuthorBook
 ADD CONSTRAINT Pk_AuthorBook PRIMARY KEY(BookAuthorId); 

ALTER TABLE AuthorBook 
 ADD CONSTRAINT Uk_AuthorBook_Book_Author UNIQUE (authorId,idBook);


ALTER TABLE  AuthorBook 
 ADD CONSTRAINT Fk_AuthorBook_Author FOREIGN KEY (authorId)
 REFERENCES Author (authorId) ON DELETE CASCADE;


 ALTER TABLE  AuthorBook 
 ADD CONSTRAINT Fk_AuthorBook_Book FOREIGN KEY (idBook)
 REFERENCES Books (idBook) ON DELETE CASCADE;
