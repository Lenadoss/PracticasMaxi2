SELECT * FROM ELEMENTOS

SELECT numero, nombre, descripcion, urlimagen FROM POKEMONS;

UPDATE POKEMONS SET UrlImagen = '' WHERE Numero = 15;

SELECT numero, nombre, p.descripcion, urlimagen, e.descripcion Tipo, d.Descripcion Debilidad FROM POKEMONS p, ELEMENTOS e, ELEMENTOS d WHERE p.IdTipo = e.Id and p.IdDebilidad = d.Id;