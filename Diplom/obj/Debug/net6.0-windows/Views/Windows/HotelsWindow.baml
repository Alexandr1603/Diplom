   M S B A M L   `   `   `  ����E  ATA.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TA.Desktop.Views.WindowsTA.Desktop.Views.Windows  5   	   +    %TA.Desktop.Views.Windows.HotelsWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:TA.Desktop.Views.Windows     5   	     � Title$  
Отели��5   	   $	��450��6   $	��600��6$    � WindowStartupLocation$ CenterScreen=�60    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 5q�6'   �� 5       � ��
 �����6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      .+�5   
   o� $��2��6   $��Center=�6   .@�5      m� -   5         m�Name$ btnAddHotel��5      $��25��6,   	 m� Icon	 5      �� 5      $��/Images/Add.png��6   5       m� 5!      -   5        $ btnEditHotel��5!      $��25��6-   	 5"      �� 5#      $��/Images/Edit.png��6   5%      m� 5&      -   5        $ btnDeleteHotel��5&      $��25��6/   	 5'      �� 5(      $��/Images/Delete.png��6   5*      5+      �� 5,   
   $��Center=�6   $��Center=�61   $��Локация��6L   R� 5.   
   -   5        
 R�Name$
 	treeView1��5.   .   $��1��6   $��16(�6    ��5/      �� 50       �� ItemsSource 6+   ��  �� Path$ Nodes�.R�51      �� ��6    �� *Header+52      54      �� 56   
   -   5         ��Name$ 	hotelsBox��56   "   $��1��6   $��1��6T   
������� �� SelectionMode$ Single=�6x   ��65   �� *Hotels+��57      �� 58      .R�59      A�  A� Columns$ 1��6"   $	��Top=�6.   5:      ��5<      �� 5=      .R�5>      � $��16(�6    �� TextAlignment$ Center=�63   .+�5?      �� $
��Bold"�6:   $��Center=�6L   ��6$   �� *Name+6L   5@      5A      5C      5D      5E      