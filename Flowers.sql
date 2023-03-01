DECLARE @Flowers TABLE(Name nvarchar(20))
INSERT INTO @Flowers
VALUES ('Rose'),
('Tulip'),
('Daisy'),
('Forget-me-not'),
('Lilac'),
('Narcissus'),
('Camomile'),
('Lily of the valley')



SELECT
f1.Name AS 'Name 1', 
f2.Name AS 'Name 2', 
f3.Name AS 'Name 3', 
f4.Name AS 'Name 4',
f5.Name AS 'Name 5'
FROM @Flowers f1, @Flowers f2, @Flowers f3, @Flowers f4, @Flowers f5
WHERE  f1.Name < f2.Name
AND f2.Name < f3.Name
AND f3.Name < f4.Name
AND f4.Name < f5.Name

/* 
Получилось 56 строк. 
Всего способов выбора 5-ти элементов из 8-ми, если порядок не важен, составляет 56. 
Вывод: решение верное
*/
