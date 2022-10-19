# Проектирование приложения для предоставления банковских услуг

---

![Gif](https://github.com/Vya4eslavSeleznev/Database/blob/develop/docs/bank.gif)

---

### Схема базы данных:

![Db Schema](/docs/db.png)

###### Описание таблиц:

•	Article — таблица наименования операции  
•	Operation — таблица операций  
•	Currency — таблица валют  
•	User — таблица данных для профиля клиента или работника  
•	Customer — таблица для личной информации клиента  
•	Balance — банковский счет клиента  
•	BalanceCards — связь “many-to-many” с таблицей Card  
•	Card — таблица для карт клиентов  
•	CardServices — связь “many-to-many” с таблицей CardService  
•	CardService — таблиц с услугами для карт  
•	CustomerCredit — связь “many-to-many” с таблицей InfoCredit  
•	InfoCredit — информация о кредите  
•	CustomerSecurities — связь “many-to-many” с таблицей InfoSecurities  
•	InfoSecurities — информация о ценных бумагах  
•	CustomerDeposit— связь “many-to-many” с таблицей InfoDeposit  
•	InfoDeposit — информация о вкладе  

---

### Приложение:

Форма аутентификации:

![Auth](/docs/auth.png)

При успешной аутентификации клиент попадает на форму User, где у него есть возможность отредактировать свои личные данные, логин и пароль:

![User acc](/docs/userAcc.png)

На вкладке “Operation” пользователь может добавить операцию, изменить ее или удалить. Справа доступна фильтрация по датам:

![User operation](/docs/userOperations.png)

На вкладке “Balance” пользователь может добавить, изменить карту и баланс. Более того, возможно приобрести услугу на карту:

![User balance](/docs/userBalance.png)

На вкладке “Credit” пользователь может оформить кредит, просмотреть все возможные условия для кредитов:

![User credit](/docs/userCredit.png)

На вкладке “Deposit” пользователь может оформить вклад, просмотреть все возможные условия для вкладов:

![User deposit](/docs/userDeposit.png)

На вкладке “Securities” пользователь может приобрести ценные бумаги:

![User securities](/docs/userSecurities.png)

---

Второй пользователь данной программы — это бухгалтер. При открытии приложения, у него есть возможность создать новый вклад, посмотреть популярные вклады. Более того, бухгалтер может создать кредит, акции, списать денежные средства, просмотреть банковскую статистику и расторгнуть вклады или кредиты:

![Accountant depos](/docs/accountantDepos.png)

![Accountant credit](/docs/accountantCredit.png)

![Accountant security](/docs/accountantSecurities.png)

![Accountant balance](/docs/accountantCustomerBalance.png)

![Accountant statistic](/docs/accountantStatistic.png)

![Accountant depos](/docs/accountantCustomerCredit.png)

---

Администратор может изменять разделы операций:

![Admin article](/docs/adminArticle.png)

Создавать услуги для карт и валюту:

![Admin article](/docs/adminCurrency.png)

Добавлять клиентов и создавать личные кабинеты:

![Admin customer](/docs/adminCustomer.png)

Просматривать банковскую статистику по клиентам:

![Admin statistic](/docs/adminStatistic.png)

Просматривать фильтрацию по услугам:

![Admin call](/docs/adminCall.png)

Создавать профили для личного кабинета:

![Admin call](/docs/adminUser.png)





















