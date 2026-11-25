# SHA256Web – výpočet kontrolní sumy SHA256 v prohlížeči

**Čeština** · [English](#english-sha256web--sha256-checksum-calculator-in-your-browser)

## Proč

Jednostránková webová aplikace pro **výpočet a ověření kontrolních součtů SHA256** přímo ve vašem počítači. Stačí otevřít `sha256.html` v prohlížeči – žádný server, žádná instalace, žádná závislost na připojení k internetu.

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

## Autoři a licence

Autor: František Sychra (© 2026, verze 1.4). Na vzniku se podíleli Martin Vondrák, paní Mamutová a ChatGPT.

Vestavěná knihovna js-sha256 je pod **MIT licencí** (její text je součástí souboru `sha256.html`). Pro zbývající kód repozitáře zatím licence deklarovaná není – pokud ho plánujete sdílet, doporučuji přidat soubor `LICENSE`.

---

# English: SHA256Web – SHA256 checksum calculator in your browser

[Čeština](#sha256web--výpočet-kontrolní-sumy-sha256-v-prohlížeči) · **English**

Single-page web app that **calculates and verifies SHA256 checksums** on your own machine. Open `sha256.html` in a browser – no server, no installation, no internet connection required.

Checking the integrity of a downloaded file (disk image, archive, update) normally means reaching for a command-line tool. This page does the same job in a browser, and it also handles **a whole folder in one go**, which is useful when comparing two copies of your data or when you need the list of checksums written out.

## Features

- **One or many files at once** (the „Vybrat soubory“ / “Select files” button)
- **Entire folder including subfolders** (the „Vybrat adresář“ / “Select folder” button)
- **Drag & drop** – drop files into the blue zone; in Firefox you can drop a whole folder there too
- **Streaming calculation in 100 MB chunks** – handles files larger than your free RAM
- **Progress indicator** with percentage and a “Cancel calculation” button
- **Result table** (file number, file name, SHA256) sortable by number
- **Export the list as TXT** – file names with their checksums, downloaded as one text file
- **Verify a checksum** – pick a file, paste the expected SHA256, the page tells you whether it matches
- **Clear the page** – reset all results at once

## Privacy

**Your files never leave your machine.** Checksums are computed locally and the page makes no network requests.

## Getting started

1. Download or copy `sha256.html`.
2. Open it in a browser (double-click it, or drag it into a browser window).
3. Optional: when you select a whole folder, the browser asks for access permission.

The app works offline.

## Supported browsers

| Browser | Drop files | Drop a folder |
|---|---|---|
| Firefox | yes | **yes**, including subfolders |
| Chrome, Edge, Opera | yes | no – use the „Vybrat adresář“ / “Select folder” button |

## Technical notes

- The whole app is **a single HTML file** (CSS and JavaScript inline), no build step, no packages.
- The hashing itself comes from the [js-sha256](https://github.com/emn178/js-sha256) library by Chen, Yi-Cyuan, embedded directly in the file.
- Files are read in 100 MB chunks, so large files are not a problem. Expect a file over about 5 GB to take minutes.

## Repository layout

```
sha256.html   – the app (HTML + CSS + JavaScript, version 1.4)
README.md     – this description
```

## Authors and licence

Author: František Sychra (© 2026, version 1.4). Contributed by Martin Vondrák, Ms Mamutová and ChatGPT.

The embedded js-sha256 library is under the **MIT licence** (its text is included in `sha256.html`). No licence is declared for the rest of the code in this repository yet – if you plan to share it, add a `LICENSE` file.
