   M S B A M L   `   `   `  ����  Project     Project.OrderHistoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Historia zamówień��5   	   $	��400��6#   $	��600��60   ���	#FFFAFAFA � WindowStartupLocation$ CenterScreen=�6S    � 	Resources 5      3  -System.Windows.Media.Effects.DropShadowEffect   
DropShadow   Color   
BlurRadius   ShadowDepth   	Direction  ModernButton �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� CornerRadius J� Effect��%z  &	        &	 H     7     5   
   $
 #333��6.   $ 10Q�6;   $ 2Q�6K   $	 270Q�6[   �� 5   
   " ��6%   .�5      ��  � ��$	 14(�6)   �� 5       � ��$	 SemiBold"�6+   �� 5       � ��
	 �����6+   �� 5       � ��	 �	#FF5A9BD56+   �� 5       � ��$	 10q�6'   �� 5       � ��$		 8,4q�6(   �� 5       �@�Cursor$
	 Hand��6'   �� 5       � ��$		 120��6&   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� #��z��6!   $ 12��6K   8   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      .��5       � $��10q�6    � RowDefinitions 5!   
   �� 5"      $��* �6   �� 5#      $
��Auto �6   .+�5'   
   &   System.Windows.Controls.DataGrid  -   5          Name$ OrdersDataGrid��5'         AutoGenerateColumns$ False��5(         
IsReadOnly$
 True��5)         CanUserAddRows$ False��5*         HeadersVisibility$ Column=�5+         SelectionMode$ Single=�5,         GridLinesVisibility$ 
Horizontal=�5-      $��Stretch=�5.      $��Stretch=�5/      $��0��50      $��0,0,0,10q�51         Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$
 Kawa��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Coffee+6N     54      $ Mleko��6%   $ * 6M    64   �� *Milk+6M     55      $ Syrop��6%   $ * 6N    64   �� *Syrup+6N     56      $
 Cena��6%   $
 Auto 6]    63   �� *Price+ �� StringFormat$ C��6]     57      $
 Data��6%   $
 Auto 6v    63   �� *	OrderDate+$ {0:dd.MM.yyyy HH:mm}��6v   59      �� 5<   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5=      �� -   5        #��[ 5=      $��↩️ Powrót��6;   
���\\��6b   5>      5?      5@      