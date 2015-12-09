Razvoj aplikacija u programskom jeziku C# – Projekt

1.	Osnovna ideja projekta

Napraviti programsku podršku za igranje društvene igre pogađanja pojmova, kako bi se olakšalo igranje iste.
 
2.	Opis igre

[Tradicionalan način]
Igra pogađanja pojmova se igra u parovima (2 – 5 para). Cilj igre je sakupiti što veći broj bodova. Igra započinje tako da se na male papiriće napiše što više riječi koji se onda presavijaju i stavljaju u neku posudu. Podijele se parovi. Svaki par ima 90s  za pogađanje što više pojmova na papirićima. Jedan član para objašnjava drugom pojam na papiriću sve dok onaj drugi ne pogodi. Svaki pogođeni pojam nosi jedan bod. Tako se izmjenjuju parovi sve dok ne ponestane papirića. Kada na red dođe par koji je već pogađao zamjenjuju se uloge, te onaj koji je objašnjavao sada pogađa i obrnuto. Par sa najviše pogođenih pojmova pobjeđuje.

Pravila za objašnjavanje:

Dozvoljeno:
	Reći od koliko se riječi sastoji pojam
	Reći početno/krajnje slovo/slog preko neke reference (npr. [za pojam Britva] ovaj pojam počinje na isto slovo kao Beduin)
	Podijeliti riječ/riječi na dijelove i objašnjavati svaki posebno (npr. [za pojam Transformator] moguće objašnjavati posebno dijelove Trans, Forma, Tor)
	Ako se neka riječ ne može pogoditi, dozvoljeno je preći na slijedeću (ali nije dozvoljeno biranje riječi, svaka se mora probati objasniti) 
Nije dozvoljeno:
	Koristiti korijen riječi
	Naziv za tu riječ/pojam na stranom jeziku
	Nisu dozvoljene rime

[Pomoću aplikacije]
Igra pogađanja pojmova se igra u parovima (2 – 5 para). Cilj igre je sakupiti što veći broj bodova. Igra započinje pokretanjem aplikacije koja ima vlastitu bazu riječi i pojmova. Prije početka igre potrebno je odabrati težinu (easy, medium, hard, extreme) koja se očituje u udjelu teških, srednje teških i jednostavnih riječi i penalizacije za proteklo vrijeme(objašnjeno kasnije), broj parova (tj. timova – omogućiti imenovanje timova, default imena su Tim 2,..,5). Aplikacija ima ugrađeno odbrojavanje vremena (različito za različite težine), nakon čijeg isteka je zabranjeno pogađanje, te aplikacija zabranjuje daljnji unos (označavanje koje su riječi pogođene). Nakon početka igre iz baze podataka se vade riječi/pojmovi pseudoslučajnim odabirom (sve riječi imaju oznaku težine za pogoditi, tako da npr. na extreme mode će sve riječi biti iz kategorije hard, broj riječi koje se pogađaju također ovisi o modu igre), te započinje odbrojavanje vremena. Nakon što tim pogodi riječ označuje se u aplikaciji da je ta riječ pogođena, te se na temelju težine riječi i proteklog vremena izračunavaju bodovi(što je neka riječ pogođena kasnije u vremenu nosit će manje bodova - penalizacija). Postupak se provodi dok se sve riječi ne pogode ili dok ne istekne vrijeme. Ako su sve riječi pogođene dodaju se bonus bodovi ovisno o vremenu koje je preostalo. Ako nisu sve riječi pogođene slijedi penalizacija gdje se oduzimaju bodovi ovisno o težini riječi koje nisu pogođene. Tim s najviše bodova pobjeđuje. 
[Opcionalno] 
Omogućiti mode igre u kojem se riječi pogađaju/crtaju/objašnjavaju pantomimom. Prilikom generiranja popisa riječi za pojedini tim, svaka riječ uz sebe sadrži oznaku na koji način se mora objasniti (ovaj način zahtjeva da sve riječi imaju oznaku da li ih je moguće nacrtati/objasniti pantomimom). 
Omogućiti singleplayer – samo za jedan tim bez bodovanja, samo za zabavu. 
[Dodatne opcije]
Omogućiti dodavanje vlastitih pojmova u bazu podataka, pri čemu je nužno unijeti sve podatke koji se traže (da li se riječ može opisati pantomimom/nacrtati, težina i sl.).

3.	Profil

Windows 10 aplikacija. Naziv aplikacije još uvijek nepoznat (to je najteže za smisliti). 

4.	Razlog odabira projekta

Prijeko potrebna aplikacija jer je igra 'jednostavno cool', te ju igramo stalno ali smo ljenčine i ne želimo pisati pojmove na papiriće. Ne postoji takva aplikacija na Windows Storeu.
 
5.	Raspodjela posla

Pošto nas ima 3 u grupi, jedna od nas će se brinuti o izgledu aplikacije, druga o funkcionalnostima vezanima uz algoritme izračunavanja bodova i unosima korisnika, dok će treća obrađivati sve vezano uz bazu podataka. Moguće je djelomično preklapanje poslova.

U ovom projektu sudjeluju: Stella Coumbassa, Josipa Popović, Iva Topolovac
