   M S B A M L   `   `   `  ����E  ATA.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TA.Desktop.Views.WindowsTA.Desktop.Views.Windows  5   	   0    *TA.Desktop.Views.Windows.HotelEditorWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:TA.Desktop.Views.Windows     5   	     � Title$%  Добавление отеля��5   	   $	��250��6"   $	��500��6/    � WindowStartupLocation$ CenterScreen=�6;    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 5q�6'   �� 5       � ��
 �����6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      $
��1.6* �6   .+�5   
   �� $��0��6   $��0��6!   $��22(�61   $��Название��6?   $��10q�6O   $��Center=�6[    �� TextAlignment$ Center=�6v   �� 5   
   -   5        	 ��Name$	 edName��5      $��0��6"   $��5q�6/   $��1��6:   $��24��6J   �� 5!   
   $��1��6   $��0��6!   $��22(�61   $��Звезды��6?   $��10q�6M   $��Center=�6Y   $ Center=�6t   �� 5"   
   -   5        $	 edStars��5"      $��1��6#   $��5q�60   $��1��6;   $��24��6K   6W   � 5#   
   $��3��6   $��2��6     5$      �� 5%      $��25 �6    �� 5&      .+�5(      o� $��2��6   $��Center=�6#   .@�5)      m� -   5        
 m�Name$
 
btnAddRoom��5)      $��25��6/    m� Icon 5*      �� 5+      $��/Images/Add.png��6    5-      m� 5.      -   5        $
 btnEditRoom��5.      $��25��60    5/      �� 50      $��/Images/Edit.png��6    52      m� 53      -   5        $
 btnDeleteRoom��53      $��25��62    54      �� 55      $��/Images/Delete.png��6    57      58      �� 5:      -   5         ��Name$ roomBox��5:   #   $��1��6   
������� �� SelectionMode$ Single=�6n   ��64   �� *
HotelRooms+��5;      �� 5<      .R�5=      A�  A� Columns$ 1��6&   $	��Top=�62   5>      ��5@      �� 5A      .R�5B      � $��16(�6   $ Center=�67   .+�5C      �� $
��Bold"�6>   $��Center=�6P   ��6(   �� *Name+6P   5D      5E      5G      5H      �� 5J   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��Center=�6J   $��3��6e   $��7��6y   .+�5K      �� -   5         ��Name$ 	btnCancel��5K   J   $��2��6-   $��0��6:   $��Отмена��6]   �� 5L      -   5        $ btnAdd��5L   G   $��2��6*   $��1��67   $��Сохранить��6W   5M      5N      5O      