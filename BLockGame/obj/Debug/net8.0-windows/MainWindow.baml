   M S B A M L   `   `   `  ����D  @BLockGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BLockGame	BLockGame  5   	       BLockGame.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BLockGame     5   	     � Title$  
MainWindow��5   	   $	��722��6   $	��549��6)   .��5	      � ��5
   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ 	#FF1BCCD2��6    � Offset$ 0Q�61   � 5      $ 	#FF1488CC��6   $ 1Q�61   5      .+�5   
   �� $��
Логін��6   $��70(�6    $
��Bold"�6.   $��Center=�5      $��0,20,0,0q�6-   
�������6?   � 5   
   $��44,344,56,0q�6   $	��Top=�6$   $��50��6<   .+�5      G� -   5         G�Name$ MyPasswordBox��5      $	��380��5      $��22(�6&   $��10q�64   $��0q�5      
�������
���   �6A   5      �� 5   
   $!��Введіть пароль��6   $
��Left=�6)   $��
94,276,0,0q�6D   $	��Top=�6X   $
��40px(�6p   �� 5   
   $(��"Введіть свій логін��6   $
��Left=�6-   $��
94,137,0,0q�6H   $	��Top=�6\   $
��40px(�6t   �� 5   
   -   5         ��Name$ LoginButton��5      $��Увійти��6&   $��94,414,106,0q�5      $	��Top=�6'   $��50��5      $��24(�6   $
��Bold"�6+   ���	#FF24919A
�������$��0q�5      5      �� 5   
   -   5         ��Name$ 
MyLoginBox��5      $��94,205,106,0q�5       $	��Top=�6(   $��50��6@   $��22(�5!      $��10q�6    $��0q�5"      
�������
���   �69   �� 5$   
   -   5         ��Name$ 	NoAccount��5$      $
��Left=�6'   $��154,469,0,0q�6B   $	��Top=�6W   $��18(�5%      
��������� 5&      $!�Немає акаунта? ��6    �� 5'      -   5        $��#?�5'      .�6I   Створіть його!6Y   5(      �� 5)   
   -   5        $��Google��5)      $��44,598,416,0q�6"   $	��Top=�68   $��66��5*      $��20(�6   $
��Bold"�6+   
�������
���   �$��0q�5,      6%   5-      5.      