   M S B A M L   `   `   `  ����  Project     Project.OrderHistoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Historia zamówień��5   	   $	��400��6#   $	��600��60   .��5      � $��10q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ OrdersDataGrid��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5         CanUserAddRows$ False��5	         HeadersVisibility$ Column=�5
         SelectionMode$ Single=�5         GridLinesVisibility$ 
Horizontal=�5      $��Stretch=�5      $��Stretch=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Kawa��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Coffee+6N     5      $	 Mleko��6%   $
 * 6M    64   �� *Milk+6M     5      $	 Syrop��6%   $
 * 6N    64   �� *Syrup+6N     5      $
	 Cena��6%   $

 Auto 6]    63   �� *Price+ �� StringFormat$ C��6]     5      $
	 Data��6%   $

 Auto 6v    63   �� *	OrderDate+$ {0:dd.MM.yyyy HH:mm}��6v   5      5      5      