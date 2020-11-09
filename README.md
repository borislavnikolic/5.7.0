# Important

Issues of this repository are tracked on https://github.com/aspnetboilerplate/aspnetboilerplate. Please create your issues on https://github.com/aspnetboilerplate/aspnetboilerplate/issues.

# ASP.NET Core & EntityFramework Core Based Startup Template

This template is a simple startup project to start with ABP
using ASP.NET Core and EntityFramework Core.

## Prerequirements

* Visual Studio 2017
* .NET Core SDK
* SQL Server

## How To Run

* Open solution in Visual Studio 2017
* Set .Web project as Startup Project and build the project.
* Run the application.

Cilj zadatka je razvoj web aplikacije koja će omogućiti operateru da za korisnika kreira ugovor koji će on potpisati kako bi se stvorili uslovi za instalaciju i korišćenje usluga Orion telekoma od strane korisnika.
Stranice za prikaz:
Potrebno je napraviti stranice za:
1.	Paket 
2.	Ugovor
3.	Ugovor štampa
4.	Početna stranica

1.	Paket
Stranica sadrži:
i.	Formu za kreaciju paketa:
o	Naziv – obavezno polje, slobodan unos svih karaktera.
o	Opis – obavezno polje, slobodan unos svih karaktera.
o	Cena – obavezno polje, definiše mesečnu cenu paketa, samo brojevi. Cena je izražena u dinarima.
o	Kategorija – obavezno polje, kategorija može biti:
	NET
	IPTV
	VOICE
o	Dugme snimi – po proveri ispravnosti popunjenih polja snima unete podatke u bazu
ii.	Tabelarni prikaz kreiranih paketa sa svim kolonama kao i sa dugmićima za brisanje i edit paketa. 
o	Opcija brisanja paketa daje popup sa potvrdom ili poništavanja tražene akcije
o	Opcija edit učitava unete podatke o paketu u formu i po snimanju ažurira tabelu
	Primer izgleda tabele:
Naziv	Opis	Cena (RSD)	Kategorija	Akcija
Internet	Internet paket brzine do 100 Mbps	1500	NET	Izmena	Brisanje
IPTV Sport	Sportski kanali, Arena, SportKlub, Euro Sport	450	IPTV	Izmena	Brisanje


2.	Ugovor
Stranica sadrži: 	
i.	Formu za kreaciju /edit ugovora – Ukoliko se do stranice došlo klikom na dugme „Kreiraj novi ugovor“ sa stranice POČETNA prikazaće se blank forma. Ukoliko se na stranicu došlo preko dugmeta edit postojećeg ugovora sa stranice POČETNA prikazivaće se forma popunjena podacima iz baze
o	 	Broj ugovora – prikazuje se samo u edit modu i predstavlja ID kolone iz tabele ugovor
o		Korisničko ime ( username ) –obavezno polje, slobodan unos sa mogućnošću unosa ( 	slova, brojeva kao i tačaka {.} ) Primer: pera.peric.
o		Trajanje ugovorne obaveze – obavezno polje, opseg vrednosti je: 12 meseci i 24 		meseca.
o		Popust – opciono polje, koje predstavlja procentualni popust celokupnog trajanja  ugovorne obaveze. Opseg vrednosti su brojevi od 0 do 100.
o	Gratis period – opciono polje, koje predstavlja početni gratis period ugovora. 
 Gratis perid je izražen u mesecima. Opseg vrednosti su brojevi od 1 do 6. Primer ukoliko je kreiran ugovor na 12 meseci i odabran gratis period 3 to znači da će ugovor prva 3  meseca biti gratis a sledećih 9 će se naplaćivati regularno. Cena ugovora (mesečne pretplate) računa se kao zbir cena paketa umanjen za popust koji je definisan u formi.
o	Polje za izbor paketa. Postoji ograničenje koji paketi se mogu pridodati ugovoru i objašnjeno je u delu USLOVI ZA KREACIJU UGOVORA. Napomena, potrebno je omogućiti da je za ugovor moguće vezati više paketa koji bi se dodavali jedan po jedan klikom na ikonicu +.
o	Status – (Aktivan/neaktivan) – u kreaciji ugovora jedini izbor koji može da se odabere je Aktivan. U edit modu može se promeniti status ugovora koji je kreiran. 
o	Dugme Snimi izmene

