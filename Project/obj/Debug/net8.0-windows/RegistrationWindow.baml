   M S B A M L   `   `   `  ����  Project'    !CoffeeOrderApp.RegistrationWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Logowanie / Rejestracja��5   	   $	��450��6)   $	��400��66    � WindowStartupLocation$ CenterScreen=�6B   ���	#FFFAFAFA � 	Resources 5      3  -System.Windows.Media.Effects.DropShadowEffect   
DropShadow   Color   
BlurRadius   ShadowDepth   	Direction  ModernButton �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� CornerRadius J� Effect��%�  &	        &	 H     7   '�� n    'G�       5	   
   $
 #333��6.   $ 10Q�6;   $ 2Q�6K   $	 270Q�6[   �� 5   
   " ��6%   .�5      ��  � ��$	 16(�6)   �� 5       � ��$	 SemiBold"�6+   �� 5       � ��
	 �����6+   �� 5       � ��	 �	#FF5A9BD56+   �� 5       � ��$	 	10,0,10,0q�6'   �� 5       � ��$
	 10,5q�6(   �� 5       �@�Cursor$
	 Hand��6'   �� 5       � ��$		 130��6&   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� #��z��6!   $ 12��5   !   8   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5       �� 5#   
   " ��6   .�5$      ��  � ��$	 14(�6)   �� 5%       � ��$	 0,5,0,10q�6'   �� 5&       � ��$	 8q�6(   5'      �� 5*   
   " G�6   .�5+      ��  � ��$	 14(�6)   �� 5,       � ��$	 0,5,0,10q�6'   �� 5-       � ��$	 8q�6(   5.      5/      .��51      � $��20q�6    � RowDefinitions 52   
   �� 53      $
��Auto �6   �� 54      $��* �6   �� 55      $
��Auto �6   .+�59   
   �� $'��!🔐 Zaloguj się lub zarejestruj��6   $��20(�5:      $
��Bold"�6"   $��Center=�5;      $��0,0,0,20q�5<      $��0��6&   �� 5?   
   $��1��6   .+�5@      �� $��Imię:��6   �� 5A      -   5         ��Name$ RegistrationNameTextBox��5A      �� 5C      $��	Nazwisko:��6   �� 5D      -   5        $  RegistrationSurnameTextBox��5D      �� 5F      $��Nazwa użytkownika:��6   �� 5G      -   5        $! RegistrationUsernameTextBox��5G      �� 5I      $��Hasło:��6   G� 5J      -   5         G�Name$ RegistrationPasswordBox��5J      5K      �� 5N   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��0,20,0,0q�6X   .+�5O      �� -   5        #��[ 5O      $��✅ Zarejestruj się��6;   6W   �� 5P      -   5        #��[ 5P      $��↩️ Powrót��6;   
���\\��6b   5Q      5R      5S      