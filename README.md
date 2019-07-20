[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/anst-foto/Broom-csharp/blob/master/LICENSE) 
![Language: C#](https://img.shields.io/badge/language-C%23-red.svg) [![CodeFactor](https://www.codefactor.io/repository/github/anst-foto/broom-csharp/badge)](https://www.codefactor.io/repository/github/anst-foto/broom-csharp)

[![GitHub: Broom](https://img.shields.io/badge/GitHub-Broom-orange.svg)](https://github.com/anst-foto/Broom-csharp)

# Broom \(Метла\)

Программа по очистке кэша браузеров и Корзины, удалению временных файлов.

---

* **Очистка кэша и Корзины, удаление временных файлов \(PowerShell\)**
* **© Starinin Andrey \(AnSt\), 2018**
* **© Автономное учреждение Воронежской области 'Многофункциональный центр предоставления государственных и муниципальных услуг', 2018**
* [**MIT License**](/LICENSE)
* **Версия: 0.6 \(Апрель 2019\)**
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

## Браузеры:

* Mozilla Firefox
* Google Chrome
* Chromium
* Яндекс.Браузер
* Opera
* Internet Explorer

## Меню:

1. Очистить только кэши браузеров
2. Очитстить только Корзину и временные файлы \(RecycleBin & Temp\)
3. Очитстить только папку Загрузки \(Downloads\)
4. Очитстить кэши браузеров и Корзину с временными файлами \(RecycleBin & Temp\) и папкой Загрузки
5. Выход

## Параметры коммандной строки:

* `s` или `silent` запускает полную очистку без вывода меню

## Логгирование
Путь к log-файл - C:\broom.log
