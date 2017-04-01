use lyy
create table utl(
                   id_admin varchar(50) primary key,
				   passe_admin varchar(30))

insert into utl values('admin','admin')
select *from utl
go
---- table de cercle de la regione safi
create table cercle(idcer int primary key,
					nomcer varchar(20))
go
create table colg(
                  
                  code_colg varchar(50) primary key ,
				  nom_colg varchar(50),
				   idcer int foreign key references cercle(idcer));
go

create table eleve(
                   codeEleve varchar(50) primary key,
				   nomEleve  varchar(50),
				   prenomEleve varchar(50),
				   nomElevefr varchar(50),
				   prenomElevefr varchar(50),
				   GenreAr   varchar(50),
				   Moyenne float,
				   code_colg varchar(50) foreign key references colg(code_colg));
				   select*from eleve
select nomEleve,prenomEleve,nomElevefr,prenomElevefr,Moyenne from eleve
insert into eleve values('a','a','a','a','a','a',12,'18516A')
----------------------------------------------------------------------------------------------------------------

insert into cercle values(1,'عبدة ')
insert into cercle values(2,'حرارة')
insert into cercle values(3,'جزولة')

select c.nom_colg from colg c,cercle cl where cl.idcer=c.idcer and cl.nomcer='عبدة'
select code_colg from colg where nom_colg

------------------------------------------------------------------------------------------------
insert into colg values( '25206X','قاسم أمين',1);

--------------
insert into colg values( '23701L','الرازي',1);
--------------------
insert into colg values( '23702M','ابن منظور',2);
----------
insert into colg values( '13997N','ابن رشد',1);
-------
insert into colg values( '13999R',' المنصور الدهبي',2);
-----------
insert into colg values( '18516A','عتمان ابن عفان',2);
-----------
insert into colg values( '19455W','تانوية الفاربي الإعدادية',3);
---------
insert into colg values( '19876D','إبن طفيل',3);
--------
insert into colg values( '19877E','إبن زيدون',1);
------
insert into colg values( '24576M','البحتري',1);
-----------
insert into colg values( '24577N','ابن حنبل',1);
-------------
insert into colg values( '24580S','هارون رشيد',3);

--------
insert into colg values( '24581T','أحمد أمين',1);
-----------------
insert into colg values( '24132E','ابن زهر',1);
--------------------
insert into colg values( '24133F','مولاي ادريس الأول',3);

-----------
insert into colg values( '25801U','السعدين',2);
insert into colg values( '26007T','الإمام الشافعي',2);
insert into colg values( '26337B','الكندي',3);		
----------------------------------------------------------------------------------------------
create table lyce(
                   code_ly varchar(50) primary key,
				   nom_ly varchar(50),
				   idcer int foreign key references cercle(idcer));
insert into  lyce values('14002U','الهداية الاسلامية',1)
insert into  lyce values('14009B',' مولاي اسماعيل',3)
insert into  lyce values('26006S',' نجيب محفوظ',1)
insert into  lyce values('14007Z',' ابن سينا',1)
insert into  lyce values('25806Z',' المعتمد بن عباد',1)
insert into  lyce values('14005X',' الفقيه الكانوني',1)
insert into  lyce values('25743F',' الثانوية التأهيلية الأمير مولاي عبد الله للأقسام الحضيرية',1)
insert into  lyce values('14003V','ابن خلدون ',1)
insert into  lyce values('25523S',' محمد بلحسن الوزاني',1)
insert into  lyce values('25522R','  الجاحظ',2)
insert into  lyce values('25089V',' ابن مولاي الحاج  ',1)
insert into  lyce values('14000S',' الحسن الثاني ',1)
insert into  lyce values('25009H','  المتنبي',1)
insert into  lyce values('23873Y',' صلاح الدين الايوبي ',1)
insert into  lyce values('14001T',' الشريف الادريسيى  الثقنية ',1)
insert into  lyce values('14004W','  الخوارزمي',1)

select *from lyce
create table bourse(
                   codeEleve varchar(50) primary key ,

				   nomEleve  varchar(50),

				   prenomEleve varchar(50),

				   nomElevefr varchar(50),

				   prenomElevefr varchar(50),

				   GenreAr   varchar(50),

				   Moyenne  varchar(50),
				 
				   nom_ly varchar(50));


				   		   select*from bourse