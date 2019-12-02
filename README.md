## Предыстория

В 2019 году изменились требования по СНИЛС и потребовалось немного изменить одно "legacy"-решение.  
Оно представляло из себя исполнямый файл (exe) и запускалось под Windows Server 2003 (x86).  
Открывало DBF-файл, извлекало из него четыре столбца и сохраняло их в новом файле.  
Требовалось написать похожую программу, чтобы не травмировать мозг пользователей.  

## Немного кода на C#
На C# написал новый обработчик с использованием VFPOLEDB-драйвера для работы с DBF-файлами.  
Потребовалось на сервере (WIN2003) установить компонент Microsoft OLE DB Provider for Visual FoxPro 9.0. 
Без него DBF-файл не обрабатывался, появлялась ошибка, что "Поставщик VFPOLEDB.1 не зарегистрирован на локальном компьютере". 
Ссылка на компонент (поставщик) - https://www.microsoft.com/en-us/download/details.aspx?id=14839  
![Image alt](https://github.com/valerymamontov/screenshots/blob/master/EditDBF.png)

## Файлы:
В проекте есть папка с названием "exe", в ней лежат:  
VFPOLEDBSetup.msi - это VFPOLEDB-драйвер  
EditDBF.exe - это обработчик  

### Механизм работы
 1. Программа открывает DBF-файл, переносит из него все строки в Dataset. 
 2. Редактирует (чуть иначе) данные и записывает их в новый Dataset.
 3. Сохраняет нужные данные в новый файл.

### Почему VFPOLEDB или проблемы с ODBC и OLEDB
Сначала для обработки DBF-файла я использовал ODBC и OLEDB, но столкнулся с несколькими проблемами.  
Если путь к исходному файлу содержал пробелы, то при открытии DBF появлялась ошибка.  
Если длина имени DBF-файла содержала более восьми символов, тоже появлялась ошибка.  
Чтобы обойти эти ошибки, приходилось копировать DBF-файл в директорию без пробелов и обрезать имя файла.  
И в итоге я решил остановиться на VFPOLEDB.  

### Полезные ссылки
 1. [Если имя таблицы содержит более восьми символов, то возникает ошибка](https://social.msdn.microsoft.com/Forums/ru-RU/06a350bb-4447-4893-8cf8-ed2bbdedfe37/-dbf-oledbconnection?forum=fordesktopru)
 2. [В конце таблицы создаётся пустая колонка "_NullFlags"](https://stackoverflow.com/questions/30886730/adding-data-to-dbf-file-adds-column-nullflags)