ii.	Istorija izmene ugovora – Tabelarni prikaz svih izmena za postojeći ugovor koji će se prikazivati samo u slučaju da je stranica u edit modu, odnosno da se do nje došlo klikom na IZMENI koje se nalazi na početnoj stranici. Istorija će prikazivati samo datum i vreme izmene ugovora, status kao i iznos mesečne ugovorne obaveze u trenutku snimanja izmene.
		Primer tabele:
Datum	Status	Suma
1900.01.01 00:00:000	Aktivan	2500
1901.01.01 00:00:000	Aktivan	2700
1902.01.01 00:00:000	Neaktivan	2700

iii.	Dugme „Štampa“ koje otvara stranicu „Ugovor štampa“
	Uslovi kreacije ugovora:
•	Obavezan uslov za kreiranje ugovora su paketi koji predstavljaju stavke ugovora. Na ugovor se može dodati više paketa ali iz različitih kateorija. Primer ( 1 NET paket, 1 IPTV paket, 1 Voice paket). Nije moguće dodati više kategorija paketa, znači ne može se dodati 2 NET paketa na 1 ugovor. 
•	Ugovor može sadržati max. 3 paketa ( 1 NET, 1 IPTV i 1 Voice paket). 
•	Korisnik ( korisničko ime) može da ima samo jedan aktivan ugovor, prilikom kreacije novog ugovora potrebno proveriti da li već postoji ugovor za uneti username i upozorenjem naglasiti da postoji aktivan ugovor sa linkom koji upućuje na formu za izmenu podataka tog već kreiranog ugovora. Neophodno je tom ugovoru izmeniti status u Neaktivan da bi novi mogao da se kreira.

3.	Ugovor štampa
Stranica za štampu ugovora sadrži sve elemente ugovora u display modu čitko raspoređene na stranici i spremne za štampu.
Primer izgleda stranice:
Ugovor o pružanju usluga
Osnovni podaci o ugovoru
Broj korisničkog ugovora:	12457
Korisničko ime:	Pera.peric
Trajanje ugovorne obaveze u mesecima	24
Gratis period u mesecima	0

Paketi i cena
Naziv	Kategorija	Cena
Internet 100	Net	1500
IPTV Kids	IPTV	500
Ring 100	VOICE	200
SUM	2200

4.	Početna stranica
Sadrži tabele:
1.	prikaz brojčano koliko trenutno ima aktivnih ugovora odnosno koliko ugovora je deaktivirano
2.	poslednjih 5 kreiranih ugovora - tabela treba da sadrži broj ugovora, username, period trajanja ugovorne obaveze, datum kreiranja, kao i dugme Izmeni, na čiji klik se otvara stranica Ugovor sa popunjenom formom podataka tog ugovora, odnosno dugme brisanje na čiji klik se otvara pop up forma sa potvrdom akcije.
3.	Izveštaj prihoda po svim aktivnim ugovorima ( koliko svaki ugovor donosi novca ukupno tokom trajanja ugovorne obaveze )
Primer tabele 1:
Trenutno aktivnih ugovora	Trenutno neaktivnih ugovora
15	7

Primer tabele 2:
Akcija	Broj ugovora	Username	Trajanje	Datum kreiranja
Izmena	Brisanje	15	Pera	12	1.1.1900 00:00:000
Izmena	Brisanje	14	Laza	24	1.1.1900 00:00:000
Izmena	Brisanje	13	Mika	24	1.1.1900 00:00:000
Izmena	Brisanje 	12	Zika	12	1.1.1900 00:00:000
Izmena	Brisanje	11	Joca	12	1.1.1900 00:00:000

Primer tabele 3:
Broj ugovora	Prihod (RSD)
1	12000
2	12000
7	24000
9	26000
10	48000
11	45000
12	70000
SUMA	307000


