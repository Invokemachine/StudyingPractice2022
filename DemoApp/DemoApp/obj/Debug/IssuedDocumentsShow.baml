   M S B A M L   `   `   `  ????B  >DemoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DemoAppDemoApp  5   	   !    DemoApp.IssuedDocumentsShow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:DemoApp     5   	     ? Title$4  .Список изданных приказов??5   	    ? Icon$ Picture2.jpg??6*   $	??450??6>   $	??800??6K   .??5	      ? 
??????? ? RowDefinitions 5
   
   ?? 5      $??70 ?6   6*   ?? 5      6    ? ColumnDefinitions 5   
   ?? 5      6!   ?? 5      $	??150 ?6   6-   .+?5   
   ? ???	#FF7FC782$??0??6+   .+?5      ?? $??25??6   $	??800??6    $8??2Введите название документа??6,   ?? 5      -   5         ??Name$ SearchTextBox??5   >   $??5q?6U   $??25??6`   $	??150??6l   5      ? 5   
   $??0??6   $??2??6!   ???	#FF7FC782.+?5      ?? -   5         ??Name$ 
ExitButton??5      $	??140??6)   $??
Назад??65   6E   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGridIssuedDocuments??5      $??1??64      AutoGenerateColumns .     
IsReadOnly . 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   ?? *Id+6U     5      $%
 Название приказа??6%   $ * 6?    6I   ?? *	OrderName+6i     5      $
 Дата издания??6%   $ * 6;    6E   ?? *DateOfOrderOutcoming+6p     5      $
 Подпись??6%   $ * 66    6@   ?? *Sign+6[     5      $
 Должность??6%   $ * 68    6B   ?? *Role+6]   5!      5"      5#      