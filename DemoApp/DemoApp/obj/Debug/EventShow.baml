   M S B A M L   `   `   `  ????B  >DemoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DemoAppDemoApp  5   	       DemoApp.EventShow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:DemoApp     5   	     ? Title$)  #Список мероприятий??5   	    ? Icon$ Picture2.jpg??6$   $	??450??68   $	??800??6E   .??5	      ? ???	#FFA0A8A0 ? RowDefinitions 5
   
   ?? 5      $??70 ?6   6*   ?? 5      6    ? ColumnDefinitions 5   
   ?? 5      6!   ?? 5      $	??150 ?6   6-   .+?5   
   ? $??1??6   $??1??6!   .+?5      ?? $????Для редактирования элемента необходимо выбрать нужный для изменения элемент, изменить его, а после обновления удалить его старую копию из списка. номер и данные старого документа обновятся??6   $
??auto??6?   $
??auto??6?    ?? TextWrapping$
 Wrap=?6  ??6?   Z? 6  5      ? 5   
   ???	#FF7FC782$??0??6+   .+?5      ?? $??25??6   $	??450??6    $%??Введите название??6,   ?? 5      -   5         ??Name$ 
ExitButton??5      $	??140??6)   $??
Назад??65   6E   ?? 5      -   5         ??Name$ SearchTextBox??5      $??5q?6-   $??25??68   $	??150??6D   6P   5      ? 5   
   $??0??6   $??2??6!   ???	#FF7FC782.+?5      ?? -   5        $ EventAddButton??5      $	??140??6-   $-??'Добавить мероприятие??69   ???#7EB9C16v   ?? 5      -   5        $ EventDeleteButton??5      $	??140??60   $+??%Удалить мероприятие??6<   ???#7EB9C16z   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGridEventShow??5      $??1??6.      AutoGenerateColumns .  	   
IsReadOnly	 . 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   ?? *Number+6[     5!      $ Название??6%   $ * 67    6A   ?? *Name+6\     5"      $# Дата проведения??6%   $ * 6>    6H   ?? *Date+6c     5#      $ Статус??6%   $ * 65    6?   ?? *Status+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5$      $
 auto 6)      CellTemplate 5%      ?? 5&      .R?5'      ?? $??
ButtonEdit??6=   -   5        $ ??Редактировать??5'   %   6O   5(      5*      5,      5-      5.      