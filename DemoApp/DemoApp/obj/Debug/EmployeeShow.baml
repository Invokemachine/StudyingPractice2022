   M S B A M L   `   `   `  ????B  >DemoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DemoAppDemoApp  5   	       DemoApp.EmployeeShow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:DemoApp     5   	   -   5          ? Title$)  #Список сотрудников??5   	    ? Icon$ Picture2.jpg??6$   $	??450??68   $	??800??6E   .??5	      ? 
??????? ? RowDefinitions 5
   
   ?? 5      $??70 ?6   6*   ?? 5      6    ? ColumnDefinitions 5   
   ?? 5      6!   ?? 5      $	??150 ?6   6-   .+?5   
   ? ???	#FF7FC782$??0??6+   .+?5      ?? $??25??6   $	??450??6    $4??.Введите имя пользователя??6,   ?? 5      -   5         ??Name$ 
ExitButton??5      $	??140??6)   $??
Назад??65   6E   ?? 5      -   5         ??Name$ SearchTextBox??5   >   $??5q?6V   $??25??6a   $	??150??6m   5      ? 5   
   $??0??6   $??2??6!   ???	#FF7FC782.+?5      ?? -   5        $ EmployeeAddButton??5      $	??140??60   $+??%Добавить сотрудника??6<   ???#7EB9C16{   ?? 5      -   5        $ EmployeeDeleteButton??5      $	??140??63   $)??#Удалить сотрудника??6?   ???#7EB9C16   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGridCommonEmployees??5      $??1??64      AutoGenerateColumns .     
IsReadOnly . 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$.
 (Полное имя сотрудника??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   ?? *Name+6i     5      $-
 'Должность сотрудника??6%   $ * 6C    6M   ?? *Role+6h   5       5!      5"      