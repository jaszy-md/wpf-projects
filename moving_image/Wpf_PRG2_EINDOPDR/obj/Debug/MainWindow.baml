   M S B A M L   `   `   `  ����L  HWpf_PRG2_EINDOPDR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Wpf_PRG2_EINDOPDRWpf_PRG2_EINDOPDR  5   	   "    Wpf_PRG2_EINDOPDR.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Wpf_PRG2_EINDOPDR     5   	     � Title$  Stop the button��5   	   $	��450��6!   $	��800��6.   
����  �.��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��0.5* �6   .+�5   
   � -   5         �Name$ 	MapCanvas��5      $��1��5      $��3��5      $��2��5      
��� ���$��	0,10,10,0q�5   #   .+�5       �� .+�5!      �� -   5         ��Name$
 Ball��5(      $��Assets/roadrunner.jpg��5!      $
��70px��5"      $
��57px��5#      $
��Left=�5$      $	��Top=�5%       � Cursor$
 Hand��5&      5(      5*      5.      �� 50   
   -   5         ��Name$ bt_start��51      $��Start��52      
���   �
�������$
��80px��55      $
��30px��56      $��0��57      $��0��58      $��Center=�59      6*   �� 5;   
   -   5         ��Name$ tbTimer��5<      $��0��5=      
�������
������ $
��80px��5@      $
��40px��5A      $��0��5B      $��0��5C      $��Center=�5D      $��Center=�5E       �� TextAlignment$ Center=�5F      $
��30px(�5G      $��0,0,0,90q�6   $
��Bold"�5H      �� 5K   
   	 �� Orientation$	 Vertical=�6   $��0��5L      $��1��5M      $��Center=�5N      $��Center=�5O      .+�5P      �� -   5        $ 	bt_Faster��5Q      $��Faster��5R      $
��60px��5S      $
��20px��5T      6   �� 5V      -   5        $ 	bt_Slower��5W      $��Slower��5X      $
��60px��5Y      $
��20px��5Z      $��0,10,0,0q�6   61   �� 5\      -   5        $ bt_Party��5]      $��Party!��5^      
��� � �
��� E��$
��18px(�5a      $
��bold"�5b      $
��90px��5c      $
��30px��5d      $��0,10,0,0q�6   5e      5i      �� 5k   
   -   5        
 ��Name$
 	cb_Runner��5o      $��3��5k      $��0��5l      $
��35px��5m      $��180px��5n      .@�5r      �� -	   5         ��Name$ 
Roadrunner��5s      $��
Roadrunner��5t      �� 5u      -
   5        $ TheRock��5v      $��The Rock��5w      �� 5x      -   5        $ Speedy��5y      $��Speedy��5z      5}      5�      5�      