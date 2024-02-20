Тестовое задание. Представляет из себя REST API сервис с методами create/update/delete протестированный с помощью Postmen. 

Стэк:
C#
ASP.NET
EF Core
PostgreSQL

SQL скрипты согласно задания:
выборки всех сотрудников: SELECT "SurName" FROM "Emploees”

сотрудники у кого зп выше 10000: SELECT "SurName" FROM "Emploees" where "Salary" > 10000 

удаление сотрудников старше 70 лет, 
DELETE FROM "Emploees"
WHERE Extract(YEAR FROM (AGE(NOW(),"BirthDay") )) > 70

обновление зп до 15000  тем сотрудникам, у которых она меньше.
UPDATE "Emploees" SET "Salary"  = 15000
WHERE "Salary" < 15000
