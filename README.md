[![GitHub](https://img.shields.io/github/license/anst-foto/Broom-csharp)](/LICENSE)
![Language: C#](https://img.shields.io/badge/language-C%23-red.svg) [![CodeFactor](https://www.codefactor.io/repository/github/anst-foto/broom-csharp/badge)](https://www.codefactor.io/repository/github/anst-foto/broom-csharp)

[![GitHub: Broom](https://img.shields.io/badge/GitHub-Broom-orange.svg)](https://github.com/anst-foto/Broom-csharp)

# Broom \(Метла\)

Программа по очистке кэша браузеров и Корзины, удалению временных файлов.

---

* **Очистка кэша и Корзины, удаление временных файлов**
* [**© Starinin Andrey \(AnSt\), 2018**](https://github.com/anst-foto)
* **© Автономное учреждение Воронежской области 'Многофункциональный центр предоставления государственных и муниципальных услуг', 2018**
* [**© Компьютерная Академия ШАГ, 2020**](https://github.com/itstep-vrn)
* [**GNU General Public License v3.0**](/LICENSE)
* **Версия: 0.11 \(Апрель 2020\)**
* **Основано на коде -** [**Broom**](https://github.com/anst-foto/Broom) \| **(c) 2018 Starinin Andrey, Автономное учреждение Воронежской области 'Многофункциональный центр предоставления государственных и муниципальных услуг'**

---

## Изменения:

[CHANGELOG.md](/CHANGELOG.md)

---

## Что делает?

* Очищает кэши основных браузеров \(поддерживаемые браузеры указаны в разделе _Браузеры_\) у всех пользователей компьютера
* Очищает Корзину Windows
* Удаляет временные файлы пользователя и системы
* Удаляет файлы в папке Загрузки \(Downloads\)
* Выводит на экран информацию об удалённых файлах
* Сохраняет информацию об удалённых файлах и папках в файле `broom.log`

## Браузеры:

* Mozilla Firefox
* Google Chrome
* Chromium
* Яндекс.Браузер
* Opera
* Internet Explorer
* Microsoft Edge
* Vivaldi

## Версии программы:

* Графическая версия
Используется .Net Core 3.1 и WPF
* Консольная версия
Используется .Net Core 3.1

### Консольное меню:

1. Очистить только кэши браузеров
2. Очитстить только Корзину и временные файлы \(RecycleBin & Temp\)
3. Очитстить только папку Загрузки \(Downloads\)
4. Очитстить кэши браузеров и Корзину с временными файлами \(RecycleBin & Temp\)
5. Очитстить кэши браузеров и папку Загрузки \(Downloads\)
6. Очитстить Корзину с временными файлами (RecycleBin & Temp) и папку Загрузки \(Downloads\)
7. Очитстить кэши браузеров и Корзину с временными файлами \(RecycleBin & Temp\) и папкой Загрузки
0. Выход
