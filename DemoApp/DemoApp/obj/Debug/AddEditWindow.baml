   M S B A M L   `   `   `  ????B  >DemoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DemoAppDemoApp  5   	       DemoApp.AddEditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:DemoApp     5   	     ? Title$1  +Добавление сотрудников??5   	    ? Icon$ Picture2.jpg??6(   $	??450??6<   $	??600??6I    ? 
ResizeMode$ NoResize=?6U   .??5	      ? ???	#FFE0D1B4 ? ColumnDefinitions 5
   
   ?? 5      $	??200 ?6   6-   ?? 5      $??* ?6   6+    ? RowDefinitions 5   
   ?? 5      $??70 ?6   6*   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   ?? 5      $??35 ?6   6*   .+?5   
   ?? $??2??6   ???	#FF7FC782.+?5      ?? $/??)Добавление сотрудника??6   $??Center=?64   $??Arial Rounded MT Bold)?6Q   $??18(?6t   5      ?? 5   
   $.??(Полное имя сотрудника??6   $??1??61   6@   ?? 5   
   $-??'Должность сотрудника??6   $??2??60   6?   ?? 5   
    ?? 	MaxLength$	 100??6)   $??1??69   $??1??6I   $
??Left=?6V   $	??200??6q   ??6   ?? *Name+6q   ?? 5   
   $	 100??6)   $??1??69   $??2??6I   $
??Left=?6V   $	??200??6q   ??6   ?? *Role+6q   ?? 5   
   -   5         ??Name$ 
SaveButton??5      $??Сохранить??6%   $??3??69   $??2??6F   6Z   ?? 5   
   -   5        $ EmployeeBackButton??5      $??
Назад??6-   6=   5      5      