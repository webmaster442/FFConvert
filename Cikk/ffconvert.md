# Írjunk FFMpeg rontend-et

Az FFMpeg egy remek, igen nagy tudású program, de finoman fogalmazva is megválogatja a barátait, ha a felhasználó barátságról van szó. Ezért gondoltam készítek hozzá egy n+1. frontend implementációt.

## De Miért?

Az első egyértelműen felmerülő kérdés, hogy miért ír ilyet az ember, ha már van n+1 megoldás? Igazából két okból kezdtem bele a projektbe. Az első ok szimplán az, hogy amiket kipróbáltam azok túlkomplikáltak és végső soron nem tetszettek. A másik ok pedig a tanulás. Rengeteget lehet tanulni egy ilyen projektből és nem utolsó sorban cikk alapanyagnak sem utolsó a téma.

## Mi az a FFMpeg?

A másik egyértelműen felmerülő kérdés, hogy mi is az az FFMpeg? A projekt hivatalos leírása alapján (https://ffmpeg.org/) “Egy komplett, platformfüggetlen megoldás hang és videó rögzítésére, konvertálására és streamelésére”.

Ebből azonban nem derül ki teljesen, hogy mi is ez. Én inkább úgy fogalmaznék, hogy az FFMpeg egy olyan önálló kodek, program csomag, ami mindenből mindenbe is konvertálni tud. Túlzás nélkül valóban állíthatom, hogy az FFMpeg tényleg bármilyen formátummal elboldogul, legyen az bármennyire egzotikus is. Erre egy jó példa, ha a Quake III engine által használt ROQ formátumból szeretnénk WMV-be konvertálni, azt is megoldja. Természetesen az egzotikus formátumok mellett támogat minden modern megoldást is.

Az FFMpeg univerzalitását és népszerűségét szerintem jól leírja, hogy a youtube videó feltöltő backend részén is ez dolgozik, illetve a népszerű VLC player mögött is ez a kodek dolgozik. További előnye, hogy hatalmas hardver támogatással rendelkezik. Ha van a gépünkben egy “krumplinál” nagyobb számítási teljesítménnyel rendelkező Nvidia vagy AMD grafikus kártya, akkor az ezekben megtalálható hardveres videó dekódolót használatba tudja venni, illetve ha a hardver tud kódolni is, akkor ezt is igénybe tudja venni.

Ez a gyakorlatban azt jelenti, hogy ha van mondjuk egy GTX960-nál újabb videó kártyánk, akkor HD (h264) és UHD (h265) kódolást minimális (1-5%) CPU használat mellett el tudunk végezni.

## FFMpeg gyorstalpaló

Az FFMpeg, mint említettem leginkább egy kodek, amit más programokba, videólejátszókba lehet építeni. Többek között ez van beépítve a VLC-be, az Mplayer-be és az MPV lejátszóba is. Ezen felül azonban használható önálló parancssori programként is. Ezentúl, ha az FFMpeg szó szerepel a cikkben, akkor a parancssori program értendő alatta.

Eltérően a hagyományos programoktól FFMpeg esetén nem jó, ha az ember valamelyik „stabil” kiadást használja. Ennek az az oka, hogy a program fejlesztése viszonylag gyorsan pörög és a stabil kiadás Debian szint szerinti stabil. Ebből adódóan nem sűrűn van ilyen kiadás. Legutóbb 2016-ban jött ki a 3.0-ás verzió.

Éppen ezért mindig a legfrissebb változat használata célszerű. Ez azonban nem azt jelenti, hogy egy olyan programot kell használnunk, ami az esetek nagy részében a feladat elvégzése helyett összeomlik. A közvetlen a Git tárolóból beszerezett és fordított programok is ugyan olyan stabilak, mint a tényleges kiadások. Ritkán fogunk összeomlással találkozni.

Ez alapján felmerülhet a kérdés, hogy akkor miért nincs sűrűbben stabil kiadás? Ennek az oka talán abban kereshető, hogy az FFMpeg rengeteg egzotikus formátumot támogat. Ezek támogatása sok esetben specifikáció hiányában reverse engineeringgel történik, ami azt jelenti, hogy a kodek eredeti binárisa alapján vagy rosszabb esetben a kódolt médiafájl alapján próbálják a fejlesztők kitalálni, megérteni, hogy hogyan is működik a kódolás és hogyan lehet reprodukálni azt. Ez egy időigényes folyamat és amíg egy kodek, ami a támogatott listában van nem véglegesedik, addig nem jelölik stabilnak a verziót.

Mivel a kodekek nagy része reverse engineeringgel fejlesztett és a világ másik részén létezik szoftver szabadalom, ezért az FFMpeg-et alapvetően forráskódban terjesztik. Ebből bináris, futtatható programot a felhasználónak kellene fordítania. Azért csak kellene, mert léteznek emberek, akik fordítanak binárist, de hivatalos FFMpeg által kiadott bináris nem létezik. Windows esetén, ha magunk akarunk fordítani binárist, akkor a https://github.com/m-ab-s/media-autobuild_suite bach szkript egész jól automatizálva, interaktívan végigvezet bennünket a folyamaton, hogy ne kelljen bajlódnunk a függőségek és a megfelelő fordítók, segédprogramok beszerzésével.

Ha ezt a módszert választjuk, akkor az előnye az, hogy egy testre szabott FFMpeg binárist kapunk, ami valóban azt tudja amit szeretnénk. De ennek az az ára, hogy nagyjából ~30GiB szabad helyre és processzor típustól függően legalább 3-4 óra szabad időre lesz szükségünk az első alkalommal.

Egy másik módszer, hogy binárishoz jussunk az az, hogy más által fordított binárist használjunk. Ennek a hátránya, hogy a bináris tudását nem mi választjuk meg, de csak szimplán le kell töltenünk és már használható is. Ilyen letöltési lehetőségeket a  projekt hivatalos oldala (https://www.ffmpeg.org/download.html) is kínál. Én a https://www.gyan.dev/ffmpeg/builds/ oldalról szoktam binárist beszerezni, mivel ezek a binárisok tartalmazzák az Nvidia kártyák használatba vételéhez szükséges kódokat is.

Hátránya ezeknek a binárisoknak, hogy ezek úgynevezett statikus build-ek. Ez azt jelenti, hogy osztott komponensek nélkül, önállóan is használható EXE fájlokat tartalmaznak. Ez papíron jól hangzik, de mint mindennek, ennek is meg van az ára.

Ez az ár pedig a tárhely. Egy ilyen ffmpeg.exe méretete simán 80-100MiB körüli, mivel minden benne van az egy darab EXE fájlban. A probléma csupán az, hogy szükségünk van az ffprobe.exe-re is.

Az ffprobe egy média típus felismerő program, ami információkat tud szolgáltatni a médiafájlról. Például olyanokat, hogy milyen hosszú az adott média, mivel és mikor lett kódolva, stb…

Média konvertálás esetén nem feltétlen van erre szükségünk, de sajnos egy funkció miatt mégis szüksége lesz rá a frondendünknek. Ez pedig a hossz lekérdezése. Sajnos az FFMpeg segítségével nem kérdezhető le egy médiafájl hossza. Erre az információra lényegében azért van szükségünk, hogy majd szép folyamatjelzőt tudjunk rajzolni a jelenlegi állapotról.

Szóval egy statikus ffmpeg build (ffmpeg.exe és ffprobe.exe) páros mérete simán elérheti a 200MiB méretet, míg ez dinamikusan betölthető és megosztható komponensek (DLL fájlok) használatával jóval kevesebb lenne, de valamit valamiért.

## Az FFMpeg használata és betekintés a problémakörbe

A program alapvető használata nem bonyolult, de hamar el lehet veszni a különböző beállításokban.  A két legfontosabb argumentum amit mindenképpen meg kell határoznunk az a bemeneti fájl és a kimeneti fájl.

A bemeneti fájl a `-i` kapcsoló segítségével adható meg, a kimenet pedig az első fájl lesz, ami kapcsolók nélkül szerepel. Ez a gyakorlatban így néz ki:

```bash
ffmpeg -i be.wav ki.mp3
```

A fenti parancssor már működőképes, mivel az mp3 egy olyan konténer formátum, ami csak mp3 kódolt hanganyagot tartalmazhat, ezért nem kell meghatároznunk a kodeket.

Ha olyan konténer formátumot használnánk, ami többféle kódolást is támogat, akkor a `-c:a` kapcsoló segítségével meg kellene határoznunk a használni kívánt kódolót. Például ha a `be.wav`˙fájlunkat Apple losless formátumba szeretnénk alakítani, akkor a következő parancsot kellene beírnunk:

```bash
ffmpeg -i be.wav -c:a alac ki.m4a
```

Egyes formátumok esetén szükségünk lesz meghatározni a bitrátát is. Erre a `-b:a` és `-b:v` opció alkalmazható audió és videó esetén. Videó kódolót ezen logika mentén a `-c:v` opcióval tudunk meghatározni.

Egy speciális konverzió, az úgynevezett muxolás. Ez azért speciális, mert nem kódoljuk újra a fájlt, csupán konténer formátumot váltunk alatta. Például ha van egy AVI fájlunk, amit át szeretnénk alakítani MKV-be, akkor az alábbi parancsot adhatjuk ki:

```bash
ffmpeg -i be.avi -c:a copy -c:v copy ki.mkv
```

A `copy` kodek név jelzi az ffmpeg számára, hogy másolni szeretnénk. Itt megjegyzem, hogy az AVI és az MKV a két olyan joker konténer, ami bármit is tartalmazhat, míg mondjuk az MP4 esetén limitálva vannak a lehetőségek.

Ha lehetőségünk van rá, akkor kerüljük az AVI fájlok használatát, mivel ezen formátum képtelen 2GiB méret fölött működni. 

Egyes formátumok esetén például rögzítve van a videó kodek és a használható hang kodek is. Ilyen például a WMV, de például a DVD formátum is. A DVD esetén van némi mozgástér, de nem sok. Éppen ezért, ha DVD lejásztó kompatibilis Mpeg2 fájlt szeretnénk kódolni, akkor erre egy külön kapcsolót biztosít az FFMpeg:

```bash
ffmpeg -i be.mkv -target pal-dvd ki.mpeg
```
Ez a hangot AC3 kódolással tárolja, valamint a videót olyan felbontással és kódolással, hogy egy PAL szabványos DVD lejátszó gond nélkül boldoguljon vele. Ez a kódolás változó bitrátát fog alkalmazni úgy, hogy 2 óra videó és hang ráférjen egy egyrétegű DVD lemezre.

Ez csak egy volt az FFMpeg egzotikus képességeiből, de nézzünk egy másik, hasznos gyakorlati példát: A telefonunk által rögzített HD videót szeretnénk kisebb méretűvé konvertálni (h.265 formátumba) hardver gyorsítással, úgy hogy csak a képet tömörítjük újra. Ebben az esetben, ha Nvidia kártyánk van, akkor valami hasonló parancsot adhatnánk meg:

```bash
ffmpeg -hwaccel nvdec -i telefon.mp4 c:v hevc_nvenc -preset slow -c:a copy ki.mp4
```
Mint látható, itt már bonyolódik a parancssor és még csak a felszínt kapargatjuk. A programunk abban fog segíteni, hogy ezt a rengeteg opciót, ami rendelkezésünkre áll egyszerűsíti előre definiált beállításokkal (preset), hogy ne kelljen ezt a rengeteg kapcsolót és mindent megjegyeznünk és fejben tartanunk.

## Mi az a frontend?

Jelen kontextusban a frontend egy olyan programot jelent, ami program használatát könnyíti meg. Az FFMpeg alapvetően egy parancssoros program. Attól függően, hogy miből mibe hogy szeretnénk konvertálni, különböző argumentumokkal kell felhívni. Ezeknek az argumentumoknak a száma és komplexitása formátumonként igen eltérő tud lenni. A program jól van dokumentálva a https://ffmpeg.org/documentation.html címen, de ez több száz oldal nagyságrendet is jelenthet. Éppen ezért ha ritkán használja az ember, akkor inkább kínszenvedés a boldogulás vele, mert minden esetben a kézikönyv olvasása szükséges.
Ezen szeretnék változtatni úgy, hogy készítek egy parancssoros programot, ami leegyszerűsíti a használatot.

## Elvárások a programmal szemben

A parancssorra a választásom azért esett, mert mostanában a fejlesztői irány a parancssoros alkalmazások felé mozdult ismételten el, továbbá a UI design jelen alkalmazás esetén annyi plusz munkát jelentene, hogy nem feltétlen érné meg számomra. Alapvetően a program fő felhasználója én leszek, de a későbbiekben nem zárkózom el a UI létrehozásától sem.

A parancssornak meg van az az előnye, hogy a tipikus felhasználói munkamenetet gyorsan lehet definiálni mockup és egyéb “komplikációk” nélkül.

Parancs szintaxis tekintetében a következő viselkedésre gondoltam:

program [bemenet] [preset] [kimeneti könyvtár]

A program neve jelenleg még képlékeny, illetve nem is lényeges. Ami viszont lényeges, hogy a [bemenet] mi lehet. Ez lehet egy fájl relatív vagy abszolút elérési útvonallal (pl: ..\foo.wav vagy c:\foo.wav) vagy egy DOS helyettesítő karaktert tartalmazó név abszolút vagy relatív elérési útvonallal. (pl.: ..\track*.wav vagy c:\inputs\*.wav)

A pereset egy előre definiált beállítás, ami név alapján azonosított. Ez lényegében leírja az FFMpeg program számára átadandó parancssort behelyettesítve a bemeneti fájlt és a kimeneti fájlt.

A kimeneti fájl a kimeneti könyvtár és bemenetként kapott fájl nevéből határozható meg, valamint ebbe beleszólhat még a preset által definiált kiterjesztés. Pl. Ha a bemeneti fájl c:\foo.wav volt, a kimeneti könyvtár pedig a d:\output és a preset kiterjesztése mp3, akkor a kimeneti fájl a d:\output\foo.mp3 fájl lesz.

A presetek esetén elvárás, hogy interaktív bemenetre is adjanak lehetőséget. Például ha mp3-ba szeretnék konvertálni, akkor a konzolon bemenetként kérdezze meg a program, hogy milyen bitrátával szeretnék konvertálni. Ez azt segíti elő, hogy ne kelljen redundánsan több presetet definiálni.

Mivel a felhasználói bemenet bármi lehet, egy minimális validáció és konvertálási lehetőséggel is rendelkeznie kell a programnak. Erre szintén egy példa az mp3 kódolás, ahol a bitráta egy megadott halmazból kerülhet ki, vagyis nem szabadon választható.

További komplikáció, hogy ezek a paraméterek lehetnek opcionálisak is, vagyis elképzelhető, hogy nem adja meg őket a felhasználó. Ebben az esetben a generálandó FFMpeg parancsorozatba nem szabad ezeknek a paramétereknek az értékét behelyettesíteni.

Attól, hogy valami parancssoros, az nem azt jelenti, hogy nem kellene ennek felhasználóbarátnak lennie. Ez a gyakorlatban azt jelenti, hogy a program rendelkezzen súgó felülettel, vagy help kapcsolóval, ami az alapvető használatot elmagyarázza, illetve ugyanez a súgó felület biztosítson leírást a különböző presetektről is.

Tehát ha a programot a help argumentummal indítom el, akkor elvárás, hogy az alapvető használatot és a támogatott presetek listáját sorolja fel. Azonban ha a help mp3 argumentumokkal van elindítva, akkor az mp3 preset leírását jelenítse meg, illetve azt, hogy milyen bemeneteket fog majd kérni a program.

## Nem funkcionális követelmények

A nem funkcionális követelmények közül a legfontosabbak számomra:

.NET 6 és C# 10
FFMpeg és függőség programok elérési útvonala meghatározható legyen
S.O.L.I.D. elvek és tesztelhetőség szem előtt tartása.
Külső függőségek (Nuget) minimalizálása
Nyílt forráskód MIT licenc szerint
Github a forrás tárolására és a CI/CD lehetőségek kihasználása

# Vágjunk bele!

Egy új projekt kezdésekor mindig érdekes téma, hogy hogyan is kezdjünk neki, hogyan is épüljön fel a szoftver. Ilyen esetben egy lehetőség, hogy részletesen megtervezzük a szoftver felépítését, majd kódolunk. Ez a fentről lefelé tervezési mód. Én személy szerint inkább az alulról felfelé tervezési módot preferálom és használom. Ez az előző ellentettje. A nagy képre fókuszálás helyett a kisebb alkotó egységeket helyezem előtérbe. 

Mindkét módszernek megvannak az előnyei és buktatói is. Az általam preferált módszer buktatója, hogy ha kellő mennyiségű figyelmet nem kap a nagy kép időközönként, akkor nagyon félre tud menni az alkalmazás felépítése. A felülről lefelé módszer hátránya pedig az, hogy ha csak a nagy képre fókuszálunk, akkor a komponensek közötti interakciót szem előtt tartva bekorlátozhatjuk a rendszert túlságosan, ami végeredményben egy “jó” architektúrát adhat, minimális kreativitással. Ez elsőre jónak hangzik, de lélekörlő tud lenni egy ilyen alkalmazás fejlesztése.

Éppen ezért a “jó” tervezés valahol a kettő között rejlik: Tisztázzuk a fontos részleteket, a többi meg majd jön.

Ilyen fontos részlet például, hogy a frontendünkben az FFMpeg elindítása a megfelelő paraméterekkel szétbontható apróbb lépésekre. Ami pedig felbontható apróbb lépésekre, ott egy jó tervezési minta lehet a Chain of Responsibility.

Egy másik fontos részlet a tesztelhetőség és a S.O.L.I.D miatt a dependency inversion és az Interface segregation. Ez gyakorlatban azt jelenti, hogy a fontosabb komponensek között interfész függőségek legyenek. Ez azt segíti elő, hogy a tesztelés közben ezek a komponensek könnyen helyettesíthetőek lesznek.

Az utolsó tisztázandó részlet a rétegezés, hogy mégis mi hogyan függhet egymásra. Mivel az alkalmazásnak nem célja, hogy gigantikusra nőjön, ezért a szimpla rétegelt architektúra valószínűleg bőven jó lesz a céljainkra. Persze előfordulhat, hogy mégsem, de ez már a jövő Gábor problémája lesz.

## Parancsor feldolgozása

Az első komponensek amiket meg tudunk alkotni az a parancssorra vonatkoznak, illetve az ott kapott argumentumok feldolgozására és tárolására.

A tárolásra az Arguments osztályt készítettem el, ami lényegében az alkalmazásunk belépési pontjának (Main metódus) a shell által szolgáltatott argumentumok tömbjét csomagolja be és lehetőséget ad ezeknek a nevesített lekérdezésére, így nem kell szórakoznunk a tömb megfelelő indexű elemének olvasgatásával, meg a null ellenőrzéssel.

Ez az osztály a DomainObjects rétegben kapott helyett. Ez a réteg lesz felelős a program logikáját leíró adatstruktúrák tárolásáért

```csharp
namespace FFConvert.Domain;

internal sealed class Arguments
{
    private readonly string[] _arguments;

    public int Count => _arguments.Length;
    public string FileName => _arguments.Length >= 1 ? _arguments[0] : string.Empty;
    public string PresetName => _arguments.Length >= 2 ? _arguments[1] : string.Empty;
    public string OutputDirectory => _arguments.Length >= 3 ? _arguments[2] : string.Empty;

    public Arguments(string[] arguments)
    {
        _arguments = arguments;
    }
}
```

Az objektum orientált paradigma lehetővé tenné számunkra, hogy az adatot és a hozzá kapcsolódó logikát keverjük. Azonban ez a gyakorlatban nem feltétlen a legjobb ötlet. Mégpedig azért, mert könnyű átesni a ló túloldalára és úgynevezett GOD Classokat létrehozni. Ezek az osztályok tipikusan a tervezés hiánya, nem megfelelősége miatt alakulnak ki idővel. Ezektől megszabadulni nehéz feladat, mert egy idő után minden mindenre függeni fog.

Éppen ezért a logikát, ami ezekhez az osztályokhoz kapcsolódik célszerű egy külön rétegbe helyezni. Ez a réteg a DomainServices lesz. Ebbe a rétegbe fogom elhelyezni az olyan logikákat, amelyek a Domain típusokhoz kapcsolódnak. A parancssor feldolgozás esetén ilyen logika lesz az, hogy el tudjuk dönteni, hogy helyes szintaxist adott-e meg a felhasználó (3db nem üres argumentum), az hogy megállapítsuk, hogy a bemeneti fájl egy adott fájl-e vagy valójában több fájl.

Mivel a felhasználóbarátság fontos, ezért szintén fontos eldönteni az argumentumok alapján, hogy specifikus súgót kell mutatnunk, vagy egy általános súgót a felhasználónak.

```csharp
using FFConvert.Domain;

namespace FFConvert.DomainServices;

internal static class ArgumentsExtensions
{
    public static bool IsSyntaxValid(this Arguments arguments)
    {
        return arguments.Count == 3
            && !string.IsNullOrEmpty(arguments.FileName)
            && !string.IsNullOrEmpty(arguments.PresetName)
            && !string.IsNullOrEmpty(arguments.OutputDirectory);
    }

    public static bool InputFileContainsWildCard(this Arguments arguments)
    {
        foreach (char chr in arguments.FileName)
        {
            switch (chr)
            {
                case '*':
                case '?':
                case '\\':
                    return true;
            }
        }
        return false;
    }

    public static bool IsGenericHelpRequested(this Arguments arguments)
    {
        return (string.IsNullOrEmpty(arguments.FileName)
            || arguments.FileName == "help")
            && string.IsNullOrEmpty(arguments.PresetName);
    }

    public static bool IsSpecificHelpRequested(this Arguments arguments)
    {
        return arguments.FileName == "help"
            && !string.IsNullOrEmpty(arguments.PresetName);
    }
}
```

## Tesztek és CI/CD beállítása

Az első logikáink elkészülte után készíthetünk egységteszteket, amivel megbizonyosodunk arról, hogy az eddig alkotott logika helyes. Ez az eddigi kódrészletek alapján akár teszt nélkül is bizonyítható, de hasznos, ha vannak tesztjeink, mert legalább be tudjuk valamivel állítani a CI/CD pipeline működését. A CI/CD önmagában egy baromi nagy témakör, számos megoldással, nem véletlen egy külön szakterület az informatikán belül. Ezért itt csak a fejlesztői szempontból fontos részekkel foglalkozok.

Mivel a projekt forráskódja a Github-on elérhető (https://github.com/webmaster442/FFConvert), ezért "bűn" lenne más CI/CD megoldást használni, mint amit a Github biztosít.

Ez a rendszer egy YAML fájl segítségével írja le a build folyamatot. Ezt a YAML fájlt nem kell nekünk nulláról megírni, mivel az Actions fülre kattintva lehetőségünk van sablonok alapján létrehozni egy környezetet.

A Github a cikk írásának pillanatában .NET és .NET Desktop sablon környezeteket biztosít. A fő különbség a kettő között az, hogy a .NET sablon Linux alapú Docker konténerben fut, míg a Desktop változat Windows alapú konténerben. Ha lehetőségünk van rá, akkor a .NET alapú sablont alkalmazzuk, mivel a Windows alapú konténerek sokkal lassabbak. Jelen program esetén nem fog gondot okozni, hogy Linuxon fusson, ezért ezt a Template-et választottam.

Az alap template a legtöbb esetben tökéletes lesz egyszerű feladatokra, maximum a .NET verziót kell átírnunk. Az alap YAML konfiguráció a következő lépéseket végzi el:

Helyreállítja a NuGet függőségeket
Lefordítja a kódot
Lefuttatja a teszteket

Ezek a lépések minden egyes alkalommal megtörténnek, amikor kódot töltünk fel a Github-ra. Ezzel követhetjük, hogy melyik integráció tört valamit el a kódban.

Az alap template-et én kiegészítettem egy code coverage riport generálással is, ezért a végleges workflow YAML fájl így néz ki:

```yaml
name: .NET

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:

    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v3
    - name: Setup .NET
      uses: actions/setup-dotnet@v2
      with:
        dotnet-version: 6.0.x
    - name: Restore dependencies
      run: dotnet restore
    - name: Build
      run: dotnet build --no-restore
    - name: Test & collect coverage
      run: dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput='../coverage/opencover.xml' --no-build --verbosity normal
    - name: OpenCover Badge Generator
      uses: danpetitt/open-cover-badge-generator-action@v1.0.10
      with:
         path-to-opencover-xml: './coverage/opencover.xml'
         minimum-coverage: 48
         repo-token: ${{ secrets.GITHUB_TOKEN }}
```

A code coverage értékeket SVG ikonként generálja le a workflow a folyamat végeztével. Ezeket a fájlokat a projekt readme.md leírásában elhelyezve mindig láthatjuk a projekt oldalán, hogy hány százalékos a kód lefedettsége. 

Ahhoz, hogy a Coverage generálás működjön, a unit teszt projektbe a `coverlet.collector` csomag mellé még fel kell vennünk a `coverlet.msbuild` csomagot is. Lényegében ez teszi lehetővé, hogy a teszt futtatás közben a coverage is mérésre kerüljön.

A coverage figyelésnek akkor van értelme, ha egy minőségi határvonalat is megszabunk vele. Jelen esetben ez 48%-ra lett beállítva, mivel 50-60% lefedettséget különösebb erőfeszítés nélkül simán el lehet érni.

## Preset modellezés

A presetek részletes specifikációja alapján viszonylag könnyen készíthető egy modell a leírása. Az egyes presetek leírásait tárolhatjuk kódban is, vagy valami adatfájlban. A programban tárolás ellen szól, hogy így minden egyes preset módosítás esetén a programot újra kellene fordítanunk, ami nem feltétlen a legjobb megoldás, mivel limitálja a bővíthetőséget a későbbiekben. Adatfájlban tárolás esetén problémát az okoz, hogy az egyes presetek esetén például hogyan írjuk le a paraméterek validálását, vagy mondjuk hogyan valósítjuk meg azt, hogy egyes beállítási lehetőségek opcionálisak lehetnek?

Ennek a kivitelezése kódban triviális, hiszen egy `if-else` elágazással megoldható a probléma, de az adat esetén már nem feltétlen evidens ennek a kivitelezése. Ha a logika leírását is beletesszük a preset definícióba, akkor nagyon könnyen abban a szituációban találhatjuk magunkat, hogy egy domain specifikus nyelvet (DSL) fejlesztünk a megoldandó probléma modellezésére.

A DSL nyelvek lényegében programozási nyelvek, amelyeknek nem feltétlen kell Turing teljesnek lenniük. A probléma általában az, hogy ezek a nyelvek egyszerűnek indulnak, de általában az idő előrehaladtával mindenre is jók lesznek, ami csak problémákat szül. Ezek miatt a problémák miatt az esetek nagyon kis százalékában éri meg saját DSL nyelvet fejleszteni. Ez is egy ilyen szituáció.

Persze adódhat a jogos felvetés, hogy miért nem LUA alapon valósítjuk meg a preseteket? Játékfejlesztők előszeretettel használják objektum leírása és logika megvalósításra. Jelen esetben is használható lenne, de a KISS elv mentén egyenlőre nem látom ennek szükségességét.

Ezért végső soron az XML formátum mellett döntöttem, mivel ez kézzel is szépen formázható, illetve beszédesebb egy picit leírásra, mint egy JSON fájl szerintem, mivel közelebb áll a HTML-hez. Ez alapvetően egy szubjektív döntés.

A modell alapvetően két fő osztályból áll. Egy osztály felelős a paraméterek leírásáért, míg egy másik magáért a központi preset leírásért felelős.

A paraméterek leírására szolgáló osztály:

```csharp
using System.Xml.Serialization;

namespace FFConvert.Domain;

[Serializable]
public sealed class PresetParameter
{
    [XmlAttribute]
    public string ParameterName { get; set; }

    [XmlAttribute]
    public string ParameterDescription { get; set; }

    [XmlIgnore]
    public string Value { get; set; }

    [XmlAttribute("Validator")]
    public string? ValidatorName { get; set; }

    [XmlAttribute]
    public string? ValidatorParameters { get; set; }

    [XmlAttribute("Converter")]
    public string? ConverterName { get; set; }

    [XmlAttribute]
    public bool IsOptional { get; set; }

    [XmlAttribute]
    public string? OptionalContent { get; set; }

    public PresetParameter()
    {
        IsOptional = false;
        ParameterName = string.Empty;
        ParameterDescription = string.Empty;
        Value = string.Empty;
    }
}
```

A paraméterek esetén a paraméter neve és a leírása csupán a nem opcionális tulajdonság. Ezeket a paramétereket elképzelhető, hogy validálni kell, ezért a `ValidatorName` a bevitt szövegen futtatandó validáló osztály nevét fogja megadni. Ezeknek a validációs osztályoknak elképzelhető, hogy paramétereket is szeretnénk átadni. Erre szolgál a `ValidatorParameters` tulajdonság. A `ConverterName` egy konvertáló osztályt ad meg, ami az ellenőrzés után fog majd lefutni. Ezzel olyan funkciók valósíthatóak majd meg, hogy a megadott időt mindig másodperc formátumra hozzuk. Az `IsOptional` és a `OptionalContent` pedig olyan paraméterek leírására szolgálnak, amelyek csak akkor adandóak majd a generált parancssorhoz, ha nem üres az értékük.

A Preset leírására pedig az alábbi osztály szolgál.

```csharp
using System.Xml.Serialization;

namespace FFConvert.Domain;

[Serializable]
public sealed class Preset
{
    [XmlAttribute]
    public string ActivatorName { get; set; }
    public string Description { get; set; }
    public string CommandLine { get; set; }
    
    [XmlAttribute]
    public string TargetExtension { get; set; }

    public List<PresetParameter> ParametersToAsk { get; set; }

    public Preset()
    {
        ActivatorName = string.Empty;
        Description = string.Empty;
        CommandLine = string.Empty;
        TargetExtension = string.Empty;
        ParametersToAsk = new List<PresetParameter>();
    }
}
```

Itt Opcionális tulajdonság nincs, mindegyik megadása kötelező. Az `ActivatorName` a Preset neve, amit a parancssorban kell majd megírni. A `Description` mező a leírásra szolgál, ami majd a dinamikus súgó generáláshoz lesz használva. A `CommandLine` és `TargetExtension` pedig a parancssor generáláshoz lesz használva, míg a `ParametersToAsk` a paramétereket írja le.

## Preset validáció

Mivel a preset beállítások egy külső XML fájlból fognak jönni, ezért a programban ellenőrizni kell használat előtt, hogy valóban  rendben vannak-e, ki van-e töltve az összes szükséges tulajdonság megfelelően.

Ehhez szintén a domain services rétegben készítettem egy extension metódust, ami egy pereset kapcsán ellenőrzi, hogy az rendben van-e.

A logika a paraméterek esetén is végez ellenőrzéseket. Például, ha a van megadva `OptionalContent`, akkor az `IsOptional` tulajdonságnak igaznak kell lennie. Hasonló módon ha van validációs paraméter, akkor a validációhoz használt osztály nevét meg kell adni. 

Ez a fajta ellenőrzés egy statikus ellenőrzésnek fogható fel, mivel csak a szintaxist figyeli, de azt már nem, hogy a preset esetén a megadott validációs osztály és konverziós osztály létezik-e egyáltalán.

A későbbiek folyamán majd ez is ellenőrzésre kerül.

```csharp
using FFConvert.Domain;

namespace FFConvert.DomainServices;

internal static class PresetExtensions
{
    public static bool IsValid(this Preset preset)
    {
        bool baseValid = !string.IsNullOrEmpty(preset.ActivatorName)
            && !string.IsNullOrEmpty(preset.Description)
            && !string.IsNullOrEmpty(preset.CommandLine)
            && !string.IsNullOrEmpty(preset.TargetExtension);

        if (preset.ParametersToAsk.Count == 0)
            return baseValid;

        return baseValid
            && preset.ParametersToAsk.All(x => x.IsValid());

    }

    public static bool IsValid(this PresetParameter parameter)
    {
        bool baseValid = !string.IsNullOrEmpty(parameter.ParameterName)
            && !string.IsNullOrEmpty(parameter.ParameterDescription);

        if (!string.IsNullOrEmpty(parameter.OptionalContent))
            return baseValid && parameter.IsOptional == true;

        if (!string.IsNullOrEmpty(parameter.ValidatorParameters))
            return baseValid && !string.IsNullOrEmpty(parameter.ValidatorName);

        return baseValid;

    }
}
```

Mivel XML fájlban tároljuk a preseteket, ezért a validációt megvalósíthatnánk egy XSD fájl segítségével. Az XSD az XML Schema Document rövdítése. Ennek setgítségével leírhatóak olyan felírhatók olyan szabályrendszerek, melynek meg kell feleljen egy XML dokumentum ahhoz, hogy "érvényes" legyen az adott sémában. Ezt minden XML olvasónak támogatnia kell.

C# és .NET 6.0 alatt azonban van egy pici bökkenő az eszköz támogatottságban, mégpedig az, hogy az XSD.exe eszköz még mindig nem került átírásra. Ez gyakorlatban azt jelenti számunkra, hogy a C# osztályainkból nem tudunk generálni XSD fájlt.

Éppen ezért a fejlesztésnek ezen pontján úgy voltam, hogy azt a minimális szabályrendszert inkább kódban valósítom meg. Ennek a megoldásnak a további előnye, hogy később akár JSON-re vagy YAML-re is átültethető a preset leírás anélkül, hogy a validációs logika törne. 

Később persze egyszerűbb szerkeszthetőség miatt az XML dokumentum alapján generáltattam egy XSD sémát. Ehhez a https://www.liquid-technologies.com/online-xml-to-xsd-converter eszközt használtam.

Ha egy XML dokumentumhoz van egy beállított XSD fájlunk, akkor az XML szerkesztése közben a Visual Studio tud számunkra InteliSense segítséget ajánlani, ami nagymértékben megkönnyítette a preset fájlok fejlesztését.

## Preset betöltés

A preset definíciónk alapján elkészíthetjük a hozzá kapcsolódó deszerializáló kódot. Ezért a `PresetManager` osztály lesz felelős, ami az `Infrastructure` rétegben kapott helyet. A `TryLoadPresets` metódus felel a betöltésért. Ez igaz értéket ad vissza, ha sikeres volt a betöltés, hamisat pedig akkor ha nem. A betöltött presetek a `presets` kimeneti argumentumban kerülnek visszaadásra.

```csharp
using FFConvert.Domain;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace FFConvert.Infrastructure;

internal class PresetManager
{
    private readonly XmlSerializer _serializer;
    private readonly string _file;

    public PresetManager()
    {
        _serializer = new XmlSerializer(typeof(Preset[]), new XmlRootAttribute("Presets"));
        _file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "presets.xml");
    }

    public bool TryLoadPresets([NotNullWhen(true)] out Preset[]? presets)
    {
        try
        {
            using var stream = File.OpenRead(_file);

            presets = (Preset[]?)_serializer.Deserialize(stream);
            return presets != null;
        }
        catch (Exception)
        {
            presets = Array.Empty<Preset>();
            return false;
        }
    }

    public bool PresetsExits
    {
        get
        {
            return File.Exists(_file);
        }
    }

    public bool CreateSamplePreset()
    {
        Preset sample = new Preset
        {
            Description = "Preset description",
            ActivatorName = "preset activator",
            CommandLine = "command line string",
            TargetExtension = ".mp4",
            ParametersToAsk = new List<PresetParameter>
        {
            new PresetParameter
            {
                ParameterDescription = "Description",
                ParameterName = "name",
            }
        }
        };


        try
        {
            string sampleName = Path.ChangeExtension(_file, ".sample.xml");

            using XmlTextWriter writer = new(sampleName, encoding: Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;

            _serializer.Serialize(writer, new Preset[] { sample });
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
```

Emellett az osztály rendelkezik egy `PresetsExits` tulajdonsággal, aminek a segítségével lekérdezhető, hogy egyáltalán létezik-e a `presets.xml` fájl. Ennek segítségével majd a főprogramban logikát tudunk megvalósítani, hogy ha nem létezne, akkor létrehozunk egy minta fájlt.

A minta fájl létrehozásáért a `CreateSamplePreset` metódus felel. Ez egy `presets.sample.xml` fájlban létrehoz egy minimális preset fájlt. Ideális esetben erre sosem lesz szükség, de előfordulhat, hogy a felhasználó majd törli a programmal szállított fájlt és sajátot akar majd létrehozni.

Ezen metódus által létrehozott mintafájl alapján készült el egyébként a programmal szállított `presets.xml` fájl tartalma is.

## Konverterek és validáció

Mivel a program menet közben a felhasználótól értékeket fog bekérni elkerülhetetlen, hogy ezeket ellenőrizzük és esetlegesen konvertáljuk. Mivel a programban N darab konvertálóra és validálóra lesz szükségünk, ezért célszerű ezeket egy interfész segítségével leírni. A konverziós interfészünk nem meglelpő módon az `Iconverter` nevet kapa. Ez egy bemeneti szöveget alakít át egy másik szöveggé.

```csharp
namespace FFConvert.Interfaces;

internal interface IConverter
{
    string Convert(string input);
}
```

A validációért az `Ivalidator` interfész lesz felelős. Ez már egy picit bonyolultabb. Az általa definiált `Validate` metódusnnak az egyik paramétere maga a szöveg amit ellenőrzünk, a másdik paramétere pedig egy `Idictionary` ami az általa használt paramétereket tárolja kulcs/érték párokban.

```csharp
namespace FFConvert.Interfaces;

internal interface IValidator
{
    (bool status, string errorMessage) Validate(string input, IDictionary<string, string> parameters);
}
```

A visszatérési értéke egy tuple, ami tartalmazza, hogy sikeres volt-e a validáció vagy sem, illetve egy hibaüzenetet, amit majd ki tudunk írni a felhasználónak.

Kérdés már csak az, hogy a `ValidatorParameters` tulajdonság szövegéből hogyan is lesznek kulcs/érték párok a konverternek? A paraméterek szintaxisára a következőt találtam ki: `param1=ertek1;param2=ertek2`. Ez alapján az egyes értékpárok között pontosvessző az elválasztó, míg kulcs és érték között az egyenlőségjel. A szabályrendszer alapján készíthetünk egy extension metódust erre a célra:

```csharp
using FFConvert.Domain;

namespace FFConvert.DomainServices;

internal static class PresetExtensions
{
    public static bool TryGetValidatorParamDictionary(this PresetParameter parameter, out IDictionary<string, string> parameters)
    {
        try
        {
            parameters = new Dictionary<string, string>();

            if (parameter.ValidatorParameters == null)
            {
                return true;
            }

            string[] argumentPairs = parameter.ValidatorParameters.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            foreach (string argumentPair in argumentPairs)
            {
                string[] keyValue = argumentPair.Split('=', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (keyValue.Length == 2)
                {
                    parameters.Add(keyValue[0], keyValue[1]);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            return true;
        }
        catch (Exception)
        {
            parameters = new Dictionary<string, string>();
            return false;
        }
    }
}
```

## Konverterek és validálók betöltése

A konvertáló és validáló osztályainkat manuálisan is példányosíthatnánk, de ez nem a legjobb ötlet. Mégpedig azért, mert akkor valahol ezeket nekünk karban kellene tartanunk és egy újabb konverter vagy validáló hozzáadásakor nem csak az interfészt implementáló osztályt kellene megírnunk, hanem egy központi helyre is fel kellene vennünk nyilvántartásba. Ez értelem szerűen nem túl kényelmes. Éppen ezért készítettem egy `ImplementationsOf<T>` generikus osztályt.

```csharp
using FFConvert.Interfaces;

namespace FFConvert.Infrastructure;

internal sealed class ImplementationsOf<T> : IImplementationsOf<T> where T: class
{
    private readonly Dictionary<string, T> _implementations;

    public ImplementationsOf()
    {
        var items = typeof(ImplementationsOf<T>)
            .Assembly.DefinedTypes
            .Where(x => x.ImplementedInterfaces.Contains(typeof(T)) && !x.IsAbstract)
            .Select(x => Activator.CreateInstance(x) as T);

        _implementations = new Dictionary<string, T>();

        foreach (var item in items)
        {
            if (item != null)
            {
                _implementations.Add(item.GetType().Name, item);
            }
        }
    }

    public int Count => _implementations.Count;

    public bool Contains(string name)
    {
        return _implementations.ContainsKey(name);
    }

    public T Get(string name)
    {
        return _implementations[name];
    }
}
```

Ez az osztály lekérdezi a jelenlegi szerelvényben tárolt összes típust és ezek közül megnézi, hogy melyik típus implementálja a `T` paraméternek megfelelő interfészt. Ha a típus implementálja ezt, akkor egy belső tárban elhelyezésre kerül belőle egy példány.

Ezt a példányt majd név alapján tudjuk lekérdezni, illetve tudjuk ellenőrizni azt is, hogy egyáltalán a megadott nevű osztály betöltésre került-e. Ez majd a konverterek és a validálók ellenőrzésénél lesz használva egy későbbi lépésben.

Az osztály rendelkezik egy `IimplementationsOf<T>` felülettel is, ami leginkább absztrakciós célokat szolgál majd a későbbiek során.

```csharp
namespace FFConvert.Interfaces;

internal interface IImplementationsOf<T> where T : class
{
    bool Contains(string name);
    T Get(string name);
    int Count { get; }
}
```
## Oszd meg és uralkodj

Az FFMpeg megfelelő argumentumokkal való elindítását megvalósíthatnánk egy gigantikus monolit osztályként számos metódussal, de már az előző mondat megfogalmazásából sejthető, hogy ez nem a legjobb ötlet. Nem a legjobb, mert a monolitokkal csak a baj van: nehezen tesztelhetőek, mivel rengeteg belső kapcsolattal rendelkeznek.

Éppen ezért érdemes a komplex feladatot kisebb, egyszerűbb lépésekre osztani. Ilyen osztás megvalósítására kiválóan alkalmas jelen program esetén a chain of responsibility, vagy magyarul felelősséglánc tervezési minta.

A programban nem teljesen a nagykönyvben megírt mintát használtam, hanem helyesen fogalmazva egy „rá hasonlítót”. Ennek az oka az, hogy a klasszikus felelősségláncban az egyes láncszemek tudnak a következő és opcionálisan az azt megelőző lépésről, mint egy láncolt listában. Ezt viszont nem szerettem volna, ezért jelen program esetén a lépések nem tudnak egymásról. Ezek végrehajtásárért majd egy másik komponens fog felelni.

Az egyes lépéseket az alábbi interfész fogja leírni:

```csharp
using FFConvert.Domain;

namespace FFConvert.Interfaces;

internal interface IStep
{
    IEnumerable<string> Issues { get; }
    bool TryExecute(State state);
}
```

Az `Issues` a lépés futtatása közben keletkezett hibák gyűjteményét fogja tárolni. Maga a `TryExecute`  metódus lesz az, amelyik leírja a lépés fő logikáját. Ha ez igaz értékkel tér vissza, akkor a lépés futtatása sikeres volt. Ez egy jelzés lesz a központi futtató felé, hogy hívja meg a következő lépés `TryExecute` metódusát. Ha azonban hamis visszatérési értéket kaptunk, akkor valami probléma történt. Ebben az esetben majd az  `Issues` által tárolt hibák gyűjteménye fog kiíródni a képernyőre.

Feltűnhet, hogy a  `TryExecute`  rendelkezik egy `State` típusőú bemenő paraméterrel. Ez felelős a globális állapot tárolásáért. Ennek a definíciója a következő:

```csharp
namespace FFConvert.Domain;

internal sealed class State
{
    public Preset[] Presets { get; }
    public IList<string> InputFiles { get; }
    public Preset CurrentPreset { get; set; }

    public ProgramConfiguration Configuration { get; }

    public Arguments Arguments { get; }

    public IList<FFMpegCommand> CreatedCommandLines { get; }

    public State(Preset[] presets, ProgramConfiguration configuration, Arguments arguments)
    {
        Presets = presets;
        Arguments = arguments;
        Configuration = configuration;
        CreatedCommandLines = new List<FFMpegCommand>();
        InputFiles = new List<string>();
        CurrentPreset = new Preset();
    }
}
```

A központi állapot tárolja az összes beolvasott preset-et (`Presets`), amiből majd egyet kiválasztunk (`CurrentPreset`) az argumentumok (`Arguments`) alapján. A `CreatedCommandLines` lista pedig tárolja a létrehozott FFMpeg parancsokat. Ennek leírásához egy külön osztályt készítettem, ami a `FFMpegCommand` nevet viseli. Ez a parancssor mellett tartalmazza a bemeneti fájlt és kimeneti fájlt is.

```csharp
internal sealed class FFMpegCommand
{
    public string CommandLine { get; init; }
    public string OutputFile { get; init; }
    public string InputFile { get; init; }

    public FFMpegCommand()
    {
        InputFile = string.Empty;
        CommandLine = string.Empty;
        OutputFile = string.Empty;
    }
}
```

Erre azért volt szükség, hogy a későbbiekben, Például egy adott lépés előtt tudjuk ellenőrizni, hogy egyáltalán létezik-e még a bemeneti fájl, illetve ha már létezik a kimenet által meghatározott fájl, akkor erre is reagálni tudjunk anélkül, hogy a generált parancsorrból próbálnánk kihámozni ezeket az információkat.

Ezen felül az állapot tartalmaz még egy `ProgramConfiguration` típusú osztályt is. Ez a program globális beállításait írja le. Jelen esetben ebből csak egy darab van még, ez pedig az FFMpeg és FFProbe parancsok mappáját határozza meg. Alapértelmezetten ezeket ugyan abban a mappában keressük, mint ahol a mi programunk lesz, de elképzelhető, hogy ez a végfelhasználó gépén teljesen máshol lesz.

```csharp
public sealed class ProgramConfiguration
{
    public string FFMpegDir { get; set; }

    public ProgramConfiguration()
    {
        FFMpegDir = AppDomain.CurrentDomain.BaseDirectory;
    }
}
```
Az egyes lépések könnyebb implementálása értekében készítettem egy `BaseStep` ősosztályt, amiből az összes lépésünk fog származni.

```csharp
using FFConvert.Domain;
using FFConvert.Interfaces;

namespace FFConvert.Steps;

internal abstract class BaseStep : IStep
{
    private readonly List<string> _issues;

    protected BaseStep()
    {
        _issues = new List<string>();
    }

    public IEnumerable<string> Issues => _issues;

    protected void AddIssue(string format, params object[] parameters)
    {
        _issues.Add(string.Format(format, parameters));
    }

    protected bool AreNoIssues()
    {
        return _issues.Count == 0;
    }

    public abstract bool TryExecute(State state);
}
```

Ez az ősosztály, mint látható főként a lépés futtatása közben keletkező hibaüzenetek kezelését egyszerűsíti le majd.

# A lépések

Ezek után már „csak” az egyes lépések lekódolása maradt hátra. Az első jó kérdés azonban, hogy milyen lépéseink is legyenek? A lépéseket a programtól elvárt viselkedés alapján határoztam meg. Ez alapján a következő, jól elkülöníthető lépésekre biztos szükségünk lesz:

* Bemeneti fájlok meghatározása – Errre azért lesz szükségünk, mert a *.mp3 elfogadott fájlnév, de ez minden mp3 kiterjesztésű fájlt jelent az adott mappában
* Presethez tartozó paraméterek begyűjtése – Egy preset rendelkezhet ugyebár tetszőleges számú, a felhasználótól begyűjthető argumentummal, ami befolyásolja majd generálandó parancsokat.
* Futtatandó parancsok legenerálása
* Parancsok futtatása

Ez a lista azonban nem teljes, mivel nem funkcionális lépéseket nem tartalmaz és ezekre is szükségünk lesz. Például a futtatás előtt nem ártana ellenőriznünk, hogy egyáltalán a beállított mappában megtalálható-e az ffmpeg és ffprobe, de ugyan ilyen nem funkcionális lépés például a preset ellenőrzése.

Mivel a preset fájlokat a felhasználói is szerkesztheti, ezért mielőtt egyáltalán használatba vesszük érdemes ellenőrizni, hogy megfelel-e bizonyos követelményeknek, hiszen ennek az elmulasztása a későbbiek során biztos, hogy visszaköszönne nem kezelt kivételek formájában.

Ezek alapján az alábbi sorrend alakult ki az elvégzendő lépésekben:

1. FFMpeg telepítés ellenőrzése
2. Bemeneti fájlok meghatározása
3. A kiválasztott preset validációja
4. A választott preset által meghatározott bemenetek begyűjtése
5. Futtatandó parancsok generálása
6. Konvertálás futtatása

A listában talán meglepő, hogy az FFMpeg ellenőrzés került az első helyre, holott csak a 6. lépésben fogjuk egyáltalán használni. Ennek felhasználói élmény szempontjából van jelentősége. Képzeljük el, hogy a preset, amit használni akarunk 5 beállítással rendelkezik. Elég hülyén venné ki magát, hogy minden lépést végigcsináltat velünk a program, majd az utolsó lépés előtt közli, hogy amúgy nem tudom a műveletsort végrehajtani, mert hiányoznak fájlok.


## FFMpeg telepítés ellenőrzése

Az első lépés nem bonyolult, lényegében megnézzük, hogy a megadott nevű fájlok léteznek-e a megadott mappában.

```csharp
using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Properties;

namespace FFConvert.Steps;

internal class CheckFFmpegInstallation : BaseStep
{
    public override bool TryExecute(State state)
    {
        if (!state.Configuration.TryGetFFmpeg(out string _))
            AddIssue(Resources.ErrorFFmpegNotFound, state.Configuration.FFMpegDir);

        if (!state.Configuration.TryGetFFProbe(out string _))
            AddIssue(Resources.ErrorFFprobeNotFound, state.Configuration.FFMpegDir);

        return AreNoIssues();
    }
}
```

Az első dolog, ami feltűnhet, hogy a hibaüzenetek nincsenek beégetve az egyes lépésekbe, mivel ez sosem egy jó ötlet. Helyette egy Resource fájlban vannak, ami azzal az előnnyel jár, hogy egy helyen tudjuk kezelni az összes üzenetet, valamint későbbiek során akár le is fordíthatjuk ezeket más nyelvekre. Azonban nem ez az egyetlen „trükk” ebben a lépésben. 

A „trükk” azonban az, hogy az ellenőrzés és lekérdezés két DomainServices rétegbeli metódusba van elrejtve, mivel a tényleges FFMpeg használat előtt is ellenőrizni kell a fájlok meglétét. Ennek az oka az, hogy a tényleges ellenőrzés és a használat között van egy időrés, ami alatt akár ki is törölheti a fájlokat a felhasználó. Feltételezzük azonban, hogy ilyenre nem vetemedne, de elképzelhető, hogy egy túlbuzgó vírusirtó teszi meg ezt helyette.

Lényeg az, hogy mivel két lépésben is kelleni fog ez, ezért legyen egy közös helyük:

```csharp
using FFConvert.Domain;
using System.Runtime.InteropServices;

namespace FFConvert.DomainServices;

internal static class ProgramConfigurationExtensions
{
    private static bool IsWindows() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    public static bool TryGetFFmpeg(this ProgramConfiguration configuration, out string ffmpegPath)
    {
        string ffmpegName = IsWindows() ? "ffmpeg.exe" : "ffmpeg";
        ffmpegPath = Path.Combine(configuration.FFMpegDir, ffmpegName);
        return File.Exists(ffmpegPath);
    }

    public static bool TryGetFFProbe(this ProgramConfiguration configuration, out string ffprobePath)
    {
        string ffprobeName = IsWindows() ? "ffprobe.exe" : "ffprobe";
        ffprobePath = Path.Combine(configuration.FFMpegDir, ffprobeName);
        return File.Exists(ffprobePath);
    }
}
```

A név meghatározásánál fontos, hogy platform függő módon történjen. Windows esetén a futtatandó fájloknak kötelező, hogy exe kiterjesztéssel rendelkezzenek. Ez azonban nem kötelező unix alapú rendszerek esetén. Ugyan nem volt követelmény, hogy a program működjön Linux alatt is, de erre mégis szükségünk van, mégpedig azért, mert a CI/CD megoldásunk Linux alapú docker image-ben fut.


## Bemeneti fájlok meghatározása

```csharp
using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Properties;

namespace FFConvert.Steps
{
    internal class CollectInputFiles : BaseStep
    {
        public override bool TryExecute(State state)
        {
            if (state.Arguments.InputFileContainsWildCard())
            {
                string directory = FileSystem.GetWorkingDirectoryFromInputFile(state.Arguments.FileName);
                var files = FileSystem.GetFilesMatchingWildCard(directory, Path.GetFileName(state.Arguments.FileName));

                state.AddFiles(files);

                if (!state.HasInputFiles())
                {
                    AddIssue(Resources.ErrorFilesNotFound);
                }
            }
            else
            {
                var singleFile = Path.GetFullPath(state.Arguments.FileName);

                if (File.Exists(singleFile))
                {
                    state.InputFiles.Add(singleFile);
                }
                else
                {
                    AddIssue(Resources.ErrorFileNotExists);
                }
            }

            return AreNoIssues();
        }
    }
}
```

A bemeneti fájlok meghatározásánál a fő rendező elv, hogy a több fájlról beszélünk vagy csupán egyről. Ez a program argumentumokhoz tartozó `InputFileContainsWildCard()` extension metódussal könnyen meghatározható. 

Az egyes fájlok és mappa meghatározásának logikája a `FileSystem` osztályban kapott helyet sok egyéb mással együtt:

```csharp
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace FFConvert.DomainServices;

internal static class FileSystem
{
    private static bool IsWindows() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    private static bool ContainsPathSeperator(string input)
    {
        if (IsWindows())
            return input.Contains('\\');
        else
            return input.Contains('/');
    }

    private static bool HasRootDir(string input)
    {
        if (IsWindows())
            return input.Contains(":\\");
        else
            return input.Contains('/');
    }

    private static string WildcardToRegex(string pattern)
    {
        return "^" + Regex.Escape(pattern).
        Replace("\\*", ".*").
        Replace("\\?", ".") + "$";
    }

    public static string GetWorkingDirectoryFromInputFile(string inputfile)
    {
        if (!ContainsPathSeperator(inputfile))
        {
            //it's in current dir
            return Environment.CurrentDirectory;
        }
        else if (HasRootDir(inputfile))
        {
            //full path
            return Path.GetDirectoryName(inputfile) ?? string.Empty;
        }
        else
        {
            //relatvie paths
            string relative = Path.GetFullPath(inputfile);
            return Path.GetDirectoryName(relative) ?? string.Empty;
        }
    }

    public static IEnumerable<string> GetFilesMatchingWildCard(string directory, string filter)
    {
        Regex r = new(WildcardToRegex(filter), RegexOptions.Compiled);
        string[] filters = Directory.GetFiles(directory);
        foreach (string file in filters)
        {
            string fileName = Path.GetFileName(file);
            if (r.IsMatch(fileName))
            {
                yield return file;
            }
        }
    }

    public static string CreateOutputFile(string inputfile, string targetExtension, string outputDirectory)
    {
        string fileName = Path.GetFileName(inputfile);
        string targetName = Path.ChangeExtension(fileName, targetExtension);
        return Path.Combine(outputDirectory, targetName);
    }
}
```

Ez a lépés a `State` osztályhoz tartozó extension metódusokat is használ. Ezek definíciója a következő:

```csharp
using FFConvert.Domain;

namespace FFConvert.DomainServices
{
    internal static class StateExtensions
    {
        public static void AddFiles(this State state, IEnumerable<string> items)
        {
            if (state.InputFiles is List<string> list)
            {
                list.AddRange(items);
            }
        }

        public static bool HasInputFiles(this State state)
        {
            return state.InputFiles.Count > 0;
        }
    }
}
```

## Preset validáció

A Preset validáció az első lépésünk, ahol külső függőségek jelennek meg, méghozzá az `IimplementationsOf<T>` típusok formájában. Ebből kettőt is vár ez a lépés. Egy a konvertereket, egy pedig a validitátorokat tartalmazza.

Ez a lépés valójában két dolgot csinál. Megkeresi a presetek közül azt, ami a paraméterként megadott névben van és a `state` változóban beállítja azt jelenleg használtnak. Ezen felül ellenőrzi a beállított presetet. Ezt a korábban bemutatott extension metódusok segítségével végzi el. 

```csharp
using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Interfaces;
using FFConvert.Properties;

namespace FFConvert.Steps
{
    internal class PresetValidation : BaseStep
    {
        private readonly IImplementationsOf<IConverter> _converters;
        private readonly IImplementationsOf<IValidator> _validators;

        public PresetValidation(IImplementationsOf<IConverter> converters,
                                IImplementationsOf<IValidator> validators)
        {
            _converters = converters;
            _validators = validators;
        }

        public override bool TryExecute(State state)
        {
            var presetToUse = state.Presets.FirstOrDefault(x => x.ActivatorName == state.Arguments.PresetName);
            if (presetToUse == null)
            {
                AddIssue(Resources.ErrorPresetNotFound, state.Arguments.PresetName);
            }
            else
            {
                state.CurrentPreset = presetToUse;
            }

            if (!state.CurrentPreset.IsValid())
            {
                AddIssue(Resources.ErrorInvalidPreset);
            }
            else
            {
                CheckConvertersNames(state.CurrentPreset);
                CheckValidatorNames(state.CurrentPreset);
            }

            return AreNoIssues();
        }

        private void CheckValidatorNames(Preset currentPreset)
        {
            var validatorNames = currentPreset.ParametersToAsk
                .Where(x => !string.IsNullOrEmpty(x.ValidatorName))
                .Select(x => x.ValidatorName!);

            foreach (var validatorName in validatorNames)
            {
                if (!_validators.Contains(validatorName))
                    AddIssue(Resources.ErrorUnknownValidator, validatorName);
            }

        }

        private void CheckConvertersNames(Preset currentPreset)
        {
            var converterNames = currentPreset.ParametersToAsk
                .Where(x => !string.IsNullOrEmpty(x.ConverterName))
                .Select(x => x.ConverterName!);

            foreach (var converterName in converterNames)
            {
                if (!_converters.Contains(converterName))
                    AddIssue(Resources.ErrorUnknownConverter, converterName);
            }
        }
    }
}
```

Az ellenőrzés nem csak ennyiben merül ki. A kiválasztott preset esetén a paramétereknél ellenőrzésre kerül, hogy a megadott nevű konverter és validáló létezik-e a szoftverben. Ez az ellenőrzés azért kell, hogy a következő lépésben, mikor bekérjük az adatokat ezzel már ne kelljen foglalkozni.

Ha szó szerint veszem a Single Responsilbility elvet, akkor valószínűleg ez a lépés implementáció sérti az elvet, mivel saját elmondásom szerint is két dolgot csinál. Valószínűleg jobb karbantarthatóság és egyszerűbb tesztelés miatt érdemes lenne ketté vágni, még az elején. Ezt fejlesztés közben azért nem tettem meg, mert egy nagyjából 5 sornyi logikának nem akartam külön osztályt létrehozni.

## A választott preset által meghatározott bemenetek begyűjtése

Ez a lépés felelős a kiválasztott preset paramétereinek a feltöltéséért, ami azt jelenti, hogy az információkat a felhasználótól kell bekérnünk. A bemenet forrása a konzol lesz. Azonban a `Console` osztály direktben használata helyett ezt egy absztrakción keresztül tesszük meg, mégpedig azért, hogy ez a lépés is jól tesztelhető legyen. 

Ugyan a `Console` osztály rendelkezik lehetőséggel arra, hogy a bemenetet és kimenetét átirányítsuk, de ez nem lesz elegendő a megfelelő teszteléshez. Éppen ezért a konzol absztrakciójáért az `Iconsole` interfész felel.

```csharp
namespace FFConvert.Interfaces;

internal interface IConsole
{
    int WindowHeight { get; }
    int WindowWidth { get; }
    void SetCursorPosition(int left, int top);

    string ReadLine();
    void WriteLine(string line);
    void Write(string line);
    void Error(params string[] errors);
    event EventHandler? CancelEvent;
}
```

Ez az interfész nem hoz sok újdonságot, csupán a rendszer konzol absztrakciójáért felelős. Az `Error` metódusával hibaüzeneteket tudunk kiírni. A `WindowHeight`, `WindowWidth` tulajdonságok  és a `SetCursorPosition()` metódus pedig pozícionálásért felelősek. Ezt majd egy másik komponens használja. A `CancelEvent` pedig akkor lesz ellőve, ha a felhasználó a CTRL+C kombinációt adja be a program futása közben. Ez ugye megszakítja az éppen aktuálisan futó folyamatot, de nekünk két folyamatunk lesz: Egy frontendünk és egy háttértben futó FFMpeg példány. Ha éppen fut az FFMpeg és a felhasználó a folyamat megszakítását kéri, akkor erre nekünk reagálnunk kell, méghozzá úgy, hogy a háttérben futó FFMpeg futást is megszakítjuk, de erről majd részletesebben a futtatásnál lesz szó.

A lépés forráskódja:

```csharp
using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Interfaces;
using FFConvert.Properties;

namespace FFConvert.Steps;

internal class GetPresetArguments : BaseStep
{
    private readonly IImplementationsOf<IConverter> _converters;
    private readonly IImplementationsOf<IValidator> _validators;
    private readonly IConsole _console;

    public GetPresetArguments(IImplementationsOf<IConverter> converters,
                              IImplementationsOf<IValidator> validators,
                              IConsole console)
    {
        _converters = converters;
        _validators = validators;
        _console = console;
    }

    public override bool TryExecute(State state)
    {
        if (!state.CurrentPreset.ParametersToAsk.Any())
            return true;

        foreach (var parameter in state.CurrentPreset.ParametersToAsk)
        {
            string input;
            if (!string.IsNullOrEmpty(parameter.ValidatorName))
            {
                input = ReadPresetValueWithValidator(parameter);
            }
            else
            { 
                input = ReadPresetValue(parameter); 
            }
            parameter.Value = ConvertValue(input, parameter);
        }

        return AreNoIssues();
    }

    private string ConvertValue(string input, PresetParameter parameter)
    {
        if (string.IsNullOrEmpty(parameter.ConverterName))
            return input;

        IConverter converter = _converters.Get(parameter.ConverterName);

        return converter.Convert(input);
    }

    private string ReadPresetValueWithValidator(PresetParameter parameter)
    {
        IDictionary<string, string> paramDictionary = new Dictionary<string, string>();

        if (parameter.ValidatorParameters != null
            && !parameter.TryGetValidatorParamDictionary(out paramDictionary))
        {
            AddIssue(Resources.ErrorPresetParamTokens);
            return string.Empty;
        }

        bool valid = false;
        string input;
        do
        {
            _console.Write(parameter.ParameterDescription);
            _console.Write(" : ");
            input = _console.ReadLine();

            if (parameter.IsOptional && string.IsNullOrEmpty(input))
            {
                break;
            }
            else if (!parameter.IsOptional && string.IsNullOrEmpty(input))
            {
                continue;
            }

            var validator = _validators.Get(parameter.ValidatorName!);

            var (status, errorMessage) = validator.Validate(input, paramDictionary);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _console.Error(errorMessage);
            }
            valid = status;
        }
        while (!valid && !parameter.IsOptional);

        return input;

    }


    private string ReadPresetValue(PresetParameter parameter)
    {
        string input;
        do
        {
            _console.Write(parameter.ParameterDescription);
            _console.Write(" : ");
            input = _console.ReadLine();
        }
        while (string.IsNullOrEmpty(input) && !parameter.IsOptional);
        return input;
    }
}
```

A paraméterek beolvasása esetén két útvonal áll előttünk: Ha a paraméter nem rendelkezik validálóval, akkor szimplán addig ismételjük a beolvasást, amíg a felhasználó üres szöveget adott meg. Abban az esetben, ha ez egy opcionális paraméter, akkor elfogadjuk az üres bemenetet is. Ezt valósítja meg a `ReadPresetValue` metódus.

A másik útvonal az, ha a beolvasandó paraméter rendelkezik validálóval. Ebben az esetben ugyan azt csináljuk, mint a nem validált paramétereknél, kiegészítve azzal, hogy ha a validáció hibás, akkor is újra bekérjük az értéket. Ezért felelős a `ReadPresetValueWithValidator` metódus.

A beolvasás után a `ConvertValue` metódussal futtatjuk a paraméterhez rendelt konvertálót, ha ez beállításra került.

## Parancssor generálás

A parancssor generálás viszonylag összetett, de lényegében arról van szó, hogy a preset parancssorába behelyettesítjük a felhasználó által megadott paramétereket. A paraméterek kapcsán azt a megközelítést alkalmaztam, hogy ezeknek a % szimbólummal kell kezdődniük és végződniük.

A rendszer három darab kitüntetett paramétert különböztet meg. Az első ilyen az `%input%` nevű. Ez a bemeneti fájl útvonalát határozza meg. A második a `%output%`, ami a kimeneti fájlt határozza meg. A harmadik pedig a %sourceext%, ami csak a kimeneti fájl kiterjesztéseként szerepelhet.

```csharp
using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Properties;
using System.Text;
using System.Text.RegularExpressions;

namespace FFConvert.Steps;

internal class CreateCommandLines : BaseStep
{
    private const string InputKey = "%input%";
    private const string OutputKey = "%output%";
    private const string SourceExtKey = "%sourceext%";

    private readonly Regex _paramRegex = new(@"\%(\w+)\%", RegexOptions.Compiled);

    private static Dictionary<ParameterKey, string> CreateParamDictionary(State currentState)
    {
        Dictionary<ParameterKey, string> parameters = new()
        {
            {  new ParameterKey(InputKey, false), "" },
            {  new ParameterKey(OutputKey, false), "" },
        };
        foreach (var parameter in currentState.CurrentPreset.ParametersToAsk)
        {
            if (!parameter.IsOptional 
                || (parameter.IsOptional && !string.IsNullOrEmpty(parameter.Value)))
            {
                parameters.Add(new ParameterKey(parameter), parameter.Value);
            }
        }
        return parameters;
    }

    public override bool TryExecute(State state)
    {
        Dictionary<ParameterKey, string> parameters = CreateParamDictionary(state);

        if (!CheckIfParameterCountMatches(state.CurrentPreset, parameters))
        {
            AddIssue(Resources.ErrorParamCountMissmatch);
            return false;
        }

        foreach (string inputfile in state.InputFiles)
        {
            parameters[new ParameterKey(InputKey, false)] = inputfile;

            string extension = state.CurrentPreset.TargetExtension;
            if (extension == SourceExtKey)
            {
                extension = Path.GetExtension(inputfile);
            }

            string outFile = FileSystem.CreateOutputFile(inputfile, extension, state.Arguments.OutputDirectory);

            parameters[new ParameterKey(OutputKey, false)] = outFile;

            if (state.CurrentPreset.TargetExtension == SourceExtKey)
            {
                outFile = Path.ChangeExtension(outFile, extension);
            }

            state.CreatedCommandLines.Add(new FFMpegCommand
            {
                CommandLine = FillParameters(state.CurrentPreset, parameters),
                OutputFile = outFile,
                InputFile = inputfile,
            });
        }

        return AreNoIssues();
    }


    private static string EscapePathIfNeeded(string path)
    {
        return !path.Contains(' ') ? path : $"\"{path}\"";
    }

    private static string FillParameters(Preset preset, Dictionary<ParameterKey, string> parameters)
    {
        StringBuilder sb = new(preset.CommandLine);
        foreach (var parameter in parameters)
        {
            if (!parameter.Key.IsOptional)
            {
                sb.Replace(parameter.Key.Name, EscapePathIfNeeded(parameter.Value));
            }
            else
            {
                var optionalContent = preset.ParametersToAsk
                    .Where(p => p.ParameterName == parameter.Key.Name)
                    .Select(p => p.OptionalContent)
                    .FirstOrDefault();

                if (!string.IsNullOrEmpty(optionalContent))
                {
                    string value = optionalContent.Replace(parameter.Key.Name, parameter.Value);
                    sb.Replace(parameter.Key.Name, value);
                }
            }
            
        }
        return sb.ToString();
    }

    private bool CheckIfParameterCountMatches(Preset currentPreset, Dictionary<ParameterKey, string> parameters)
    {
        MatchCollection matches = _paramRegex.Matches(currentPreset.CommandLine);
        int count = 0;
        foreach (Match match in matches)
        {
            if (parameters.Keys.Any(x => x.Name == match.Value))
                ++count;
            else
                --count;
        }

        return count == parameters.Count;

    }
}
```

A `CreateParamDictionary` metódus első körben a speciális paramétereinket (`%input%` és `%output%`), illetve a preset paramétereinek nevét és értékét összerendeli egy asszociatív tömbbe.

Itt feltűnhet, hogy a Dictionary kulcs típusa egy `ParameterKey` osztály, ami a paraméter nevén kívül információt tárol arról, hogy opcionális volt-e vagy sem. 

Utóbbira azért van szükségünk, mivel az opcionális paraméterek esetén, ha üresen van hagyva, akkor nem kell megjelennie a generált parancssorban az értéknek.

Ilyenre lehet példa, ha a hang mintavételezési frekvenciáját szeretnénk opcionálisan módosítani. Ezt a `-ar [szám]` FFMpeg argumentummal tudjuk megtenni, ahol a szám a frekvenciát jelöli Hz-ben. Ha ezt nem adjuk meg, akkor az eredeti mintavételezési frekvencia lesz használva.

Felmerülhet ezen a ponton a kérdés, hogy ha két tulajdonságból álló osztályt készítünk, akkor nem-e megérné egy value tuple-t alkalmazni osztály helyett?

A válasz jelen esetben az, hogy nem. Value tuple esetén mind a két tulajdonság figyelembe vételével történne az egyenlőség vizsgálata, ami nem lenne jó, mivel kétszer is szenelhetne a tömbben ugyan az a paraméternév eltérő opcionalitással. Egy megoldás az lehetne, hogy az értéket tároljuk value tuple-ben az opcionalitást leíró `bool` értékkel, de ebben nem sok kihívás van, illetve nem sokat tanulnánk belőle. Éppen ezért azt az irányt választottam, hogy készítek egy saját osztályt, a `ParameterKey`-t aminek az Equals és GetHashCode metódusa úgy van felülírva, hogy csak a nevet veszi figyelembe.

Az osztály létrehozása nem igényelt különösebben logikát. A megfelelő adattagok és konstruktorok definiálása után az osztály nevén a CTRL+. előhozható menüből a Generate Equals and GetHashCode opcióval legeneráltattam a nekem megfelelő implementációt. Így a végleges implementáció így nézett ki:

```csharp
// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

namespace FFConvert.Domain;

internal sealed class ParameterKey : IEquatable<ParameterKey?>
{
    public string Name { get; init; }
    public bool IsOptional { get; init; }

    public ParameterKey(string name, bool isOptional)
    {
        Name = name;
        IsOptional = isOptional;
    }

    public ParameterKey(PresetParameter parameter)
    {
        Name = parameter.ParameterName;
        IsOptional = parameter.IsOptional;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ParameterKey);
    }

    public bool Equals(ParameterKey? other)
    {
        return other != null &&
               Name == other.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }

    public static bool operator ==(ParameterKey? left, ParameterKey? right)
    {
        return EqualityComparer<ParameterKey>.Default.Equals(left, right);
    }

    public static bool operator !=(ParameterKey? left, ParameterKey? right)
    {
        return !(left == right);
    }
}
```

Az egyes pataméterek számának ellenőrzését reguláris kifejezések használatával állapítom meg. Ezzel azt ellenőrzöm, hogy a `CommandLine` tulajdonságban megadott paraméterek és a behelyettesíthető paraméterek száma megegyezik-e. Ha nem, akkor azt azt jelenti, hogy valami félre ment és a generálandó parancssor biztos, hogy nem lesz futtatható.

Ha minden rendben volt, akkor a paraméterek neveit az általuk tárolt értékre cseréljük, illetve külön eltároljuk a bemeneti fájl nevét és a kimeneti nevet is.

## Kódolás

Elérkeztünk az utolsó és legfontosabb lépéshez, a kódolás futtatásához. 