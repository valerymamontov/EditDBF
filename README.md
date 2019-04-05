## Небольшой обработчик DBF-файла
![Image alt](https://github.com/valerymamontov/screenshots/blob/master/EditDBF.png)

Обработчик писался под Windows Server 2003 (x86).
Для работы программы необходимо установить Microsoft OLE DB Provider for Visual FoxPro 9.0.
Без его наличия DBF-файл не обработается. Появлятся ошибка, что "Поставщик VFPOLEDB.1 не зарегистрирован на локальном компьютере".
Ссылка на компонент (поставщик) - https://www.microsoft.com/en-us/download/details.aspx?id=14839
Обработчик открывает DBF-файл, все строки из таблицы записывает в DataSet. Редактирует и измененные данные пишет в новый Dataset.
Сначала для обработки DBF-файла я использовал ODBC, а потом OLEDB.
Но столкнулся с такими проблемами. Если путь к исходному файлу содержит пробелы, то появляется ошибка при открытии DBF.
Если длина имени DBF-файла содержит более восьми символов, то это также приводит к ошибке.
Чтобы обойти эти ошибки, я пробовал копировать DBF-файл в директорию без пробелов и обрезал название в имени файла.
И в итоге решил остановиться на VFPOLEDB.
