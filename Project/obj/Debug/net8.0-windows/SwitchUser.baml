   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	       Project.SwitchUser   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	     � Title$  Panel sterowania��5   	   $	��300��6"   $	��400��6/    � WindowStartupLocation$ CenterScreen=�6;   ���	#FFFAFAFA � 	Resources 5      3  -System.Windows.Media.Effects.DropShadowEffect   
DropShadow   Color   
BlurRadius   ShadowDepth   	Direction  ModernButton �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� CornerRadius J� SnapsToDevicePixels J� Effect��%�  &	        &	 H     7     5   
   $
 #333��6.   $ 10Q�6;   $ 2Q�6K   $	 270Q�6[   �� 5   
   " ��6%   .�5      ��  � ��$	 16(�6)   �� 5       � ��$	 SemiBold"�6+   �� 5       � ��
	 �����6+   �� 5       � ��	 �	#FF5A9BD56+   �� 5       � ��$	 10q�6'   �� 5       � ��$		 110��6&   �� 5       � ��$	 60��6'   �� 5       �@�Cursor$
	 Hand��6'   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� #��z��6!   $ 12��5   !   $
 True��5   !   8   ._�5       �� $��Center=�6/   $��Center=�6L   5!      5"      5$      5%      5&      .��5(      � $
��0,20q�6    � RowDefinitions 5)   
   �� 5*      $
��Auto �6   �� 5+      $
��Auto �6   �� 5,      $��* �6   .+�50   
   �� $��⚙️ Panel sterowania��6   $��24(�51      $
��Bold"�52      ���#333$��Center=�54      $��0,0,0,30q�55      $��0��56      �� 59   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��1��6K   .+�5:      �� -   5        #��[ 5:      $��📜 Historia��6;   6Q   �� 5;      -   5        #��[ 5;      $��🔑 Logowanie��6;   6R   �� 5<      -   5        #��[ 5<      $��↩️ Powrót��6;   
���\\��6b   5=      5A      5B      