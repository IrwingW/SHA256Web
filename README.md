# SHA256Web – výpočet kontrolní sumy SHA256 v prohlížeči

Jednostránková webová aplikace pro **výpočet a ověření kontrolních součtů SHA256** přímo ve vašem počítači. Stačí otevřít `sha256.html` v prohlížeči – žádný server, žádná instalace, žádná závislost na připojení k internetu.

## Proč

Ověření integrity staženého souboru (obraz disku, archiv, aktualizace) obvykle vyžaduje nástroj v příkazové řádce. Tato stránka stejnou úlohu zvládne v prohlížeči a umí i **dávkové zpracování celého adresáře**, což se hodí při porovnávání dvou kopií dat nebo když potřebujete seznam součtů vypsat.

## Funkce

- **Výběr jednoho i více souborů** najednou (tlačítko „Vybrat soubory“)
- **Výběr celého adresáře** včetně podadresářů (tlačítko „Vybrat adresář“)
- **Drag & drop** – soubory stačí přetáhnout do modré zóny; ve Firefoxu tak lze vložit i celý adresář
- **Proudový výpočet po blocích 100 MB** – stránka zvládne i soubory větší, než je volná operační paměť
- **Průběh výpočtu** s ukazatelem procent a tlačítkem „Zrušit výpočet“
- **Tabulka výsledků** (pořadové číslo souboru, název souboru, SHA256) se řazením podle čísla
- **Export seznamu do TXT** – seznam souborů a jejich součtů stáhnete jako jeden textový soubor
- **Ověření sumy** – vyberete soubor, vložíte očekávanou SHA256 a stránka porovná, zda sedí
- **Vymazat stránku** – rychlé vynulování výsledků

## Soukromí

Soubory se **nikam neposílají**. Kontrolní součty se počítají lokálně ve vašem počítači a stránka s ničím nekomunikuje po síti.

## Jak spustit

1. Stáhněte nebo zkopírujte soubor `sha256.html`.
2. Otevřete ho v prohlížeči (dvojklikem, nebo přetažením do okna prohlížeče).
3. Volitelně: při výběru celého adresáře se prohlížeč zeptá na povolení přístupu.

Aplikace funguje i offline.

## Podporované prohlížeče

| Prohlížeč | Soubory přetažením | Adresář přetažením |
|---|---|---|
| Firefox | ano | **ano**, včetně podadresářů |
| Chrome, Edge, Opera | ano | ne – adresář lze vložit jen tlačítkem „Vybrat adresář“ |

## Technické poznámky

- Celá aplikace je **jeden HTML soubor** (CSS i JavaScript jsou uvnitř), bez build kroku a bez balíčků.
- Výpočet SHA256 zajišťuje knihovna [js-sha256](https://github.com/emn178/js-sha256) od autora Chen, Yi-Cyuan, vestavěná přímo do souboru.
- Soubory se čtou po blocích 100 MB, proto nevzniká problém s velkými soubory. U souborů nad cca 5 GB počítejte s výpočtem řádově v minutách.

## Struktura repozitáře

```
sha256.html   – aplikace (HTML + CSS + JavaScript, verze 1.4)
README.md     – tento popis
```

## Autoři a licence

Autor: František Sychra (© 2026, verze 1.4). Na vzniku se podíleli Martin Vondrák, paní Mamutová a ChatGPT.

Vestavěná knihovna js-sha256 je pod **MIT licencí** (její text je součástí souboru `sha256.html`). Pro zbývající kód repozitáře zatím licence deklarovaná není – pokud ho plánujete sdílet, doporučuji přidat soubor `LICENSE`.
