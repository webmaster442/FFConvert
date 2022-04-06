# Írjunk FFMpeg rontend-et

Az FFMpeg egy remek, igen nagy tudású program, de finoman fogalmazva is megválogatja a barátait, ha a felhasználó barátságról van szó. Ezért gondoltam készítek hozzá egy n+1. frontend implementációt.

## De Miért?

Az első egyértelműen felmerülő kérdés, hogy miért ír ilyet az ember, ha már van n+1 megoldás? Igazából két okból kezdtem bele a projektbe. Az első ok szimplán az, hogy amiket kipróbáltam azok túlkomplikáltak és végső soron nem tetszettek. A másik ok pedig a tanulás. Rengeteget lehet tanulni egy ilyen projektből és nem utolsó sorban cikk alapanyagnak sem utolsó a téma.

## Mi az a FFMpeg?

A másik egyértelműen felmerülő kérdés, hogy mi is az az FFMpeg? A projekt hivatalos leírása alapján (https://ffmpeg.org/) “Egy komplett, platformfüggetlen megoldás hang és videó rögzítésére, konvertálására és streamelésére”.

Ebből azonban nem derül ki teljesen, hogy mi is ez. Én inkább úgy fogalmaznék, hogy az FFMpeg egy olyan önálló kodek, program csomag, ami mindenből mindenbe is konvertálni tud. Túlzás nélkül valóban állíthatom, hogy az FFMpeg tényleg bármilyen formátummal elboldogul, legyen az bármennyire egzotikus is. Erre egy jó példa, ha a Quake III engine által használt ROQ formátumból szeretnénk WMV-be konvertálni, azt is megoldja. Természetesen az egzotikus formátumok mellett támogat minden modern megoldást is.

Az FFMpeg univerzalitását és népszerűségét szerintem jól leírja, hogy a youtube videó feltöltő backend részén is ez dolgozik, illetve a népszerű VLC player mögött is ez a kodek dolgozik. További előnye, hogy hatalmas hardver támogatással rendelkezik. Ha van a gépünkben egy “krumplinál” nagyobb számítási teljesítménnyel rendelkező Nvidia vagy AMD grafikus kártya, akkor az ezekben megtalálható hardveres videó dekódolót használatba tudja venni, illetve ha a hardver tud kódolni is, akkor ezt is igénybe tudja venni.

Ez a gyakorlatban azt jelenti, hogy ha van mondjuk egy GTX960-nál újabb videó kártyánk, akkor HD (h264) és UHD (h265) kódolást minimális (1-5%) CPU használat mellett el tudunk végezni.

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

public class Arguments
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

public static class ArgumentsExtensions
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
        return arguments.FileName == "help"
            && string.IsNullOrEmpty(arguments.PresetName);
    }
}
```

## Tesztek és CI/CD beállítása

Az első logikáink elkészülte után készíthetünk egységteszteket, amivel megbizonyosodunk arról, hogy az eddig alkotott logika helyes. Ez az eddigi kódrészletek alapján akár teszt nélkül is bizonyítható, de hasznos, ha vannak tesztjeink, mert legalább be tudjuk valamivel állítani a CI/CD pipeline működését. A CI/CD önmagában egy baromi nagy témakör, számos megoldással, nem véletlen egy külön szakterület az informatikán belül. Ezért itt csak a fejlesztői szempontból fontos részekkel foglalkozok.

Mivel a projekt forráskódja a Github-on elérhető (https://github.com/webmaster442/FFConvert),ezért bűn lenne más CI/CD megoldást használni, mint amit a Github biztosít.

Ez a rendszer egy YAML fájl segítségével írja le a build folyamatot. Ezt a YAML fájlt nem kell nekünk nulláról megírni, mivel az Actions fülre kattintva lehetőségünk van sablonok alapján létrehozni egy környezetet.

A Github a cikk írásának pillanatában .NET és .NET Desktop sablon környezeteket biztosít. A fő különbség a kettő között az, hogy a .NET sablon Linux alapú Docker konténerben fut, míg a Desktop változat Windows alapú konténerben. Ha lehetőségünk van rá, akkor a .NET alapú sablont alkalmazzuk, mivel a Windows alapú konténerek sokkal lassabbak. Jelen program esetén fog gondot okozni, hogy Linuxon fusson, ezért ezt a Template-et választottam.

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

